function addShop() {
    $.ajax({
        url: _RootBase + "Shop/ViewAddUpdateShop",
        //dataType: "json",
        type: "GET",
        async: true,
        beforeSend: function () {
            $("body").addClass('loading');
        },
        complete: function () {
            $("body").removeClass('loading');
        },
        success: function (data) {
            if (data != null) {
                InitDialog({
                    id: 'addShop',
                    //fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Add new Shop',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Save',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_addShop();
                                },
                                isClose: false,
                            },
                            {
                                text: 'Cancel',
                                isClose: true,
                                style: 'background-color:#B7BDD3;',
                            },

                        ]
                    },
                    callback: function () {

                    }
                });
            }
        },
        error: function (err) {
            console.log(err)
        }
    });
}
function ajax_addShop() {
    var shopname = $('#shopname').val();
    var shoplocation = $('#shoplocation').val();
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "Shop/AddUpdateShop",
            dataType: "json",
            type: "POST",
            data: {
                Name: shopname,
                Location: shoplocation
            },
            async: true,
            beforeSend: function () {
                $("body").addClass('loading');
            },
            complete: function () {
                $("body").removeClass('loading');
            },
            success: function (data) {
                if (data != null) {
                    var returncode = data.returncode;
                    if (returncode == 0) {
                        toastr["success"]('Added new Shops success', 'Notification');
                        $('#addShop').modal('hide');
                        reload_table();
                    }
                    else {
                        if (returncode == -1) {
                            toastr["error"]('Error', 'Notification');
                        }
                        else {
                            toastr["error"]('Error', 'Notification');
                        }
                    }
                }
            },
            error: function (err) {
                console.log(err)
            }
        });
    }
}
function editShop(id) {
    $.ajax({
        url: _RootBase + "Shop/ViewAddUpdateShop",
        //dataType: "json",
        type: "GET",
        data: {
            id: id
        },
        async: true,
        beforeSend: function () {
            $("body").addClass('loading');
        },
        complete: function () {
            $("body").removeClass('loading');
        },
        success: function (data) {
            if (data != null) {
                InitDialog({
                    id: 'editShop',
                    //fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Update Shop',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Save',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_editShop(id);
                                },
                                isClose: false,
                            },
                            {
                                text: 'Cancel',
                                isClose: true,
                                style: 'background-color:#B7BDD3;',
                            },

                        ]
                    },
                    callback: function () {

                    }
                });
            }
        },
        error: function (err) {
            console.log(err)
        }
    });
}
function ajax_editShop(id) {
    var shopname = $('#shopname').val();
    var shoplocation = $('#shoplocation').val();
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "Shop/AddUpdateShop",
            dataType: "json",
            type: "POST",
            data: {
                ShopID: id,
                Name: shopname,
                Location: shoplocation
            },
            async: true,
            beforeSend: function () {
                $("body").addClass('loading');
            },
            complete: function () {
                $("body").removeClass('loading');
            },
            success: function (data) {
                if (data != null) {
                    var returncode = data.returncode;
                    if (returncode == 0) {
                        toastr["success"]('Update Shop success', 'Notification');
                        $('#editShop').modal('hide');
                        reload_table();
                    }
                    else {
                        if (returncode == -1) {
                            toastr["error"]('Error', 'Notification');
                        }
                        else {
                            toastr["error"]('Error', 'Notification');
                        }
                    }
                }
            },
            error: function (err) {
                console.log(err)
            }
        });
    }
}
function deleteShop(id) {
    InitDialog({
        id: 'deleteShop',
        width: 600,
        title: 'Notification',
        body: '<div>Shop will be deleted from the system</div>'
            + '<div>Are you sure?</div>'
        ,
        icon: 'iconmoon-NotifyDelete',
        footer: {
            button: [
                {
                    text: 'Ok',
                    style: 'background-color:#5C77D0;',
                    click: function () {
                        ajax_deleteShop(id);
                    },
                    isClose: false,
                },
                {
                    text: 'Cancel',
                    isClose: true,
                    style: 'background-color:#B7BDD3;',
                },
            ]
        }
    });
}
function ajax_deleteShop(id) {
    $.ajax({
        url: _RootBase + "Shop/DeleteShop",
        dataType: "json",
        type: "POST",
        data: {
            id: id,
        },
        async: true,
        beforeSend: function () {
            $("body").addClass('loading');
        },
        complete: function () {
            $("body").removeClass('loading');
        },
        success: function (data) {
            if (data != null) {
                var returncode = data.returncode;
                if (returncode == 0) {
                    toastr["success"]('Delete Shops success', 'Notification');
                    $('#deleteShop').modal('hide');
                    reload_table();
                }
                else {
                    if (returncode == -1) {
                        toastr["error"]('Error', 'Notification');
                    }
                    else {
                        toastr["error"]('Error', 'Notification');
                    }
                }
            }
        },
        error: function (err) {
            console.log(err)
        }
    });
}
function reload_table() {
    $.ajax({
        url: _RootBase + "Shop/ViewList",
        //dataType: "json",
        type: "GET",
        async: true,
        beforeSend: function () {
            $("body").addClass('loading');
        },
        complete: function () {
            $("body").removeClass('loading');
        },
        success: function (data) {
            $('#table_shop').html(data);
        }
    });
}