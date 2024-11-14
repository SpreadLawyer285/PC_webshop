let componentsData = {};

function loadComponents() {
    fetch('components.txt')
    .then(response => response.text())
    .then(data => {
        const lines = data.split('\n').filter(line => line.trim() !== '');
        lines.forEach(line => {
            const [category, name, price, parameter] = line.split(';').map(item => item.trim());
            const parameterList = parameter.split(',').map(param => param.trim());
            if (!componentsData[category]) componentsData[category] = [];
            componentsData[category].push({name, parameter: parameterList, price})
        });
        console.log('Betöltött adatok:', componentsData)
    })
    .catch(error => console.error('Hiba az adatok betöltésekor:', error));
}

function showOptions(category){
    const modal = document.getElementById('modal');
    const title = document.getElementById('modal-title');
    const optionsList = document.getElementById('options-list');

    if (!componentsData[category] || componentsData[category].length === 0){
        alert(`Nincs elérhető adat ehhez a kategóriához: ${category}`);
        return;
    }

    optionsList.innerText = '';
    title.innerText = `Válassz ${category.toUpperCase()} típust`;

    componentsData[category].forEach(item => {
        const li = document.createElement('li');
        li.innerHTML = `${item.name}  ${item.price} Ft (${item.parameter}) <button onclick="addComponent('${category}', '${item.name}')">Hozzáadás</button>`;
        optionsList.appendChild(li);
    });

    modal.style.display = 'block';

}

function closeModal() {
    document.getElementById('modal').style.display = 'none';
}

function addComponent(category, name) {
    console.log(`Hozzáadva: ${name} (${category})`);
    closeModal();
}

window.onload = loadComponents;