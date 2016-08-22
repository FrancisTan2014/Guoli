(function (window, $) {
    var goback = function() {
        var jumpUrl = $('#btnBack').prop('href');
        location.href = jumpUrl;
    };

    $(function() {
        var id = common.getQueryParam('id');
        if (!id) {
            goback();
        }

        var target = $('input[name=target]').val();
        common.ajax({
            url: '/Instructor/GetSingle',
            data: { id: id, target: target },
            success: function(res) {
                if (res.code == 108) {
                    goback();
                    return;
                }

                common.fillForm('form', res.data);
            }
        });
    });
})(window, jQuery);