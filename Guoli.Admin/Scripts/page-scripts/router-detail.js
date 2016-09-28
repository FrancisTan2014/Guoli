/// <reference path="common.js" />

(function (window, $) {
    $(function() {
        $('#btnSave').on('click', function () { page.save(); });
        $('#btnBack').on('click', function () { page.back(); });

        page.initComponents();
        page.loadData();
    });

    window.page = {
        id: 0,
        $parsely: null,

        initComponents: function() {
            this.$parsely = $('form').parsley();
        },

        loadData: function() {
            var _this = this;
            _this.id = parseInt(common.getQueryParam('id'));
            if (_this.id > 0) {
                common.ajax({
                    url: '/Instructor/GetSingle',
                    data: {
                        id: _this.id,
                        target: 'InstructorRouterPosition'
                    }
                }).done(function(res) {
                    if (res.code == 108) {
                        common.fillForm('form', res.data);
                        return;
                    }

                    _this.back();
                });
            }
        },

        save: function() {
            var _this = this;
            if (_this.$parsely.validate()) {
                var json = common.formJsonfiy('form');
                common.ajax({
                    url: '/Instructor/SaveRouter',
                    data: { json: JSON.stringify(json) }
                }).done(function(res) {
                    if (res.code == 100) {
                        _this.back();
                        return;
                    }

                    common.alert(res.msg);
                });
            }
        },

        back: function() {
            location.href = '/Instructor/Router';
        }
    };
})(window, jQuery);