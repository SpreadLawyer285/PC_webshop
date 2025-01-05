document.addEventListener("DOMContentLoaded", () => {
    const mainKosar = document.querySelector("main");
    const footerSpan = document.querySelector("footer span");
    let cartItems = JSON.parse(localStorage.getItem("cartItems")) || [];
    let totalCost = 0;

    // Kosár elemek megjelenítése
    cartItems.forEach((item, index) => {
        const div = document.createElement("div");
        div.innerHTML = item.html;

        // Hozzáadunk egy egyedi osztályt
        div.classList.add("cart-item");

        // Eredeti kosár gomb eltávolítása
        const kosarbaButton = div.querySelector(".kosarba");
        if (kosarbaButton) kosarbaButton.remove();

        // Eltávolítás gomb hozzáadása

        // Hozzáadjuk a main elemhez
        mainKosar.appendChild(div);

        // Összes költség frissítése
        totalCost += item.price;
    });

    // Frissítjük az összköltséget
    updateTotalCost(totalCost);

    // Egyedi elem eltávolítása
    mainKosar.addEventListener("click", (e) => {
        if (e.target.classList.contains("remove-item")) {
            const itemDiv = e.target.closest(".cart-item");

            // Meghatározzuk az elem indexét a cartItems tömbben
            const indexToRemove = Array.from(mainKosar.children).indexOf(itemDiv);
            const itemPrice = cartItems[indexToRemove].price;

            // Frissítjük az összköltséget
            totalCost -= itemPrice;
            updateTotalCost(totalCost);

            // Eltávolítjuk az elemet a DOM-ból
            itemDiv.remove();

            // Frissítjük a localStorage tartalmát
            cartItems.splice(indexToRemove, 1); // Töröljük az elemet a tömbből
            localStorage.setItem("cartItems", JSON.stringify(cartItems));
        }
    });

    // Kosár ürítése
    const footer = document.querySelector("footer");
    const clearButton = document.createElement("button");
    clearButton.textContent = "Kosár ürítése";
    clearButton.classList.add("clear-cart");
    footer.appendChild(clearButton);

    clearButton.addEventListener("click", () => {
        // Minden elem eltávolítása
        mainKosar.innerHTML = "";
        cartItems = [];
        localStorage.setItem("cartItems", JSON.stringify(cartItems));

        // Ár nullázása
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