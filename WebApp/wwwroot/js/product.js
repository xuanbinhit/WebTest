function addProduct() {
    $.ajax({
        url: _RootBase + "Product/ViewAddUpdateProduct",
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
                    id: 'addProduct',
                    //fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Add new Product',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Save',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_addProduct();
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
function ajax_addProduct() {
    var productname = $('#productname').val();
    var price = $('#price').val();
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "Product/AddUpdateProduct",
            dataType: "json",
            type: "POST",
            data: {
                Name: productname,
                Price: price
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
                        toastr["success"]('Added new Products success', 'Notification');
                        $('#addProduct').modal('hide');
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
function editProduct(id) {
    $.ajax({
        url: _RootBase + "Product/ViewAddUpdateProduct",
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
                    id: 'editProduct',
                    //fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Update Product',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Save',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_editProduct(id);
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
function ajax_editProduct(id) {
    var productname = $('#productname').val();
    var price = $('#price').val();
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "Product/AddUpdateProduct",
            dataType: "json",
            type: "POST",
            data: {
                ProductID: id,
                Name: productname,
                Price: price
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
                        toastr["success"]('Update Product success', 'Notification');
                        $('#editProduct').modal('hide');
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
function deleteProduct(id) {
    InitDialog({
        id: 'deleteProduct',
        width: 600,
        title: 'Notification',
        body: '<div>Product will be deleted from the system</div>'
            + '<div>Are you sure?</div>'
        ,
        icon: 'iconmoon-NotifyDelete',
        footer: {
            button: [
                {
                    text: 'Ok',
                    style: 'background-color:#5C77D0;',
                    click: function () {
                        ajax_deleteProduct(id);
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
function ajax_deleteProduct(id) {
    $.ajax({
        url: _RootBase + "Product/DeleteProduct",
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
                    toastr["success"]('Delete Products success', 'Notification');
                    $('#deleteProduct').modal('hide');
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
        url: _RootBase + "Product/ViewList",
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
            $('#table_product').html(data);
        }
    });
}