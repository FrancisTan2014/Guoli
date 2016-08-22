(function (windiw, $) {
    $(function () {
        $('.file-upload').on('click', function () {
            page.$currentUploadBtn = $(this);
            page.currentUploadType = $(this).data('type');
            common.alert(
                $('.uploadify-box').show(),
                function () {
                    setTimeout(function () { $('.uploadify-box').hide(); }, 100);
                },
                '上传文件');
        });

        $('#btnReset').on('click', function () {
            page.resetForm();
        });

        $('#btnSave').on('click', function () {
            page.save();
        });

        // init
        var stationId = common.getQueryParam('id');
        if (stationId > 0) {
            page.stationId = stationId;
            page.initForm();
        }
        page.initComponents();
    });

    window.page = {
        $uploadify: null,
        $parsley: null,
        $currentUploadBtn: null,
        currentUploadType: 0,
        stationId: 0,

        /**
         * 上传的文件信息数组
         * { FileType: 1, StationId: 0, FileSize: 0, FileName: '', FilePath: '' }
         */
        fileArray: [],

        initForm: function () {
            var _this = this;
            common.ajax({
                url: '/Line/GetStationInfo',
                data: { stationId: _this.stationId },
                success: function (res) {
                    if (res.code == 108) {
                        var data = res.data;

                        $('input[name=StationName]').val(data.station.StationName);
                        $('input[name=SN]').val(data.station.SN);
                        $('input[name=Spell]').val(data.station.Spell);

                        _this.fileArray = data.files || [];
                        for (var i = 0; i < _this.fileArray.length; i++) {
                            var file = _this.fileArray[i];
                            var $target = $('input[data-type={0}]'.format(file.FileType));
                            _this.showFileName(file.FileName, file.FileSize, file.Id, file.FileType, $target);
                        }
                    } else {
                        common.alert(res.msg, function () {
                            location.href = '/Line/Stations';
                        });
                    }
                }
            });
        },

        initComponents: function () {
            var _this = this;
            _this.$uploadify = common.uploadify('#btnSelect', {
                uploader: '/Files/FileUpload',
                queueSizeLimit: 10,
                fileSizeLimit: '100MB',
                fileTypeExts: '',
                formData: { fileType: 1 },
                onUploadSuccess: _this.uploadSuccess
            });

            _this.$parsley = $('form').parsley();
        },

        showFileName: function (fileName, fileSize, fileId, fileType, $target) {
            var displayText = '{0} {1}KB'.format(fileName, fileSize);
            $('<label class="text-lg mr-20 file-name">{0}</label><a class="text-lg mr-40 delete-file" href="javascript:void(0);" data-id="{1}" data-filename="{2}" data-type="{3}" onclick="page.deleteFile(this);">删 除</a>'.format(displayText, fileId, fileName, fileType)).insertBefore($target);
        },

        deleteFile: function (dom) {
            common.confirm('您确定要删除此文件吗？', function() {
                var id = $(dom).data('id');
                var fileName = $(dom).data('filename');
                var fileType = $(dom).data('type');
                if (id > 0) {
                    common.ajax({
                        url: '/Line/DeleteStationFiles',
                        data: { fileId: id },
                        success: function(res) {
                            if (res.code == 100) {
                                $(dom).prev().remove();
                                $(dom).remove();

                                page.fileArray.remove(function(obj) {
                                    return obj.Id == id && obj.FileName == fileName && obj.FileType == fileType;
                                });
                            }

                            setTimeout(function() {
                                common.alert(res.msg);
                            }, 500);
                        }
                    });
                } else {
                    $(dom).prev().remove();
                    $(dom).remove();

                    page.fileArray.remove(function (obj) {
                        return obj.Id == id && obj.FileName == fileName && obj.FileType == fileType;
                    });
                }
            });
        },

        uploadSuccess: function (file, data, response) {
            data = common.tryParseJson(data);

            page.showFileName(data.OriginalFileName, data.FileSize, 0, page.currentUploadType, page.$currentUploadBtn);

            page.fileArray.push({
                FileType: page.currentUploadType,
                FileSize: data.FileSize,
                FileName: data.OriginalFileName,
                FilePath: data.FileRelativePath,
                StationId: page.stationId
            });
        },

        resetForm: function () {
            var _this = this;

            $('.file-name,.delete-file').remove();
            if (_this.stationId > 0) {
                _this.initForm();
            } else {
                $('form')[0].reset();

                var _this = this;
                _this.fileArray = [];
            }
        },

        save: function () {
            var _this = this;
            if (_this.$parsley.validate()) {
                var station = common.formJsonfiy('form');
                station.Id = _this.stationId;

                common.showLoading();
                common.ajax({
                    url: '?',
                    data: {
                        station: JSON.stringify(station),
                        files: JSON.stringify(_this.fileArray)
                    },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 100) {
                            location.href = '/Line/Stations';
                            return;
                        }

                        common.alert(res.msg);
                    }
                });
            }
        }
    };
})(window, jQuery);