/// <reference path="common.js" />
/// <reference path="../plugins/bootstrap-multiselect/bootstrap-multiselect.js" />

(function (window, $) {
    $(function () {
        $('.type-label').on('click', function() {
            if ($(this).hasClass('active')) {
                return;
            }

            var value = $(this).data('value');
            $('input[name=AnnounceType]').val(value);
            console.log(value);
            $($(this).data('target')).show().siblings('.toggle-content').hide();
        });

        $('.file-upload').on('click', function () {
            var filePath = $('input[name=FilePath]').val();
            if (filePath) {
                common.alert('一条通知一次只能上传一个文件');
                return;
            }

            common.alert(
                $('.uploadify-box').show(),
                function () {
                    setTimeout(function () { $('.uploadify-box').hide(); }, 100);
                },
                '上传文件');
        });

        $('#btnSave').on('click', function() {
            page.save();
        });

        $('#btnBack').on('click', function() {
            page.back();
        });

        page.initComponents();
        page.loadData();
    });

    window.page = {
        id: 0,
        $parsley: null,
        $uploadify: null,
        
        loadData: function () {
            var _this = this;
            _this.id = parseInt(common.getQueryParam('id'));
            if (_this.id > 0) {
                common.ajax({
                    url: '/Announce/GetGingle',
                    data: { id: _this.id }
                }).done(function (res) {
                    if (res.code == 108) {
                        common.fillForm('form', res.data);
                        
                        if (res.data.AnnounceType == 1) {
                            _this.showFileName(res.data.FileName, $('.file-upload'));
                        } else {
                            $('.type-label:last').click();
                        }
                    }
                });
            }
        },

        initComponents: function () {
            var _this = this;

            _this.$uploadify = common.uploadify('#btnSelect', {
                uploader: '/Files/FileUpload',
                queueSizeLimit: 1,
                fileSizeLimit: '100MB',
                fileTypeExts: '*.doc; *.docx;',
                formData: { fileType: 5 },
                onUploadSuccess: _this.uploadSuccess
            });

            _this.$parsley = $('form').parsley();
        },

        uploadSuccess: function (file, data, response) {
            data = common.tryParseJson(data);

            $('input[name=Title]').val(data.OriginalFileName.substr(0, data.OriginalFileName.indexOf('.')));
            $('input[name=FilePath]').val(data.FileRelativePath);
            $('input[name=FileName]').val(data.OriginalFileName);

            page.showFileName(data.OriginalFileName, $('.file-upload'));
        },

        showFileName: function (fileName, $target) {
            $('<label class="text-lg mr-20 file-name">{0}</label><a class="text-lg mr-40 delete-file" href="javascript:void(0);" onclick="page.deleteFile(this);">删 除</a>'.format(fileName)).insertBefore($target);
        },
        
        deleteFile: function (dom) {
            common.confirm('您确定要删除此文件吗？', function () {
                $(dom).prev().remove();
                $(dom).remove();
                $('input[name=FilePath]').val('');
                $('input[name=FileName]').val('');
            });
        },

        back: function() {
            location.href = '/Announce/Index';
        },

        save: function() {
            var _this = this;
            
            if (_this.$parsley.validate()) {
                var json = common.formJsonfiy('form');
                
                if (json.AnnounceType == 1 && (!json.FilePath || !json.FileName)) {
                    common.alert('请上传文件');
                    return;
                }

                if (json.AnnounceType == 2 && !json.Content) {
                    common.alert('内容不能为空');
                    return;
                }

                common.ajax({
                    url: '/Announce/Save',
                    data: { json: JSON.stringify(json) }
                }).done(function (res) {
                    if (res.code == 100) {
                        _this.back();
                        return;
                    }

                    common.alert(res.msg);
                });
            }
        }
    };
})(window, jQuery);