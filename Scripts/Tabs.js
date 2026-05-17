// Sidebar Function Start

function sidebarF() { 

let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".fa-magnifying-glass");

closeBtn.addEventListener("click", () => {
    sidebar.classList.toggle("open");
});

searchBtn.addEventListener("click", () => { // Sidebar open when you click on the search iocn
    sidebar.classList.toggle("open");
});

}
// Sidebar Function End

// Tabs Function Start

function showPanel(evt, panelName) {

    var i, panels, navbuttons;

    panels = document.getElementsByClassName("col-lg-12");

    for (i = 0; i < panels.length; i++) { 
        panels[i].style.display = "none";    
    }

    navbuttons = document.getElementsByClassName("nav-link");
    for (i = 0; i < navbuttons.length; i++) {
        navbuttons[i].className = navbuttons[i].className.replace(" active", "");
    }

    document.getElementById(panelName).style.display = "grid";
    evt.currentTarget.className += " active";
}

// Tabs Function End
