(function (window, $) {
    $(function () {
        page.initTree();
        page.$parsley = $('#departEdit').parsley();

        $('#btnCollapseAll').on('click', function () {
            page.$tree.treeview('collapseAll');
        });

        $('#btnExpandAll').on('click', function () {
            page.$tree.treeview('expandAll');
        });
    });

    window.page = {
        $tree: null,
        treeData: {},
        $parsley: null,

        initTree: function () {
            var _this = this;
            common.ajax({
                url: '/Common/GetDeparts',
                success: function (res) {
                    if (res.code == 108) {
                        var data = res.data;
                        var tree = _this.buldTree(0, data);

                        _this.$tree = $('#treeView').treeview({ data: tree });
                        _this.$tree.treeview('expandAll');
                    }
                }
            });
        },

        createTreeItem: function (departId, parentId, name) {
            return '<span>{0}</span><span class="btn btn-sm ml-10" data-name="{0}" data-id="{1}" data-parent="{2}" onclick="page.addDepart(this);">添加子级</span><span class="btn btn-sm ml-10" data-name="{0}" data-id="{1}" data-parent="{2}" onclick="page.deleteDepart(this);">删除</span>'.format(name, departId, parentId);
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
                var text = _this.createTreeItem(subArr[i].Id, subArr[i].ParentId, subArr[i].DepartmentName);
                var subNodes = _this.buldTree(subArr[i].Id, data);
                nodes.push({
                    text: text,
                    nodes: subNodes
                });
            }

            return nodes;
        },

        addDepart: function (dom) {
            var _this = this;
            var $btn = $(dom);
            var id = $btn.data('id');
            var name = $btn.data('name');
            var nodeId = $btn.parent().data('nodeid');

            var addNode = function (departId, departName) {
                _this.$tree.treeview('addNode', [nodeId, { node: { text: _this.createTreeItem(departId, id, departName) } }]);
            };

            $('#parentName').text(name);
            $('input[name=ParentId]').val(id);

            var $form = $('#departEdit').show();
            common.showModal({
                title: '添加部门',
                content: $form,
                confirm: function () {
                    var success = _this.saveDepart(addNode);
                    if (!success) {
                        return false;
                    }

                    $form.hide();
                },
                cancel: function() {
                    $form.hide();
                }
            });
        },

        deleteDepart: function (dom) {
            var $btn = $(dom);
            var id = $btn.data('id');
            var parentId = $btn.data('parent');
            var name = $btn.data('name');

            if (parentId == 0) {
                common.alert('您不能删除铁路局节点！');
                return;
            }

            if(confirm('您确定要删除{0}吗？'.format(name))) {
                common.showLoading();
                common.ajax({
                    url: '/People/DeleteDepart',
                    data: { id: id },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 100) {
                            location.reload();
                            return;
                        }

                        common.alert(res.msg);
                    },
                    error: function () {
                        common.hideLoading();
                        common.alert('删除失败，请稍后重试。');
                    }
                });
            };
        },

        saveDepart: function (callback) {
            var _this = this;
            if (_this.$parsley.validate()) {
                var depart = common.formJsonfiy('#departEdit');

                common.showLoading();
                common.ajax({
                    url: '/People/AddDepart',
                    data: { depart: JSON.stringify(depart) },
                    success: function (res) {
                        common.hideLoading();
                        if (res.code == 116) {
                            callback(res.id, depart.DepartmentName);
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