/// <reference path="common.js" />

(function (window, $) {
    $(function () {
        page.init();
        page.parsley = page.$input.parsley();

        $('#btnAddKeywords').on('click', function() {
            page.showKeywordsInput();
        });
    });

    window.page = {
        $input: $('#txtInput').parent(),
        parsley: null,

        init: function() {
            common.ajax({
                url: '/Files/GetKeywords',
                success: function(res) {
                    if (res.code == 108) {
                        var $tile = $('.tile-body').empty();
                        for (var i = 0; i < res.data.length; i++) {
                            $tile.append('<button class="btn btn-default btn-border mb-10 mr-10">{0}</button>'.format(res.data[i].Keywords));
                        }
                    }
                }
            });
        },

        showKeywordsInput: function() {
            var _this = this;

            _this.$input.show();
            common.showModal({
                title: '添加关键字',
                content: _this.$input,
                confirmText: '保 存',
                confirm: _this.addKeywords,
                cancel: function() {
                    _this.$input.hide();
                }
            });
        },

        addKeywords: function() {
            if (page.parsley.validate()) {
                var keywords = $('#txtInput').val().trim();
                common.ajax({
                    url: '/Files/AddKeywords',
                    data: { keywords: keywords },
                    success: function(res) {
                        if (res.code == 100) {
                            var $first = $('.tile-body>.btn:first');
                            var $keywords = $('<button class="btn btn-default btn-border mb-10 mr-10">{0}</button>'.format(keywords));

                            if ($first.length > 0) {
                                $keywords.insertBefore($first);
                            } else {
                                $('.tile-body').append($keywords);
                            }
                        }
                    }
                });

                page.$input.hide();
                return true;
            }

            return false;
        }
    };
})(window, jQuery);