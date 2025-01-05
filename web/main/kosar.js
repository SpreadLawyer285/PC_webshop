document.addEventListener("DOMContentLoaded", () => {
    const mainKosar = document.querySelector("main");
    const footerSpan = document.querySelector("footer span");
    let cartItems = JSON.parse(localStorage.getItem("cartItems")) || [];
    let totalCost = 0;

    cartItems.forEach((item, index) => {
        const div = document.createElement("div");
        div.innerHTML = item.html;

        div.classList.add("cart-item");

        const kosarbaButton = div.querySelector(".kosarba");
        if (kosarbaButton) kosarbaButton.remove();

        mainKosar.appendChild(div);

        totalCost += item.price;
    });

    updateTotalCost(totalCost);

    mainKosar.addEventListener("click", (e) => {
        if (e.target.classList.contains("remove-item")) {
            const itemDiv = e.target.closest(".cart-item");

            const indexToRemove = Array.from(mainKosar.children).indexOf(itemDiv);
            const itemPrice = cartItems[indexToRemove].price;

            totalCost -= itemPrice;
            updateTotalCost(totalCost);

            itemDiv.remove();

            cartItems.splice(indexToRemove, 1); 
            localStorage.setItem("cartItems", JSON.stringify(cartItems));
        }
    });

    const footer = document.querySelector("footer");
    const clearButton = document.createElement("button");
    clearButton.textContent = "Kosár ürítése";
    clearButton.classList.add("clear-cart");
    footer.appendChild(clearButton);

    clearButton.addEventListener("click", () => {
        mainKosar.innerHTML = "";
        cartItems = [];
        localStorage.setItem("cartItems", JSON.stringify(cartItems));

        totalCost = 0;
        updateTotalCost(totalCost);
    });

    function updateTotalCost(cost) {
        footerSpan.textContent = `Összesen: ${cost} Ft`;
    }
});


const details = itemDiv.querySelector(".details");
const detailed = itemDiv.querySelector(".detailed")
isToggled = false;

            detailed.style.display = "none";

            details.addEventListener("click", () => {
                if (isToggled)
                {
                    detailed.style.display = "none";
                }
                else
                {
                    detailed.style.display = "block";
                }

                isToggled = !isToggled;
            });