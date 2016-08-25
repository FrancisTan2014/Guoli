(function (window, $) {
    $(function () {
        page.initComponents();

        $('#btnSave').on('click', function () {
            page.save();
        });

        $('#btnBack').on('click', function () {
            location.href = '/Line/TrainNo';
        });
    });

    window.page = (function () {
        return {
            isFirstTime: $('input[name=IsFirstTime]').val() === 'True',
            stationCount: $('input[name=StationCount]').val(),

            initComponents: function () {
                $('.pick-time:first').prop({
                    readonly: true,
                    value: '始发站'
                }).removeAttr('data-field');
                $('.pick-time:last').prop({
                    readonly: true,
                    value: '终点站'
                }).removeAttr('data-field');

                $('#dtBox').DateTimePicker();
            },

            save: function () {
                var _this = this;
                
                if (_this.inputValidate()) {

                }
            },

            inputValidate: function () {
                var $trList = $('tbody>tr');
                var trCount = $trList.length;

                $trList.each(function (i, v) {
                    
                });
            },

            getEntity: function ($tr) {
                var arrive = $(this).find('input[name=ArriveTime]').val();
                var start = $(this).find('input[name=DepartTime]').val();
            }
        };
    })();
})(window, jQuery);