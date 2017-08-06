(function (window, $) {
    $(function () {
        page.initTree();
        page.initUploadify();
        page.$parsley = $('#directoryEdit').parsley();

        $('#btnCollapseAll').on('click', function () {
            page.$tree.treeview('collapseAll');
        });

        $('#btnExpandAll').on('click', function () {
            page.$tree.treeview('expandAll');
        });

        $('#btnAddDirectory').on('click', function () {
            $('#parentName').text('无上级目录');
            $('input[name=ParentId]').val(0);
            $('input[name=TypeName]').val('');
            page.addDirectory(function () {
                location.reload();
            });
        });
    });

    window.page = {
        $tree: null,
        treeData: {},
        $parsley: null,
        currFileTypeId: 0, // 当前准备上传的文件分类id
        currNodeId: 0,
        $uploadify: null,

        initUploadify: function() {
            var _this = this;
            _this.$uploadify = common.uploadify('#uploadify', {
                swf: '/Scripts/plugins/jquery.uploadify/uploadify.swf',
                uploader: '/Files/AddFiles',
                queueSizeLimit: 10,
                fileSizeLimit: '1024MB',
                //fileTypeExts: '*.zip; *.htm; *.html; *.jpg; *.jpeg; *.png; *.gif; *.mp4; *.doc; *.docx; *.xls; *.xlsx; *.ppt; *.pptx; *.pdf;',
                formData: { fileType: 3 },
                onUploadSuccess: _this.uploadSuccess,
                onUploadStart: function () {
                    var formData = { fileType: 3, typeId: page.currFileTypeId };
                    page.$uploadify.uploadify('settings', 'formData', formData);
                }
            });
        },

        initTree: function () {
            var _this = this;
            common.ajax({
                url: '/Files/GetDirecAndFiles',
                success: function (res) {
                    if (res.code == 108) {
                        var directories = res.data.directories;
                        var files = res.data.files;

                        for (var i = 0; i < directories.length; i++) {
                            var typeId = directories[i].Id;
                            var subFiles = files.where(function (item) {
                                return item.TypeId == typeId;
                            });

                            directories[i].files = subFiles;
                        }

                        var tree = _this.buldTree(0, directories);

                        _this.$tree = $('#treeView').treeview({ data: tree });
                        _this.$tree.treeview('collapseAll');
                    }
                }
            });
        },

        getIconClass: function (ext) {
            switch (ext.toLowerCase()) {
                case 'folder':
                    return 'fa fa-folder-open';
                case '.doc':
                case '.docx':
                    return 'fa fa-file-word-o';
                case '.xls':
                case '.xlsx':
                    return 'fa fa-file-excel-o';
                case '.pdf':
                    return 'fa fa-file-pdf-o';
                case '.jpg':
                case '.jpeg':
                case '.png':
                case '.gif':
                case '.bmp':
                    return 'fa fa-file-image-o';
                default:
                    return 'icon-docs';
            }
        },

        createTreeItem: function (type, id, name, parentId) {
            var _this = this;
            var iconClass = '';
            if (type === 'file') {
                var ext = name.substr(name.indexOf('.'));
                iconClass = _this.getIconClass(ext);

                return '<i class="{0}"></i><span>{1}</span><span class="btn btn-sm ml-10" data-name="{1}" data-id="{2}" data-type="file" onclick="page.deleteItem(this);">删除</span>'.format(iconClass, name, id);
            }

            iconClass = _this.getIconClass('folder');
            return '<i class="{0}"></i><span>{1}</span><span class="btn btn-sm ml-10" data-id="{2}" onclick="page.addFiles(this);">添加文件</span><span class="btn btn-sm ml-10" data-name="{1}" data-id="{2}" data-parent="{3}" onclick="page.addItem(this);">添加子目录</span><span class="btn btn-sm ml-10" data-name="{1}" data-id="{2}" data-parent="{3}" onclick="page.deleteItem(this);">删除</span>'.format(iconClass, name, id, parentId || '');
        },

        buldTree: function (parentId, data) {
            var _this = this;
            var subArr = data.where(function (item) {
                return item.ParentId == parentId;
            });

            if (subArr.length === 0) {
                return [];
            }

            var nodes = [];
            for (var i = 0; i < subArr.length; i++) {
                var text = _this.createTreeItem('folder', subArr[i].Id, subArr[i].TypeName, subArr[i].ParentId);
                var subNodes = _this.buldTree(subArr[i].Id, data);

                var files = subArr[i].files;
                // 创建subArr[i]下的file节点
                for (var j = 0; j < files.length; j++) {
                    var fileText = _this.createTreeItem('file', files[j].Id, files[j].FileName);
                    subNodes.push({
                        text: fileText
                    });
                }

                nodes.push({
                    text: text,
                    nodes: subNodes
                });
            }

            return nodes;
        },

        addFiles: function (dom) {
            var _this = this;
            _this.currFileTypeId = $(dom).data('id');
            _this.currNodeId = $(dom).parent().data('nodeid');
            
            _this.$tree.treeview('expandNode', _this.currNodeId);

            var dirName = $(dom).data('name');
            var $fileUpload = $('#fileUpload').show();
            common.showModal({
                title: '添加文件至目录《{0}》下'.format(dirName),
                content: $fileUpload,
                confirm: function () {
                    $fileUpload.hide();
                },
                cancel: function() {
                    $fileUpload.hide();
                }
            });
        },

        uploadSuccess: function (file, res) {
            res = common.tryParseJson(res);

            var _this = page;
            var msg = res.msg;
            if (msg.code == 100) {
                var path = res.data;
                var text = _this.createTreeItem('file', res.fileId, path.OriginalFileName);
                _this.$tree.treeview('addNode', [_this.currNodeId, { node: { text: text } }]);
            } else {
                alert(msg);
            }
        },

        addDirectory: function (callback) {
            var _this = this;
            var $form = $('#directoryEdit').show();
            common.showModal({
                title: '添加目录',
                content: $form,
                confirm: function () {
                    var success = _this.saveItem(callback);
                    if (!success) {
                        return false;
                    }

                    $form.hide();
                },
                cancel: function () {
                    $form.hide();
                }
            });
        },

        addItem: function (dom) {
            var _this = this;
            var $btn = $(dom);
            var id = $btn.data('id');
            var name = $btn.data('name');
            var nodeId = $btn.parent().data('nodeid');

            var addNode = function (id, name) {
                _this.$tree.treeview('addNode', [nodeId, { node: { text: _this.createTreeItem('folder', id, name) } }]);
            };

            $('#parentName').text(name);
            $('input[name=ParentId]').val(id);

            _this.addDirectory(addNode);
        },

        deleteItem: function (dom) {
            var $btn = $(dom);
            var id = $btn.data('id');
            var name = $btn.data('name');
            var type = $btn.data('type');

            if (confirm('您确定要删除{0}吗？'.format(name))) {
                common.showLoading();

                var ajaxUrl = '/Files/DeleteDirectory';
                if (type == 'file') {
                    ajaxUrl = '/Files/DeleteFiles';
                }

                common.ajax({
                    url: ajaxUrl,
                    data: { id: id },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 100) {
                            location.reload();
                            return;
                        }

                        common.alert('存在子级，无法删除');
                    },
                    error: function () {
                        common.hideLoading();
                        common.alert('删除失败，请稍后重试。');
                    }
                });
            };
        },

        saveItem: function (callback) {
            var _this = this;
            if (_this.$parsley.validate()) {
                var directory = common.formJsonfiy('#directoryEdit');

                common.showLoading();
                common.ajax({
                    url: '/Files/AddDirectory',
                    data: { directory: JSON.stringify(directory) },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 116) {
                            callback(res.id, directory.TypeName);
                            return;
                        }

                        alert(res.msg);
                    },
                    error: function () {
                        common.hideLoading();
                    }
                });

                return true;
            }

            return false;
        }
    };
})(window, jQuery);