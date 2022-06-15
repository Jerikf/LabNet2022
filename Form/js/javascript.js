

function clearForm() {
    console.log("%c holisssss estoy limpiando el formulario", "color:tomato");
    const form = document.getElementById("formulario");
    form.reset();
  }

const handlerInput = (id) => {
    const element = document.getElementById(id);
    element.value.trim() === ""
      ? (element.style.border = "2px solid red")
      : (element.style.border = "2px solid green");
};

const calculateAge = (dateOfBirth) =>{
  
  //TIENE MARGEN DE ERROR EN HORAS
    var today = new Date();
    var birthDate = new Date(dateOfBirth);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}


const validarGender = () =>{
    return document.getElementById("male").checked || document.getElementById("female").checked  || document.getElementById("other").checked ;
}

const validarCamposCompletos = () => {
    const name = document.getElementById("name").value;
    const lastName = document.getElementById("lastName").value;
    const city = document.getElementById("city").value;
    const zip_code = document.getElementById("zip_code").value;
    const date = document.getElementById("date").value;
    const empresa = document.getElementById("empresa").value;
    return (name && lastName && city && zip_code && date && empresa && validarGender());
}

const sub = (e) => {
    //e.preventDefault(); // Evita el comportamiento de enviar la información al servidor
    // VALIDAR SI TODOS LOS DATOS ESTÀN CARGADOS CORRECTAMENTE --> OSEA QUE NO HAYA NINGÙN VACÌO
    if(!validarCamposCompletos()){
        alert("UPS! AÙN FALTA COMPLETAR DATOS!");
        e.preventDefault();
    }else{
        console.log("--------ACÀ PODRÌA IR VALIDAR CADA CAMPO DEL INPUT... QUE SEA EL TIPO DE DATO CORRECTO, PERO LO HICIMOS EN EL HTML, aunque serìa mejor cuando ocurre el evento blur porque asì evalua luego de escribir cada campo..-----------");
        //Me limpia el formulario --> evito que al mostrar el show_data.html me llegue los campos vacios, asì que se ejecuta luego de los 30milisegundos
        setTimeout(() => {
          clearForm();
        }, 30);
    }
};


   

function start() {
    
    
    const form = document.getElementById("formulario");
    form.addEventListener("submit", sub)
  
    /* Si tuviera muchos màs campos de input no voy a estar agregando manualmente el evento blur, utilizaria querySelectorAll("#formulario input") -->me trae todos los imputs que estèn en el formulari y ya con un iterador asigno el evento blur */
    document.getElementById("name").addEventListener("blur", function () {
      handlerInput("name");
    }); 
    document
      .getElementById("lastName")
      .addEventListener("blur", () => handlerInput("lastName")); 

    document
      .getElementById("city")
      .addEventListener("blur", () => handlerInput("city")); 

    document
      .getElementById("zip_code")
      .addEventListener("blur", () => handlerInput("zip_code")); 
    
    document
      .getElementById("empresa")
      .addEventListener("blur", () => handlerInput("empresa")); 

    document
      .getElementById("date")
      .addEventListener("blur", () => handlerInput("date"));
    
    //Evento change --> cada vez que modifico el input de Fecha me calcularà la edad

    document.getElementById("date").addEventListener("change", function(){
      if(this.value){
        document.getElementById("age").innerHTML = `La edad es : ${calculateAge(this.value)} años`;
        console.log(this.value);
      }

    });
    

  };
  

window.onload = start; // Cuando el DOM este cargado se ejecuta la funcion start;
