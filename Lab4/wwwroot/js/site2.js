
function login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    
    if (username === "admin" && password === "password") {
        document.getElementById("message").innerText = "Welcome, " + username + "!";
    } else {
        document.getElementById("message").innerText = "Invalid username or password";
    }
}
