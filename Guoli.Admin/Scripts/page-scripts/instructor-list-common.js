(function (window, $) {
    $(function () {
        window.selectChange = function () {
            var instructorId = $('#insList').val();
            var month = $('#monthList').val();

            var newUrl = '{0}?instructorId={1}&month={2}'.format(page.ajaxUrl, instructorId, month);
            page.$dataTable.DataTable().ajax.url(newUrl).load();
        };

        var $filter = $('<div id="filterBox" class="row"><div class="col-sm-3 mb-20"><label>选择指导司机：</label><select onchange="window.selectChange();" class="select filter" id="insList"><option value="-1">全部</option></select></div></div>');
        if (!page.donotNeedMonth) {
            $filter.append('<div class="col-sm-3 mb-20"><label>选择月份：</label><select onchange="window.selectChange();" class="select filter" id="monthList"></select></div>');
        }

        $filter.insertBefore($('#responsive-usage_wrapper'));

        common.ajax({
            url: '/Instructor/GetInstructorList',
            success: function (res) {
                if (res.code == 108) {
                    for (var i = 0; i < res.data.length; i++) {
                        var model = res.data[i];
                        var displayText = '{0} - {1}'.format(model.Name, model.DepartmentName);
                        $('#insList').append('<option value="{0}">{1}</option>'.format(model.Id, displayText));
                    }
                }
            }
        });

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
    });
})(window, jQuery);