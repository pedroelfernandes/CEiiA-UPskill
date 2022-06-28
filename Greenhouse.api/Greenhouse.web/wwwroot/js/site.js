// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var rows = document.getElementById("trans_separate").getElementsByTagName("tbody")
[0].getElementsByTagName("tr");

// loops through each row
for (i = 0; i < rows.length; i++) {
    cells = rows[i].getElementsByTagName('td');
    if (cells[0].innerHTML == 'R')
        rows[i].className = "red";

    if (cells[0].innerHTML == 'Y')
        rows[i].className = "yellow";
}

//Password confirmation

//var password = document.getElementById("password")
//var confirm_password = document.getElementById("oldPassword");

//function validatePassword(){
//    if (password.value != oldPassword.value) {
//        confirm_password.setCustomValidity("Passwords Don't Match");
//    } else {
//        confirm_password.setCustomValidity('');
//    }
//}

//password.onchange = validatePassword;
//confirm_password.onkeyup = validatePassword;

