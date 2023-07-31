// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Event for hamburger open & close
const burger = document.getElementById("bar");
const close = document.getElementById("close");
const nav = document.getElementById("navbar");

if (burger) {
    burger.addEventListener("click", () => {
        nav.classList.add("active");
    });
}

if (close) {
    close.addEventListener("click", () => {
        nav.classList.remove("active");
    });
}

//Search
const search = document.querySelector("search__btn");

function searchReDir() {

}