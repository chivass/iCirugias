

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
    ObtenerQuirofanos: 'ObtenerQuirofanos',
    ObtenerCirugias: 'ObtenerCirugias',
    ObtenerCirugia: 'ObtenerCirugia',
    InsertarCirugia: 'InsertarCirugia',
    ModificarCirugia: 'ModificarCirugia',
    ObtenerEnfermero: 'ObtenerEnfermero',
    InsertarEnfermeria: 'InsertarEnfermeria',
    ModificarEnfermeria: 'ModificarEnfermeria',
    InsertarMedico:'InsertarMedico',
    ObtenerMedico: 'ObtenerMedico',
    ModificarMedico:'ModificarMedico',
};
var ObjetAfanadora = {
Oid:0
};
var ObjetEnfermeria = {
    Oid: 0
};
var ObjetCirugia = {
    Oid: 0
};
var ObjetEnfermeria = {
    Oid: 0
};
var ObjetMedico = {
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
        asyn:true,
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
        $('#ListaEnfermeria').append('<li><a  href="javascript:AbrirDetallesEnfermeria(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });
}

//pagina detallesenfermeria
$('#DetallesEnfermeria').bind('pagebeforeshow',
            function () {

                if (ObjetEnfermeria.Oid < 0) {
                    $('#txtNombreEnfermeria').val("");
                    $('#txtFechaNacimientoEnfermeria').val("");
                    $('#txtTelefonoEnfermeria').val("");
                    $('#txtEspecialidadEnfermeria').val("");
                    $('#txtCorreoEnfermeria').val("");
                }
                else {
                    var prams = { OidEnfermeria: ObjetEnfermeria.Oid };
                    ObtenerDatosWS(prams, WS.ObtenerEnfermero, "CargaEnfermero");
                }

            });

function CargaEnfermero(Objeto) {
   
    $('#txtEspecialidadCirugia').val(Objeto[0].Especialidad);
    $('#txtNombreEnfermeria').val(Objeto[0].Nombre);
    $('#txtFechaNacimientoEnfermeria').val(ConvertirFecha(Objeto[0].FechaNacimiento));
    $('#txtTelefonoEnfermeria').val(Objeto[0].Telefono);
    $('#txtEspecialidadEnfermeria').val(Objeto[0].Especialidad);
    $('#txtCorreoEnfermeria').val(Objeto[0].Correo);
}
function AbrirDetallesEnfermeria(OID) {
    ObjetEnfermeria.Oid = OID;
    $.mobile.changePage("#DetallesEnfermeria", { transition: 'pop', role: 'dialog' });

}
$("#btnGrabaraEnfermeria").click(function (event) {

    if (ObjetEnfermeria.Oid < 0) {
        var params = {

            
           Nombre : $('#txtNombreEnfermeria').val(),
            FechaNacimiento: $('#txtFechaNacimientoEnfermeria').val(),
            Telefono:   $('#txtTelefonoEnfermeria').val(),
            Especialidad: $('#txtEspecialidadEnfermeria').val(),
            Correo: $('#txtCorreoEnfermeria').val(),


        };

        InsertarDatosWs(params, WS.InsertarEnfermeria);

    }
    else {

        var params = {
            OidEnfermeria: ObjetEnfermeria.Oid,
            Nombre: $('#txtNombreEnfermeria').val(),
            FechaNacimiento: $('#txtFechaNacimientoEnfermeria').val(),
            Telefono: $('#txtTelefonoEnfermeria').val(),
            Especialidad: $('#txtEspecialidadEnfermeria').val(),
            Correo: $('#txtCorreoEnfermeria').val(),


        };

        InsertarDatosWs(params, WS.ModificarEnfermeria);
    }

});









//pagina Medicos
$('#medicos').bind('pagebeforeshow',
            function () {
                ObtenerDatosWSsinParametros(WS.ObtenerMedicos, "CargarMedicos");
                ObjetEnfermeria.Oid = 0;
            });

function CargarMedicos(Lista) {
    $('#ListaMedicos').empty();
    $.each(Lista, function (i, item) {
        $('#ListaMedicos').append('<li><a  href="javascript:AbrirDetallesMedico(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });
}

//pagina detallesedico
$('#DetallesMedico').bind('pagebeforeshow',
            function () {

                if (ObjetEnfermeria.Oid < 0) {
                    $('#txtNombreMedico').val("");
                    $('#txtFechaNacimientoMedico').val("");
                    $('#txtTelefonoMedico').val("");
                    $('#txtEspecialidadMedico').val("");
                    $('#txtCedulaMedico').val("");
                    $('#txtCorreoMedico').val("");
                }
                else {
                    var prams = { OidMedico: ObjetMedico.Oid };
                    ObtenerDatosWS(prams, WS.ObtenerMedico, "CargaMedico");
                }

            });

function CargaMedico(Objeto) {

    
    $('#txtNombreMedico').val(Objeto[0].Nombre);
    $('#txtFechaNacimientoMedico').val(ConvertirFecha(Objeto[0].FechaNacimiento));
    $('#txtTelefonoMedico').val(Objeto[0].Telefono);
    $('#txtEspecialidadMedico').val(Objeto[0].Especialidad);
    $('#txtCorreoMedico').val(Objeto[0].Correo);
    $('#txtCedulaMedico').val(Objeto[0].Cedula);
}


function AbrirDetallesMedico(OID) {
    ObjetMedico.Oid = OID;
    $.mobile.changePage("#DetallesMedico", { transition: 'pop', role: 'dialog' });

}

$("#btnGrabarMedico").click(function (event) {

    if (ObjetMedico.Oid < 0) {
        var params = {


            Nombre: $('#txtNombreMedico').val(),
            FechaNacimiento: $('#txtFechaNacimientoMedico').val(),
            Telefono: $('#txtTelefonoMedico').val(),
            Cedula: $('#txtCedulaMedico').val(),
            Especialidad: $('#txtEspecialidadMedico').val(),
            Correo: $('#txtCorreoMedico').val(),


        };

        InsertarDatosWs(params, WS.InsertarMedico);

    }
    else {

        var params = {
            OidMedico: ObjetMedico.Oid,
            Nombre: $('#txtNombreMedico').val(),
            FechaNacimiento: $('#txtFechaNacimientoMedico').val(),
            Telefono: $('#txtTelefonoMedico').val(),
            Especialidad: $('#txtEspecialidadMedico').val(),
            Correo: $('#txtCorreoMedico').val(),


        };

        InsertarDatosWs(params, WS.ModificarMedico);
    }

});












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


//pagina cirugias
$('#cirugia').bind('pagebeforeshow',
            function () {
                ObtenerDatosWSsinParametros(WS.ObtenerCirugias, "CargarCirugias");
                ObjetEnfermeria.Oid = 0;
            });

function CargarCirugias(Lista) {
    $('#ListaCirugias').empty();
    $.each(Lista, function (i, item) {
        $('#ListaCirugias').append('<li><a  href="javascript:AbrirDetallesCirugia(' + Lista[i].OID + ');" data-rel="dialog">' + Lista[i].Nombre + '</a></li>').listview('refresh');
    });
}

//pagina detallesacirugia
$('#DetallesCirugia').bind('pagebeforeshow',
            function () {

                if (ObjetCirugia.Oid < 0) {
                    $('#txtNombreCirugia').val("");
                    $('#txtEspecialidadCirugia').val("");
                }
                else {
                    var prams = {OidCirugia:ObjetCirugia.Oid};
                    ObtenerDatosWS(prams, WS.ObtenerCirugia, "CargaCirugia");
                }

            });

function CargaCirugia(Objeto) {
    $('#txtNombreCirugia').val(Objeto[0].Nombre);
    $('#txtEspecialidadCirugia').val(Objeto[0].Especialidad);
}

function AbrirDetallesCirugia(OID) {
    ObjetCirugia.Oid = OID;
    $.mobile.changePage("#DetallesCirugia", { transition: 'pop', role: 'dialog' });
    
}

$("#btnGrabaCirugia").click(function (event) {

    if (ObjetCirugia.Oid < 0) {
        var params = {
            
            Nombre: $('#txtNombreCirugia').val(),
            Especialidad: $('#txtEspecialidadCirugia').val(),
      

        };

        InsertarDatosWs(params, WS.InsertarCirugia);

    }
    else {

        var params = {
            OidACirugia:ObjetCirugia.Oid,
            Nombre: $('#txtNombreCirugia').val(),
            Especialidad: $('#txtEspecialidadCirugia').val(),
            

        };

        InsertarDatosWs(params, WS.ModificarCirugia);
    }

});