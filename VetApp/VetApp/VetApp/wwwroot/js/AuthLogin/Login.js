const contrasenaValor = document.getElementById("password");

const contrasena = contrasenaValor.value;


function validarcontrasena() {
    // Verificar longitud mínima
    if (contrasena.length < 8) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            footer: '<a href="">Why do I have this issue?</a>'
        });
    }

    // Verificar si contiene al menos una letra mayúscula
    if (!/[A-Z]/.test(contrasena)) {
        return "La contrasena debe contener al menos una letra mayúscula.";
    }

    // Verificar si contiene al menos una letra minúscula
    if (!/[a-z]/.test(contrasena)) {
        return "La contrasena debe contener al menos una letra minúscula.";
    }

    // Verificar si contiene al menos un número
    if (!/[0-9]/.test(contrasena)) {
        return "La contrasena debe contener al menos un número.";
    }

    // Verificar si contiene al menos un caracter especial (por ejemplo, !@#$%^&*)
    if (!/[!@#$%^&*]/.test(contrasena)) {
        return "La contrasena debe contener al menos un carácter especial.";
    }

    // La contrasena cumple con todos los criterios
    return "contrasena válida";
}