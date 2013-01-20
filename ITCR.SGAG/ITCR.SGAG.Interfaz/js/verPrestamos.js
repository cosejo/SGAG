
var _PrestamoSeleccionado;

function OnLoad() {

    document.getElementById("li_prestamosDevoluciones").className = "active";

}

function CrearTablaPrestamos (aDataSet) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    var tablaPrestamos = $('#example').dataTable({
        "sScrollY": "200px",
        "bPaginate": false,
        "bJQueryUI": true,
        "aaData": aDataSet,
        "aoColumns": [
            { "sTitle": "ID" },
            { "sTitle": "Identificación" },
			{ "sTitle": "Nombre" },
			{ "sTitle": "Fecha Préstamo" },
			{ "sTitle": "Tipo"},
			{ "sTitle": "Estado"}
		    ],
        "oLanguage": {
            "sZeroRecords": "No se han encontrado préstamos pendientes",
			"sInfo": "Se han encontrado _TOTAL_ préstamos pendientes",
			"sInfoEmpty": "No hay resultados por mostrar",
			"sInfoFiltered": "(búsqueda para los _MAX_ préstamos pendientes)",
			"sSearch": "Buscar:"
            },
        "sDom": '<"H"Tfr>t<"F"ip>',
		"oTableTools": {
			"sRowSelect": "single",
			"aButtons": []
			},
        "aoColumnDefs": [
            { "bSearchable": false, "bVisible": false, "aTargets": [0] }
			]
    });

    tablaPrestamos.$('tr').click(function () {
        var ddata = tablaPrestamos.fnGetData(this); //obtiene los datos de la fila
        _PrestamoSeleccionado = ddata[0];
    });

};

function MostrarDetallePrestamo() {
    __doPostBack('MostrarDetallePrestamo', _PrestamoSeleccionado);
};