(function (window, $) {
    $(function () {
        $('#btnAddPerson').on('click', function () {
            location.href = '/People/PersonEdit';
        });

        page.initDataTable();
    });

    window.page = {
        $dataTable: null,

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: '/People/GetPersons',
                fields: ['WorkNo', 'Name', 'Sex', 'PostName', 'DepartmentName', "Id"],
                aoColumnDefs: [
                {
                    aTargets: [2],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        $(nTd).empty().append(sData == 1 ? '男' : '女');
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/People/PersonEdit?id={0}">修 改</a>'.format(sData));
                    }
                }]
            });
        }
    };
})(window, jQuery);