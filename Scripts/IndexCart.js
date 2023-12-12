function loadCartDOM() {
    let cartDiv = document.getElementById("cart-items-container");

    if (!cartDiv) {
        return;
    }

    loadCartItems()
}

function loadCartItems() {
    var cart = getCarrito();

    cart.forEach((id) => {
        let courseData = obtenerNombreCursoPorId(id);
        addCartItem(id, courseData.name);
    })
}

function addCartItem(id, name) {
    const cartDiv = document.getElementById("cart-items-container");

    cartDiv.innerHTML += `
    <tr>
        <td>${name}</td>
        <td><button class="btn btn-danger btn-sm" onclick="removeFromCarrito(${id})">Remove from Cart</button></td>
    </tr>;
`
}


addEventListener("DOMContentLoaded", (event) => {
    loadCartDOM();
});