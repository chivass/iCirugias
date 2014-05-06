

function ConvertirFecha(tdate) {

    var fecha = new Date(parseInt(tdate.substring(tdate.indexOf('(') + 1, tdate.indexOf(')'))))
    var yyyy = fecha.getFullYear().toString();
    var mm = (fecha.getMonth() + 1).toString(); // getMonth() is zero-based         
    var dd = fecha.getDate().toString();

    if (mm <= 9) { mm = "0" + mm };
    if (dd <= 9) { dd = "0" + dd };

    return (yyyy+"-"+mm+"-" + dd  );
};



var wsAddress = 'iCirugiasWebServices.asmx/';

var WS = {
    InsertarAfanadora: 'InsertarAfanadora',
    ObtenerAfanadoras: 'ObtenerAfanadoras',
    ObtenerAfanadora:'ObtenerAfanadora',
    ModificarAfanadora: 'ModificarAfanadora',
    ObtenerEnfermeria: 'ObtenerEnfermeria',
    ObtenerMedicos: 'ObtenerMedicos',
    ObtenerQuirofanos:'ObtenerQuirofanos',
};
var ObjetAfanadora = {
Oid:0
};
var ObjetEnfermeria = {
    Oid: 0
};

//Variables en memoria






function ObtenerDatosWS(params, WS,funcion) {

       var datos= $.ajax({
        type: 'POST',
        crossDomain: true,
        url: wsAddress  + WS,
        data: JSON.stringify(params),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {
            if (datos.d == 0) {
                //$.mobile.changePage("#pageone", { transition: 'pop', role: 'dialog' }); return;
            }
            try
            {
                eval(funcion + '(jQuery.parseJSON(datos.d))');
            }
            catch(err)
            {
                
                eval(funcion + '(datos.d)');
            }

        },
        error: AjaxError
        }); 
}
function InsertarDatosWs(params, WS) {
    $.ajax({
        type: 'POST',
        crossDomain: true,
        url: wsAddress + WS,
        data: JSON.stringify(params),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (msg) {
            //AjaxOK(msg);
        },
        error: AjaxError
    });

}
function ObtenerDatosWSsinParametros(WS, funcion) {
    $.ajax({
        type: 'POST',
        crossDomain: true,
        asyn:false,
        url: wsAddress + WS,
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {
            //if (datos.d == 0) {
            //    //$.mobile.changePage("#pageone", { transition: 'pop', role: 'dialog' }); return;
            //}
            
            try
            {
                eval(funcion + '(jQuery.parseJSON(datos.d))');
            }
            catch (err) {
                

                eval(funcion + '(datos.d)');
            }

        },
        error: AjaxError
    });
}
function AjaxError(result) {
    alert("ERROR " + result.status + ' ' + result.statusText);
}

//pagi home
$(document).bind("mobileinit", function () {
    $.support.cors = true;
    $.mobile.allowCrossDomainPages = true;
    $.mobile.pushStateEnabled = false;
});
$(document).ready(function () {

  
});

//pagina afanadora
$('#afanadora').bind('pagebeforeshow',
            function () {
                ObtenerDatosWSsinParametros(WS.ObtenerAfanadoras, "CargarAfanadoras");
                ObjetAfanadora.Oid = 0;
            });


//pagina detallesafanadora
$('#DetallesAfanadora').bind('pagebeforeshow',
            function () {
                

            });
function CargarAfanadora(Objeto) {
  
        $('#txtNombreAfanadora').val(Objeto[0].Nombre);
        $('#txtTelefonoAfanadora').val(Objeto[0].Telefono);
        $('#txtFechaNacimientoAfanadora').val(ConvertirFecha(Objeto[0].FechaNacimiento));
        $('#txtCorreoAfanadora').val(Objeto[0].Correo);
        ObjetAfanadora.Oid = Objeto[0].OID;
    
}
function AfanadoraDetalles(Oid) {
    var parms = {
        OidAfanadora: Oid
    };
    ObtenerDatosWS(parms, WS.ObtenerAfanadora, "CargarAfanadora");
    
    $.mobile.changePage("#DetallesAfanadora", { transition: 'pop', role: 'dialog' });
}



function CargarAfanadoras(Lista)
{
    $('#ListaAfanadoras').empty();
    $.each(Lista, function (i, item) {
        $('#ListaAfanadoras').append('<li><a  href="javascript:AfanadoraDetalles(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });

}
/** BOTON DE GRABAR afanadora **/
$("#btnGrabarAfanadora").click(function (event) {

    if (ObjetAfanadora.Oid > 0) {
        var params = {
            OidAfanadora: ObjetAfanadora.Oid,
            Nombre: $('#txtNombreAfanadora').val(),
            Telefono: $('#txtTelefonoAfanadora').val(),
            FechaNacimiento: $('#txtFechaNacimientoAfanadora').val(),
            Correo: $('#txtCorreoAfanadora').val(),

        };

        InsertarDatosWs(params, WS.ModificarAfanadora);
        
    }
    else {

        var params = {
            Nombre: $('#txtNombreAfanadora').val(),
            Telefono: $('#txtTelefonoAfanadora').val(),
            FechaNacimiento: $('#txtFechaNacimientoAfanadora').val(),
            Correo: $('#txtCorreoAfanadora').val(),

        };

        InsertarDatosWs(params, WS.InsertarAfanadora);
    }
    
});


//pagina Enfermeria
$('#enfermeria').bind('pagebeforeshow',
            function () {
                ObtenerDatosWSsinParametros(WS.ObtenerEnfermeria, "CargarEnfermeria");
                ObjetEnfermeria.Oid = 0;
            });

function CargarEnfermeria(Lista) {
    $('#ListaEnfermeria').empty();
    $.each(Lista, function (i, item) {
        $('#ListaEnfermeria').append('<li><a  href="javascript:DetallesEnfermeria(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });
}








//pagina Medicos
$('#medicos').bind('pagebeforeshow',
            function () {
                ObtenerDatosWSsinParametros(WS.ObtenerMedicos, "CargarMedicos");
                ObjetEnfermeria.Oid = 0;
            });

function CargarMedicos(Lista) {
    $('#ListaMedicos').empty();
    $.each(Lista, function (i, item) {
        $('#ListaMedicos').append('<li><a  href="javascript:DetallesMedicos(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });
}


//pagina quirofanos
$('#quirofano').bind('pagebeforeshow',
            function () {
                ObtenerDatosWSsinParametros(WS.ObtenerQuirofanos, "CargarQuirofano");
                ObjetEnfermeria.Oid = 0;
            });

function CargarQuirofano(Lista) {
    $('#ListaQuirofano').empty();
    $.each(Lista, function (i, item) {
        $('#ListaQuirofano').append('<li><a  href="javascript:DetallesQuirofano(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });
}