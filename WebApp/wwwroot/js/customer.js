function addCustomer() {
    $.ajax({
        url: _RootBase + "Customer/ViewAddUpdateCustomer",
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
                    id: 'addCustomer',
                    //fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Add new Customer',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Save',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_addCustomer();
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
function ajax_addCustomer() {
    var fullname = $('#fullname').val();
    var dob = $('#dob').val();
    var email = $('#email').val();
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "Customer/AddUpdateCustomer",
            dataType: "json",
            type: "POST",
            data: {
                Name: fullname,
                DOB: dob,
                Email: email
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
                        toastr["success"]('Added new customers success', 'Notification');
                        $('#addCustomer').modal('hide');
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
function editCustomer(id) {
    $.ajax({
        url: _RootBase + "Customer/ViewAddUpdateCustomer",
        //dataType: "json",
        type: "GET",
        data: {
            id:id
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
                    id: 'editCustomer',
                    //fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Update Customer',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Save',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_editCustomer(id);
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
function ajax_editCustomer(id) {
    var fullname = $('#fullname').val();
    var dob = $('#dob').val();
    var email = $('#email').val();
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "Customer/AddUpdateCustomer",
            dataType: "json",
            type: "POST",
            data: {
                CustomerID:id,
                Name: fullname,
                DOB: dob,
                Email: email
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
                        toastr["success"]('Update customers success', 'Notification');
                        $('#editCustomer').modal('hide');
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
function deleteCustomer(id) {
    InitDialog({
        id: 'deleteCustomer',
        width: 600,
        title: 'Notification',
        body: '<div>Customer will be deleted from the system</div>'
            + '<div>Are you sure?</div>'
        ,
        icon: 'iconmoon-NotifyDelete',
        footer: {
            button: [
                {
                    text: 'Ok',
                    style: 'background-color:#5C77D0;',
                    click: function () {
                        ajax_deleteCustomer(id);
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
function ajax_deleteCustomer(id) {
    $.ajax({
        url: _RootBase + "Customer/DeleteCustomer",
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
                    toastr["success"]('Delete customers success', 'Notification');
                    $('#deleteCustomer').modal('hide');
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
        url: _RootBase + "Customer/ViewList",
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
            $('#table_customer').html(data);
        }
    });
}