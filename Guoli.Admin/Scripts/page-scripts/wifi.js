/// <reference path="common.js" />

(function (window, $) {
    $(function () {
        $('#btnView').on('click', function() {
            page.viewClick();
        });

        $('#btnMore').on('click', function() {
            page.loadMore();
        });

        page.initComponents();
    });

    window.page = {
        pageIndex: 1,
        pageSize: 20,
        pid: 0,
        time: '',
        name: '',

        initComponents: function () {
            common.ajax({
                url: '/Instructor/GetInstructorList'
            }).done(function(res) {
                if (res.code == 108) {
                    res.data.forEach(function (value, index) {
                        var html = '<option value="{0}">{1}</option>'.format(value.Id, value.Name + ' | ' + value.WorkNo);
                        $('[name=InstructorId]').append(html);
                    });
                }  
            });

            $('#dtBox').DateTimePicker({
                dateTimeFormat: 'yyyy-MM-dd HH:mm',
                shortDayNames: ['日', '一', '二', '三', '四', '五', '六'],
                fullDayNames: ['周日', '周一', '周二', '周三', '周四', '周五', '周六'],
                shortMonthNames: ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12'],
                fullMonthNames: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
                titleContentDateTime: '选择时间',
                setButtonContent: "确定",
                clearButtonContent: "清除",
                formatHumanDate: function (sDate) {
                    return sDate.dayShort + ", " + sDate.month + " " + sDate.dd + ", " + sDate.yyyy;
                }
            });
        },

        viewClick: function() {
            var time = $('[name=ConnectTime]').val();
            var pid = +$('[name=InstructorId]').val();

            if (!time) {
                common.alert('请选择一个时间点');
                return;
            }

            if (pid <= 0) {
                common.alert('请选择一个指导司机');
                return;
            }

            $('.timeline-post').remove();

            var name = $('[name=InstructorId]>option:selected').text();
            this.pageIndex = 1;
            this.pid = pid;
            this.time = time;
            this.name = name;
            this.loadData();
        },

        loadData: function() {
            var _this = this;

            common.showLoading();
            common.ajax({
                url: '/Instructor/GetWifiRecods',
                data: {
                    pid: _this.pid,
                    time: _this.time,
                    pageIndex: _this.pageIndex,
                    pageSize: _this.pageSize
                }
            }).done(function(res) {
                common.hideLoading();
                if (res.code == 108) {
                    if (_this.pageIndex === 1) {
                        $('#btnHead').text(_this.name);
                    }

                    res.data.forEach(function (value, index) {
                        var conn = value.ConnectFlag == 1 ? 'WIFI自动连接' : 'WIFI断开连接';
                        var time = common.processDate(value.ConnectTime).format('yyyy-MM-dd HH:mm:ss');
                        $('#timeLine').append('<li class="timeline-post"><aside><div class="thumb wh30 bg-blue"><i class="fa fa-clock-o"></i></div></aside><div class="post-container"><div class="panel panel-default b-0"><h3 class="custom-font text-blue">{0}</h3><p>{1}</p><p>{2}</p></div></div></li>'.format(value.Location, conn, time));
                    });

                    $('#btnMore').show();
                    return;
                }

                common.alert('没有更多记录了');
                $('#btnMore').hide();
            });
        },

        loadMore: function() {
            var _this = this;
            _this.pageIndex++;
            _this.loadData();
        }
    };
})(window, jQuery);