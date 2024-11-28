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

function renderAlkatreszek(alkatreszek) {
    alkatreszekContainer.innerHTML = ""; // Tartalom törlése

    // Elemek csoportosítása típus szerint
    const grouped = alkatreszek.reduce((groups, item) => {
        if (!groups[item.type]) {
            groups[item.type] = [];
        }
        groups[item.type].push(item);
        return groups;
    }, {});

    // Csoportok megjelenítése
    Object.keys(grouped).forEach((type) => {
        const groupDiv = document.createElement("div");
        groupDiv.className = "group"
        groupDiv.classList.add("group");
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
                    <button>Részletek</button>
                </div>
                <div class="detailed">
                    Morbi rutrum porta porttitor. Nulla sit amet lorem vel metus pretium euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus egestas eleifend libero, at accumsan enim blandit sed. Praesent imperdiet leo at velit porta facilisis vitae eu lacus. Integer dapibus vel ligula sit amet feugiat. Suspendisse vitae enim id lorem iaculis tincidunt. Proin aliquam dignissim erat, sed pulvinar eros vestibulum at. Quisque id congue metus, ac feugiat neque. Quisque at justo tempus, tincidunt tellus pellentesque, sodales enim. Ut ut enim lacus. Duis quis dapibus dolor, sit amet ultricies augue. Morbi sollicitudin ante mi, ut rhoncus massa accumsan iaculis. Duis accumsan ultricies euismod. Suspendisse vitae lacus vitae orci mollis auctor. Aenean accumsan diam risus, sed blandit sem cursus a.
                    Morbi rutrum porta porttitor. Nulla sit amet lorem vel metus pretium euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus egestas eleifend libero, at accumsan enim blandit sed. Praesent imperdiet leo at velit porta facilisis vitae eu lacus. Integer dapibus vel ligula sit amet feugiat. Suspendisse vitae enim id lorem iaculis tincidunt. Proin aliquam dignissim erat, sed pulvinar eros vestibulum at. Quisque id congue metus, ac feugiat neque. Quisque at justo tempus, tincidunt tellus pellentesque, sodales enim. Ut ut enim lacus. Duis quis dapibus dolor, sit amet ultricies augue. Morbi sollicitudin ante mi, ut rhoncus massa accumsan iaculis. Duis accumsan ultricies euismod. Suspendisse vitae lacus vitae orci mollis auctor. Aenean accumsan diam risus, sed blandit sem cursus a.
                    Morbi rutrum porta porttitor. Nulla sit amet lorem vel metus pretium euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus egestas eleifend libero, at accumsan enim blandit sed. Praesent imperdiet leo at velit porta facilisis vitae eu lacus. Integer dapibus vel ligula sit amet feugiat. Suspendisse vitae enim id lorem iaculis tincidunt. Proin aliquam dignissim erat, sed pulvinar eros vestibulum at. Quisque id congue metus, ac feugiat neque. Quisque at justo tempus, tincidunt tellus pellentesque, sodales enim. Ut ut enim lacus. Duis quis dapibus dolor, sit amet ultricies augue. Morbi sollicitudin ante mi, ut rhoncus massa accumsan iaculis. Duis accumsan ultricies euismod. Suspendisse vitae lacus vitae orci mollis auctor. Aenean accumsan diam risus, sed blandit sem cursus a.
                </div>
            `;

            const button = itemDiv.querySelector("button");
            button.addEventListener("click", () => {
                itemDiv.classList.toggle("expanded");
            });

            groupDiv.appendChild(itemDiv);
        });

        alkatreszekContainer.appendChild(groupDiv);
    });
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