var oTable;
var fecha = new Date();

var mes = fecha.getMonth()+1;
var dia = fecha.getDate();

var fechaHoy = (dia < 10 ? '0' : '') + dia + '/' +
    (mes<10 ? '0' : '') + mes + '/' +
    fecha.getFullYear();

function CrearTablaReporteInventario(aDataSet) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    TableTools.DEFAULTS.aButtons = [];
    oTable = $('#example').dataTable({
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "sRowSelect": "single",
            "aButtons": [
				{
				    "sExtends": "pdf",
				    "sButtonText": "Exportar a PDF",
				    "sPdfOrientation": "landscape",
				    "sPdfSize": "A4",
				    "sPdfMessage": "Sistema de Gestíon del Área del Gimnasio                                                                                                                                                                                  Reporte sobre el Inventario                                                                                                                                                                                                            generado el: " + fechaHoy,
                    "sNewLine": "\n"
				}
            ],
	    "sSwfPath": "/swf/copy_csv_xls_pdf.swf"

        },
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": aDataSet,
        "oLanguage": {
            "oPaginate": {
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Última",
                "sFirst": "Primera"
            },
            "sLengthMenu": 'Mostrar <select>' +
                                    '<option value="10">10</option>' +
                                    '<option value="20">20</option>' +
                                    '<option value="30">30</option>' +
                                    '<option value="40">40</option>' +
                                    '<option value="50">50</option>' +
                                    '<option value="-1">Todos</option>',

            "sInfo": "Mostrando del _START_ al _END_ de los resultados (Total: _TOTAL_ resultados)",

            "sInfoFiltered": " - filtrados de _MAX_ registros",

            "sInfoEmpty": "No hay resultados de búsqueda",

            "sZeroRecords": "No hay registros a mostrar",

            "sProcessing": "Espere, por favor...",

            "sSearch": "Buscar:"
        },
        "aoColumns": [
						{ "sTitle": "Tipo Implemento", "sClass": "center" },
						{ "sTitle": "Implemento", "sClass": "center" },
						{ "sTitle": "Cantidad Inventario", "sClass": "center" },
                        { "sTitle": "Deporte", "sClass": "center" }
					]
    });
};

function CrearTablaReporteIngresos(aDataSet, fechaInicio, fechaFinal) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    TableTools.DEFAULTS.aButtons = [];
    oTable = $('#example').dataTable({
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "sRowSelect": "single",
            "aButtons": [
				{
				    "sExtends": "pdf",
				    "sButtonText": "Exportar a PDF",
				    "sPdfOrientation": "landscape",
				    "sPdfSize": "A4",
				    "sPdfMessage": "Sistema de Gestíon del Área del Gimnasio                                                                                                                                                                                  Reporte sobre los Ingresos desde " + fechaInicio + " hasta " + fechaFinal + "                                                                                                                                                       generado el: " + fechaHoy,
                    "sNewLine": "\n"
				}
            ],
	    "sSwfPath": "/swf/copy_csv_xls_pdf.swf"

        },
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": aDataSet,
        "oLanguage": {
            "oPaginate": {
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Última",
                "sFirst": "Primera"
            },
            "sLengthMenu": 'Mostrar <select>' +
                                    '<option value="10">10</option>' +
                                    '<option value="20">20</option>' +
                                    '<option value="30">30</option>' +
                                    '<option value="40">40</option>' +
                                    '<option value="50">50</option>' +
                                    '<option value="-1">Todos</option>',

            "sInfo": "Mostrando del _START_ al _END_ de los resultados (Total: _TOTAL_ resultados)",

            "sInfoFiltered": " - filtrados de _MAX_ registros",

            "sInfoEmpty": "No hay resultados de búsqueda",

            "sZeroRecords": "No hay registros a mostrar",

            "sProcessing": "Espere, por favor...",

            "sSearch": "Buscar:"
        },
        "aoColumns": [
						{ "sTitle": "Carné Usuario", "sClass": "center" },
						{ "sTitle": "Fecha Del Ingreso", "sClass": "center" },
                        { "sTitle": "Fecha Del Reporte", "sClass": "center" }
					]
    });
};


