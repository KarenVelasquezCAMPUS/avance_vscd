$(document).ready(function() {
  // Cargar la lista de documentos
  cargarListadoDocumentos();

  // Cargar la lista de empresas
  cargarListaEmpresas();

  // Eventos del formulario
  $("#btn-guardar").click(function() {
    guardarDocumento();
  });
});

function cargarListadoDocumentos() {
  $.ajax({
    url: "/documentos/listar",
    type: "GET",
    dataType: "json",
    success: function(respuesta) {
      // Actualizar el contenido de la tabla
      $("#table-listado tbody").empty();
      for (var documento of respuesta) {
        var fila = $("<tr></tr>");
        for (var campo in documento) {
          var celda = $("<td></td>");
          celda.text(documento[campo]);
          fila.append(celda);
        }
        $("#table-listado tbody").append(fila);
      }
    },
    error: function(error) {
      console.log(error);
    }
  });
}

function cargarListaEmpresas() {
  $.ajax({
    url: "/empresas/listar",
    type: "GET",
    dataType: "json",
    success: function(respuesta) {
      // Actualizar el contenido del select
      $("#empresa").empty();
      for (var empresa of respuesta) {
        var option = $("<option></option>");
        option.value = empresa.idempresa;
        option.text = empresa.razonsocial;
        $("#empresa").append(option);
      }
    },
    error: function(error) {
      console.log(error);
    }
  });
}

function guardarDocumento() {
  // Obtener los datos del formulario
  var datos = $("#form-documento").serialize();

  // Enviar los datos al servidor
  $.ajax({
    url: "/documentos/guardar",
    type: "POST",
    data: datos,
    dataType: "json",
    success: function(respuesta) {
      // Actualizar la lista de documentos
      cargarListadoDocumentos();

      // Limpiar el formulario
      $("#form-documento").find("input, select").val("");
    },
    error: function(error) {
      console.log(error);
    }
  });
}