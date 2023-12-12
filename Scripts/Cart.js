

var carrito = []

function loadCarrito() {
    if (localStorage.carrito != undefined) {
        carrito = JSON.parse(localStorage.carrito);
    }
}

function getCarrito() {
    return [...carrito];
}

function addToCarrito(courseID) {
    if (carrito.indexOf(courseID) == -1) {
        carrito.push(parseInt(courseID))
        localStorage.setItem("carrito", JSON.stringify(carrito));
    }
}

function removeFromCarrito(courseID) {
    if (carrito.indexOf(courseID) >= 0) {
        carrito.splice(carrito.indexOf(courseID), 1)
        localStorage.setItem("carrito", JSON.stringify(carrito));
    }
}

function emptyCarrito() {
    carrito = [];
    localStorage.setItem("carrito", JSON.stringify(carrito));
}

function getCarritoString() {
    return carrito.join(",");
}

function loadAddToCartButton(parent) {
    var button = document.createElement("button");
    var courseID = parseInt(parent.dataset.courseid);
    parent.appendChild(button)
    button.classList.add("btn")
    if (carrito.indexOf(courseID) == -1) {
        button.innerHTML = "Add to Cart";
        button.classList.add("btn-success")
        button.onclick = function () {
            addToCarrito(courseID);
            location.reload()
        };
    } else {
        button.innerHTML = "Remove from Cart";
        button.classList.add("btn-danger")
        button.onclick = function () {
            removeFromCarrito(courseID);
            location.reload()
        };
    }
    

}

addEventListener("DOMContentLoaded", (event) => {
    let button = document.getElementById("cartButton");
    loadCarrito()
    if (button) {
        loadAddToCartButton(button)
    }
});




