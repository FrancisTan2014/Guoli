(function(window, $) {
    $(function () {
        page.$parsley = $('form').parsley();
        page.initUpload();

        page.id = common.getQueryParam('id');
        page.initForm();

        $('.sex').on('click', function() {
            $('input[name=Sex]').val($(this).data('value'));
        });

        $('input[name=IdentityNo]').on('keyup', function() {
            var value = $(this).val().trim();
            var date = common.matchBirthDate(value);

            $('input[name=BirthDate]').val(date);
        });

        $('#btnAddPost').on('click', function() {
            var $form = $('.post-input').show();
            common.showModal({
                title: '添加职务',
                content: $form,
                confirm: function () {
                    var $input = $('input[name=PostName]');
                    var postName = $input.val().trim();
                    if (postName.length > 0) {
                        common.ajax({
                            url: '/People/AddPostion',
                            data: { postName: postName },
                            success: function(res) {
                                if (res.code == 100) {
                                    page.initPosition($('select[name=PostId]').val());
                                    return;
                                }

                                alert(res.msg);
                            }
                        });

                        $form.hide();
                        return true;
                    }

                    return false;
                },
                cancel: function() {
                    $form.hide();
                }
            });
        });

        $('#btnSave').on('click', function() {
            page.save();
        });

        $('#btnBack').on('click', function() {
            location.href = '/People/Index';
        });
    });

    window.page = {
        id: 0,
        $parsley: null,
        $postInput: null,
        $uploadify: null,

        initForm: function() {
            var _this = this;
            if (_this.id > 0) {
                common.ajax({
                    url: '/People/GetPersonInfo',
                    data: { id: _this.id },
                    success: function (res) {
                        if (res.code == 108) {
                            common.fillForm('form', res.data);

                            $('.sex').each(function() {
                                if ($(this).data('value') == res.data.Sex) {
                                    $(this).addClass('active');
                                }
                            });

                            var birthDate = common.processDate(res.data.BirthDate);
                            $('input[name=BirthDate]').val(birthDate.format('yyyy-MM-dd'));
                            $('#photo').prop('src', res.data.PhotoPath);

                            _this.initDepart(res.data.DepartmentId);
                            _this.initPosition(res.data.PostId);
                        } else {
                            location.href = '/People/Index';
                        }
                    }
                });
            } else {
                _this.initDepart(0);
                _this.initPosition(0);
            }
        },

        initUpload: function () {
            var _this = this;
            _this.$uploadify = common.uploadify('#imgUpload', {
                uploader: '/Files/FileUpload',
                multi: false,
                queueSizeLimit: 10,
                fileSizeLimit: '100MB',
                fileTypeExts: '*.jpg; *.jpeg; *.png;',
                formData: { fileType: 2 },
                onUploadSuccess: _this.uploadSuccess
            });

            _this.$parsley = $('form').parsley();
        },

        initDepart: function (departId) {
            var _this = this;
            common.ajax({
                url: '/Common/GetDeparts',
                success: function(res) {
                    if (res.code == 108) {
                        var $select = $('select[name=DepartmentId]').empty();
                        $select.append(_this.createOption(-1, '请选择', false));

                        for (var i = 0; i < res.data.length; i++) {
                            var model = res.data[i];
                            var parent = res.data.where(function(item) {
                                return item.Id == model.ParentId;
                            });

                            var parentName = parent.length > 0 ? parent[0].DepartmentName : '';
                            var displayText = model.DepartmentName;
                            if (parentName) {
                                displayText = '{0} - {1}'.format(parentName, model.DepartmentName);
                            }

                            var option = _this.createOption(model.Id, displayText, model.Id == departId);
                            $select.append(option);
                        }
                    }
                }
            });
        },

        initPosition: function(postId) {
            var _this = this;
            common.ajax({
                url: '/Common/GetPositions',
                success: function (res) {
                    if (res.code == 108) {
                        var $select = $('select[name=PostId]').empty();
                        $select.append(_this.createOption(-1, '请选择', false));

                        for (var i = 0; i < res.data.length; i++) {
                            var model = res.data[i];
                            var option = _this.createOption(model.Id, model.PostName, model.Id == postId);
                            $select.append(option);
                        }
                    }
                }
            });
        },

        createOption: function(value, text, selected) {
            return '<option value="{0}" {1}>{2}</option>'.format(value, selected ? 'selected' : '', text);
        },

        uploadSuccess: function (file, data, response) {
            data = common.tryParseJson(data);

            $('input[name=PhotoPath]').val(data.FileRelativePath);
            $('#photo').prop('src', data.FileRelativePath);
        },

        save: function() {
            var _this = this;
            if (_this.$parsley.validate()) {
                var json = common.formJsonfiy('form');
                if (!json.Sex) {
                    common.alert('请选择性别');
                    return;
                }

                if (json.DepartmentId == -1) {
                    common.alert('请选择部门');
                    return;
                }

                if (json.PostId == -1) {
                    common.alert('请选择职务');
                    return;
                }

                if (!json.PhotoPath) {
                    common.alert('请上传照片');
                    return;
                }

                common.showLoading();
                common.ajax({
                    url: '/People/PersonEdit',
                    data: { model: JSON.stringify(json) },
                    success: function (res) {
                        common.hideLoading();

                        if (res.code == 100) {
                            location.href = '/People/Index';
                            return;
                        }

                        common.alert('保存失败，请稍后重试');
                    }
                });
            }
        }
    };
})(window, jQuery);