window.addEventListener("load", inicial);

function inicial() {
    document.querySelector("#botonAsignarPuntaje").addEventListener("click", asignarPuntaje);
}

function asignarPuntaje(p) {
    p.preventDefault();
    let puntaje = document.querySelector("#Puntaje").value;
    let parrafo = document.querySelector("#parrafoPuntaje");
    let formulario = document.querySelector("#formularioEvento");

    if (puntaje < 0)
        parrafo.innerHTML = "El puntaje no puede ser menor a 0";
    else
        formulario.submit(); 
}