function myfunction() {
    var text = document.getElementById("Customer_Name").value;
    var reg = /^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$/;
 
    var a = reg.test(text);
    if (!reg.test(text)) {
        document.getElementById("text").innerText = "No";

    }
    else {
        document.getElementById("text").innerText = "Yes";
        document.getElementById("text").style.color = "green";
    }
    
/*    document.getElementById("check").style.backgroundColor = "#839192";*/
}