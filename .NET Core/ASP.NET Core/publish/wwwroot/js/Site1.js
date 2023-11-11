var seconds = 0;
var seconds1 = 5;
function myFunction(time)
{
   
    displayseconds();
    setInterval(displayseconds, 1000);

    
    setTimeout('redirectpage()', time*1000);

}
function displayseconds() {
    seconds += 1;
    
    document.getElementById("timing").innerHTML = "Time left " + seconds + " seconds";
    
}


function redirectpage() {
    document.getElementById("myForm").submit();

}

function myFunction1(res) {
    
    document.getElementById("progress").style.width = res + "%";
    
}


function myFunction2() {
    displayseconds1();
    setInterval(displayseconds1, 1000);
    setTimeout('redirectpage1()', 5000);
}

function displayseconds1() {
    seconds1 -= 1;
    console.log("hi");
    if (seconds1 > 0) {
        document.getElementById("time").innerHTML = "Page wiil be redirected in " + seconds1 + " seconds";
    }
   
   

}

function redirectpage1() {
    window.location.replace("http://soumyajeet-001-site1.btempurl.com/Home/Logout");
}


function password_show_hide() {
    var x = document.getElementById("password");
    var show_eye = document.getElementById("show_eye");
    var hide_eye = document.getElementById("hide_eye");
    hide_eye.classList.remove("d-none");
    if (x.type === "password") {
        x.type = "text";
        show_eye.style.display = "none";
        hide_eye.style.display = "block";
    } else {
        x.type = "password";
        show_eye.style.display = "block";
        hide_eye.style.display = "none";
    }
}