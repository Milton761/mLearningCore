function error_handler(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}

$(function () {
    //callback handler for form submit
    /*$("#profileForm").submit(function (e) {
        var postData = $(this).serializeArray();
        var formURL = $(this).attr("action");
        console.log(formURL);
        /*$.ajax(
        {
            url: formURL,
            type: "POST",
            data: postData,
            success: function (data, textStatus, jqXHR) {
                //data: return data from server
            },
            error: function (jqXHR, textStatus, errorThrown) {
                //if fails      
            }
        });
        e.preventDefault(); //STOP default action
        //e.unbind(); //unbind. to stop multiple form submit.
    });*/
});

function editProfile()
{
    //var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var wnd = $("#profileWindow").data("kendoWindow");

    //wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}




/*Angular functions*/

var home = true;
var expandir_menu = function () {
    //$('.box').css('margin-left','300px');
    $('.box-menu-item-titulo').css('display', 'initial');
    $('.box-menu-titulo').css('display', 'initial');
    $('.box-menu-item-logo')
        .css('text-align', 'right')
        .css('text-align', '-webkit-right')
        .css('text-align', '-moz-center');;
    $('.box-menu-img')
        .css('text-align', 'right')
        .css('text-align', '-webkit-right')
        .css('text-align', '-moz-center');
    $('.box-menu').css('width', '300px');
};

var contraer_menu = function () {
    if (!home) {
        //$('.box').css('margin-left','100px');
        $('.box-menu-item-titulo').css('display', 'none');
        $('.box-menu-titulo').css('display', 'none');
        $('.box-menu-item-logo')
            .css('text-align', 'center')
            .css('text-align', '-webkit-center')
            .css('text-align', '-moz-center');;
        $('.box-menu-img').css('text-align', 'center')
            .css('text-align', '-webkit-center')
            .css('text-align', '-moz-center');
        $('.box-menu').css('width', '100px');

    }
};

var hacer_menu_fijo = function () {

    $('.box-menu').mouseenter(function () {
        expandir_menu();
    });
    $('.box-menu').mouseleave(function () {
        contraer_menu();

    });


};

var iniciado_click_items = false;

var refrescar_activos = function () {
    $('.box-menu-item').each(function () {
        var activo = $(this).attr('activo');
        var clase = $(this).attr('clase-activo')
        if (activo == 'true') {
            $(this).addClass(clase);
        }
        else {
            $(this).removeClass(clase);
        }
    });
};

var agregarClickItem = function () {
    if (!iniciado_click_items) {
        $('.box-menu-item').click(function (event) {
            $('.box-menu-item').each(function () {
                $(this).attr('activo', 'false');
            });
            $(this).attr('activo', 'true');

            refrescar_activos();
        });
        iniciado_click_items = true;
    }
}


var setItemActual = function (id) {
    $('.box-menu-item').each(function () {
        $(this).attr('activo', 'false');
    });
    $(id).attr('activo', 'true');
    refrescar_activos();
}

var hacerHome = function (opc) {
    if (opc) {
        $('.box').each(function () {
            console.log('##');
            $(this).css('margin-left', '300px');
        });

    }
    else {
        $('.box').each(function () {
            $(this).css('margin-left', '100px');
        });
    }
}

document.addEventListener('DOMContentLoaded', function () {

    hacer_menu_fijo();


    $('.showPopup').click(function (event) {
        event.preventDefault();
        //console.log("aa");
        $('.popup-user-opcion').css('visibility', 'visible');
    });
    $(document).mouseup(function (e) {
        var container = $(".popup-user-opcion");

        if (!container.is(e.target)) {
            $('.popup-user-opcion').css('visibility', 'collapse');
        }
    });


});