//Validación de formulario.
const formulario = document.getElementById('form');

const validar = (e) => {
    const inputNombre = document.getElementById('Nombre'),
        inputRaza = document.getElementById('Raza'),
        inputEspecie = document.getElementById('Especie'),
        inputSexo = document.getElementById('Sexo');
        alertError = document.getElementById('alertError');

    if (inputNombre.value == 0 || inputRaza.value == 0 || inputEspecie.value == 0 || inputSexo.value == 'sexo') {
        e.preventDefault();
        alertError.classList.remove('hide');
        alertError.classList.add('show');
        setTimeout(() => {
            alertError.classList.remove('show');
            alertError.classList.add('hide');
        }, 2000);
    }
}   

//Eventos del formulario.
formulario.addEventListener('submit', validar);