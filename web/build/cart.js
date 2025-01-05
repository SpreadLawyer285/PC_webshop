window.onload = function() {
    const cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    const totalPrice = localStorage.getItem('totalPrice') || 0;

    const cartItemsDiv = document.getElementById('cart-items');
    const totalPriceSpan = document.getElementById('cart-total-price');
    totalPriceSpan.innerText = `${totalPrice} Ft`;

    cartItems.forEach(item => {
        const div = document.createElement('div');
        div.classList.add('cart-item');
        div.innerHTML = `
            <h3>${item.category}: ${item.name}</h3>
            <p>Ár: ${item.price}</p>
        `;
        cartItemsDiv.appendChild(div);
    });
};

function placeOrder() {
    const name = document.getElementById('name').value;
    const address = document.getElementById('address').value;
    const email = document.getElementById('email').value;

    if (!name || !address || !email) {
        alert('Kérlek töltsd ki az összes mezőt!');
        return;
    }

    alert(`Rendelés leadva! Köszönjük, ${name}.`);
    localStorage.clear();
    window.location.href = 'config.html'; 
}
