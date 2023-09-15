function Validate() {
    
    var userName = document.getElementById("ContentPlaceHolder1_userName").value;
    var password = document.getElementById("password").value;
    console.log(password);
    if (userName == "" || password == "") {
        alert("You must Enter UserName and Password");
        return false;
    }
    return true;
}