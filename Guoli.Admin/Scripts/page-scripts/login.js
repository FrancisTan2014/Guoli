(function () {
    $(function () {
        page.init();

        // 登 录
        $('#btnLogin').on('click', function () {
            if (page.parsley.validate()) {
                page.login();
            }
        });

        // 绑定enter事件
        common.bindEnterEvent('input', '#btnLogin');
    });

    window.page = {
        parsley: null,
        $form: $('form'),
        backUrl: '',

        init: function () {
            var _this = this;
            _this.parsley = $('form').parsley();
            _this.backUrl = $('input[name=backUrl]').val();
        },

        getFormData: function () {
            return this.$form.serialize();
        },

        jump: function () {
            var _this = this;
            var jumpUrl = _this.backUrl;
            if (!jumpUrl) {
                jumpUrl = '/Home/Index';
            }

            window.location.href = jumpUrl;
        },

        showFailedTips: function() {
            common.tiles({
                target: '.login-btn',
                text: '用户或者密码错误'
            });
        }, 

        login: function () {
            var _this = this;
            var formData = _this.getFormData();

            common.ajax({
                url: '/Home/Login',
                data: formData,
                success: function (res) {
                    if (res.code == 102) {
                        _this.jump();
                    } else {
                        _this.showFailedTips();
                    }
                }
            });
        }
    };
})();