var TrainMoment = (function () {
    function TrainMoment() {
    }
    return TrainMoment;
}());

var ValidateResult = (function () {
    function ValidateResult(isValid, msg, element) {
        this.isValid = isValid;
        this.msg = msg;
        this.element = element;
    }
    return ValidateResult;
}());

var Page = (function () {
    function Page() {
        this.isFirstTime = $('input[name=IsFirstTime]').val() === 'True';
        this.stationCount = $('input[name=StationCount]').val();
        this.errorClassName = 'error-tr';
    }

    Page.prototype.initComponents = function () {
        $('.pick-time:first').prop({
            readonly: true,
            value: '始发站'
        }).removeAttr('data-field');
        $('.pick-time:last').prop({
            readonly: true,
            value: '终点站'
        }).removeAttr('data-field');
        $('#dtBox').DateTimePicker();
    };

    Page.prototype.save = function () {
        var _this = this;
        $('.' + _this.errorClassName).removeClass(_this.errorClassName);
        var validateRes = _this.inputValidate();
        if (validateRes.isValid) {
            var inputData = _this.getInputData();
            var postData = _this.dataFilter(inputData);
            _this.submit(postData);
        }
        else {
            common.alert(validateRes.msg);
            $(validateRes.element).addClass(_this.errorClassName);
        }
    };

    Page.prototype.submit = function (data) {
        var json = JSON.stringify(data);
        common.ajax({
            url: '/Line/Save',
            data: { json: json }
        }).done(function (res) {
            common.alert(res.msg);
            if (res.code == 100) {
                location.href = '/Line/TrainNo';
            }
        });
    };

    Page.prototype.inputValidate = function () {
        var _this = this;
        var $trList = $('.train-moment');
        var trCount = $trList.length;
        var isValid = true;
        var msg = '';
        var element = null;
        $trList.each(function (i, v) {
            element = this;
            var model = _this.buildEntity($(this));
            if (i === 0) {
                if (!model.DepartTime) {
                    isValid = false;
                    msg = '起点站的出发时间不能为空';
                    return false;
                }
            }
            else if (i === trCount - 1) {
                if (!model.ArriveTime) {
                    isValid = false;
                    msg = '终点站的到达时间不能为空';
                    return false;
                }
            }
            else {
                var isNotTheSameStatus = (model.ArriveTime === '' && model.DepartTime !== '') || (model.ArriveTime !== '' && model.DepartTime === '');
                if (isNotTheSameStatus) {
                    isValid = false;
                    msg = '非起始或终点站的到达/出发时间要么同时有值，要么同时为空，请重新输入';
                    return false;
                }
            }
            var kms = parseFloat(model.IntervalKms);
            if (model.IntervalKms && (isNaN(kms) || kms < 0)) {
                isValid = false;
                msg = '您输出的区间公里不是有效的值';
                return false;
            }
            var speed = parseFloat(model.SuggestSpeed);
            if (model.SuggestSpeed && (isNaN(speed) || speed < 0)) {
                isValid = false;
                msg = '您输入的建议车速不是有效的值';
                return false;
            }
        });
        return new ValidateResult(isValid, msg, element);
    };

    Page.prototype.getInputData = function () {
        var _this = this;
        var $trList = $('.train-moment');
        var array = new Array();
        $trList.each(function (i, v) {
            var entity = _this.buildEntity($(v));
            array.push(entity);
        });
        return array;
    };

    Page.prototype.dataFilter = function (data) {
        var postData;
        if (!this.isFirstTime) {
            postData = new Array();
            data.forEach(function (value, index) {
                if (value.Updated) {
                    postData.push(value);
                }
            });
        }
        else {
            postData = data;
        }
        return postData;
    };

    Page.prototype.buildEntity = function ($tr) {
        var model = new TrainMoment();
        model.Id = $tr.find('input[name=Id]').val();
        model.TrainNoLineId = $tr.find('input[name=TrainNoLineId]').val();
        model.TrainStationId = $tr.find('input[name=TrainStationId]').val();
        model.StopMinutes = $tr.find('input[name=StopMinutes]').val();
        model.IntervalKms = $tr.find('input[name=IntervalKms]').val();
        model.SuggestSpeed = $tr.find('input[name=SuggestSpeed]').val();
        model.Sort = $tr.find('input[name=Sort]').val();
        model.ArriveTime = $tr.find('input[name=ArriveTime]').val();
        model.DepartTime = $tr.find('input[name=DepartTime]').val();

        var orignalArrive = $tr.find('input[name=ArriveTime]').data('orignal');
        var orignalDepart = $tr.find('input[name=DepartTime]').data('orignal');
        var orignalInter = $tr.find('input[name=IntervalKms]').data('orignal');
        var orignalSpeed = $tr.find('input[name=SuggestSpeed]').data('orignal');
        model.Updated =
            orignalArrive != model.ArriveTime ||
                orignalDepart != model.DepartTime ||
                orignalInter != model.IntervalKms ||
                orignalSpeed != model.SuggestSpeed;
        return model;
    };
    return Page;
}());

(function (window, $) {
    $(function () {
        var page = new Page();
        page.initComponents();
        $('#btnSave').on('click', function () {
            page.save();
        });
        $('#btnBack').on('click', function () {
            location.href = '/Line/TrainNo';
        });
    });
})(window, jQuery);
