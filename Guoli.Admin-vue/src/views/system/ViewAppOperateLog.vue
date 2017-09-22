



<template>
    <section>

        <!--工具条-->
        <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
            <el-form :inline="true" :model="conditions" @submit.native.prevent="load">
                

                <el-form-item>
                            <el-select v-model="conditions.DepartmentId.value" placeholder="部门" clearable>
                                <el-option v-for="item in DepartmentIdSelectData" :key="item.DepartmentName" :label="item.DepartmentName" :value="item.Id"></el-option>
                            </el-select>
                </el-form-item>
                <el-form-item>
                            <el-select v-model="conditions.PostId.value" placeholder="职务" clearable>
                                <el-option v-for="item in PostIdSelectData" :key="item.PostName" :label="item.PostName" :value="item.Id"></el-option>
                            </el-select>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.WorkNo.value" placeholder="工号"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-select v-model="conditions.LogType.value" placeholder="日志类型" clearable>
                                <el-option v-for="item in LogTypeSelectData" :key="item.key" :label="item.key" :value="item.value"></el-option>
                            </el-select>
                </el-form-item>

                <el-form-item>
                    <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
                </el-form-item>
            </el-form>
        </el-col>

        <!-- 列表 -->
        <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

            <el-table-column type="index" width="80" label="序号"></el-table-column>

            <el-table-column prop="LogContent"
                                label="日志内容"
                                
                                
                                ></el-table-column>
            <el-table-column prop="LogType"
                                label="日志类型"
                                :formatter="LogTypeFormatter"
                                
                                ></el-table-column>
            <el-table-column prop="Name"
                                label="姓名"
                                
                                
                                ></el-table-column>
            <el-table-column prop="WorkNo"
                                label="工号"
                                
                                
                                ></el-table-column>
            <el-table-column prop="PostName"
                                label="职务"
                                
                                
                                ></el-table-column>
            <el-table-column prop="DepartmentName"
                                label="部门"
                                
                                
                                ></el-table-column>
            <el-table-column prop="AddTime"
                                label="添加时间"
                                :formatter="AddTimeFormatter"
                                
                                ></el-table-column>


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
        

    </section>
</template>
<script>
    
    import moment from 'moment';
    
    import server from '@/store/server';
    import { timepickerOptions } from '@/utils';

    export default {
        data() {
            return {
                isLoading: false,
                data: [],

                // 搜索
                apiUrl: '/Instructor/GetListForVue',
                table: 'ViewAppOperateLog',
                order: 'AddTime',
                desc: true,
                conditions: {
									DepartmentId: { value: undefined, type: 'equal' },
									PostId: { value: undefined, type: 'equal' },
									WorkNo: { value: undefined, type: 'like' },
									LogType: { value: undefined, type: 'equal' },
                },
								DepartmentIdSelectData: [],
								PostIdSelectData: [],
								LogTypeSelectData: [{key:'登录平板',value:1},{key:'退出登录',value:2},{key:'资料更新',value:4},{key:'查看最新公告',value:5},{key:'业务学习',value:6},{key:'查看行车资料',value:7}],

                // 分页
                total: 0,
                sizes: [10, 20, 50, 100],
                size: 10,
                page: 1,
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

						LogTypeFormatter: function(row) { return {1: '登录平板',2: '退出登录',4: '资料更新',5: '查看最新公告',6: '业务学习',7: '查看行车资料'}[row.LogType]; },						AddTimeFormatter: function(row) { return moment(row.AddTime).format('YYYY-MM-DD HH:mm:ss'); },

            handlePageChange: function (page) {
                this.page = page;
                this.load();
            }
        },

        mounted() {
			server.post('/Common/GetDeparts', {}, this).then(res => {
                      let { code, data } = res;this.DepartmentIdSelectData = data;});
			server.post('/Common/GetPositions', {}, this).then(res => {
                      let { code, data } = res;this.PostIdSelectData = data;});

            this.load();
        }
    };
</script>
<style scoped lang="scss">

</style>

