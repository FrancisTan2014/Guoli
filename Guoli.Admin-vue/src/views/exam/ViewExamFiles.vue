



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.FileName.value" placeholder="题库名称"></el-input>
        </el-form-item>
        <el-form-item>
          <el-select v-model="conditions.ExamTypeId.value" placeholder="题库分类">
            <el-option v-for="item in ExamTypeIdSelectData" :key="item.TypeName" :label="item.TypeName" :value="item.Id"></el-option>
          </el-select>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="showAddDialog" icon="plus">添加题库</el-button>
        </el-form-item>

      </el-form>

    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="FileName" label="题库名称"></el-table-column>
      <el-table-column prop="FileDesc" label="题库描述"></el-table-column>
      <el-table-column prop="TypeName" label="题库分类"></el-table-column>
      <el-table-column prop="QuestionCount" label="试题数量"></el-table-column>
      <el-table-column prop="AddTime" label="上传时间" :formatter="AddTimeFormatter"></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text">
            <a :href="handleDownloadUrl(scope.row.FilePath)" :download="scope.row.FileName">下载</a>
          </el-button>
        </template>
      </el-table-column>

    </el-table>

    <!--分页工具条-->
    <el-col :span="24" class="toolbar">
      共
      <span>{{ total }}</span> 条， 每页显示
      <el-select v-model="size" size="small" style="width: 70px;" @change="load">
        <el-option v-for="item in sizes" :value="item" :label="item" :key="item"></el-option>
      </el-select>
      条
      <el-pagination layout="prev, pager, next" @current-change="handlePageChange" :page-size="size" :total="total" style="float:right;">
      </el-pagination>
    </el-col>

    <!-- 添加题库弹窗 -->
    <el-dialog title="添加题库" :visible="addDialogVisible"
      :before-close="() => {addDialogVisible=false}">

      <el-form ref="addForm" :model="addFormModel" label-width="120px" :rules="addFormRules" @submit.native.prevent="handleAddFile">

        <el-form-item label="题库文件：">
          <el-upload class="upload-demo" drag :action="fileUploadApi" :on-success="uploadSuccess" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet">
            <i class="el-icon-upload"></i>
            <div class="el-upload__text">将文件拖到此处，或
              <em>点击上传</em>
            </div>
            <div class="el-upload__tip" slot="tip">只能上传xls/xlsx文件，且题库文件格式必须与
              <a :href="templateFileUrl" download>点击下载模板</a> 保持一致，否则无法上传成功</div>
          </el-upload>
        </el-form-item>

        <el-form-item label="题库分类：" prop="ExamTypeId">
          <el-select v-model="addFormModel.ExamTypeId">
            <el-option v-for="item in ExamTypeIdSelectData" :key="item.TypeName" :label="item.TypeName" :value="item.Id"></el-option>
          </el-select>
          <el-button @click="showAddType">添加分类</el-button>
        </el-form-item>

        <el-form-item label="题库名称：" prop="FileName">
          <el-input v-model="addFormModel.FileName"></el-input>
        </el-form-item>

        <el-form-item label="题库描述：">
          <el-input v-model="addFormModel.FileDesc"></el-input>
        </el-form-item>
      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="addDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="handleAddFile" :loading="addFormLoading">确 定</el-button>
      </div>

    </el-dialog>

    <!-- 添加分类弹窗 -->
    <el-dialog title="添加分类" :visible="typeDialogVisible"
      :before-close="() => {typeDialogVisible=false}">

      <el-form ref="typeForm" :model="typeFormModel" label-width="120px" :rules="typeFormRules">
        <el-form-item label="分类名称：" prop="TypeName">
          <el-input placeholder="不能超过20个字" v-model="typeFormModel.TypeName"></el-input>
        </el-form-item>
      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="typeDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="handleAddType">确 定</el-button>
      </div>

    </el-dialog>

  </section>
