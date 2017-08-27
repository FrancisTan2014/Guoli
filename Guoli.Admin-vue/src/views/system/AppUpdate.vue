



<template>
  <section>

    <el-row class="toolbar">
      <el-col :span="24">
        <el-button icon="plus" type="primary" @click="showDialog">发布新版本</el-button>
      </el-col>
    </el-row>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="Version" label="版本号"></el-table-column>
      <el-table-column prop="UpdateLog" label="更新日志"></el-table-column>
      <el-table-column prop="HashCode" label="哈希值"></el-table-column>
      <el-table-column prop="Token" label="令牌"></el-table-column>
      <el-table-column prop="AddTime" :formatter="timeFormatter" label="更新时间"></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text" @click="handleDelete(scope.row)">删除</el-button>
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

    <!-- 弹窗 -->
    <el-dialog title="发布新版本" :visible="editFormVisible" :before-close="() => editFormVisible = false">

      <!-- 账户编辑表单 -->
      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item label="发布级别：">
          <el-radio-group v-model="editFormModel.level">
            <el-radio-button :label="1">重大版本更新</el-radio-button>
            <el-radio-button :label="2">模块局部更新</el-radio-button>
            <el-radio-button :label="3">BUG修复</el-radio-button>
          </el-radio-group>
        </el-form-item>

        <el-form-item label="文件：">
          <el-upload ref="upload" class="upload-demo" drag :action="getUploadUrl()" :on-success="uploadSuccess" :before-upload="beforeUpload" accept="application/vnd.android">
            <i class="el-icon-upload"></i>
            <div class="el-upload__text">将文件拖到此处，或
              <em>点击上传</em>
            </div>
            <div class="el-upload__tip" slot="tip">仅支持apk文件上传</div>
          </el-upload>
        </el-form-item>

        <el-form-item label="更新日志：" prop="UpdateLog">
          <el-input type="textarea" :rows="8" v-model="editFormModel.UpdateLog"></el-input>
        </el-form-item>

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="editFormVisible = false">取消</el-button>
        <el-button type="primary" @click.native="submit" :loading="editFormLoading">确定</el-button>
      </div>

    </el-dialog>

  </section>
</template>
<script>

import moment from 'moment';
import NProgress from 'nprogress';
import server from '@/store/server';
import local from '@/store/local';
import { timepickerOptions } from '@/utils';

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'AppUpdate',
      order: 'AddTime',
      desc: true,
      conditions: {
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 弹窗表单
      editFormVisible: false,
      editFormLoading: false,
      editFormModel: {
        UpdateLog: '',
        Url: '',
        level: 3
      },
      editFormRules: {
        UpdateLog: [{ required: true, message: '请输入更新日志', trigger: 'blur' }]
      },
      fileUploadApi: ''
    };
  },

  methods: {
    load: function() {
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

    timeFormatter: function (row) {
      return moment(row.AddTime).format('YYYY-MM-DD HH:mm:ss');
    },

    handlePageChange: function(page) {
      this.page = page;
      this.load();
    },

    getUploadUrl: function() {
      return `${server.base}/AppUpdate/Upload?level=${this.editFormModel.level}&token=${local.getItem('token')}&async=true`;
    },

    showDialog: function () {
      this.editFormModel.UpdateLog = '';
      this.editFormModel.Url = '';
      this.editFormModel.level = 3;
      // this.$refs.upload.clearFiles();
      console.info(this.$refs);

      this.editFormVisible = true;
    },

    uploadSuccess: function(res) {
      let { path, version, hash } = res;
      this.editFormModel.Url = path;
      this.editFormModel.HashCode = hash;
    },

    beforeUpload: function(file) {
      // 验证文件类型
      if (!/.+\.apk$/.test(file.name)) {
        this.$message({ type: 'error', message: '请选择.apk文件进行上传' });
        return false;
      }
    },

    submit: function() {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          let model = this.editFormModel;
          if (!model.Url) {
            this.$message({ type: 'error', message: '请上传文件(:=' });
            return;
          }

          this.editFormLoading = true;
          NProgress.start();

          server.post('/AppUpdate/Add', { model: model, level: model.level }, this).then(res => {
            this.editFormLoading = false;
            NProgress.done();

            if (res.code === 100) {
              this.load();
              this.editFormVisible = false;
              this.$message({ type: 'success', message: '发布成功(:=' });
            } else {
              this.$message({ type: 'error', message: '发布失败，请稍后重试(:=' });
            }
          });
        }
      });
    },

    handleDelete: function (model) {
      this.$confirm('您确定删除此项吗？').then(() => {
        NProgress.start();
        server.post('/AppUpdate/Delete', { id: model.Id }, this)
          .then(res => {
            NProgress.done();
            if (res.code === 100) {
              this.$message({ type: 'success', message: '删除成功(:=' });
              this.load();
            } else {
              this.$message({ type: 'error', message: '删除失败，请稍后重试(:=' });
            }
          });
      }).catch(() => { /* 取消 */ });
    }
  },

  mounted() {

    this.load();
  }
};
</script>
<style scoped lang="scss">

</style>

