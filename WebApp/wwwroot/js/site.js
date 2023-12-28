function init_popup() {
    InitDialog({
        id: 'abc',
        width: 600,
        title: 'Thông báo',
        body: '<div>Bạn có muốn xóa nội dung này!</div>'
            + '<div>Nội dung này cần phải xóa bạn có muốn xóa liền không?'
        ,
        icon: 'iconmoon-NotifyDelete',
        footer: {
            //text: 'Text null sẽ bị ẩn!',
            button: [
                {
                    //css: 'btn-primary',
                    text: 'Quay lại',
                    isClose: true,
                    style: 'background-color:#B7BDD3;',
                    //click: function () {
                    //    alert("Đóng Dialog, nếu truyền Iclose = false sẽ không đóng")
                    //}
                },
                {
                    //css: 'btn-success',
                    text: 'Đồng ý',
                    style: 'background-color:#5C77D0;',
                    click: function () {
                        alert("Excute Function, Successfull");
                        //RemoveDialog();
                    },
                    isClose: true,
                },
            ]
        },
        callback: function () {

        }
    });
}