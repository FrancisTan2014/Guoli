(function (windiw, $) {
    $(function () {
        $('#btnBack').on('click', function () {
            location.href = '/Line/TrainNo';
        });

        $('#btnSave').on('click', function () {
            page.save();
        });

        $('.station-intell').on('keyup', function () {
            var input = $(this).val();
            var $list = $(this).siblings('.list-group').empty().show();
            if (input.length > 0) {
                common.ajax({
                    url: '/Line/SearchLines',
                    data: { key: input },
                    success: function (res) {
                        if (res.code == 108) {
                            var data = res.data;
                            for (var i = 0; i < data.length; i++) {
                                var displayName = "{0}&nbsp;&nbsp;&nbsp;&nbsp;{1}".format(data[i].LineName, data[i].Spell);
                                var $item = $('<a href="javascript:void(0);" class="list-group-item" data-id="{0}" data-name="{1}" data-firststationid="{2}" data-firststation="{3}" data-laststationid="{4}" data-laststation="{5}">{6}</a>'.format(data[i].Id, data[i].LineName, data[i].FirstStationId, data[i].FirstStation, data[i].LastStationId, data[i].LastStation, displayName));

                                $item.on('click', function () {
                                    page.listItemClick($(this));
                                });

                                $list.append($item);
                            }
                        }
                    }
                });
            }
        }).on('blur', function (e) {
            var trigger = e.relatedTarget;
            if ($(trigger).parent().siblings('input')[0] == $(this)[0]) {
                $(this).focus();
                return false;
            }

            $(this).siblings('.list-group').hide();
        });

        $('.radio-label').on('click', function () {
            if ($(this).hasClass('active')) {
                return;
            }

            var value = $(this).data('value');
            $(this).parent().prev().val(value);
        });

        // 输入车次将开头字母与编号分开存储
        $('input[name=FullName]').on('keyup', function() {
            var value = $(this).val().trim();
            var regexRes = /^([a-zA-Z]+)(\d+)$/.exec(value);

            if (regexRes == null) {
                $('input[name=Code]').val('');
                $('input[name=Number]').val(value);
                return;
            }

            $('input[name=Code]').val(regexRes[1]);
            $('input[name=Number]').val(regexRes[2]);
        });

        // init 
        var trainNoId = common.getQueryParam('id');
        if (trainNoId > 0) {
            page.trainNoId = trainNoId;
            page.initForm();
        }
        page.initComponents();
    });

    window.page = {
        $parsley: null,
        trainNoId: 0,

        /**
         * 当前线路上的所有车站 { Id: 0, StationId: 0, StationName: '', Sort: 0 }
         */
        lines: {
            maxSort: 0,
            list: []
        },

        initForm: function () {
            var _this = this;
            common.ajax({
                url: '/Line/GetTrainNo',
                data: { id: _this.trainNoId },
                success: function (res) {
                    if (res.code == 108) {
                        var data = res.data;

                        common.fillForm('form', data.trainNo);
                        _this.lines.list = data.lines;
                        _this.updateStations();
                        _this.lines.maxSort = data.lines.max(function (item) {
                            return item.Sort;
                        }) || 0;

                        for (var i = 0; i < data.lines.length; i++) {
                            var item = data.lines[i];
                            _this.addLine(item.TrainNoLineId, item.LineId, item.LineName);
                        }

                        $('.direction>label').each(function() {
                            if ($(this).data('value') == data.trainNo.Direction) {
                                $(this).addClass('active');
                            }
                        });
                        $('.runtype>label').each(function() {
                            if ($(this).data('value') == data.trainNo.RunType) {
                                $(this).addClass('active');
                            }
                        });
                    } else {
                        common.alert(res.msg, function () {
                            location.href = '/Line/TrainNo';
                        });
                    }
                }
            });
        },

        initComponents: function () {
            var _this = this;

            _this.$parsley = $('form').parsley();
        },

        listItemClick: function ($item) {
            var _this = this;
            var id = $item.data('id');
            var name = $item.data('name');
            var firstStationId = $item.data('firststationid');
            var firstStation = $item.data('firststation');
            var lastStationId = $item.data('laststationid');
            var lastStation = $item.data('laststation');

            if (_this.lines.list.contains(
                function (line) { return line.LineId == id; }
            )) {
                common.alert('{0} 已存在'.format(name));
                return;
            }

            // 判断当前选择的线路与已经存在的线路是否能连贯
            var lastLine = _this.lines.list.last();
            if (lastLine) {
                if (lastLine.LastStationId != firstStationId) {
                    common.alert('您当前选择的这条线路，与上一条线路不能连贯在一起，请重新选择！');
                    return;
                }
            }

            _this.lines.maxSort += 1;
            _this.lines.list.push({
                Id: 0,
                TrainNoId: _this.trainNoId,
                LineId: id,
                Sort: _this.lines.maxSort,
                FirstStationId: firstStationId,
                FirstStation: firstStation,
                LastStationId: lastStationId,
                LastStation: lastStation
            });

            _this.addLine(0, id, name);
            _this.updateStations();
        },

        // 更新本车次的起点/终点站
        updateStations: function() {
            var _this = this;
            if (_this.lines.list.length > 0) {
                var firstLine = _this.lines.list.first();
                var lastLine = _this.lines.list.last();

                $('input[name=FirstStation]').val(firstLine.FirstStation);
                $('input[name=LastStation]').val(lastLine.LastStation);

                $('#firstLastStations').empty().append('<label class="mr-10 text-lg">{0}</label><i class="fa fa-chevron-right text-lg mr-10"></i><label class="text-lg">{1}</label>'.format(firstLine.FirstStation, lastLine.LastStation));
            }
        },

        addLine: function (trainNoLIneId, lineId, lineName) {
            var _this = this;
            var $lineList = $('.line-list');
            var $line = $('<div data-trainnolineid="{0}" data-lineid="{1}" class="btn btn-lightred btn-ef btn-ef-5 btn-ef-5b mb-10 mr-10"><i class="fa fa-trash"></i><span>{2}</span></div>'.format(trainNoLIneId, lineId, lineName));

            $line.on('click', function () {
                _this.deleteLine($(this));
            });

            $lineList.append($line);
            if ($lineList.children('.btn').length > 1) {
                $('<i class="fa fa-chevron-right text-lg mr-10"></i>').insertBefore($line);
            }
        },

        deleteLine: function ($line) {
            var _this = this;
            var lineId = $line.data('lineid');

            var removeArray = function () {
                _this.lines.list.remove(function (line) {
                    return line.LineId == lineId;
                });

                var $prev = $line.prev();
                if ($prev.hasClass('fa')) {
                    $prev.remove();
                }
                $line.remove();
                _this.updateStations();
            };

            var firstItem = _this.lines.list.first();
            var lastItem = _this.lines.list.last();
            if (lineId != firstItem.LineId && lineId != lastItem.LineId) {
                common.alert('为保存线路的连贯性，您只能从头尾删除线路，而不能先删除中间的线路！');
                return;
            }

            var trainNoLIneId = $line.data('trainnolineid');
            if (confirm('您确定要从本车次中移除此线路吗？')) {
                if (trainNoLIneId == 0) {
                    removeArray();
                    return;
                }

                common.ajax({
                    url: '/Line/DeleteTrainNoLine',
                    data: { id: trainNoLIneId },
                    success: function (res) {
                        if (res.code == 100) {
                            removeArray();
                            _this.save();
                        } else {
                            common.alert('删除失败，请稍后重试');
                        }
                    }
                });
            }
        },

        save: function () {
            var _this = this;
            if (_this.$parsley.validate()) {
                if (_this.lines.list.length === 0) {
                    common.alert('请选择本车次所经过的线路！');
                    return;
                }

                var trainNo = common.formJsonfiy('form');

                common.showLoading();
                common.ajax({
                    url: '/Line/SaveTrainNo',
                    data: {
                        trainNo: JSON.stringify(trainNo),
                        lines: JSON.stringify(_this.lines.list)
                    },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 100) {
                            location.href = '/Line/TrainNo';
                            return;
                        }

                        common.alert(res.msg);
                    },
                    error: function () {
                        common.hideLoading();
                        common.alert('保存失败');
                    }
                });
            }
        }
    };
})(window, jQuery);