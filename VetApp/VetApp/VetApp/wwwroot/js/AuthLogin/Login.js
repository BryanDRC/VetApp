const contrasenaValor = document.getElementById("password");

const contrasena = contrasenaValor.value;


function validarcontrasena() {
    // Verificar longitud m�nima
    if (contrasena.length < 8) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            footer: '<a href="">Why do I have this issue?</a>'
        });
    }

    // Verificar si contiene al menos una letra may�scula
    if (!/[A-Z]/.test(contrasena)) {
        return "La contrasena debe contener al menos una letra may�scula.";
    }

    // Verificar si contiene al menos una letra min�scula
    if (!/[a-z]/.test(contrasena)) {
        return "La contrasena debe contener al menos una letra min�scula.";
    }

    // Verificar si contiene al menos un n�mero
    if (!/[0-9]/.test(contrasena)) {
        return "La contrasena debe contener al menos un n�mero.";
    }

    // Verificar si contiene al menos un caracter especial (por ejemplo, !@#$%^&*)
    if (!/[!@#$%^&*]/.test(contrasena)) {
        return "La contrasena debe contener al menos un car�cter especial.";
    }

    // La contrasena cumple con todos los criterios
    return "contrasena v�lida";
}