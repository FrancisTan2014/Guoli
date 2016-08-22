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
                    aoData.push({ name: 'target', value: 'ViewInstructorTeach' });
                    aoData.push({ name: 'month', value: new Date().format('yyyy-MM') });
                    aoData.push({ name: 'order', value: 'TeachStart' });
                },
                fields: ['Name', 'DepartmentName', 'TeachPlace', 'JoinCount', 'TeachStart', "Id"],
                aoColumnDefs: [
                {
                    aTargets: [4],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        var start = common.processDate(sData);
                        var end = common.processDate(oData.TeachEnd);
                        var date = start.format('yyyy-MM-dd');
                        var displayText = '{0} {1} 至 {2}'.format(date, start.format('HH:mm'), end.format('HH:mm'));

                        $(nTd).empty().append(displayText);
                    }
                },
                {
                    aTargets: [5],
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Instructor/TeachDetail?id={0}">查看详情</a>'.format(sData));
                    }
                }]
            });
        }
    };
})(window, jQuery);