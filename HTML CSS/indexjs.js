function myfunction(){
    window.alert(5+6);
}


function formSumbmition(){
    window.alert("Form is submitted!");
}

function getFoundationPrice(productVolume, efficiency, layersPerApplication){
    return efficiency * productVolume / layersPerApplication;
}

document.getElementById("foundationPrice").innerHTML = 'Foundation price per layer:' + getFoundationPrice(100, 30, 1) + 'kuna';

function arrayOfProducts(){
    const Products = ["Foundation" , "Blush" , "Mascara" , "Concealer" , "Lipstick" ,"Eyeliner" , "Eyeshadow"];
    let prodLength = Products.length;

    let text = "<ul>";
    for(let i=0; i<prodLength;i++){
        text += "<li>" + Products[i] + "</li>";
    }
    text += "</ul>";
}

document.getElementByClass("demo").innerHTML = text;



// kreiranje objekta

const makeupProducts = {type: "Mascara", brand: "Maybelline", color: "black"}
document.getElementById("makeup").innerHTML = "The type of mascara we use is: " + makeupProducts.type;

const employees = {
    name: "Jessica",
    lastName: "Smith",
    specialization: "Facial sector"
}


document.getElementById("firstEmployeeName").innerHTML = employees.name;
document.getElementById("firstEmployeeLastName").innerHTML = employees.lastName;
document.getElementById("firstEmployeeSpecialization").innerHTML = employees.specialization;

// let ne moze biti redeklariran !
// drugi nacin pristupa objektu: employees['lastName'];

// object prototype 

function Employee(name, lastName, specialization){
    this.name = name;
    this.lastName = lastName;
    this.specialization = specialization;
}

//definiranje objekta
const boss = new Employee('Marina','Marich','MakeUp Artist');

name : {
    nickname: 'Mara'
}

// pristupanje : boss.name.nickname  ili boss['name']['nickname]
