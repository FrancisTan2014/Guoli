<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Guoli.WebTest.HtmlParser.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <script>
        ; (function (window, document) {
            window.getQueryString = function (name) {
                var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
                var r = window.location.search.substr(1).match(reg);
                if (r != null) return decodeURIComponent(r[2]);
                return '';
            };

            window.onload = function () {
                var id = getQueryString('id');
                var keywords = getQueryString('keywords');
                var dom = document.getElementById(id);
                var content = dom.innerText.replace(keywords, '<font style="background: yellow;">' + keywords + '</font>');
                dom.innerHTML = content;

                window.scrollTo(0, dom.offsetTop - 20);
            };
        })(window, document);
    </script>
</body>
</html>
