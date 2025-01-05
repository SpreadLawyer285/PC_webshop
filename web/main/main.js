const checkboxes = {
    CPU: "cpuCheckbox",
    GPU: "gpuCheckbox",
    SSD: "ssdCheckbox",
    HDD: "hddCheckbox",
    Motherboard: "alaplapCheckbox",
    RAM: "memoriaCheckbox",
    Mouse: "egerCheckbox",
    Keyboard: "billentyuzetCheckbox",
    Monitor: "monitorCheckbox",
};

const alkatreszekContainer = document.getElementById("alkatreszek");

let originalData = []; 

fetch("formatted_computer_parts.txt")
    .then((response) => response.text())
    .then((data) => {
        const alkatreszek = parseData(data);
        originalData = alkatreszek;
        renderAlkatreszek(alkatreszek);
        addFilterListeners(alkatreszek);
    })
    .catch((error) => console.error("Hiba az adatok betöltésekor:", error));

function parseData(data) {
    const lines = data.split("\n").filter((line) => line.trim() !== "");
    return lines.map((line) => {
        const [type, name, brandAndType, price] = line.split(";");
        return { type, name, brandAndType, price };
    });
}

let selectedItems = []; // Az összehasonlítandó elemek
let selectedType = null; // A kiválasztott típus

function renderAlkatreszek(alkatreszek) {
    alkatreszekContainer.innerHTML = ""; // Tartalom törlése

    const grouped = alkatreszek.reduce((groups, item) => {
        if (!groups[item.type]) {
            groups[item.type] = [];
        }
        groups[item.type].push(item);
        return groups;
    }, {});

    Object.keys(grouped).forEach((type) => {
        const groupDiv = document.createElement("div");
        groupDiv.className = "group";
        groupDiv.dataset.type = type;

        groupDiv.innerHTML = `<h2>${type}</h2>`;
        grouped[type].forEach(({ name, brandAndType, price }) => {
            const itemDiv = document.createElement("div");
            itemDiv.classList.add("alkatresz");

            itemDiv.innerHTML = `
                <div class="first">
                    <img src="kepek/${name.replace(/ /g, "_")}.jpg" alt="${name}">
                    <div class="info">
                        <h3>${name}</h3>
                        <p>${brandAndType}</p>
                        <p>${price} Ft</p>
                    </div>
                    <button class="details">Részletek</button>
                    <button class="compare-btn">Összehasonlítás</button>
                    <button class="kosarba">Kosárba</button>
                </div>
                <div class="detailed">
                    Morbi rutrum porta porttitor. Nulla sit amet lorem vel metus pretium euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus egestas eleifend libero, at accumsan enim blandit sed. Praesent imperdiet leo at velit porta facilisis vitae eu lacus. Integer dapibus vel ligula sit amet feugiat. Suspendisse vitae enim id lorem iaculis tincidunt. Proin aliquam dignissim erat, sed pulvinar eros vestibulum at. Quisque id congue metus, ac feugiat neque. Quisque at justo tempus, tincidunt tellus pellentesque, sodales enim. Ut ut enim lacus. Duis quis dapibus dolor, sit amet ultricies augue. Morbi sollicitudin ante mi, ut rhoncus massa accumsan iaculis. Duis accumsan ultricies euismod. Suspendisse vitae lacus vitae orci mollis auctor. Aenean accumsan diam risus, sed blandit sem cursus a.
                    Morbi rutrum porta porttitor. Nulla sit amet lorem vel metus pretium euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus egestas eleifend libero, at accumsan enim blandit sed. Praesent imperdiet leo at velit porta facilisis vitae eu lacus. Integer dapibus vel ligula sit amet feugiat. Suspendisse vitae enim id lorem iaculis tincidunt. Proin aliquam dignissim erat, sed pulvinar eros vestibulum at. Quisque id congue metus, ac feugiat neque. Quisque at justo tempus, tincidunt tellus pellentesque, sodales enim. Ut ut enim lacus. Duis quis dapibus dolor, sit amet ultricies augue. Morbi sollicitudin ante mi, ut rhoncus massa accumsan iaculis. Duis accumsan ultricies euismod. Suspendisse vitae lacus vitae orci mollis auctor. Aenean accumsan diam risus, sed blandit sem cursus a.
                    Morbi rutrum porta porttitor. Nulla sit amet lorem vel metus pretium euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus egestas eleifend libero, at accumsan enim blandit sed. Praesent imperdiet leo at velit porta facilisis vitae eu lacus. Integer dapibus vel ligula sit amet feugiat. Suspendisse vitae enim id lorem iaculis tincidunt. Proin aliquam dignissim erat, sed pulvinar eros vestibulum at. Quisque id congue metus, ac feugiat neque. Quisque at justo tempus, tincidunt tellus pellentesque, sodales enim. Ut ut enim lacus. Duis quis dapibus dolor, sit amet ultricies augue. Morbi sollicitudin ante mi, ut rhoncus massa accumsan iaculis. Duis accumsan ultricies euismod. Suspendisse vitae lacus vitae orci mollis auctor. Aenean accumsan diam risus, sed blandit sem cursus a.
                </div>
            `;

            const details = itemDiv.querySelector(".details");
            const detailed = itemDiv.querySelector(".detailed")
            const compareButton = itemDiv.querySelector(".compare-btn");
            const kosarba = itemDiv.querySelector(".kosarba")

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

            compareButton.addEventListener("click", () => {
                compareButton.style.backgroundColor = "lightgreen"
                if (selectedItems.length === 0) {
                    // Az első elem kiválasztásakor mentjük a típust
                    selectedItems.push({ type, name, brandAndType, price });
                    selectedType = type;
                    updateCompareButtonVisibility();
                } else if (selectedItems.length < 2) {
                    // Ellenőrizzük, hogy azonos típusú-e
                    if (type === selectedType) {
                        selectedItems.push({ type, name, brandAndType, price });
                        updateCompareButtonVisibility();
                        if (selectedItems.length === 2) {
                            disableAllCompareButtons();
                        }
                    } else {
                        alert("Csak azonos típusú termékeket lehet összehasonlítani!");
                        compareButton.style.backgroundColor = "#007BFF"
                    }
                } else {
                    alert("Maximum 2 elemet választhatsz ki összehasonlításra.");
                }
            });

            groupDiv.appendChild(itemDiv);
        });

        alkatreszekContainer.appendChild(groupDiv);
    });
}

