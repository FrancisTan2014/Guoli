/// <reference path="common.js" />

; (function (window, $) {
    $(function () {
        page.loadData();
        page.initComponents();

        $('.need-review').on('click', page.needReviewChanged);
        $('#btnAddStandard').on('click', page.btnAddStandardClick);

        $('#btnSave').on('click', function() {
            page.save();
        });

        $('#btnBack').on('click', function() {
            page.back();
        });

        $('input[name=QuataAmmount]').on('input', function () {
            page.quota = $(this).val();
        });
    });

    window.page = {
        $mainParsley: null,
        $subParsley: null,
        quotaId: 0,
        standardInputExists: false,
        quota: 0,

        /**
         * { Id: 主键, ConditionAmmount: 达标条件， ExtraScore: 加/扣分 }
         */
        standard: [],

        initComponents: function() {
            this.$mainParsley = $('#mainForm').parsley();
            this.$subParsley = $('#subForm').parsley();
        },

        loadData: function() {
            var _this = this;
            _this.quotaId = common.getQueryParam('id') || 0;
            if (_this.quotaId > 0) {
                common.ajax({
                    url: '/Instructor/GetSingle',
                    data: { id: _this.quotaId, target: 'InstructorQuota' }
                }).done(function(res) {
                    if (res.code == '108') {
                        common.fillForm('#mainForm', res.data);
                        common.fillForm('#subForm', res.data);

                        _this.quota = res.data.QuataAmmount;
                        $('.need-review').each(function() {
                            var value = $(this).data('value');
                            if (value == res.data.NeedReview) {
                                $(this).addClass('active');
                            } else {
                                $(this).removeClass('active');
                            }
                        });

                        if ((res.data.NeedReview + '') === 'true') {
                            $('#subForm').show();
                        } else {
                            $('#subForm').hide();
                        }

                        return;
                    }

                    _this.back();
                });

                common.ajax({
                    url: '/Instructor/GetStandardList',
                    data: { quotaId: _this.quotaId }
                }).done(function(res) {
                    if (res.code == 108) {
                        _this.standard = res.data;
                        for (var i = 0; i < _this.standard.length; i++) {
                            _this.createStandardItem(i);
                        }
                    }
                });
            }

        },

        /**
         * 是否参与评分选项改变时触发此方法
         */
        needReviewChanged: function () {
            // 此处this不再是page
            var value = $(this).data('value');
            $('input[name=NeedReview]').val(value);

            var $subForm = $('#subForm');
            if ((value + '') === 'true') {
                $subForm.show();
            } else {
                $subForm.hide();
            }
        },

        btnAddStandardClick: function () {
            if (page.standardInputExists) {
                return;
            }

            if (page.$mainParsley.validate() && page.$subParsley.validate()) {
                page.createStandardInput();
                $('input[name=QuataAmmount]').attr('disabled', true);
            }
        },

        btnConfirmStandardClick: function() {
            if (page.$subParsley.validate()) {
                var finish = parseInt($('#finishAmmount').val());
                var extra = Math.abs(parseInt($('#extraScore').val()));
                extra = finish >= (page.quota - 0) ? extra : extra - 2 * extra;

                page.standard.push({
                    Id: 0,
                    ConditionAmmount: finish,
                    ExtraScore: extra
                });

                page.createStandardItem(page.standard.length - 1);
                page.removeStandardInput();
            }
        },

        btnCancelStandardClick: function() {
            page.removeStandardInput();
        },

        removeStandardInput: function() {
            $('#standardInput').remove();
            page.standardInputExists = false;
            $('input[name=QuataAmmount]').attr('disabled', false);
        },

        createStandardInput: function() {
            $('<div id="standardInput" class="col-sm-offset-2 col-sm-10"><div class="row"><div class="col-sm-4"><input type="text" id="finishAmmount" class="form-control" placeholder="完成量" required data-parsley-required-message="完成量不能为空" data-parsley-type="number" data-parsley-type-message="请输入有效的数值" data-parsley-min="0" data-parsley-min-message="请输入有效的数值"/></div><div class="col-sm-4"><input type="text" id="extraScore" class="form-control" placeholder="加/扣分数" required data-parsley-required-message="加/扣分数不能为空" data-parsley-type="number" data-parsley-type-message="请输入有效的数值"/></div><div class="col-sm-4 btn-group"><div class="btn btn-info" id="btnConfirmStandard">确 定</div><div class="btn btn-default" id="btnCancelStandard">取 消</div></div></div></div>').insertBefore('#standardDescription');

            page.standardInputExists = true;
            $('#btnConfirmStandard').on('click', page.btnConfirmStandardClick);
            $('#btnCancelStandard').on('click', page.btnCancelStandardClick);
        },

        createStandardItem: function(index) {
            var _this = this;
            var standard = _this.standard[index];
            if (standard) {
                var score = Math.abs(standard.ExtraScore);
                var desc = standard.ConditionAmmount < _this.quota ? '未满' : '达到';
                var operate = standard.ExtraScore >= 0 ? '加' : '扣';
                var displayText = '{0}{1}{2}{3}分'.format(desc, standard.ConditionAmmount, operate, score);

                var $item = $('<div class="btn btn-lightred btn-ef btn-ef-5 btn-ef-5b mb-10 mr-10 standard-item" data-index="{0}"><i class="fa fa-trash"></i><span>{1}</span></div>'.format(index, displayText));
                $item.on('click', function () {
                    common.confirm('您确定要删除此评分标准吗？', function() {
                        _this.deleteStandard(index);
                    });
                });

                $item.insertBefore('#btnAddStandard');
            }
        },

        deleteStandard: function (index) {
            var _this = this;
            var deleteItem = function() {
                _this.standard.splice(index, 1);
                $('.standard-item').each(function() {
                    if ($(this).data('index') == index) {
                        $(this).remove();
                    };
                });
            };
            
            var standard = _this.standard[index];
            if (standard.Id > 0) {
                common.ajax({
                    url: '/Instructor/DeleteStandard',
                    data: { id: standard.Id }
                }).done(function(res) {
                    if (res.code == 100) {
                        deleteItem();
                        return;
                    }

                    common.alert(res.msg);
                });
            } else {
                deleteItem();
            }
        },

        save: function() {
            var _this = this;
            if (_this.$mainParsley.validate() && _this.$subParsley.validate()) {
                var main = common.formJsonfiy('#mainForm');
                var sub = common.formJsonfiy('#subForm');

                var json = $.extend({}, main, sub);
                if (json.NeedReview && _this.standard.length === 0) {
                    common.alert('此项指标若要参与评分，您至少需要添加一项评分标准！');
                    return;
                }

                common.ajax({
                    url: '/Instructor/SaveQuota',
                    data: {
                        quota: JSON.stringify(json),
                        standard: JSON.stringify(_this.standard)
                    }
                }).done(function(res) {
                    if (res.code == 100) {
                        _this.back();
                        return;
                    }

                    common.alert(res.msg);
                });
            }
        },

        back: function() {
            location.href = '/Instructor/Quota';
        }
    };
})(window, jQuery);