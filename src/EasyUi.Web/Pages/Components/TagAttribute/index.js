$(function () {

    $("#TagAttributeFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#TagAttributeFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#TagAttributeFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/TagAttributeFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('EasyUi');

    var service = easyUi.components.tagAttribute;
    var createModal = new abp.ModalManager(abp.appPath + 'Components/TagAttribute/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Components/TagAttribute/EditModal');

    var dataTable = $('#TagAttributeTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('EasyUi.TagAttribute.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyUi.TagAttribute.Delete'),
                                confirmMessage: function (data) {
                                    return l('TagAttributeDeletionConfirmationMessage', data.record.id);
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
                title: l('TagAttributeName'),
                data: "name"
            },
            {
                title: l('TagAttributeType'),
                data: "type"
            },
            {
                title: l('TagAttributeDefaultValue'),
                data: "defaultValue"
            },
            {
                title: l('TagAttributeDescription'),
                data: "description"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTagAttributeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
