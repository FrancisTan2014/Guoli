(function (window, $) {
    $(function () {
        page.initDataTable();
    });

    window.page = {
        $dataTable: null,
        ajaxUrl: '/Instructor/GetQuotaList',

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: _this.ajaxUrl,
                iDisplayLength: 1000,
                fields: ['QuotaName', 'QuataAmmount', 'NeedReview', 'ReviewDesc', 'BaseScore', "Id"],
                aoColumnDefs: [
                {
                    aTargets: [2],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        $(nTd).empty().append(sData ? '是' : '否');
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Instructor/QuotaEdit?id={0}">查看/修改</a>'.format(sData));

                        $(nTd).append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Instructor/QuotaEdit?id={0}">评分标准</a>'.format(sData));
                    }
                }]
            });
        }
    };
})(window, jQuery);