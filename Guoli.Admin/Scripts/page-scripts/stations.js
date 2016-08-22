(function (window, $) {
    $(function() {
        $('#btnAddStation').on('click', function () {
            location.href = '/Line/StationEdit';
        });

        $('input[type=search]').on('keyup', function() {
            page.search(this.value);
        });

        page.initDataTable();
    });

    window.page = {
        $dataTable: null,

        initDataTable: function () {
            var _this = this;
            _this.$dataTable = common.dataTable('.dataTable', {
                sAjaxSource: '/Line/GetStations',
                fields: ['SN', 'StationName', 'Spell', 'UpdateTime', 'CzCount', 'ZcCount', 'ZdCount', 'Id'],
                aoColumnDefs: [
                {
                    aTargets: [3],
                    fnCreatedCell: function (nTd, sData, oData, iRow, iCol) {
                        var date = common.processDate(sData);
                        $(nTd).empty().append(date.format('yyyy-MM-dd HH:mm:ss'));
                    }
                },
                {
                    aTargets: [7],
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
                        $(nTd).empty().append('<a role="button" tabindex="0" class="edit text-primary text-strong text-sm mr-10" href="/Line/StationEdit?id={0}">修改/上传文件</a>'.format(sData));
                    }
                }]
            });
        },

        search: function(key) {
            var _this = this;
            if (key) {
                _this.$dataTable.DataTable().search(key, false, true).draw();
            }
        }
    };
})(window, jQuery);