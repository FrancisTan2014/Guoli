/// <reference path="../plugins/jquery.cookie/jquery.cookie.js" />
(function() {
    $(function () {
        var url = location.href;
        var indexOfParamsStart = url.indexOf('?');
        if (indexOfParamsStart === -1) {
            indexOfParamsStart = url.length - 1;
        }
        
        var $currentMenu = null;
        $('#navigation a').each(function() {
            var href = $(this).attr('href');
            var index = url.indexOf(href);
            if (index > 0 && index < indexOfParamsStart) {
                $currentMenu = $(this);
            } 
        });

        if ($currentMenu) {
            $currentMenu.parent('li').addClass('active')
                .parent('ul').css('display', 'block')
                .parent('li').addClass('active open');
        }
    });
})();