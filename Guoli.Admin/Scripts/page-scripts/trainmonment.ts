import '../typings/jquery/jquery'

export class TrainMoment {
    public Id: number;
    public TrainNoLineId: number;
    public TrainStationId: number;
    public ArriveTime: string;
    public DepartTime: string;
    public StopMinutes: number;
    public IntervalKms: any;
    public SuggestSpeed: any;
    public Sort: number;
    public Updated: boolean;
}

export class ValidateResult {
    constructor(public isValid: boolean, public msg: string, public element: any) { }
}

export class Page {
    isFirstTime: boolean = $('input[name=IsFirstTime]').val() === 'True';
    stationCount: number = $('input[name=StationCount]').val();
    errorClassName: string = 'error-tr';
     
    initComponents() {
        $('.pick-time:first').prop({
            readonly: true,
            value: '始发站'
        }).removeAttr('data-field');
        $('.pick-time:last').prop({
            readonly: true,
            value: '终点站'
        }).removeAttr('data-field');

        $('#dtBox').DateTimePicker();
    }

    save() {
        let _this = this;
        $('.' + _this.errorClassName).removeClass(_this.errorClassName);
        
        let validateRes = _this.inputValidate();
        if (validateRes.isValid) {
            let inputData = _this.getInputData();
            let postData = _this.dataFilter(inputData);
        } else {
            common.alert(validateRes.msg);
            $(validateRes.element).addClass(_this.errorClassName);
        }
    }

    inputValidate() {
        let _this = this;
        let $trList = $('.train-moment');
        let trCount = $trList.length;

        let isValid = true;
        let msg = '';
        let element = null;
        $trList.each(function (i, v) {
            element = this;

            let model = _this.buildEntity($(this));

            if (i === 0) {
                if (!model.DepartTime) {
                    isValid = false;
                    msg = '起点站的出发时间不能为空';
                    return false;
                }
            } else if (i === trCount - 1) {
                if (!model.ArriveTime) {
                    isValid = false;
                    msg = '终点站的到达时间不能为空';
                    return false;
                }
            } else {
                let isNotTheSameStatus = (model.ArriveTime === '' && model.DepartTime !== '') || (model.ArriveTime !== '' && model.DepartTime === '');
                if (isNotTheSameStatus) {
                    isValid = false;
                    msg = '非起始或终点站的到达/出发时间要么同时有值，要么同时为空，请重新输入';
                    return false;
                }
            }

            let kms = parseFloat(model.IntervalKms);
            if (model.IntervalKms && (isNaN(kms) || kms < 0)) {
                isValid = false;
                msg = '您输出的区间公里不是有效的值';
                return false;
            }

            let speed = parseFloat(model.SuggestSpeed);
            if (model.SuggestSpeed && (isNaN(speed) || speed < 0)) {
                isValid = false;
                msg = '您输入的建议车速不是有效的值';
                return false;
            }
        });

        return new ValidateResult(isValid, msg, element);
    }

    getInputData() {
        let _this = this;
        let $trList = $('.train-moment');

        let array = new Array<TrainMoment>();
        $trList.each((i, v) => {
            let entity = _this.buildEntity($(v));
            array.push(entity);
        });

        return array;
    }

    dataFilter(data: TrainMoment[]) {
        let postData: TrainMoment[];
        if (!this.isFirstTime) {
            postData = new Array<TrainMoment>();
            data.forEach((value, index) => {
                if (value.Updated) {
                    postData.push(value);
                }
            });
        } else {
            postData = data;
        }

        return postData;
    }

    buildEntity($tr: JQuery) {
        let model = new TrainMoment();
        model.Id = $tr.find('input[name=Id]').val();
        model.TrainNoLineId = $tr.find('input[name=TrainNoLineId]').val();
        model.TrainStationId = $tr.find('input[name=TrainStationId]').val();
        model.StopMinutes = $tr.find('input[name=StopMinutes]').val();
        model.IntervalKms = $tr.find('input[name=IntervalKms]').val();
        model.SuggestSpeed = $tr.find('input[name=SuggestSpeed]').val();
        model.Sort = $tr.find('input[name=Sort]').val();
        model.ArriveTime = $tr.find('input[name=ArriveTime]').val();
        model.DepartTime = $tr.find('input[name=DepartTime]').val();

        let orignalArrive = $tr.find('input[name=ArriveTime]').data('orignal');
        let orignalDepart = $tr.find('input[name=DepartTime]').data('orignal');
        let orignalInter = $tr.find('input[name=IntervalKms]').data('orignal');
        let orignalSpeed = $tr.find('input[name=SuggestSpeed]').data('orignal');

        model.Updated =
            orignalArrive != model.ArriveTime ||
            orignalDepart != model.DepartTime ||
            orignalInter != model.IntervalKms ||
            orignalSpeed != model.SuggestSpeed;

        return model;
    }
}

(function (window, $) {
    $(function () {
        let page = new Page();

        page.initComponents();

        $('#btnSave').on('click', function () {
            page.save();
        });

        $('#btnBack').on('click', function () {
            location.href = '/Line/TrainNo';
        });
    });
})(window, jQuery);