/// <reference path="common.js" />

; (function (window, $) {
    $(function () {
        page.loadData();
        page.initComponents();

        $('.need-review').on('click', page.needReviewChanged);

        $('#btnSave').on('click', function() {
            page.save();
        });

        $('#btnBack').on('click', function() {
            page.back();
        });
    });

    window.page = {
        $mainParsley: null,
        $subParsley: null,
        quotaId: 0,

        initComponents: function() {
            this.$mainParsley = $('#mainForm').parsley();
            this.$subParsley = $('#subForm').parsley();
        },

        loadData: function() {
            var _this = this;
            _this.quotaId = common.getQueryParam('id') || 0;
            if (_this.quotaId > 0) {
                common.ajax({
                    url: '/Instructor/',
                    data: { id: _this.quotaId, target: 'InstructorQuota' }
                }).done(function(res) {
                    if (res.code == '108') {
                        common.fillForm('#mainForm', res);

                        $('.need-review').each(function() {
                            var value = $(this).data('value');
                            if (value == res.NeedReview) {
                                $(this).addClass('active');
                            } else {
                                $(this).removeClass('active');
                            }
                        });

                        _this.needReviewChanged();

                        return;
                    }

                    _this.back();
                });
            }

        },

        /**
         * 是否参与评分选项改变时触发此方法
         */
        needReviewChanged: function () {
            // 此处this不再是page
            var value = $(this).data('value');
            $('input[name=NeedReview]').val(value);

            var $subForm = $('#subForm');
            if ((value + '') === 'true') {
                $subForm.show();
            } else {
                $subForm.hide();
            }
        },

        save: function() {
            
        },

        back: function() {
            location.href = '/Instructor/Quota';
        }
    };
})(window, jQuery);