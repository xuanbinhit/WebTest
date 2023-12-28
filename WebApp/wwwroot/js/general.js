
var InitDialog = function (obj) {
    if (!obj) obj = {};

    var id = obj.id || 'modal-custom';

    var htmlHeader = function () {
        if (obj.title) {
            return '<div class="modal-header">'
                + '<h4 class="modal-title">' + obj.title + '</h4>'
                + (obj.fullscreen == true ? '<button type="button" class="iconfullscreen"><i class="iconmoon iconmoon-full2"></i></button>' : '')
                + (obj.disableClose == true ? '' : '<button type="button" class="close" aria-label="Close"><i class="iconmoon iconmoon-Close"></i></button>')
                + '</div>';
        }
        return '<div class="modal-header">'
            + (obj.fullscreen == true ? '<button type="button" class="iconfullscreen"><i class="iconmoon iconmoon-full2"></i></button>' : '')
            + (obj.disableClose == true ? '' : '<button type="button" class="close" aria-label="Close"><i class="iconmoon iconmoon-Close"></i></button>')
            + '</div>';
    };

    var htmlBody = function () {
        if (obj.body) {
            return '<div class="modal-body">' + obj.body + (obj.icon ? '<p class="cnt-icon"><i class="iconmoon ' + obj.icon + '" ></i></p>' : '') + '</div>';
        }
        return '';
    };
    var cls_btn_xs = '';
    if (isMobile()) {
        cls_btn_xs = 'btn-xs';
    }
    var htmlFooter = function () {
        if (obj.footer) {
            var html = '';
            html += '<div class="modal-footer">';
            if (obj.footer.text) {
                html += '<div>' + obj.footer.text + '</div>';
            }
            if (obj.footer.button) {
                $.each(obj.footer.button, function (idx, val) {
                    html += '<button type="button" ' + (val.style ? 'style="' + val.style + '"' : '') + ' ' + (val.isClose ? 'data-dismiss="modal"' : '') + ' class="btn btn-custom ' + cls_btn_xs + ' ' + (val.css ? val.css : '') + '">' + val.text + '</button>';
                });
            }
            html += '</div>';
            return html;
        }
        return '';
    };

    var maxZIndex = getMaxZIndex();

    var html = '';
    html += '<div class="modal fade ' + (obj.class ? obj.class : '') + '" data-backdrop="' + (obj.backdrop ? obj.backdrop : 'static') + '" id="' + id + '" style="z-index:' + (maxZIndex + 2) + '">';
    html += '<div class="modal-dialog modal-custom-icon ' + (obj.fullscreen == true ? '' : 'modal-dialog-centered') + '" style="' + (obj.width ? 'width:' + (!isMobile() ? obj.width + 'px;max-width:' + (!isMobile() ? obj.width + 'px;' : 'auto;') : 'auto;') : '') + '">';
    html += '<div class="modal-content">';
    html += htmlHeader() + htmlBody() + htmlFooter();
    html += '</div></div></div>';
    $('body').addClass('modal-open').append(html);
    $('#' + id).modal();
    //if (obj.fullscreen) {
    //    setTimeout(function () {
    //        $('#' + id).removeClass('invisible');
    //    }, 1000)
    //}
    $('#' + id).on('shown.bs.modal', function () {
        $('#' + id).next('.modal-backdrop').css('z-index', ((maxZIndex + 2) - 1));
        $('.pace-progress').css('z-index', (maxZIndex + 3));
        //$(this).find('input:text:visible:first').focus();
        //$(this).find('[autofocus]').focus();
    })
    $('#' + id).on('hidden.bs.modal', function () {
        $('#' + id).remove();
        if ($('.modal:visible').length) {
            $('body').addClass('modal-open');
        }
        else {
            $('body').removeClass('modal-open');
        }
    })
    $('#' + id).addClass(obj.cssClass || '');
    $('#' + id + ' .modal-header button[class="close"]').on('click', function () {
        if (obj.isconfirm) {
            InitDialogCourse({
                id: 'confirmCloseDialog',
                width: 600,
                title: 'Notification',
                body: obj.confirmtitle ? obj.confirmtitle : '<div style="font-size:18px;"><div>Data will be delete</div>'
                    + '<div>Are you sure?</div></div>'
                ,
                icon: 'iconmoon-TestTimeOut',
                footer: {
                    button: [
                        {
                            text: 'Back',
                            isClose: true,
                            style: 'background-color:#B7BDD3;',
                        },
                        {
                            //css:'btn-submit',
                            text: 'Ok',
                            style: 'background-color:#5C77D0;',
                            click: function () {
                                $('#confirmCloseDialog').modal('hide');
                                $('#' + id).modal('hide');
                            },
                            isClose: false,
                        },
                    ]
                }
            });
        }
        else {
            $('#' + id).modal('hide');
        }
    })

    var thisModal = $('#' + id);
    $('#' + id + ' .modal-footer .btn').each(function (idx) {
        var ExcuteFunc = obj.footer.button[idx].click;
        if (ExcuteFunc) { $(this).click(function () { ExcuteFunc(thisModal); }); }
    });
    //gọi sự kiện fullscreen
    $('#' + obj.id).on('click', '.iconfullscreen', function () {
        $('#' + obj.id).find('.modal-content').addClass('fullscreen');
        $('#' + obj.id).find('.modal-header .iconfullscreen').removeClass('iconfullscreen').addClass('iconofffullscreen');
        $('#' + obj.id).find('.modal-header .iconmoon.iconmoon-full2').removeClass('iconmoon-full2').addClass('iconmoon-full1');
    });
    //gọi sự kiện tắt fullscreen
    $('#' + obj.id).on('click', '.iconofffullscreen', function () {
        $('#' + obj.id).find('.modal-content').removeClass('fullscreen');
        $('#' + obj.id).find('.modal-header .iconofffullscreen').removeClass('iconofffullscreen').addClass('iconfullscreen');
        $('#' + obj.id).find('.modal-header .iconmoon.iconmoon-full1').removeClass('iconmoon-full1').addClass('iconmoon-full2');
    });
    //bắt sự kiện phím    
    $(document).off('keydown').on("keydown", function (event) {
        //esc
        if (event.which == 27) {
            $('#' + id).modal('hide');
            //console.log('remove');
        }
        //enter
        if (event.which == 13) {
            $('#' + id + ' .modal-footer button[type="button"].btn-submit').trigger('click');
        }
        //console.log(event.which);
    });
    if (typeof obj.callback === 'function') {
        obj.callback();
    }
    return thisModal;
}
var getMaxZIndex = function () {
    var maxZIndex = Math.max.apply(null, $.map($('div').not('.cke,.pace-inactive .pace-progress,.toast,#toast-container,.swal2-container')
        , function (e, i) {
            if ($(e).css('position') !== 'static')
                return parseInt($(e).css('z-index')) || 1;
        })
    );

    //nếu z-index vượt ngưỡng tối đa, thì lấy tối đa z-index trừ đi 2, max(z-index) = max(int) = Math.pow(2,31)-1) = 2147483647
    return Math.min(maxZIndex, Math.pow(2, 31) - 4);
}
function isMobile() {
    var isMobile = false;
    var media = window.matchMedia("only screen and (max-width: 767px)")

    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) && media.matches) {
        isMobile = true;
    }
    return isMobile;
}