window.onload = function () {
    listarEncargado();
}


function listarEncargado() {
    fetch("http://192.168.100.83:8082/api/Encargado")
        .then(res => res.json())
        .then(res => {
            crearListado(res);
        });
}

function crearListado(res) {
    var contenido = "";
    contenido += "<h2>Encargado</h2>";
    document.getElementById("divTabla").innerHTML = contenido;
}



