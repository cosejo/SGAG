
var dTable;
var dInformacion;


function ObtenerDatosModificarDanos() {
    __doPostBack('ModificarDaños', dInformacion);
};

function ObtenerDatosEliminarDanos() {
    __doPostBack('EliminarDaños', dInformacion);
};

function CrearTablaDanos(dDataSet) {
    $('#dynamico').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="danos"></table>');
    TableTools.DEFAULTS.aButtons = [];
    dTable = $('#danos').dataTable({
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "sRowSelect": "single"
        },
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": dDataSet,
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
                        { "sTitle": "Id Daño", "sClass": "center" },
                        { "sTitle": "Descripción Implemento", "sClass": "center" },
						{ "sTitle": "Descripción del Daño", "sClass": "center" },
                        { "sTitle": "Cantidades Dañadas", "sClass": "center" },
						{ "sTitle": "Fecha del Daño", "sClass": "center" }
					]
    });

    dTable.$('tr').click(function () {
        var ddata = dTable.fnGetData(this);
        dInformacion = ddata;
        //$('#MainContent_TextBoxInfo').value = data[0];
        //alert('The cell clicked on had the value of '+ data[0]);  
    });
    dTable.fnSetColumnVis(0, false);
};