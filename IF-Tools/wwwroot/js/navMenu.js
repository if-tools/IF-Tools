let navMenuShown = false;
let collapseClass = "collapse";

function toggleNavMenu() {
    let navMenu = document.querySelector(".nav-menu");

    if(navMenuShown) navMenu.classList.add(collapseClass)
    else navMenu.classList.remove(collapseClass);

    navMenuShown = !navMenuShown;
}