﻿function CrearTablaInventario(aDataSet) {
    $('#dynamic').html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
    $('#example').dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "aaData": aDataSet,
        "aoColumns": [
						{ "sTitle": "Engine" },
						{ "sTitle": "Version", "sClass": "center" },
						{ "sTitle": "Grade", "sClass": "center" }
					]
    });
};