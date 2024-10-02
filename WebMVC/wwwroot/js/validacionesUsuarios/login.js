window.addEventListener("load", inicioLogin);

function inicioLogin() {
    document.querySelector("#botonLogin").addEventListener("click", validarLogin);
}

function validarLogin(e) {
    e.preventDefault();

    let form = document.querySelector("#formularioLogin");
    let email = document.querySelector("#emailLogin").value;
    let password = document.querySelector("#passwordLogin").value;
    let parrafo = document.querySelector("#parrafoLogin");

    if (email == "" || password == "")
        parrafo.innerHTML = "Debe completar todos los campos";
    else
        form.submit();
}
