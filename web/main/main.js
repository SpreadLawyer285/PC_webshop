// A checkboxok azonosítói
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

// Az alkatrészek szekció
const alkatreszekContainer = document.getElementById("alkatreszek");

// Adatok betöltése és szűrő hozzáadása
fetch("formatted_computer_parts.txt")
    .then((response) => response.text())
    .then((data) => {
        const alkatreszek = parseData(data);
        renderAlkatreszek(alkatreszek);
        addFilterListeners(alkatreszek);
    })
    .catch((error) => console.error("Hiba az adatok betöltésekor:", error));

// Adatok feldolgozása
function parseData(data) {
    const lines = data.split("\n").filter((line) => line.trim() !== "");
    return lines.map((line) => {
        const [type, name, brandAndType, price] = line.split(";");
        return { type, name, brandAndType, price };
    });
}

// Alkatrészek megjelenítése
function renderAlkatreszek(alkatreszek) {
    alkatreszekContainer.innerHTML = ""; // Előző tartalom törlése
    alkatreszek.forEach(({ type, name, brandAndType, price }) => {
        const div = document.createElement("div");
        div.classList.add("alkatresz");
        div.dataset.type = type;

        // Hozzáadás az alkatrész div-hez
        div.innerHTML = `
            <div class="first">
                <img src="kepek/${name.replace(/ /g, "_")}.jpg" alt="${name}">
                <div class="info">
                    <h3>${name}</h3>
                    <p>${brandAndType}</p>
                    <p>${price} Ft</p>
                </div>
                <button>Részletek</button>
            </div>
            <div class="detailed">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vehicula est at elit scelerisque, a fermentum orci varius.
            </div>
        `;

        // Gomb esemény hozzáadása
        const button = div.querySelector("button");
        button.addEventListener("click", () => {
            div.classList.toggle("expanded");
        });

        alkatreszekContainer.appendChild(div);
    });
}

// Szűrő hozzáadása
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

// Kiválasztott típusok lekérése
function getSelectedTypes() {
    return Object.keys(checkboxes).filter(
        (type) => document.getElementById(checkboxes[type]).checked
    );
}
