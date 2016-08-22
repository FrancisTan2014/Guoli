(function (window, $) {
    $(function () {
        $('#btnAddLine').on('click', function () {
            location.href = '/Exam/NotifyEdit';
        });

        page.initDataTable();
    });

    window.page = {
        $dataTable: null,

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: '/Exam/GetNotifies',
                fields: ['ExamName', 'FileName', 'PostName', 'QuestionCount', 'EndTime', 'AddTime', "Id"],
                aoColumnDefs: [
                {
                    aTargets: [4,5],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        var date = common.processDate(sData);
                        $(nTd).empty().append(date.format('yyyy-MM-dd HH:mm:ss'));
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Exam/Result?notifyId={0}">查看考试结果</a>'.format(sData));
                    }
                }]
            });
        }
    };
})(window, jQuery);