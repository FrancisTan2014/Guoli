



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.Title.value" placeholder="标题"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.PubTime.value" type="daterange" placeholder="发布时间" align="right">
          </el-date-picker>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="dialogVisible = true" icon="plus">发布公告</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="Title" label="公告标题"></el-table-column>
      <el-table-column prop="AnnounceType" label="公告类型" :formatter="AnnounceTypeFormatter"></el-table-column>
      <el-table-column prop="Content" label="公告内容" :formatter="ContentFormatter"></el-table-column>
      <el-table-column prop="PubTime" label="发布时间" :formatter="PubTimeFormatter"></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text" @click="showEditForm(scope.row)">修改</el-button>
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
    <el-dialog title="发布新公告" :visible="dialogVisible" :before-close="reset">

      <el-form ref="editForm" :model="editFormModel" :rules="editFormRules" label-width="120px">

        <el-form-item label="标题：" prop="Title">
          <el-input v-model="editFormModel.Title"></el-input>
        </el-form-item>

        <el-form-item label="公告类型：" prop="AnnounceType">
          <el-radio-group v-model="editFormModel.AnnounceType">
            <el-radio-button :label="1">文件</el-radio-button>
            <el-radio-button :label="2">文字</el-radio-button>
          </el-radio-group>
        </el-form-item>

        <el-form-item label="选择文件：" v-if="editFormModel.AnnounceType === 1">
          <el-upload class="upload-demo" drag :action="fileUploadUrl" :on-success="uploadSuccess" accept="application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/pdf">
            <i class="el-icon-upload"></i>
            <div class="el-upload__text">将文件拖到此处，或
              <em>点击上传</em>
            </div>
            <div class="el-upload__tip" slot="tip">仅支持doc/docx/pdf格式的文件</div>
          </el-upload>
        </el-form-item>

        <el-form-item label="文件名称：" prop="FileName" v-if="editFormModel.AnnounceType === 1">
          <el-input v-model="editFormModel.FileName"></el-input>
        </el-form-item>

        <el-form-item label="公告内容：" v-if="editFormModel.AnnounceType === 2" prop="Content">
          <el-input type="textarea" :rows="5" v-model="editFormModel.Content"></el-input>
        </el-form-item>

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="reset">取 消</el-button>
        <el-button type="primary" @click="handleEdit" :loading="editFormLoading">确 定</el-button>
      </div>

    </el-dialog>

  </section>
</template>
<script>

import moment from 'moment';
import NProgess from 'nprogress';
import clone from 'clone';
import server from '@/store/server';
import { timepickerOptions } from '@/utils';

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'Announcement',
      order: 'PubTime',
      desc: true,
      conditions: {
        Title: { value: undefined, type: 'like' },
        PubTime: { value: undefined, type: 'between' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 编辑公告
      fileUploadUrl: `${server.base}/Files/FileUpload?fileType=5`,
      dialogVisible: false,
      editFormLoading: false,
      editFormModel: {
        Id: 0,
        Title: '',
        AnnounceType: 1,
        Content: '',
        FileName: '',
        FilePath: '',
        PubTime: ''
      },
      editFormRules: {
        Title: [
          { required: true, message: '请输入公告标题', trigger: 'blur' },
          { max: 30, message: '标题不能超过30个字', trigger: 'blur' }
        ],
        Content: [{ required: true, message: '请输入公告内容', trigger: 'blur' }]
      }
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

    AnnounceTypeFormatter: function (row) { return row.AnnounceType === 1 ? '文件' : '文本'; },
    ContentFormatter: function (row) { return row.AnnounceType === 1 ? row.FileName : row.Content },
    PubTimeFormatter: function (row) { return moment(row.PubTime).format('YYYY-MM-DD HH:mm:ss'); },

    handlePageChange: function (page) {
      this.page = page;
    },

    reset: function (done) {
      this.$refs.editForm.resetFields();
      this.dialogVisible = false;
      if (typeof done === 'function') {
        done();
      }
    },

    showEditForm: function (model) {
      this.editFormModel = clone(model);
      this.dialogVisible = true;
    },

    uploadSuccess: function (file) {
      let model = this.editFormModel;
      model.FileName = file.OriginalFileName.replace(file.FileExtension, '');
      model.FilePath = file.FileRelativePath;
    },

    handleEdit: function () {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          this.editFormLoading = true;
          NProgess.start();

          let m = this.editFormModel;
          let successMsg = m.Id > 0 ? '公告修改成功(:=' : '公告发布成功(:=';
          let failureMsg = m.Id > 0 ? '公告修改失败，请稍后重试(:=' : '公告发布失败，请稍后重试(:=';

          server.post('/Announce/Save', { json: JSON.stringify(this.editFormModel) }, this)
            .then(res => {
              this.editFormLoading = false;
              NProgess.done();
              if (res.code === 100) {
                this.dialogVisible = false;
                this.$refs.editForm.resetFields();
                this.load();
                this.$message({ type: 'success', message: successMsg });
              } else {
                this.$message({ type: 'error', message: failureMsg });
              }
            });
        }
      });
    },

    handleDelete: function (row) {
      this.$confirm('您确定要删除此公告吗？')
        .then(() => {
          server.post('/Announce/Delete', { id: row.Id }, this)
            .then(res => {
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

