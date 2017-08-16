



<template>
  <section>

    <!--工具条-->
    <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
      <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

        <el-form-item>
          <el-input v-model="conditions.ExamName.value" placeholder="考试名称"></el-input>
        </el-form-item>
        <el-form-item>
          <el-input v-model="conditions.FileName.value" placeholder="考试内容"></el-input>
        </el-form-item>
        <el-form-item>
          <el-date-picker v-model="conditions.AddTime.value" type="daterange" placeholder="添加时间" align="right">
          </el-date-picker>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
          <el-button type="primary" v-on:click="notifyDialogVisible = true" icon="plus">添加考试通知</el-button>
        </el-form-item>
      </el-form>
    </el-col>

    <!-- 列表 -->
    <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

      <el-table-column type="index" width="80" label="序号"></el-table-column>

      <el-table-column prop="ExamName" label="考试名称" min-width="120"></el-table-column>
      <el-table-column prop="FileName" label="考试内容" min-width="120"></el-table-column>
      <el-table-column prop="PostName" label="参考人群"></el-table-column>
      <el-table-column prop="QuestionCount" label="题目总数"></el-table-column>
      <el-table-column prop="PassScore" label="通过分数"></el-table-column>
      <el-table-column prop="ResitCount" label="允许考试次数"></el-table-column>
      <el-table-column prop="TimeLimit" label="考试限时（分）"></el-table-column>
      <el-table-column prop="EndTime" label="考试截止时间" :formatter="EndTimeFormatter" min-width="120"></el-table-column>
      <el-table-column prop="AddTime" label="添加时间" :formatter="AddTimeFormatter"></el-table-column>

      <el-table-column label="操作" min-width="120">
        <template scope="scope">
          <el-button type="text" @click="showEditDialog(scope.row)">修改</el-button>
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

    <!-- 添加考试通知弹窗 -->
    <el-dialog :title="editFormModel.Id > 0 ? '修改考试通知' : '发布考试通知'" :visible="notifyDialogVisible"
      :before-close="() => {notifyDialogVisible=false}">

      <el-form ref="editForm" :model="editFormModel" label-width="120px" :rules="editFormRules" @submit.native.prevent="handleAddFile">

        <el-form-item label="考试题库：" prop="ExamFilesIdSelected">
          <el-cascader :options="cascaderOptions" v-model="editFormModel.ExamFilesIdSelected" clearable expand-trigger="hover" :show-all-levels="false"></el-cascader>
        </el-form-item>

        <el-form-item label="参考人群：" prop="PostId">
          <el-select v-model="editFormModel.PostId" clearable filterable placeholder="输入关键字搜索">
            <el-option v-for="item in posts" :key="item.Id" :label="item.PostName" :value="item.Id"></el-option>
          </el-select>
        </el-form-item>

        <el-form-item label="考试名称：" prop="ExamName">
          <el-input v-model="editFormModel.ExamName"></el-input>
        </el-form-item>

        <el-form-item label="抽取试题数量：" prop="QuestionCount">
          <el-input v-model.number="editFormModel.QuestionCount"></el-input>
        </el-form-item>

        <el-form-item label="通过分数：" prop="PassScore">
          <el-input v-model.number="editFormModel.PassScore" placeholder="满分100"></el-input>
        </el-form-item>

        <el-form-item label="允许补考次数：" prop="ResitCount">
          <el-input v-model.number="editFormModel.ResitCount"></el-input>
        </el-form-item>

        <el-form-item label="考试限时：" prop="TimeLimit">
          <el-input v-model.number="editFormModel.TimeLimit" placeholder="单位：分"></el-input>
        </el-form-item>

        <el-form-item label="考试截止时间：" prop="EndTime">
          <el-date-picker v-model="editFormModel.EndTime" type="datetime" placeholder="选择日期时间">
          </el-date-picker>
        </el-form-item>

      </el-form>

      <div slot="footer" class="dialog-footer">
        <el-button @click="notifyDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="handleEditNotify" :loading="editFormLoading">确 定</el-button>
      </div>

    </el-dialog>

  </section>
</template>
<script>

import moment from 'moment';
import _ from 'underscore';
import server from '@/store/server';
import { timepickerOptions } from '@/utils';
import NProgress from 'nprogress';
import clone from 'clone';

let timeValidator = function (rule, value, callback) {
  if (!value) {
    callback(new Error('请选择考试截止时间'));
  } else {
    let time = moment(value);
    if (time.isBefore(moment())) {
      callback(new Error('截止时间必须在当前时间之后'));
    } else {
      callback();
    }
  }
};

