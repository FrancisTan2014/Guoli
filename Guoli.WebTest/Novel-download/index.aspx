<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Guoli.WebTest.Novel_download.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>武神天下</title>
    <style>
        body {
            padding: 0;
            margin: 0;
            font-family: "Lucida Grande", "Microsoft JhengHei", "Microsoft YaHei";
            color: #333;
            background: #f5f5d5;
        }

        #chapters {
            width: 95%;
            margin: 0 auto;
        }

        article {
            text-align: left;
            padding: 20px 0;
            border-bottom: 1px solid #999;
        }

            article div {
                font-size: 1em;
                text-align:justify;
                text-justify: inter-word;
            }

            article h1 {
                text-align: center;
                color: #333;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="chapters">
        </div>
    </form>

    <script src="/js/jquery-1.9.1.min.js"></script>
    <script>
        var nextChapter = function (url, callback) {
            $.ajax({
                url: '?',
                type: 'POST',
                dataType: 'json',
                data: { novelUrl: url }
            }).done(function (data) {
                var article = '<article>' + data.Title + data.Content + '</article>'
                $('#chapters').append(article);
            }).done(function (data) {
                if (data.NextChapter) {
                    setTimeout(function () {
                        nextChapter(data.NextChapter);
                    }, 30 * 1000);
                }
            });
        };

        $(function () {
            nextChapter('http://www.biquge.tw/3_3258/4491335.html');
        });
    </script>
</body>
</html>
