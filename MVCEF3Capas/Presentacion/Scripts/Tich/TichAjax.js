
<script type="text/javascript">

    function CalcularIMSS() {

            var urlws = 'http://localhost:55592/WCFAlumnos.svc/CalcularIMSS';
    var id = $("#lblId").text();
    var alumno = {id: id};
    var parametros = JSON.stringify(alumno);
    LLamaAJAXPost(urlws, parametros, MuestraAportacionesIMSS);
           

        }
    function LLamaAJAXPost(url, parametros,funcionExito) {
        $.ajax(
            {

                type: 'post',
                url: url,
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: funcionExito,
                error: errorGenerico
            }
        );

        }

    function MuestraAportacionesIMSS(data) {
            try {
        imss = data.d;
    if (imss != null) {
        $("#<%= lblEnfermedades.ClientID%>").text(imss.EnfermedadMaternidad);
    $("#<%= lblInvalidez.ClientID%>").text(imss.InvalidezVida);
    $("#<%= lblRetiro.ClientID%>").text(imss.Retiro);
    $("#<%= lblCesantia.ClientID%>").text(imss.Cesantía);
    $("#<%= lblInfonavit.ClientID%>").text(imss.Infonavit);
    $("#venModalclienteIMSS").modal();
                }
    else {
        alert('La respuesta recibida del Web Service es incorrecta ' + data.d);
                }
            }
    catch (ex) {
        alumno = [];
    alert('Error al recibir los datos');
            }
        }



    function errorGenerico(jqXHR, exception) {
            var msg = '';
    if (jqXHR.status === 0) {
        msg = 'No está conectado, favor de verificar su conexión.';
            }
    else if (jqXHR.status === 404) {
        msg = 'Página no encontrada [404]';
            }
    else if (jqXHR.status === 500) {
        msg = 'Error no hay conexión al servidor [500]';
            }
    else if (jqXHR.status === 'parseerror') {
        msg = 'El parseo del JSON es erróneo.';
            }
    else if (jqXHR.status === 'timeout') {
        $('body').addClass('loaded');
            }
    else if (jqXHR.status === 'abort') {
        msg = 'La petición Ajax fue abortada.';
            }
    else {
        msg = 'Error no conocido. ';
    console.log(exception);
            }
    alert(msg);
        }

</script>
