﻿$(function () {

var dataManager = ej.DataManager({
    url: "/api/Customers",
    adaptor: new ej.WebApiAdaptor(),
    offline: true
});
dataManager.ready.done(function (e) {
    $("#Grid").ejGrid({
        dataSource: ej.DataManager({
            json: e.result,
            adaptor: new ej.remoteSaveAdaptor(),
            insertUrl: "/api/Customers/Insert",
            updateUrl: "/api/Customers/Update",
            removeUrl: "/api/Customers/Remove",
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
            { field: "CustomerId", headerText: 'Id', isPrimaryKey: true, isIdentity: true, visible: false },
            { field: "FirstName", headerText: 'Nombre', validationRules: { required: true } },
            { field: "LastName", headerText: 'Apellido', validationRules: { required: true } },
            { field: "Phone", headerText: 'Telefono', validationRules: { required: true } },
            { field: "Email", headerText: 'Email', validationRules: { required: true } },
            { field: "Street", headerText: 'Direccion', validationRules: { required: true } },
            { field: "City", headerText: 'Ciudad', validationRules: { required: true } },
            { field: "State", headerText: 'Departamento', validationRules: { required: true } },
            { field: "ZipCode", headerText: 'Pais', validationRules: { required: true } },
           
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
