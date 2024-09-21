window.addEventListener("load", inicio);

function inicio() {
    document.querySelector("#botonModificar").addEventListener("click", validarFormulario);
}

function validarFormulario(e) {
    e.preventDefault();

    let formulario = document.querySelector("#formularioModificar");
    let email = document.querySelector("#emailModificar").value;
    let password = document.querySelector("#passwordModificar").value;
    let parrafoM = document.querySelector("#parrafoModificar");

    if (email == "" || password == "")
        parrafoM.innerHTML = "Debe completar todos los campos";
    else if (!emailEsValido(email))
        parrafoM.innerHTML = "Ingrese un email valido";
    else
        formulario.submit();
}

function emailEsValido(email) {
    let tieneArroba = false;

    for (let i = 0; i < email.length; i++) {
        if (email[i] == "@")
            tieneArroba = true;
    }

    return tieneArroba;
}