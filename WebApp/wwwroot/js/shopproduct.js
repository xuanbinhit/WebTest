function addProduct(id) {
    $.ajax({
        url: _RootBase + "ShopProduct/ViewAddProduct",
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
                    title: 'Add Product To Shop',
                    body: data,
                    footer: {
                        button: [
                            {
                                //css: 'btn-success',
                                text: 'Add',
                                style: 'background-color:#5C77D0;',
                                click: function () {
                                    ajax_addProduct(id);
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
function ajax_addProduct(id) {
    var productID = $('#productID').find(":selected").val();;
    if ($('form').valid()) {
        $.ajax({
            url: _RootBase + "ShopProduct/AddProduct",
            dataType: "json",
            type: "POST",
            data: {
                ShopID: id,
                ProductID: productID
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
                        toastr["success"]('Added Product to Shop success', 'Notification');
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
function deleteProduct(id) {
    InitDialog({
        id: 'deleteProduct',
        width: 600,
        title: 'Notification',
        body: '<div>Product will be removed from the Shop</div>'
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
        url: _RootBase + "ShopProduct/DeleteProduct",
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
        url: _RootBase + "ShopProduct/ViewList",
        //dataType: "json",
        type: "GET",
        data: {
            id: shopId
        },
        async: true,
        beforeSend: function () {
            $("body").addClass('loading');
        },
        complete: function () {
            $("body").removeClass('loading');
        },
        success: function (data) {
            $('#table_shopproduct').html(data);
        }
    });
}