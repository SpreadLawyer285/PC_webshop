// Adatok betöltése egy TXT-fájlból
fetch('parts.txt') // A fájl elérési útja
    .then(response => response.text())
    .then(data => processParts(data)) // Az adatok feldolgozása
    .catch(error => console.error('Hiba a fájl betöltésekor:', error));


    function processParts(partsData) {
        // Alkatrészek feldolgozása
        const parts = partsData.trim().split('\n').map(line => {
            const [type, name, price, details] = line.split(';');
            return { type, name, price: parseInt(price, 10), details };
        });
    
        // Adatok szűrése és csoportosítása
        const groupedByType = groupBy(parts, 'type');
        const groupedByBrand = groupBy(parts, part => part.name.split(' ')[0]); // Márka az első szó
        const sortedByPrice = [...parts].sort((a, b) => a.price - b.price); // Ár szerint növekvő sorrend
    
        // Megjelenítés
        displayParts(groupedByType, 'type');
        console.log('Csoportosítás márka szerint:', groupedByBrand);
        console.log('Ár szerint növekvő:', sortedByPrice);
    }
    
    // Helper függvény csoportosításhoz
    function groupBy(array, key) {
        return array.reduce((result, item) => {
            const groupKey = typeof key === 'function' ? key(item) : item[key];
            if (!result[groupKey]) result[groupKey] = [];
            result[groupKey].push(item);
            return result;
        }, {});
    }
    

    function displayParts(groupedParts, groupBy) {
        const alkatreszekSection = document.getElementById('alkatreszek');
        alkatreszekSection.innerHTML = '';
    
        Object.keys(groupedParts).forEach(group => {
            const groupDiv = document.createElement('div');
            groupDiv.id = group.toLowerCase();
            groupDiv.classList.add('group');
            groupDiv.innerHTML = `<h3>${group} (${groupBy})</h3>`;
    
            groupedParts[group].forEach(part => {
                const partDiv = document.createElement('div');
                partDiv.classList.add('part');
    
                const imageDiv = document.createElement('div');
                imageDiv.classList.add('image');
                imageDiv.innerHTML = `<img src="images/${part.name.replace(/\s+/g, '_').toLowerCase()}.jpg"}">`;
    
                const detailsDiv = document.createElement('div');
                detailsDiv.classList.add('details');
                detailsDiv.innerHTML = `
                    <h4>${part.name}</h4>
                    <p>Ár: ${part.price} Ft</p>
                    <p>${part.details}</p>
                `;
    
                const buttonDiv = document.createElement('div');
                buttonDiv.classList.add('button');
                const button = document.createElement('button');
                button.textContent = 'További részletek';
                button.addEventListener('click', () => {
                    alert(`Részletek:\nNév: ${part.name}\nÁr: ${part.price} Ft\n${part.details}`);
                });
                buttonDiv.appendChild(button);
    
                partDiv.appendChild(imageDiv);
                partDiv.appendChild(detailsDiv);
                partDiv.appendChild(buttonDiv);
                groupDiv.appendChild(partDiv);
            });
    
            alkatreszekSection.appendChild(groupDiv);
        });
    }
    
    