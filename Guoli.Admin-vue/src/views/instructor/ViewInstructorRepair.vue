



<template>
    <section>

        <!--工具条-->
        <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
            <el-form :inline="true" :model="conditions" @submit.native.prevent="load">


                <el-form-item>
                            <el-input v-model="conditions.Name.value" placeholder="指导司机"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.TrainCode.value" placeholder="车次"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.LocomotiveType.value" placeholder="机车型号"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.Location.value" placeholder="发生地点"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-date-picker v-model="conditions.HappenTime.value" type="daterange" placeholder="发生时间" align="right">
                            </el-date-picker>
                </el-form-item>

                <el-form-item>
                    <el-button type="primary" v-on:click="load" icon="search">查询</el-button>
                </el-form-item>
            </el-form>
        </el-col>

        <!-- 列表 -->
        <el-table :data="data" highlight-current-row v-loading="isLoading" id="table">

            <el-table-column type="index" width="80" label="序号"></el-table-column>

            <el-table-column prop="Name"
                                label="指导司机"


                                ></el-table-column>
            <el-table-column prop="DepartmentName"
                                label="所属单位"


                                ></el-table-column>
            <el-table-column prop="LocomotiveType"
                                label="机车型号"


                                ></el-table-column>
            <el-table-column prop="TrainCode"
                                label="车次"


                                ></el-table-column>
            <el-table-column prop="DriverName"
                                label="司机"


                                ></el-table-column>
            <el-table-column prop="Location"
                                label="发生地点"


                                ></el-table-column>
            <el-table-column prop="FaultLocation"
                                label="故障处所"


                                ></el-table-column>
            <el-table-column prop="HappenTime"
                                label="发生时间"
                                :formatter="HappenTimeFormatter"

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
                table: 'ViewInstructorRepair',
                order: 'HappenTime',
                desc: true,
                conditions: {
									Name: { value: undefined, type: 'like' },
									TrainCode: { value: undefined, type: 'like' },
									LocomotiveType: { value: undefined, type: 'like' },
									Location: { value: undefined, type: 'like' },
									HappenTime: { value: undefined, type: 'between' },
                },

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

						HappenTimeFormatter: function(row) { return moment(row.HappenTime).format('YYYY-MM-DD'); },

            handlePageChange: function (page) {
                this.page = page;
                this.load();
            }
        },

        mounted() {

            this.load();
        }
    };
</script>
<style scoped lang="scss">

</style>

