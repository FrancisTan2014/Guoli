<template>
  <section>

    <!-- 工具条 -->
    <el-row class="toolbar">
      <el-col :span="24">
        <el-button size="small" icon="arrow-left" title="返回上级目录" @click.native="folderBack" v-if="pathStack.length > 0"></el-button>
        <el-breadcrumb separator=">" class="file-path">
          <el-breadcrumb-item v-for="folder in pathStack" :key="folder.Id" @click.native="breadClick(folder)">{{ folder.TypeName }}</el-breadcrumb-item>
        </el-breadcrumb>
        <el-button class="btn-add" size="small" type="primary" icon="plus" @click.native="newFolder">新建文件夹</el-button>
        <el-button class="btn-add" size="small" type="primary" icon="plus" v-if="curParentId > 0" @click.native="addFiles">添加文件</el-button>
      </el-col>
    </el-row>

    <!-- 文件夹列表 -->
    <el-row :gutter="8" class="content center" :loading="isFileLoading">

      <!-- 没有任何文件或文件夹时 -->
      <el-col :span="24" class="file-empty" v-if="curDirs.length === 0 && curFiles.length === 0">
        <img src="../assets/empty.png" />
        <p>空空如也(:=</p>
      </el-col>

      <!-- 文件夹 -->
      <el-col :span="3" v-for="folder in curDirs" :key="folder.Id" @click.native="openFolder(folder)">
        <div class="folder">
          <i class="folder-img fa fa-folder-o" aria-hidden="true"></i>
          <div class="file-info">
            <span class="file-name">{{ folder.TypeName }}</span>
            <!--<span class="file-time">2017-08-04 10:16</span>-->
          </div>
          <div class="file-shadow">
            <p>
              <el-button class="file-btn" size="small" icon="edit" @click.native.stop="renameFolder(folder)">重命名</el-button>
              <el-button class="file-btn" size="small" icon="delete" @click.native.stop="remove(folder.Id, 1)">删除</el-button>
            </p>
            <span class="file-tip">点击打开</span>
          </div>
        </div>
      </el-col>

      <!-- 文件 -->
      <transition name="fade" v-for="file in curFiles" :key="file.Id">
        <el-col :span="3">
          <div class="folder">
            <i class="folder-img" :class="getFileIconClass(file.FileExtension)" aria-hidden="true"></i>
            <div class="file-info">
              <span class="file-name">{{ file.FileName }}</span>
              <!--<span class="file-time">2017-08-04 10:16</span>-->
            </div>
            <div class="file-shadow">
              <p>
                <el-button class="file-btn" size="small" icon="edit" @click.native.stop="renameFile(file)">重命名</el-button>
                <el-button class="file-btn" size="small" icon="delete" @click.native.stop="remove(file.Id, 2)">删除</el-button>
              </p>
            </div>
          </div>
        </el-col>
      </transition>

    </el-row>

    <!-- 添加文件 -->
    <el-dialog title="添加文件" v-model="isUploadVisible">
      <el-upload class="file-upload" ref="upload" :action="uploadPath()" :on-success="uploadSuccess" drag multiple>
        <i class="el-icon-upload"></i>
        <div class="el-upload__text">将文件拖到此处，或
          <em>点击上传</em>
        </div>
      </el-upload>
    </el-dialog>

    <!-- 重命名 -->
    <el-dialog title="重命名" v-model="renameFormVisible" :close-on-click-modal="false">
      <el-form :model="renameFormModel" label-width="100px" :rules="renameFormRules" @submit.native.prevent="renameFormSubmit" ref="renameForm">
        <el-form-item :label="renameFormModel.type === 1 ? '目录名称:' : '文件名称:'" prop="name">
          <el-input v-model="renameFormModel.name" auto-complete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click.native="renameFormVisible = false">取消</el-button>
        <el-button type="primary" @click.native="renameFormSubmit" :loading="renameFormLoading">提交</el-button>
      </div>
    </el-dialog>

    <!-- 新建 -->
    <el-dialog title="新建文件夹" v-model="newFormVisible" :close-on-click-modal="false">
      <el-form :model="newFormModel" label-width="100px" :rules="newFormRules" @submit.native.prevent="newFormSubmit" ref="newForm">
        <el-form-item label="目录名称:" prop="name">
          <el-input v-model="newFormModel.name" auto-complete="off"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click.native="newFormVisible = false">取消</el-button>
        <el-button type="primary" @click.native="newFormSubmit" :loading="newFormLoading">提交</el-button>
      </div>
    </el-dialog>

  </section>
</template>

<script>
import NProgress from 'nprogress';
import server from '../store/server';
import local from '../store/local';
import { fileIcons, rules } from '../utils';

export default {
  data() {
    return {
      isFileLoading: false,
      data: [],
      curParentId: 0,
      curDirs: [],
      curFiles: [],
      pathStack: [],

      // 文件/目录重合表单数据
      renameFormVisible: false,
      renameFormLoading: false,
      renameFormModel: { id: 0, name: '', origin: '', type: 1 }, // type为1表示对目录重命名，2表示对文件重命名
      renameFormRules: { name: [rules.required, rules.getMaxRule(50)] },
      renameOriginModel: {},

      // 新建文件夹表彰数据
      newFormVisible: false,
      newFormLoading: false,
      newFormModel: { name: '' },
      newFormRules: { name: [rules.required, rules.getMaxRule(50)] },

      // 上传文件
      isUploadVisible: false
    };
  }, // end data()

  methods: {
    loadFiles: function () {
      this.isFileLoading = true;
      NProgress.start();

      return server.post('/Files/GetDirecAndFiles', {}, this).then(res => {
        this.isFileLoading = false;
        NProgress.done();
        this.data = res.data;
      });
    },

    getCurrentFiles: function () {
      let _this = this;
      _this.curDirs = _this.data.directories.filter((item, index) => item.ParentId === _this.curParentId);
      _this.curFiles = _this.data.files.filter((item, index) => item.TypeId === _this.curParentId);
    },

    openFolder: function (folder) {
      this.curParentId = folder.Id;
      this.getCurrentFiles();
      this.pathStack.push(folder);
    },

    // 文件路径点击事件
    breadClick: function (folder) {
      let p = this.pathStack;
      for (let i = p.length - 1; i >= 0; i--) {
        if (p[i].Id !== folder.Id) {
          p.splice(i, 1);
        } else {
          this.curParentId = folder.Id;
          this.getCurrentFiles();
          break;
        }
      }
    },

    folderBack: function () {
      let p = this.pathStack;
      p.pop();
      this.curParentId = p.length === 0 ? 0 : p[p.length - 1].Id;
      this.getCurrentFiles();
    },

    getFileIconClass: extension => {
      return fileIcons[extension] || 'fa fa-file-o';
    },

    newFolder: function () {
      this.newFormVisible = true;
      this.newFormModel.name = '';
    },

    newFormSubmit: function () {
      this.$refs.newForm.validate(valid => {
        if (valid) {
          this.newFormLoading = true;
          NProgress.start();

          let m = this.newFormModel;
          let model = { TypeName: m.name, ParentId: this.curParentId };
          server.post('/Files/AddDirectory', { dir: JSON.stringify(model) }, this)
            .then(res => {
              this.newFormLoading = false;
              NProgress.done();

              let { code, id } = res;
              if (code === 119) {
                this.$message({ type: 'error', message: '已存在相同名称的目录(:=', duration: 3000 });
              } else if (code === 116) {
                // 目录添加成功
                this.$message({ type: 'success', message: '目录添加成功(:=', duration: 3000 });
                this.newFormVisible = false;
                model.Id = id;
                this.addLocal(model, 1);
              } else {
                this.$message({ type: 'error', message: '添加失败，请稍后重试(:=', duration: 3000 });
              }
            });
        }
      });
    },

    addFiles: function () {
      this.isUploadVisible = true;
    },

    // 动态获取文件上传地址，因为需要通过url传递动态参数
    uploadPath: function () {
      return `${server.base}/Files/AddFiles?token=${local.getItem('token')}&fileType=3&typeId=${this.curParentId}`;
    },

    // 文件上传成功
    uploadSuccess: function (response, file, fileList) {
      let { msg, fileModel } = response;
      if (msg.code === 100) {
        this.data.files.push(fileModel);
        this.curFiles.push(fileModel);
        this.$notify({ type: 'success', title: '提示', message: `《${file.name}》上传成功！` });
      } else if (msg.code === 111) {
        this.$notify({ type: 'error', message: `《${file.name}上传失败(:=`, duration: 3000 });
      } else {
        this.$notify({ type: 'error', message: `《${file.name}》已存在(:=`, duration: 3000 });
      }
    },

    addLocal: function (model, type) {
      if (type === 1) {
        this.data.directories.push(model);
        this.curDirs.push(model);
      } else if (type === 2) {
        this.data.file.push(model);
        this.curFiles.push(model);
      }
    },

    renameFolder: function (folder) {
      this.renameFormVisible = true;
      this.renameFormModel.id = folder.Id;
      this.renameFormModel.name = folder.TypeName;
      this.renameFormModel.origin = folder.TypeName;
      this.renameFormModel.type = 1;
      this.renameOriginModel = folder;
    },

    renameFile: function (file) {
      this.renameFormVisible = true;
      this.renameFormModel.id = file.Id;
      this.renameFormModel.type = 2;
      this.renameOriginModel = file;

      let name = file.FileName.replace(file.FileExtension, '');
      this.renameFormModel.name = name;
      this.renameFormModel.origin = name;
    },

    renameFormSubmit: function () {
      this.$refs.renameForm.validate(valid => {
        if (valid) {
          let m = this.renameFormModel;
          let changed = m.name !== m.origin;
          if (changed) {
            this.renameFormLoading = true;
            NProgress.start();
            if (m.type === 1) {
              // 目录重命名
              server.post('/Files/Rename', this.renameFormModel, this)
                .then(res => {
                  console.info(res);
                  let { code } = res;
                  if (code === 100) {
                    this.$message({ type: 'success', title: '提示', message: `已成功将《${m.origin}》重命名为《${m.name}》(:=`, duration: 3000 });
                    this.renameOriginModel.TypeName = m.name;
                    this.renameFormLoading = false;
                    this.renameFormVisible = false;
                    NProgress.done();
                  }
                });
            } else {
              let { id, type } = this.renameFormModel;
              let name = this.renameFormModel.name + this.renameOriginModel.FileExtension;
              // 文件重命名
              server.post('/Files/Rename', { id, name, type }, this)
                .then(res => {
                  let { code } = res;
                  if (code === 100) {
                    this.$message({ type: 'success', title: '提示', message: `已成功将《${m.origin}》重命名为《${m.name}》(:=`, duration: 3000 });
                    this.renameOriginModel.FileName = name;
                    this.renameFormLoading = false;
                    this.renameFormVisible = false;
                    NProgress.done();
                  }
                });
            }
          } else {
            this.renameFormVisible = false;
          }
        }
      });
    },

    remove: function (id, type) {
      this.$confirm('文件或者目录删除后将无法恢复，是否确定删除？').then(() => {
        server.post('/Files/Delete', { id, type }, this)
          .then(res => {
            let { code } = res;
            if (code === 100) {
              this.$message({ type: 'success', message: '删除成功(:=', duration: 3000 });
              this.removeFromLocalData(id, type);
            }
          });
      }).catch(() => { /* 取消 */ });
    },

    findIndex: (arr, id) => {
      for (let i = 0; i < arr.length; i++) {
        if (arr[i].Id === id) {
          return i;
        }
      }

      return -1;
    },

    removeFromLocalData: function (id, type) {
      let index = -1;

      if (type === 1) {
        index = this.findIndex(this.data.directories, id);
        this.data.directories.splice(index, 1);

        index = this.findIndex(this.curDirs, id);
        if (index >= 0) {
          this.curDirs.splice(index, 1);
        }
      } else {
        index = this.findIndex(this.data.files, id);
        this.data.files.splice(index, 1);

        index = this.findIndex(this.curFiles, id);
        if (index >= 0) {
          this.curFiles.splice(index, 1);
        }
      }
    }
  }, // end methods

  mounted() {
    this.loadFiles().then(res => this.getCurrentFiles());
  }
};
</script>

<style scoped lang="scss">
@import './sass/mixins.scss';

$folderColor: #A3DDFF;
$folderContrastColor: #ED5E07;
$pdfColor: #F14B37;
$blue: #20A0FF;

.toolbar {
  border-bottom: 1px solid $borderColor;

  .btn-add {
    float: right;
    margin-left: 8px;
  }
}

.file-path {
  display: inline-block;
  margin: 0 24px 0 8px;
  position: absolute;
  bottom: 10px;
}

.file-empty {
  text-align: center;

  p {
    color: $lightSilver;
    font-size: 1.5rem;
    margin: 0;
  }
}

.folder {
  text-align: center;
  padding: 10px;
  cursor: pointer;
  margin-top: 10px;
  position: relative;
  border: 1px solid $borderColor;
  overflow: hidden;

  &.active {
    background: $folderColor;

    .folder-img {
      color: #fff;
    }
    .file-info .file-name {
      color: #fff;
    }
    .file-info .file-time {
      color: #fff;
    }
  }

  .file-info {
    // padding: 10px 14px 0 14px;
    span {
      display: inline-block;
      margin-top: 10px;

      &:last-child {
        margin-bottom: 0;
      }
    }

    .file-name {
      font-size: 14px;
      color: #324057;
      width: 100%;
      height: 40px;
      line-height: 20px;
      overflow: hidden;
      text-overflow: ellipsis;
      display: -webkit-box;
      -webkit-line-clamp: 2;
      -webkit-box-orient: vertical;
    }

    .file-time {
      font-size: 14px;
      color: $lightSilver;
    }
  }

  .folder-img {
    width: 100%;
    color: $folderColor;
    font-size: 5rem;
  }

  .file-shadow {
    position: absolute;
    bottom: -95px;
    left: 0;
    padding: 10px 0;
    text-align: center;
    background-color: #000;
    width: 100%;
    opacity: 0.8;
    color: #fff;
    @include prefix(transition, bottom 0.3s);

    .file-btn {
      color: #fff;
      background: #000;
      border: 1px solid #fff;
    }
  }

  &:hover .file-shadow {
    bottom: 0;
  }
}

.fade-enter-active,
.fade-leave-active {
  transition: all .5s ease-out
}

.fade-enter,
.fade-leave-to {
  opacity: 0
}
</style>
