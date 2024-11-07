let componentsData = {};

// Adatok betöltése a fájlból
function loadComponents() {
    fetch('components.txt') // A fájl elérési útja
    .then(response => response.text())
    .then(data => {
      const lines = data.split('\n').filter(line => line.trim() !== ''); // Üres sorok kizárása
      lines.forEach(line => {
        const [category, name, price, specs] = line.split(';').map(item => item.trim()); // Szóközök törlése
        if (!componentsData[category]) componentsData[category] = [];
        componentsData[category].push({ name, price, specs });
      });
      console.log('Betöltött adatok:', componentsData); // Ellenőrzés
    })
    .catch(error => console.error('Hiba az adatok betöltésekor:', error));
}

// Modal ablak megnyitása
function showOptions(category) {
  const modal = document.getElementById('modal');
  const title = document.getElementById('modal-title');
  const optionsList = document.getElementById('options-list');

  // Ellenőrizzük, hogy van-e adat az adott kategóriához
  if (!componentsData[category] || componentsData[category].length === 0) {
    alert(`Nincs elérhető adat ehhez a kategóriához: ${category}`);
    return;
  }

  // Töröljük a korábbi elemeket
  optionsList.innerHTML = '';
  title.innerText = `Válassz ${category.toUpperCase()} típust`;

  // Típusok hozzáadása a listához
  componentsData[category].forEach(item => {
    const li = document.createElement('li');
    li.innerHTML = `${item.name} - ${item.price} Ft (${item.specs}) <button onclick="addComponent('${category}', '${item.name}')">Hozzáadás</button>`;
    optionsList.appendChild(li);
  });

  modal.style.display = 'block';
}

// Modal ablak bezárása
function closeModal() {
  document.getElementById('modal').style.display = 'none';
}

// Kiválasztott komponens hozzáadása
function addComponent(category, name) {
  console.log(`Hozzáadva: ${name} (${category})`);
  closeModal();
}

// Az oldal betöltésekor az adatok betöltése
window.onload = loadComponents;
