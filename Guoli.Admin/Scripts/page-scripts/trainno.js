(function (window, $) {
    $(function () {
        $('#btnAddTrainNo').on('click', function () {
            location.href = '/Line/TrainNoEdit';
        });

        page.initDataTable();
    });

    window.page = {
        $dataTable: null,

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: '/Line/GetTrainNos',
                fields: ['FullName', 'FirstStation', 'LastStation', 'Direction', 'RunType', 'UpdateTime', "Id"],
                aoColumnDefs: [
                {
                    aTargets: [4],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        var displayText = '';
                        switch (sData) {
                            case 1:
                                displayText = '客车';
                                break;
                            case 2:
                                displayText = '货车';
                                break;
                            case 3:
                                displayText = '单机';
                                break;
                            case 4:
                            default:
                                displayText = '其他';
                                break;
                        }
                        $(nTd).empty().append(displayText);
                    }
                },
                {
                    aTargets: [5],
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Line/TrainNoEdit?id={0}">修 改</a>'.format(sData));

                        $(nTd).append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Line/TrainMoment?trainNoId={0}">列车时刻</a>'.format(sData));
                    }
                }]
            });
        }
    };
})(window, jQuery);