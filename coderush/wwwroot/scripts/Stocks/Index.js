$(function () {

var dataManager = ej.DataManager({
    url: "/api/Stocks",
    adaptor: new ej.WebApiAdaptor(),
    offline: true
});
var dataManagerProducts = ej.DataManager({
    url: "/api/Products",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });
var dataManageStores = ej.DataManager({
    url: "/api/Stores",
        adaptor: new ej.WebApiAdaptor(),
        offline: true
    });
dataManager.ready.done(function (e) {
    $("#Grid").ejGrid({
        dataSource: ej.DataManager({
            json: e.result,
            adaptor: new ej.remoteSaveAdaptor(),
            insertUrl: "/api/Stocks/Insert",
            updateUrl: "/api/Stocks/Update",
            removeUrl: "/api/Stocks/Remove",
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
            
            { field: "StoreId", headerText: 'Almacen', foreignKeyField: "StoreId", foreignKeyValue: "StoreName", dataSource: dataManageStores },
            { field: "ProductId", headerText: 'Producto', foreignKeyField: "ProductId", foreignKeyValue: "ProductName", dataSource: dataManagerProducts },
            { field: "Quantity", headerText: 'Cantidad', defaultValue: 0, editType: "numericedit", format: "{0:n2}" },
           
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
