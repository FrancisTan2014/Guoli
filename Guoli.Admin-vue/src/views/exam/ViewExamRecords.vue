



<template>
    <section>

        <!--工具条-->
        <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
            <el-form :inline="true" :model="conditions" @submit.native.prevent="load">

                <el-form-item>
                            <el-input v-model="conditions.Name.value" placeholder="姓名"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-select v-model="conditions.DepartmentId.value" placeholder="所属单位">
                                <el-option v-for="item in DepartmentIdSelectData" :key="item.Id" :label="item.DepartmentName" :value="item.Id"></el-option>
                            </el-select>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.ExamName.value" placeholder="考试名称"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-select v-model="conditions.Passed.value" placeholder="是否通过">
                                <el-option v-for="item in PassedSelectData" :key="item.key" :label="item.key" :value="item.value"></el-option>
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

            <el-table-column prop="ExamName"
                                label="考试名称"


                                ></el-table-column>
            <el-table-column prop="Name"
                                label="参考人姓名"


                                ></el-table-column>
            <el-table-column prop="PostName"
                                label="职务"


                                ></el-table-column>
            <el-table-column prop="DepartmentName"
                                label="所属单位"


                                ></el-table-column>
            <el-table-column prop="MaxScore"
                                label="最高分数"


                                ></el-table-column>
            <el-table-column prop="Passed"
                                label="是否通过"


                                ></el-table-column>

            <el-table-column label="操作" min-width="120">
                <template scope="scope">

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
                table: 'ViewExamRecords',
                order: '',
                desc: false,
                conditions: {
									Name: { value: undefined, type: 'like' },
									DepartmentId: { value: undefined, type: 'equal' },
									ExamName: { value: undefined, type: 'like' },
									Passed: { value: undefined, type: 'equal' },
                },
								DepartmentIdSelectData: [],
								PassedSelectData: [{ key: '通过', value: '通过' }, { key: '未通过', value: '未通过' }],

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



            handlePageChange: function (page) {
                this.page = page;
                this.load();
            }
        },

        mounted() {
			server.post('/Common/GetDeparts', {}, this).then(res => {
                      let { code, data } = res;this.DepartmentIdSelectData = data;});

            this.load();
        }
    };
</script>
<style scoped lang="scss">

</style>