export default {
  data() {
    return {
      isLoading: false,
      data: [],

      // 搜索
      apiUrl: '/Instructor/GetListForVue',
      table: 'ViewExamNotify',
      order: 'Id',
      desc: false,
      conditions: {
        ExamName: { value: undefined, type: 'like' },
        FileName: { value: undefined, type: 'like' },
        AddTime: { value: undefined, type: 'between' },
      },

      // 分页
      total: 0,
      sizes: [10, 20, 50, 100],
      size: 10,
      page: 1,

      // 添加考试通知
      notifyDialogVisible: false,
      editFormLoading: false,
      editFormModel: {
        ExamName: undefined,
        PostId: undefined,
        ExamFilesIdSelected: [],
        ExamFilesId: undefined,
        QuestionCount: undefined,
        PassScore: undefined,
        ResitCount: undefined,
        EndTime: undefined,
        TimeLimit: undefined
      },
      editFormRules: {
        ExamName: [
          { required: true, message: '请输入考试名称', trigger: 'blur' },
          { max: 50, message: '考试名称不能超过50个字', trigger: 'input' }
        ],
        PostId: [{ required: true, type: 'number', message: '请选择参考人员职务', trigger: 'change' }],
        ExamFilesIdSelected: [{ required: true, type: 'array', message: '请选择考试题库', trigger: 'change' }],
        QuestionCount: [
          { required: true, type: 'number', message: '请输入本次考试题目数量', trigger: 'blur' },
          { min: 1, type: 'number', message: '请输入有效的题目数量', trigger: 'blur' }
        ],
        PassScore: [
          { required: true, type: 'number', message: '请输入本次考试通过分数（满分100）', trigger: 'blur' },
          { min: 1, max: 100, type: 'number', message: '请输入有效的通过分数（1~100）', trigger: 'blur' }
        ],
        ResitCount: [
          { required: true, type: 'number', message: '请输入本次允许考试次数（最少1次）', trigger: 'blur' },
          { min: 1, type: 'number', message: '请输入有效的考试次数（最少1次）', trigger: 'blur' }
        ],
        EndTime: [{ validator: timeValidator, required: true, trigger: 'change' }],
        TimeLimit: [
          { required: true, type: 'number', message: '请输入本次考试限时（单位：分）', trigger: 'blur' },
          { min: 1, type: 'number', message: '请输入有效的考试限时（最少1分钟）', trigger: 'blur' }
        ]
      },

      // 考试题库级联选择数据源
      cascaderOptions: [],

      // 职位列表，参考人群选择器的数据源
      posts: []
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

    EndTimeFormatter: function (row) { return moment(row.EndTime).format('YYYY-MM-DD HH:mm:ss'); }, AddTimeFormatter: function (row) { return moment(row.AddTime).format('YYYY-MM-DD'); },

    handlePageChange: function (page) {
      this.page = page;
    },

    // 加载考试题库，作为考试题库中的级联选择器的数据源
    loadExamLibs: function () {
      let tasks = [];
      tasks[0] = new Promise((resolve, reject) => {
        server.post('/Exam/GetTypeList', {}, this).then(res => {
          resolve(res.data);
        });
      });
      tasks[1] = new Promise((resolve, reject) => {
        server.post('/Exam/GetExamFileList', {}, this).then(res => {
          resolve(res.data);
        });
      });

      let self = this;
      // 将typeList和fileList处理成具有层级关系的对象数组
      // 将作为题库选项中的级联选择器的数据源
      Promise.all(tasks).then(values => {
        let arr = self.cascaderOptions,
          types = values[0],
          files = values[1];
        types.forEach(item => {
          arr.push({
            label: item.TypeName,
            value: item.Id,
            children: []
          });
        });

        arr.forEach(item => {
          let list = _.filter(files, file => file.ExamTypeId === item.value);
          if (list.length > 0) {
            item.children = [];
            list.forEach(elem => {
              item.children.push({
                label: elem.FileName,
                value: elem.Id
              });
            });
          }
        });

        self.cascaderOptions = arr;
      });
    },

    // 加载职务列表，作为参考人群中的select选择器的数据源
    loadPosts: function () {
      server.post('/Common/GetPositions', {}, this)
        .then(res => {
          this.posts = res.data;
        });
    },

    // 编辑考试通知弹窗中点击确定时触发
    handleEditNotify: function () {
      this.$refs.editForm.validate(valid => {
        if (valid) {
          // 由于级联选择器的结果是数组
          // 因此需要将数组的最后一项提取出来
          // 作为最终选择结果
          let model = this.editFormModel;
          model.ExamFilesId = _.last(model.ExamFilesIdSelected);

          let apiPath = model.Id > 0 ? '/Exam/UpdateNotify' : '/Exam/SaveNotify';
          let successMsg = model.Id > 0 ? '考试通知修改成功(:=' : '考试通知添加成功(:=';
          let failureMsg = model.Id > 0 ? '考试通知修改失败，请稍后重试(:=' : '考试通知添加失败，请稍后重试(:=';

          this.editFormLoading = true;
          NProgress.start();
          server.post(apiPath, { json: JSON.stringify(model) }, this)
            .then(res => {
              this.editFormLoading = false;
              NProgress.done();

              let { code } = res;
              if (code === 100) {
                this.notifyDialogVisible = false;
                this.$refs.editForm.resetFields();
                this.$message({ type: 'success', message: successMsg });
                this.load();
              } else {
                this.$message({ type: 'error', message: failureMsg });
              }
            });
        }
      });
    },

    // 显示修改考试通知弹窗
    showEditDialog: function (model) {
      this.editFormModel = clone(model);
      let alias = this.editFormModel;
      console.info(alias);

      // 使时间在el-datetimepicker中能正常显示
      alias.EndTime = moment(alias.EndTime).format('YYYY-MM-DD HH:mm:ss');

      // 设置级联选择器的已选择项为model中对应的值
      this.cascaderOptions.forEach(item => {
        let o = _.find(item.children, elem => elem.value === alias.ExamFilesId);
        if (!!o) {
          alias.ExamFilesIdSelected = [item.value, alias.ExamFilesId];
        }
      });

      this.notifyDialogVisible = true;
    },

    // 删除考试通知
    handleDelete: function (model) {
      this.$confirm('您确定要删除此考试通知吗？')
        .then(() => {
          server.post('/Exam/DeleteNotify', { id: model.Id }, this)
            .then(res => {
              if (res.code === 100) {
                this.$message({ type: 'success', message: '删除成功(:=' });
                this.load();
              } else {
                this.$message({ type: 'error', message: '删除失败，请稍后重试(:=' });
              }
            });
        }).catch(() => { /* 取消 */ })
    }
  },

  mounted() {
    this.load();
    this.loadExamLibs();
    this.loadPosts();
  }
};
</script>
<style scoped lang="scss">

</style>