function CrearTablaReportePrestamos(aDataSet,fechaInicio, fechaFinal) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    TableTools.DEFAULTS.aButtons = [];
    oTable = $('#example').dataTable({
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "sRowSelect": "single",
            "aButtons": [
				{
				    "sExtends": "pdf",
				    "sButtonText": "Exportar a PDF",
				    "sPdfOrientation": "landscape",
				    "sPdfSize": "A4",
				    "sPdfMessage": "Sistema de Gestíon del Área del Gimnasio                                                                                                                                                                                  Reporte sobre los Préstamos desde " + fechaInicio + " hasta " + fechaFinal + "                                                                                                                                                                                generado el: " + fechaHoy,
				    "sNewLine": "\n"
				}
            ],
            "sSwfPath": "/swf/copy_csv_xls_pdf.swf"

        },
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": aDataSet,
        "oLanguage": {
            "oPaginate": {
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Última",
                "sFirst": "Primera"
            },
            "sLengthMenu": 'Mostrar <select>' +
                                    '<option value="10">10</option>' +
                                    '<option value="20">20</option>' +
                                    '<option value="30">30</option>' +
                                    '<option value="40">40</option>' +
                                    '<option value="50">50</option>' +
                                    '<option value="-1">Todos</option>',

            "sInfo": "Mostrando del _START_ al _END_ de los resultados (Total: _TOTAL_ resultados)",

            "sInfoFiltered": " - filtrados de _MAX_ registros",

            "sInfoEmpty": "No hay resultados de búsqueda",

            "sZeroRecords": "No hay registros a mostrar",

            "sProcessing": "Espere, por favor...",

            "sSearch": "Buscar:"
        },
        "aoColumns": [
						{ "sTitle": "Carné Usuario", "sClass": "center" },
						{ "sTitle": "Fecha Del Préstamo", "sClass": "center" },
                        { "sTitle": "Nombre Préstamo", "sClass": "center" },
                        { "sTitle": "Estado", "sClass": "center" }
					]
    });
};

function CrearTablaReportePrestamosImp(aDataSet, fechaInicio, fechaFinal) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    TableTools.DEFAULTS.aButtons = [];
    oTable = $('#example').dataTable({
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "sRowSelect": "single",
            "aButtons": [
				{
				    "sExtends": "pdf",
				    "sButtonText": "Exportar a PDF",
				    "sPdfOrientation": "landscape",
				    "sPdfSize": "A4",
				    "sPdfMessage": "Sistema de Gestíon del Área del Gimnasio                                                                                                                                                                                  Reporte sobre los Préstamos desde " + fechaInicio + " hasta " + fechaFinal + "                                                                                                                                                                                generado el: " + fechaHoy,
				    "sNewLine": "\n"
				}
            ],
            "sSwfPath": "/swf/copy_csv_xls_pdf.swf"

        },
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": aDataSet,
        "oLanguage": {
            "oPaginate": {
                "sPrevious": "Anterior",
                "sNext": "Siguiente",
                "sLast": "Última",
                "sFirst": "Primera"
            },
            "sLengthMenu": 'Mostrar <select>' +
                                    '<option value="10">10</option>' +
                                    '<option value="20">20</option>' +
                                    '<option value="30">30</option>' +
                                    '<option value="40">40</option>' +
                                    '<option value="50">50</option>' +
                                    '<option value="-1">Todos</option>',

            "sInfo": "Mostrando del _START_ al _END_ de los resultados (Total: _TOTAL_ resultados)",

            "sInfoFiltered": " - filtrados de _MAX_ registros",

            "sInfoEmpty": "No hay resultados de búsqueda",

            "sZeroRecords": "No hay registros a mostrar",

            "sProcessing": "Espere, por favor...",

            "sSearch": "Buscar:"
        },
        "aoColumns": [
						{ "sTitle": "Nombre Implemento", "sClass": "center" },
                        { "sTitle": "Cantidades Prestadas", "sClass": "center" }
					]
    });
};


