$(function () {

var dataManager = ej.DataManager({
    url: "/api/Categories",
    adaptor: new ej.WebApiAdaptor(),
    offline: true
});
dataManager.ready.done(function (e) {
    $("#Grid").ejGrid({
        dataSource: ej.DataManager({
            json: e.result,
            adaptor: new ej.remoteSaveAdaptor(),
            insertUrl: "/api/Categories/Insert",
            updateUrl: "/api/Categories/Update",
            removeUrl: "/api/Categories/Remove",
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
            { field: "CategoryId", headerText: 'Id', isPrimaryKey: true, isIdentity: true, visible: false },
            { field: "CategoryName", headerText: 'Nombre', validationRules: { required: true } },
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
