window.addEventListener("load", inicio);

function inicio(){
    document.querySelector("#botonCrear").addEventListener("click", verificar);
}

function verificar(e) {
    e.preventDefault();

    let formulario = document.querySelector("#formulario");
    let parrafo = document.querySelector("#parrafo");
    let email = document.querySelector("#email").value;
    let password = document.querySelector("#password").value;

    if (emailEsValido(email) && passwordEsValida(password))
        formulario.submit();
    else if (email == "" || password == "")
        parrafo.innerHTML = "Debe completar todos los campos";
    else
        parrafo.innerHTML = "La contraseña debe contener al menos: una mayúscula, una minúscula, un número y un signo de puntuación";
}

function passwordEsValida(password) {

    let tieneMinuscula = false;
    let tieneMayuscula = false;
    let tieneNumero = false;
    let tieneSignoDePuntuacion = false;

    for (let i = 0; i < password.length; i++) {
        if (password.charCodeAt(i) >= 97 && password.charCodeAt(i) <= 122)
            tieneMinuscula = true;
        if (password.charCodeAt(i) >= 65 && password.charCodeAt(i) <= 90)
            tieneMayuscula = true;
        if (password.charCodeAt(i) >= 48 && password.charCodeAt(i) <= 57)
            tieneNumero = true;
        if (password[i] == "." || password[i] == "," || password[i] == ":" || password[i] == ";" || password[i] == "!")
            tieneSignoDePuntuacion = true;      
    }

    if (tieneMinuscula && tieneMayuscula && tieneNumero && tieneSignoDePuntuacion && password.length >= 6)
        return true;
    else
        return false;
}

function emailEsValido(email) {
    let tieneArroba = false;

    for (let i = 0; i < email.length; i++) {
        if (email[i] == "@")
            tieneArroba = true;
    }

    return tieneArroba;
}
