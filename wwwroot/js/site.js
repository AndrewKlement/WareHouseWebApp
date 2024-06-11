var menu = document.getElementById("menuButton")
var navbar = document.getElementById("navbarNav")
var buttons = document.querySelectorAll(".btn")

function toggleMenu() {
    navbar.classList.toggle("active")
}

function modalHandler(event) {
    var mdlTarget = event.target.dataset.target
    var elemnt = document.getElementById(mdlTarget)
    elemnt.style.display = "block" 
}

function modalCloser(event) {
    var mdlTarget = document.querySelectorAll(".modal-fade")
    mdlTarget.forEach(function (elmnt){
        elmnt.style.display = "none"
    })
}

menu.addEventListener("click", toggleMenu)

buttons.forEach(function (button){
    if (button.dataset.toggle == "modal") {
        button.addEventListener("click", modalHandler);
    }
    if (button.dataset.dismiss == "modal") {
        console.log("halo")
        button.addEventListener("click", modalCloser);
    }
})