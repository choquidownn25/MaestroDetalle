$(function () {
var dataManager = ej.DataManager({
    url: "/api/Orders",
    adaptor: new ej.WebApiAdaptor(),
    offline: true
});

var dataManagerCustomers = ej.DataManager({
    url: "/api/Customers",
    adaptor: new ej.WebApiAdaptor()
});

var dataManagerStore = ej.DataManager({
    url: "/api/Stores",
        adaptor: new ej.WebApiAdaptor()
});

var dataManagerStaff = ej.DataManager({
    url: "/api/Staffs",
        adaptor: new ej.WebApiAdaptor()
});

dataManager.ready.done(function (e) {
    $("#Grid").ejGrid({
        dataSource: ej.DataManager({
            json: e.result,
            adaptor: new ej.remoteSaveAdaptor(),
            insertUrl: "/api/Orders/Insert",
            updateUrl: "/api/Orders/Update",
            removeUrl: "/api/Orders/Remove",
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
            { field: "OrderId", headerText: 'Id', isPrimaryKey: true, isIdentity: true, visible: false },
            { field: "CustomerId", headerText: 'Marca', foreignKeyField: "CustomerId", foreignKeyValue: "FirstName", dataSource: dataManagerCustomers, validationRules: { required: true } },
            { field: "StoreId", headerText: 'Almacen', foreignKeyField: "StoreId", foreignKeyValue: "StoreName", dataSource: dataManagerStore, validationRules: { required: true } },
            { field: "StaffId", headerText: 'Cliente', foreignKeyField: "StaffId", foreignKeyValue: "FirstName", dataSource: dataManagerStaff, validationRules: { required: true } },

            { field: "OrderDate", headerText: 'Fecha Orden', editType: "datepicker", format: "{0:MM/dd/yyyy}", validationRules: { required: true } },
            { field: "RequiredDate", headerText: 'Fecha Despacho', editType: "datepicker", format: "{0:MM/dd/yyyy}", validationRules: { required: true } },
            { field: "ShippedDate", headerText: 'Fecha Envio', editType: "datepicker", format: "{0:MM/dd/yyyy}", validationRules: { required: true } },

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
