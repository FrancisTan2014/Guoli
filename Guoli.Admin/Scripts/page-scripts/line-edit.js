(function (windiw, $) {
    $(function () {
        $('#btnBack').on('click', function () {
            location.href = '/Line/Index';
        });

        $('#btnSave').on('click', function () {
            page.save();
        });

        $('.station-intell').on('keyup', function() {
            var input = $(this).val();
            var $list = $(this).siblings('.list-group').empty().show();
            if (input.length > 0) {
                common.ajax({
                    url: '/Line/SearchStations',
                    data: { key: input },
                    success: function (res) {
                        if (res.code == 108) {
                            var data = res.data;
                            for (var i = 0; i < data.length; i++) {
                                var displayName = "{0}&nbsp;&nbsp;&nbsp;&nbsp;{1}&nbsp;&nbsp;&nbsp;&nbsp;{2}".format(data[i].StationName, data[i].Spell, data[i].SN);
                                var $item = $('<a href="javascript:void(0);" class="list-group-item" data-id="{0}" data-name="{1}">{2}</a>'.format(data[i].Id, data[i].StationName, displayName));

                                $item.on('click', function() {
                                    page.listItemClick($(this));
                                });

                                $list.append($item);
                            }
                        }
                    }
                });
            }
        }).on('focus', function () {
            $('.list-group.on').removeClass('on').hide();
            $(this).siblings('.list-group').addClass('on').show();
        });

        $('.station-input').on('focus', function () {
            page.$currentInput = $(this)

            var $alert = $('.input-alert').show();
            common.showModal({
                title: '选择车站',
                showConfirm: false,
                showCancel: false,
                content: $alert,
                cancel: function() {
                    $alert.hide();
                }
            });
        });

        // init
        var lineId = common.getQueryParam('id');
        if (lineId > 0) {
            page.lineId = lineId;
            page.initForm();
        }
        page.initComponents();
    });

    window.page = {
        $parsley: null,
        lineId: 0,

        $currentInput: null,

        /**
         * 当前线路上的所有车站 { Id: 0, StationId: 0, StationName: '', Sort: 0 }
         */
        stations: {
            maxSort: 0,
            list: []
        },

        initForm: function () {
            var _this = this;
            common.ajax({
                url: '/Line/GetLineInfo',
                data: { id: _this.lineId },
                success: function (res) {
                    if (res.code == 108) {
                        var data = res.data;

                        common.fillForm('form', data.line);
                        _this.stations.list = data.stations;
                        _this.stations.maxSort = data.stations.max(function(item) {
                            return item.Sort;
                        }) || 0;

                        for (var i = 0; i < data.stations.length; i++) {
                            var item = data.stations[i];
                            _this.addStation(item.Id, item.StationId, item.StationName);
                        }
                    } else {
                        common.alert(res.msg, function () {
                            location.href = '/Line/Index';
                        });
                    }
                }
            });
        },

        initComponents: function () {
            var _this = this;

            _this.$parsley = $('form').parsley();
        },

        listItemClick: function($item) {
            var _this = this;
            var $parent = $item.parent();
            var id = $item.data('id');
            var name = $item.data('name');

            if (!$parent.hasClass('add-station')) {
                _this.$currentInput.val(name);
                _this.$currentInput.prev().val(id);

                $('.input-alert').appendTo('body');
                common.hideModal();

            } else {
                if (_this.stations.list.contains(
                    function(station) { return station.StationId == id; }
                )) {
                    common.alert('{0} 已存在'.format(name));
                } else {
                    _this.stations.maxSort += 1;
                    _this.stations.list.push({
                        Id: 0,
                        StationId: id,
                        StationName: name,
                        Sort: _this.stations.maxSort
                    });

                    _this.addStation(0, id, name);
                }
            }
        },

        addStation: function (lineStationId, stationId, stationName) {
            var _this = this;
            var $stationList = $('.station-list');
            var $station = $('<div data-linestationid="{0}" data-stationid="{1}" class="btn btn-lightred btn-ef btn-ef-5 btn-ef-5b mb-10 mr-10"><i class="fa fa-trash"></i><span>{2}</span></div>'.format(lineStationId, stationId, stationName));

            $station.on('click', function() {
                _this.deleteStation($(this));
            });

            $stationList.append($station);
            if ($stationList.children('.btn').length > 1) {
                $('<i class="fa fa-chevron-right text-lg mr-10"></i>').insertBefore($station);
            }
        },

        deleteStation: function ($station) {
            var _this = this;
            var lineStationId = $station.data('linestationid');
            if (confirm('您确定要删除此车站吗？，这个操作将使列车时刻，车次等与这条线路相关的数据变得不准备，请谨慎操作！')) {
                if (confirm('再次提醒，这个操作将使列车时刻，车次等与这条线路相关的数据变得不准备，请谨慎操作！确定删除？')) {
                    common.ajax({
                        url: '/Line/DeleteLineStation',
                        data: { lineStationId: lineStationId },
                        success: function(res) {
                            if (res.code == 100) {
                                var stationId = $station.data('stationid');
                                _this.stations.list.remove(function(station) {
                                    return station.StationId == stationId;
                                });

                                var $prev = $station.prev();
                                if ($prev.hasClass('fa')) {
                                    $prev.remove();
                                }
                                $station.remove();
                            } else {
                                common.alert('删除失败，请稍后重试');
                            }
                        }
                    });
                }
            }
        },

        save: function () {
            var _this = this;
            if (_this.$parsley.validate()) {
                var line = common.formJsonfiy('form');

                if (line.FirstStationId == 0 || line.LastStationId == 0) {
                    common.alert('起始站或终点站请从根据车站拼音、名称或者SN号码搜索出的结果中选择，只是自己打字输入的不能被录入。');

                    return;
                }

                common.showLoading();
                common.ajax({
                    url: '?',
                    data: {
                        line: JSON.stringify(line),
                        stations: JSON.stringify(_this.stations.list)
                    },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 100) {
                            location.href = '/Line/Index';
                            return;
                        }

                        common.alert(res.msg);
                    },
                    error: function() {
                        common.hideLoading();
                        common.alert('保存失败');
                    }
                });
            }
        }
    };
})(window, jQuery);