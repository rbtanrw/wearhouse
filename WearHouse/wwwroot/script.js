const nav = document.querySelector('.nav-nav');
document.querySelector('.hamburger').onclick = () => {
  nav.classList.toggle('active');
}

function validatePassword(){
    var password = document.getElementById("password").value;
    var confirm = document.getElementById("confirm").value;

    if(confirm != password){
        alert("Wrong input on Confirm Password");
        return false;
    }

    var checkbox = document.getElementById("checkbox");
    if(!checkbox.checked){
        alert("Please agree to the terms and conditions before submitting");
        return false;
    }

    return true;
}

var categoryBody = document.getElementById("category-body");
var rows = categoryBody.getElementsByTagName("tr");

for(var i = 0 ; i < rows.length ; i++){
    if(i%2 === 0){
        rows[i].classList.add("even");
    }
    else{
        rows[i].classList.add("odd");
    }
}

function openPopup(popupId) {
    var popup = document.getElementById(popupId);
    popup.style.display = "block";
}