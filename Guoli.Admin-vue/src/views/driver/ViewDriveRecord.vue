



<template>
    <section>

        <!--工具条-->
        <el-col :span="24" class="toolbar" style="padding-bottom: 0px;">
            <el-form :inline="true" :model="conditions" @submit.native.prevent="load">
                

                <el-form-item>
                            <el-input v-model="conditions.FullName.value" placeholder="车次"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.DriverName.value" placeholder="司机姓名"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.LocomotiveType.value" placeholder="机车型号"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-input v-model="conditions.LineName.value" placeholder="运行线路"></el-input>
                </el-form-item>
                <el-form-item>
                            <el-date-picker v-model="conditions.AttendTime.value" type="daterange" placeholder="运行日期" align="right">
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

            <el-table-column prop="DriverName"
                                label="司机"
                                :formatter="DriverNameFormatter"
                                
                                ></el-table-column>
            <el-table-column prop="ViceDriverName"
                                label="副司机"
                                :formatter="ViceDriverNameFormatter"
                                
                                ></el-table-column>
            <el-table-column prop="FullName"
                                label="车次"
                                
                                
                                ></el-table-column>
            <el-table-column prop="LineName"
                                label="运行线路"
                                
                                
                                ></el-table-column>
            <el-table-column prop="LocomotiveType"
                                label="机车型号"
                                
                                
                                ></el-table-column>
            <el-table-column prop="AttendTime"
                                label="出勤时间"
                                :formatter="AttendTimeFormatter"
                                sortable
                                ></el-table-column>
            <el-table-column prop="RecordEndTime"
                                label="退勤时间"
                                :formatter="RecordEndTimeFormatter"
                                sortable
                                ></el-table-column>
            <el-table-column prop="AddTime"
                                label="添加时间"
                                :formatter="AddTimeFormatter"
                                sortable
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
                table: 'ViewDriveRecord',
                order: 'AddTime',
                desc: true,
                conditions: {
									FullName: { value: undefined, type: 'like' },
									DriverName: { value: undefined, type: 'like' },
									LocomotiveType: { value: undefined, type: 'like' },
									LineName: { value: undefined, type: 'like' },
									AttendTime: { value: undefined, type: 'between' },
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

						DriverNameFormatter: function(row) { return `${row.DriverName}-${row.DriverWorkNo}`; },						ViceDriverNameFormatter: function(row) { if (row.ViceDriverName) {
  return `${row.ViceDriverName}-${row.ViceDriverWorkNo}`;
}

return ''; },						AttendTimeFormatter: function(row) { let d = moment(row.AttendTime);
if (d.year() === 1900) {
	return '';
}

return d.format('YYYY-MM-DD HH:mm'); },						RecordEndTimeFormatter: function(row) { let d = moment(row.RecordEndTime);
if (d.year() === 1900) {
	return '';
}

return d.format('YYYY-MM-DD HH:mm'); },						AddTimeFormatter: function(row) { let d = moment(row.AddTime);
if (d.year() === 1900) {
	return '';
}

return d.format('YYYY-MM-DD HH:mm'); },

            handlePageChange: function (page) {
                this.page = page;
            }
        },

        mounted() {

            this.load();
        }
    };
</script>
<style scoped lang="scss">

</style>

