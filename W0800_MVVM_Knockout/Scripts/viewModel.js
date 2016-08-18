function ViewModel(options) {
    var self = this;

    //标题、数据集、弹出对话框和内容（HTML）
    self.title          = ko.observable(options.title);
    self.recordSet      = ko.observableArray();
    self.dialogContent  = ko.observable();
    self.dialog         = options.dialogId ? $("#" + options.dialogId) : $("#dialog");

    //排序
    //orderBy，defaultOrderBy & isAsc: 当前排序字段名，默认排序字段名和方向（升序/降序）
    //totalPages， pageNumbers & pageIndex：总页数，页码列表和当前页
    self.orderBy        = ko.observable();
    self.isAsc          = ko.observable();
    self.defaultOrderBy = options.defaultOrderBy;

    //分页
    //totalPages， pageNumbers & pageIndex：总页数，页码列表和当前页
    self.totalPages     = ko.observable();
    self.pageNumbers    = ko.observableArray();
    self.pageIndex      = ko.observable();

    //查询条件：标签和输入值
    self.searchCriteria = ko.observableArray(options.searchCriteria);

    //作为显示数据的表格的头部：显示文字和对应的字段名（辅助排序）
    self.headers = ko.observableArray(options.headers);

    //CRUD均通过ajax调用实现，这里提供用于获取ajax请求地址的方法
    self.dataQueryUrlAccessor   = options.dataQueryUrlAccessor;
    self.dataAddUrlAccessor     = options.dataAddUrlAccessor;
    self.dataUpdateAccessor     = options.dataUpdateAccessor;
    self.dataDeleteAccessor     = options.dataDeleteAccessor;

    //removeData：删除操作完成后将数据从recordSet中移除
    //replaceData：修改操作后更新recordSet中相应记录
    self.removeData     = options.removeData;
    self.replaceData    = options.replaceData;

    //Search按钮
    self.search = function () {
        self.orderBy(self.defaultOrderBy);
        self.isAsc(true);
        self.pageIndex(1);
        $.ajax(
        {
            url: self.dataQueryUrlAccessor(self),
            type: "GET",
            cache: false,
            success: function (result) {
                // debugger;
                self.recordSet(result.Data);
                self.totalPages(result.TotalPages);
                self.resetPageNumbders();
            }
        });
    };

    //Reset按钮
    self.reset = function () {
        for (var i = 0; i < self.searchCriteria().length; i++) {
            self.searchCriteria()[i].value("");
        }
    };

    //获取数据之后根据记录数重置页码
    self.resetPageNumbders = function () {
        self.pageNumbers.removeAll();
        for (var i = 1; i <= self.totalPages(); i++) {
            self.pageNumbers.push(i);
        }
    };

    //点击表格头部进行排序
    self.sort = function (header) {
        if (self.orderBy() == header.value) {
            self.isAsc(!self.isAsc());
        }
        self.orderBy(header.value);
        self.pageIndex(1);
        $.ajax(
        {
            url: self.dataQueryUrlAccessor(self),
            type: "GET",
            cache: false,
            success: function (result) {
                self.recordSet(result.Data);
            }
        });
    };

    //点击页码获取当前页数据
    self.turnPage = function (pageIndex) {
        self.pageIndex(pageIndex);
        $.ajax(
        {
            url: self.dataQueryUrlAccessor(self),
            type: "GET",
            cache: false,
            success: function (result) {
                self.recordSet(result.Data);
            }
        });
    };

    //点击Add按钮弹出“添加数据”对话框
    self.onDataAdding = function () {
        $.ajax(
        {
            url: self.dataAddUrlAccessor(self),
            type: "GET",
            cache: false,
            success: function (result) {
                // debugger;
                self.dialogContent(result);
                self.dialog.modal("show");
            }
        });
    };

    //点击“添加数据”对话框的Save按钮关闭对话框，并将添加的记录插入recordSet
    self.onDataAdded = function (data) {
        self.dialog.modal("hide");
        self.recordSet.unshift(data);
    };

    //点击Update按钮弹出“修改数据”对话框
    self.onDataUpdating = function (data) {
        $.ajax(
        {
            url: self.dataUpdateAccessor(data, self),
            type: "GET",
            cache: false,
            success: function (result) {
                self.dialogContent(result);
                self.dialog.modal("show");
            }
        });
    };

    //点击“修改数据”对话框的Save按钮关闭对话框，并修改recordSet中的数据
    self.onDataUpdated = function (data) {
        self.dialog.modal("hide");
        self.replaceData(data, self);
    };

    //点击Delete按钮删除当前记录
    self.onDataDeleting = function (data) {
        $.ajax(
        {
            url: self.dataDeleteAccessor(data, self),
            type: "GET",
            cache: false,
            success: function (result) {
                self.removeData(result, self);
            }
        });
    };
}