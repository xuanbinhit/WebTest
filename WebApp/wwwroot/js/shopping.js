function addShopping() {
    $.ajax({
        url: _RootBase + "Shopping/ViewAddProduct",
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
                    id: 'addShopping',
                    fullscreen: true,
                    width: $(window).width() * 0.6,
                    title: 'Add Product To Cart',
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