function disableAllCompareButtons() {
    const compareButtons = document.querySelectorAll(".compare-btn");
    compareButtons.forEach((button) => {
        button.disabled = true;
        button.style.backgroundColor = "grey";
        button.style.color = "white";
        button.style.cursor = "not-allowed";
    });
}

function updateCompareButtonVisibility() {
    const compareLink = document.getElementById("compare-link");
    if (selectedItems.length === 2) {
        compareLink.classList.remove("hidden");
        localStorage.setItem("compareItems", JSON.stringify(selectedItems));
    } else {
        compareLink.classList.add("hidden");
    }
}

function addFilterListeners(alkatreszek) {
    Object.values(checkboxes).forEach((checkboxId) => {
        const checkbox = document.getElementById(checkboxId);
        checkbox.addEventListener("change", () => {
            const selectedTypes = getSelectedTypes();
            const filtered = selectedTypes.length
                ? alkatreszek.filter((item) => selectedTypes.includes(item.type))
                : alkatreszek;
            renderAlkatreszek(filtered);
        });
    });
}

function getSelectedTypes() {
    return Object.keys(checkboxes).filter(
        (type) => document.getElementById(checkboxes[type]).checked
    );
}

function clearAllCheckboxes() {
    Object.values(checkboxes).forEach((checkboxId) => {
        const checkbox = document.getElementById(checkboxId);
        if (checkbox) {
            checkbox.checked = false;
        }
    });

    renderAlkatreszek(originalData);
}

function updateCompareButtonVisibility() {
    const compareLink = document.getElementById("compare-link");
    if (selectedItems.length === 2) {
        compareLink.classList.remove("hidden");
        localStorage.setItem("compareItems", JSON.stringify(selectedItems));
    } else {
        compareLink.classList.add("hidden");
    }
}

document.addEventListener("DOMContentLoaded", () => {
    const compareItems = JSON.parse(localStorage.getItem("compareItems") || "[]");
    if (compareItems.length === 2) {
        const [firstItem, secondItem] = compareItems;
        const containers = document.querySelectorAll("#osszh_elemek > div");

        containers[0].innerHTML = `
            <h3>${firstItem.name}</h3>
            <p>${firstItem.brandAndType}</p>
            <p>${firstItem.price} Ft</p>
        `;
        containers[1].innerHTML = `
            <h3>${secondItem.name}</h3>
            <p>${secondItem.brandAndType}</p>
            <p>${secondItem.price} Ft</p>
        `;

        const firstPrice = parseInt(firstItem.price.replace(/\D/g, ""));
        const secondPrice = parseInt(secondItem.price.replace(/\D/g, ""));

        if (firstPrice < secondPrice) {
            containers[0].style.backgroundColor = "lightgreen";
        } else {
            containers[1].style.backgroundColor = "lightgreen";
        }
    }
});

document.addEventListener("DOMContentLoaded", () => {
    const cartCount = document.querySelector("#elemek .elem span sub");
    const cartSpan = document.querySelector("#elemek .elem span");
    let cartItems = JSON.parse(localStorage.getItem("cartItems")) || [];

    // Kezdetben rejtjük a span-t, ha nincs termék
    updateCartSpanVisibility();

    // Frissítjük a számlálót
    cartCount.textContent = cartItems.length;

    document.body.addEventListener("click", (e) => {
        if (e.target.classList.contains("kosarba")) {
            const itemDiv = e.target.closest(".alkatresz");

            // Az elem klónozása az osztályokkal és ID-kkal együtt
            const clonedDiv = itemDiv.cloneNode(true);

            // Eltávolítjuk a „Kosárba” gombot a másolatról
            const kosarbaButton = clonedDiv.querySelector(".kosarba");
            if (kosarbaButton) kosarbaButton.remove();

            // Hozzáadunk egy eltávolítás gombot
            const removeButton = document.createElement("button");
            removeButton.textContent = "Eltávolítás";
            removeButton.classList.add("remove-item");
            clonedDiv.appendChild(removeButton);

            // Adatmentés a localStorage-ba
            const itemData = {
                html: clonedDiv.outerHTML,
                price: parseInt(itemDiv.querySelector(".info p:last-child").textContent.replace(/\D/g, ""), 10),
            };

            cartItems.push(itemData);
            localStorage.setItem("cartItems", JSON.stringify(cartItems));

            // Frissítjük a számlálót és a span láthatóságát
            cartCount.textContent = cartItems.length;
            updateCartSpanVisibility();
        }
    });

    function updateCartSpanVisibility() {
        if (cartItems.length > 0) {
            cartSpan.style.display = "inline-block";
        } else {
            cartSpan.style.display = "none";
        }
    }
});