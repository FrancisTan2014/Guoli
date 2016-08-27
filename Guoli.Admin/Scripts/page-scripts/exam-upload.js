(function () {
    $(function () {
        page.initComponents();

        $('#btnAdd').on('click', function () {
            page.showAddTypeBox();
        });

        $('#btnShowUpload').on('click', function () {
            page.showUploadify();
        });

        $('#btnSave').on('click', function () {
            page.saveExam();
        });

        $('#btnBack').on('click', function () {
            location.href = '/Exam/Files';
        });
    });

    window.page = {
        $dropList: $('select[name=ExamTypeId]'),
        defaultTypeId: 0,
        $addTypeParsley: null,
        $formParsley: null,
        $uploadify: null,

        initComponents: function () {
            var _this = this;
            _this.$addTypeParsley = $('#addTypeBox').parsley();
            _this.$formParsley = $('#examInputForm').parsley();

            _this.$uploadify = common.uploadify('#uploadify', {
                uploader: '/Files/FileUpload',
                queueSizeLimit: 1,
                fileSizeLimit: '100MB',
                multi: false,
                fileTypeExts: '*.xls; *.xlsx;',
                formData: { fileType: 4 },
                onUploadSuccess: _this.uploadSuccess
            });

            _this.getDropData();
        },

        getDropData: function () {
            var _this = this;
            common.ajax({
                url: '/Exam/GetTypeList'
            }).done(function (res) {
                if (res.code == 108) {
                    _this.buildDropList(res.data);
                }
            }).done(function (res) {
                if (res.code != 108) {
                    common.alert(res.msg);
                }
            });
        },

        buildDropList: function (data) {
            for (var i = 0; i < data.length; i++) {
                var selected = data[i].Id == this.defaultTypeId;
                this.addOption(data[i].Id, data[i].TypeName, selected);
            }
        },

        addOption: function (value, text, selected) {
            var selectedAttr = selected ? ' selected="selected"' : '';
            var innerHtml = '<option value="{0}" {1}>{2}</option>'.format(value, selectedAttr, text);

            this.$dropList.append(innerHtml);
        },

        showAddTypeBox: function () {
            var _this = this;
            var $addBox = $('#addTypeBox').show();
            common.showModal({
                title: '添加分类',
                content: $addBox,
                confirm: function () {
                    if (_this.saveType()) {
                        $addBox.hide();
                        return true;
                    }

                    return false;
                },
                cancel: function () {
                    $addBox.hide();
                }
            });
        },

        saveType: function () {
            var _this = this;
            if (_this.$addTypeParsley.validate()) {
                var name = $('input[name=typeName]').val();
                common.ajax({
                    url: '/Exam/AddExamType',
                    data: { name: name }
                }).then(function (res) {
                    if (res.code == 108) {
                        var id = res.data;
                        _this.addOption(id, name);
                        return;
                    }

                    alert(res.msg);
                });

                return true;
            }

            return false;
        },

        showUploadify: function () {
            common.alert(
                $('#uploadBox').show(),
                function () {
                    setTimeout(function () { $('#uploadBox').hide(); }, 100);
                },
                '上传文件');
        },

        uploadSuccess: function (file, data, response) {
            data = common.tryParseJson(data);

            if (data.code) {
                alert(data.msg);
                return;
            }

            var examName = data.OriginalFileName.replace(data.FileExtension, '');
            $('input[name=FileName]').val(examName);
            $('input[name=FilePath]').val(data.FileRelativePath);

            $('.file-name').remove();
            page.showFileName(data.OriginalFileName, data.FileSize, $('#btnShowUpload'))
        },

        showFileName: function (fileName, fileSize, $target) {
            var displayText = '{0} {1}KB'.format(fileName, fileSize);
            $('<label class="text-lg mr-20 file-name">{0}</label>'.format(displayText)).insertBefore($target);
        },

        saveExam: function () {
            var _this = this;
            var filePath = $('input[name=FilePath]').val();
            if (!filePath) {
                common.alert('请上传题库文件');
                return;
            }

            if (_this.$formParsley.validate()) {
                var json = common.formJsonfiy('#examInputForm');

                common.showLoading();
                common.ajax({
                    url: '/Exam/Upload',
                    data: { data: JSON.stringify(json) }
                }).done(function () {
                    common.hideLoading();
                }).done(function (res) {
                    if (res.code == 100) {
                        common.alert('上传成功');
                        location.href = '/Exam/Files';
                    } else {
                        common.alert('上传失败，请严格按照模板的格式上传文件');
                    }
                });
            }
        }
    };
})(window, jQuery);