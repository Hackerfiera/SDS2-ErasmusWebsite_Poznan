// Cart Number

addEventListener("DOMContentLoaded", (event) => {
    let button = document.getElementById("cart-button")
    cart = []
    if (localStorage.carrito != undefined) {
        cart = JSON.parse(localStorage.carrito);
    }

    button.innerHTML = "Cart (" + cart.length + ")";
});

// Utility
function obtenerNombreCursoPorId(courseId) {
    return fetch(`/Courses/GetNameById/${courseId}`)
        .then(response => response.json())
        .then(data => {
            return { name: data.Name, url: data.Url };
        })
        .catch(error => console.error('Error:', error));
}

// Cart Index

function loadCartDOM() {
    let cartDiv = document.getElementById("cart-items-container");

    if (!cartDiv) {
        return;
    }

    loadCartItems()
}

async function loadCartItems() {
    var cart = getCarrito();

    for (let i = 0; i < cart.length; i++) {
        let courseData = await obtenerNombreCursoPorId(cart[i]);
        addCartItem(cart[i], courseData.name);
    }
}

function addCartItem(id, name) {
    const cartDiv = document.getElementById("cart-items-container");

    console.log(name)

    cartDiv.innerHTML += '<tr><td>' + name + '</td><td><button class="btn btn-danger btn-sm" onclick="removeFromCarrito(' + id + '); location.reload()">Remove from Cart</button></td></tr>';
}


addEventListener("DOMContentLoaded", (event) => {
    loadCartDOM();
});