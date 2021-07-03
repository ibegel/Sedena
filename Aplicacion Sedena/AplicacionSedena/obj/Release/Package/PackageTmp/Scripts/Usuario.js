window.onload = function () {
    listarUsuario();
}



function listarUsuario()
{
    fetch("http://192.168.100.83:8082/api/Usuario")
        .then(res => res.json())
        .then(res => {
            crearListado(res);
        });
}

function crearListado(res) {
    var contenido = "";
    contenido += "<h2>Usuarios</h2>";
    
    contenido += "<table class='table table-hover table-dark'>";
    contenido += "<thead class='thead-dark'>"
    contenido += "<tr>";
    contenido += "<td>Id_Usuario</td>";
    contenido += "<td>Clase</td>";
    contenido += "<td>Rango</td>";
    contenido += "<td>Nombre</td>";
    contenido += "<td>Operaciones</td>";
    contenido += "</tr>";
    contenido += "</thead>"
    contenido += "<tbody id='varias'>";
    for (var i = 0; i < res.length; i++) {
        contenido += "<tr class='opc'>";
        contenido += "<td>" + res[i].id_Usuario + "</td>";
        contenido += "<td>" + res[i].clave + "</td>";
        contenido += "<td>" + res[i].rango + "</td>";
        contenido += "<td>" + res[i].nombre + "</td>";
        contenido += "<td>";
        contenido += "<button onclick='AbrirModal(" + res[i].id_Usuario + ")' type='button' class='btn btn-outline-light btn-sm' data-bs-toggle='modal' data-bs-target='#exampleModal'>Editar</button>";
        contenido += "<button onclick='Eliminar(" + res[i].id_Usuario + ")' type='button' class='btn btn-outline-light btn-sm'>Eliminar</button>";
        contenido += "</td>";

        contenido += "</tr>";
    }

    contenido += "</tbody>";
    contenido += "</table>";
    document.getElementById("divTabla").innerHTML = contenido;
}

function Eliminar(iidUsuario) {
    if (confirm("Desea Eliminar Realmente") == 1)
    {
        fetch("http://192.168.100.83:8082/api/Usuario?id_Usuario=" + iidUsuario, {
            method: "PUT"
        }).then(res => res.json())
            .then(res => {
                if (res == 1) {
                    alert("Se elimino correctamente");
                    listarUsuario();
                }
                else {
                    alert("No se elimino");
                }
            })
    }
}

function Limpiar() {
    var limpiar = document.getElementsByClassName("limpiar");
    var nlimpiar = limpiar.length;
    for (var i = 0; i < nlimpiar; i++) {
        limpiar[i].value = "";
    }
}

function AbrirModal(id)
{
    Limpiar();
    if (id == 0)
    {
        document.getElementById("tclave").value = "D-";
        document.getElementById("lbltitulo").innerHTML = "Agregar Doctor";
    }
    else
    {
        fetch("http://192.168.100.83:8082/api/Usuario?id_Usuario=" + id)
            .then(res => res.json())
            .then(res => {

                document.getElementById("tid_Usuario").value = res.id_Usuario;
                document.getElementById("tnombre").value = res.nombre;
                document.getElementById("tclave").value = res.clave;
                document.getElementById("cborango").value = res.rango;

            });



        document.getElementById("lbltitulo").innerHTML = "Editar Doctor";
    }
}

function Guardar() {
    if (confirm("Desea Guardar los Cambios") == 1)
    {
        var jid= document.getElementById("tid_Usuario").value;
        var jclave=document.getElementById("tclave").value;
        var jrango=document.getElementById("cborango").value;
        var jnombre = document.getElementById("tnombre").value;
        if (jid == null||jid==0)
        {
            fetch("http://192.168.100.83:8082/api/Usuario")
                .then(res => res.json())
                .then(res => {
                    jid = res.length+1;
                });
        }
        fetch("http://192.168.100.83:8082/api/Usuario",
            {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: 'POST',
                body: JSON.stringify({
                    "Id_Usuario": jid,
                    "Clave": jclave,
                    "Rango": jrango,
                    "Nombre": jnombre
                })
            }).then(res => res.json())
            .then(res => {
                if (res == 1) {
                    alert("Se ejecuto correctamente");
                    listarUsuario();
                    document.getElementById("btnClose").click();
                }
                else
                {
                    alert("Error");
                }
            })
    }

}

