(function (window, $) {
    $(function () {
        page.initDropList();
        page.initDataTable();

        $('#filterBox select').on('change', function () {
            page.refreshTable();
        });

        $('#btnExport').on('click', function () {
            //location.href = '/Exam/NotifyEdit';
        });
    });

    window.page = {
        $dataTable: null,
        ajaxUrl: '/Exam/GetResults',
        notifyId: common.getQueryParam('notifyId'),

        initDropList: function () {
            common.ajax({
                url: '/Common/GetDeparts'
            }).done(function (res) {
                if (res.code == 108) {
                    common.buildOptions('select[name=DepartmentId]', {
                        data: res.data,
                        text: 'DepartmentName',
                        value: 'Id'
                    });

                    return;
                }

                console.info(res);
            });

            common.ajax({
                url: '/Common/GetExamNotifies'
            }).done(function (res) {
                if (res.code == 108) {
                    common.buildOptions('select[name=ExamNotifyId]', {
                        data: res.data,
                        text: 'ExamName',
                        value: 'Id'
                    });

                    return;
                }

                console.info(res);
            });

            common.buildOptions('select[name=Passed]', {
                data: [{ text: '通过', value: '通过' },
                       { text: '未通过', value: '未通过' }],
                text: 'text',
                value: 'value'
            });
        },

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: _this.ajaxUrl,
                fields: ['ExamName', 'Name', 'PostName', 'DepartmentName', 'MaxScore', 'Passed', "Id"],
                fnServerParams: function (aoData) {
                    aoData.push({
                        name: 'notifyId',
                        value: _this.notifyId || 0
                    });
                },
                aoColumnDefs: [
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Exam/ResultDetail?notifyId={0}&personId={1}">查看详情</a>'.format(sData, oData.PersionId));
                    }
                }]
            });
        },

        refreshTable: function () {
            var _this = this;
            var notifyId = $('select[name=ExamNotifyId]').val();
            var departId = $('select[name=DepartmentId]').val();
            var passed = $('select[name=Passed]').val();

            var newUrl = '{0}?notifyId={1}&departId={2}&passed={3}'.format(_this.ajaxUrl, notifyId, departId, passed);
            _this.$dataTable.DataTable().ajax.url(newUrl).load();
        }
    };
})(window, jQuery);