document.addEventListener("DOMContentLoaded", function () {
    let form = document.querySelector("#formR");
    let contra = document.querySelector("[name = 'contraseña']");

    form.addEventListener("submit", function (e)
    {
        let contraseña = contra.value;

        if (contraseña.length < 8) {
            //uso preventDefault para evitar que se manden los datos aunque no sean validos y se recargue la pagina o te redireccione
            e.preventDefault();
            alert("la contraseña debe tener al menos 8 caracteres");
            return;
        }

        let tieneLetra = false;
        let tieneNumero = false;

        for (let i = 0; i < contraseña.length; i++) {
            let carac = contraseña[i];

            if (carac >= 'a' && carac <= 'z' || carac >= 'A' && carac <= 'Z') {
                tieneLetra = true;
            } else if (carac >= '0' && carac <= '9') {
                tieneNumero = true;
            } else {
                e.preventDefault();
                alert("la contraseña solo puede contener letras y numeros");
                return;
            }
        }

        if (!tieneLetra || !tieneNumero) {
            e.preventDefault();
            alert("la contraseña debe contener al menos una letra y un numero.");
        }
    });
});
        
    
