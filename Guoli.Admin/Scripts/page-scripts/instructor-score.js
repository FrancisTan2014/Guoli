/// <reference path="common.js" />

; (function (window, $) {
    $(function () {
        page.initMonth();
        page.initDataTable();
    });

    window.page = {
        $dataTable: null,
        ajaxUrl: '/Instructor/GetScoreList',

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: _this.ajaxUrl,
                fnServerParams: function (aoData) {
                    aoData.push({ name: 'month', value: new Date().format('yyyy-MM') });
                },
                fields: ['Name', 'DepartmentName', 'Score', 'Month', "UpdateTime", "Id"],
                aoColumnDefs: [
                    {
                        aTargets: [3],
                        fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                            var month = '{0}-{1}'.format(oData.Year, oData.Month < 10 ? '0' + oData.Month : oData.Month);
                            $(nTd).empty().append(month);
                        }
                    },
                    {
                        aTargets: [4],
                        fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                            var date = common.processDate(sData);
                            $(nTd).empty().append(date.format('yyyy-MM-dd HH:mm:ss'));
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
                            $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Instructor/PlanDetail?id={0}">查看详情</a>'.format(sData));
                        }
                    }]
            });
        },

        initMonth: function() {
            var date = new Date();
            var month = date.getMonth();
            var year = date.getFullYear();

            for (var j = 0; j <= 35; j++) {
                date.setYear(year);
                date.setMonth(month);

                $('#monthList').append('<option value="{0}">{0}</option>'.format(date.format('yyyy-MM')));

                month -= 1;
                if (month < 0) {
                    month = 11;
                    year -= 1;
                }
            }
        },

        selectChange: function () {
            var month = $('#monthList').val();

            var newUrl = '{0}?month={1}'.format(page.ajaxUrl, month);
            page.$dataTable.DataTable().ajax.url(newUrl).load();
        }
    };
})(window, jQuery);