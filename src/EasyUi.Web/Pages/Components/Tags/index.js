$(function () {

    $("#TagsFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#TagsFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#TagsFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/TagsFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('EasyUi');

    var service = easyUi.components.tags;
    var createModal = new abp.ModalManager(abp.appPath + 'Components/Tags/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Components/Tags/EditModal');

    var dataTable = $('#TagsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyUi.Tags.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyUi.Tags.Delete'),
                                confirmMessage: function (data) {
                                    return l('TagsDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('TagsName'),
                data: "name"
            },
            {
                title: l('TagsCode'),
                data: "code"
            },
            {
                title: l('TagsIsEnable'),
                data: "isEnable"
            },
            {
                title: l('TagsAttribute'),
                data: "attribute"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTagsButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