</template>
<script>
import moment from 'moment';
import { rules } from '@/utils';
import server from '@/store/server';
import { timepickerOptions } from '@/utils';
import NProgress from 'nprogress';

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'ViewExamFiles',
      order: 'AddTime',
      desc: true,
      conditions: {
        FileName: { value: undefined, type: 'like' },
        ExamTypeId: { value: undefined, type: 'equal' },
      },
      ExamTypeIdSelectData: [],

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 添加题库
      addDialogVisible: false,
      addFormLoading: false,
      addFormModel: {
        ExamTypeId: undefined,
        FileName: '',
        FileDesc: '',
        FilePath: ''
      },
      addFormRules: {
        ExamTypeId: [{ required: true, message: '请选择题库分类', type: 'number', trigger: 'change' }],
        FileName: [{ required: true, message: '请输入题库名称', trigger: 'blur' }]
      },
      fileUploadApi: `${server.base}/Exam/FileUpload?fileType=4`,
      templateFileUrl: `${server.base}/Templates/exam-file.xls`,

      // 添加分类
      typeDialogVisible: false,
      typeFormLoading: false,
      typeFormModel: { TypeName: '' },
      typeFormRules: { TypeName: [{ required: true, message: '名称不能为空', trigger: 'blur' }] }
    };
  },

  methods: {
    load: function () {
      let o = {
        page: this.page,
        size: this.size,
        order: this.order,
        desc: this.desc,
        table: this.table,
        conditions: this.conditions
      };
      server.post(this.apiUrl, { json: JSON.stringify(o) }).then(res => {
        let { data } = res;
        if (data) {
          let { total, list } = data;
          this.total = total;
          this.data = list;
        }
      });
    },

    showAddType: function () {
      this.addDialogVisible = false;
      this.typeDialogVisible = true;
    },

    showAddDialog: function () {
      this.addDialogVisible = true;
    },

    AddTimeFormatter: function (row) { return moment(row.AddTime).format('YYYY-MM-DD'); },

    handlePageChange: function (page) {
      this.page = page;
    },

    handleDownloadUrl: function (path) {
      return server.base + path;
    },

    loadTypeList: function () {
      server.post('/Exam/GetTypeList', {}, this).then(res => {
        let { code, data } = res; this.ExamTypeIdSelectData = data;
      });
    },

    // 添加分类
    handleAddType: function () {
      this.$refs['typeForm'].validate(valid => {
        if (valid) {
          this.typeFormLoading = true;
          NProgress.start();
          server.post('/Exam/AddExamType', { name: this.typeFormModel.TypeName }, this)
            .then(res => {
              this.typeFormLoading = false;
              NProgress.done();

              let { code } = res;
              if (code === 118) {
                this.$message({ type: 'error', message: '已存在相同分类(:=' });
              } else {
                this.$message({ type: 'success', message: '分类添加成功(:=' });
                this.loadTypeList();
                this.typeDialogVisible = false;
                this.addDialogVisible = true;
              }
            });
        }
      });
    },

    // 添加题库

    uploadSuccess: function (res) {
      let m = this.addFormModel;
      let name = res.OriginalFileName.replace(res.FileExtension, '');
      m.FilePath = res.FileRelativePath;
      m.FileName = name;
      m.FileDesc = name;
    },

    handleAddFile: function () {
      this.$refs.addForm.validate(valid => {
        if (valid) {
          let model = this.addFormModel;
          if (!model.FilePath) {
            this.$message({ type: 'error', message: '请上传题库文件' });
          } else {
            this.addFormLoading = true;
            NProgress.start();
            server.post('/Exam/Upload', { data: JSON.stringify(model) }, this)
              .then(res => {
                this.addFormLoading = false;
                NProgress.done();
                let { code } = res;
                if (code !== 100) {
                  this.$message({ type: 'error', message: '题库添加失败，请检查您上传的文件格式是否与模板文件一致(:=' });
                } else {
                  this.$message({ type: 'success', message: '题库添加成功(:=' });
                  this.load();
                  this.addDialogVisible = false;
                }
              });
          }
        }
      });
    }
  },

  mounted() {
    this.load();
    this.loadTypeList();
  }
};
</script>
<style scoped lang="scss">
a {
  color: #20a0ff;
  text-decoration: none;
}
</style>

