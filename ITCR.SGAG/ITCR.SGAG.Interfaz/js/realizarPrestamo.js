
var _MensajeAlerta = '';
var _ListaTextBoxDurante = new Array();

function OnLoad() {

    //document.getElementById("li_realizarPrestamo").className = "active";

    if (_MensajeAlerta != '') {
        alert(_MensajeAlerta);
    }

    VerificarTxtDurante(_ListaTextBoxDurante);

}

function VerificarTxtDurante(pIdsTextBox) {
    for (var i = 1; i < pIdsTextBox.length; i++) {
        var textboxDurante = document.getElementById('MainContent_' + pIdsTextBox[i]);
        if (textboxDurante != null) {
            if (isNaN(textboxDurante.value)) {
                alert('Debe ingresar un número');
                textboxDurante.value = '1';
            } 
        }
    }
}
