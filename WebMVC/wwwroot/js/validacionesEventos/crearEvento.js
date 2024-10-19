window.addEventListener("load", inicial);

function inicial() {
    document.querySelector("#botonCrearEvento").addEventListener("click", crearEvento);
}

function crearEvento(e) {
    e.preventDefault();
    let nombreEvento = document.querySelector("#nombreEvento").value;
    let parrafo = document.querySelector("#parrafoEvento");
    let formulario = document.querySelector("#formularioEvento");

    if (nombreEvento == "")
        parrafo.innerHTML = "Elija un nombre";
    else
        formulario.submit(); 
}