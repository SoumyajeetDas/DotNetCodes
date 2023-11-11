// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Calculate() {
    var title = document.getElementById("Title").value;
    console.log(title);

    if (title != "" || title != null) {

        var element = document.getElementById("Alert");
        console.log("This is"+element);
        element.classList.add = "alert-success";
        element.innerHTML = "<h1>Added</h1>";
        console.log(element);
        
    }
    
   
}
