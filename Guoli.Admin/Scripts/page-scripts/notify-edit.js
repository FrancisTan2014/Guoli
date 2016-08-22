(function (window, $) {
    $(function () {
        page.initComponents();

        $('#btnSave').on('click', function () {
            page.save();
        });

        $('#btnBack').on('click', function () {
            location.href = '/Exam/Notify';
        });
    });

    window.page = {
        $parsley: null,

        initComponents: function () {
            var _this = this;
            _this.$parsley = $('#examInputForm').parsley();
            $('input[name=EndTime]').datetimepicker();

            common.ajax({
                url: '/Exam/GetExamFileList'
            }).done(function (res) {
                if (res.code == 108) {
                    common.buildOptions('select[name=ExamFilesId]', {
                        data: res.data,
                        text: 'FileName',
                        value: 'Id'
                    });
                    return;
                }

                common.info(res.msg);
            });

            common.ajax({
                url: '/Common/GetPositions'
            }).done(function (res) {
                if (res.code == 108) {
                    common.buildOptions('select[name=PostId]', {
                        data: res.data,
                        text: 'PostName',
                        value: 'Id'
                    });
                    return;
                }

                common.info(res.msg);
            });
        },

        save: function () {
            var _this = this;
            if (_this.$parsley.validate()) {
                var endTime = $('input[name=EndTime]').val();
                if (!common.isValidDate(endTime)) {
                    common.alert('请输入有效的截止时间');
                    return;
                }

                var date = new Date(endTime);
                if (date < new Date()) {
                    common.alert('截止时间不能在当前时间以前');
                    return;
                }

                var json = common.formJsonfiy('#examInputForm');

                common.showLoading();
                common.ajax({
                    url: '/Exam/SaveNotify',
                    data: { json: JSON.stringify(json) }
                }).done(function (res) {
                    common.hideLoading();
                    if (res.code == 100) {
                        location.href = '/Exam/Notify';
                        return;
                    }

                    common.alert(res.msg);
                });
            }
        }
    };
})(window, jQuery);

