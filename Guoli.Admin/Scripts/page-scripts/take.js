(function (window, $) {
    $(function () {
        page.initDataTable();
    });

    window.page = {
        $dataTable: null,
        ajaxUrl: '/Instructor/GetList',

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: _this.ajaxUrl,
                fnServerParams: function (aoData) {
                    aoData.push({ name: 'target', value: 'ViewInstructorTempTake' });
                    aoData.push({ name: 'month', value: new Date().format('yyyy-MM') });
                    aoData.push({ name: 'order', value: 'TakeDate' });
                },
                fields: ['Name', 'DepartmentName', 'TrainCode', 'TakeSection', 'DriverName', 'TakeDate', "Id"],
                aoColumnDefs: [
                {
                    aTargets: [4],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        var date = common.processDate(sData);
                        $(nTd).empty().append(date.format('yyyy-MM-dd'));
                    }
                },
                {
                    aTargets: [6],
                    bSortable: false,
                    /*
                     * 此方法在单元格被创建完时调用
                     * 其中：
                     *  nTd 表示此单元所在的dom元素
                     *  sData 表示给予此单元格的字段值
                     *  oData 表示给予本行的数据
                     *  iRow 表示本行的索引
                     *  iCol 表示本单元格的索引
                    */
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Instructor/TakeDetail?id={0}">查看详情</a>'.format(sData));
                    }
                }]
            });
        }
    };
})(window, jQuery);