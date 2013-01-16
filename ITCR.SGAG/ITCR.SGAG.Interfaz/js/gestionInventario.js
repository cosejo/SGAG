var oTable;
var informacion;

function CrearTablaInventario(aDataSet) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    TableTools.DEFAULTS.aButtons = [];
    oTable = $('#example').dataTable({
    "sDom": 'T<"clear">lfrtip',
					"oTableTools": {
						"sRowSelect": "single"
					},
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": aDataSet,
        "aoColumns": [
                        { "sTitle": "Id Implemento", "sClass": "center"},
						{ "sTitle": "Tipo Implemento", "sClass": "center"},
						{ "sTitle": "Implemento", "sClass": "center" },
						{ "sTitle": "Cantidad Inventario", "sClass": "center" },
                        { "sTitle": "Deporte", "sClass": "center" }
					]
    });

    oTable.$('tr').click(function () {
        var data = oTable.fnGetData(this);
        informacion = data;
        //$('#MainContent_TextBoxInfo').value = data[0];
        //alert('The cell clicked on had the value of '+ data[0]);  
    });
    oTable.fnSetColumnVis( 0, false );
};

function ObtenerDatosModificar()
{
    __doPostBack('Modificar', informacion)
};

function ObtenerDatosEliminar() {
    __doPostBack('Eliminar', informacion)
};

function ObtenerDatosDanos() {
    __doPostBack('Danos', informacion)
};

function RedibujarTabla() {
    oTable.fnDraw();
 };
