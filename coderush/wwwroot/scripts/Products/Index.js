$(function () {
var dataManager = ej.DataManager({
    url: "/api/Products",
    adaptor: new ej.WebApiAdaptor(),
    offline: true
});

var dataManagerBrand = ej.DataManager({
    url: "/api/Brands",
    adaptor: new ej.WebApiAdaptor()
});

var dataManagerCategory = ej.DataManager({
    url: "/api/Categories",
        adaptor: new ej.WebApiAdaptor()
});

dataManager.ready.done(function (e) {
    $("#Grid").ejGrid({
        dataSource: ej.DataManager({
            json: e.result,
            adaptor: new ej.remoteSaveAdaptor(),
            insertUrl: "/api/Products/Insert",
            updateUrl: "/api/Products/Update",
            removeUrl: "/api/Products/Remove",
        }),
        toolbarSettings: {
            showToolbar: true,
            toolbarItems: ["add", "edit", "delete", "update", "cancel", "search", "printGrid"]
        },
        editSettings: {
            allowEditing: true,
            allowAdding: true,
            allowDeleting: true,
            showDeleteConfirmDialog: true,
            editMode: "dialog"
        },
        isResponsive: true,
        enableResponsiveRow: true,
        allowSorting: true,
        allowSearching: true,
        allowFiltering: true,
        filterSettings: {
            filterType: "excel",
            maxFilterChoices: 100,
            enableCaseSensitivity: false
        },
        allowPaging: true,
        pageSettings: { pageSize: 10, printMode: ej.Grid.PrintMode.CurrentPage },
        columns: [
            { field: "Id", headerText: 'Id', isPrimaryKey: true, isIdentity: true, visible: false },
            { field: "BrandId", headerText: 'Marca', foreignKeyField: "BrandId", foreignKeyValue: "BrandName", dataSource: dataManagerBrand, validationRules: { required: true } },
            { field: "CategoryId", headerText: 'Categoria', foreignKeyField: "CategoryId", foreignKeyValue: "CategoryName", dataSource: dataManagerCategory, validationRules: { required: true } },
            { field: "ProductName", headerText: 'Nombre', validationRules: { required: true } },
            { field: "ModelYear", headerText: 'Modelo', defaultValue: 0, editType: "numericedit", format: "{0:n2}" },
            { field: "ListPrice", headerText: 'Precio', defaultValue: 0, editType: "numericedit", format: "{0:n2}" },
        ],
        actionComplete: "complete",
    });
});


});
function complete(args) {
    if (args.requestType == 'beginedit') {
        $("#" + this._id + "_dialogEdit").ejDialog({ title: "Edit Record" });
    }
}
