$(function () {
var dataManager = ej.DataManager({
    url: "/api/OrderItems",
    adaptor: new ej.WebApiAdaptor(),
    offline: true
});

var dataManagerCustomers = ej.DataManager({
    url: "/api/Products",
    adaptor: new ej.WebApiAdaptor()
});

var dataManagerStore = ej.DataManager({
    url: "/api/Orders",
        adaptor: new ej.WebApiAdaptor()
});



dataManager.ready.done(function (e) {
    $("#Grid").ejGrid({
        dataSource: ej.DataManager({
            json: e.result,
            adaptor: new ej.remoteSaveAdaptor(),
            insertUrl: "/api/OrderItems/Insert",
            updateUrl: "/api/OrderItems/Update",
            removeUrl: "/api/OrderItems/Remove",
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
            { field: "ItemId", headerText: 'Id', isPrimaryKey: true, isIdentity: true, visible: false },
            { field: "OrderId", headerText: 'Orden', foreignKeyField: "OrderId", foreignKeyValue: "OrderId", dataSource: dataManagerStore, validationRules: { required: true } },
            { field: "ProductId", headerText: 'Procto', foreignKeyField: "ProductId", foreignKeyValue: "ProductName", dataSource: dataManagerCustomers, validationRules: { required: true } },
            { field: "Quantity", headerText: 'Cantidad', defaultValue: 0, editType: "numericedit", format: "{0:n2}" },
            { field: "ListPrice", headerText: 'Precio', defaultValue: 0, editType: "numericedit", format: "{0:n2}" },
            { field: "Discount", headerText: 'Descuento', defaultValue: 0, editType: "numericedit", format: "{0:n2}" },

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
