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
        const name_div = document.createElement('div')
        const price_div = document.createElement('div')
        const button = document.createElement('div')
        const h3 = document.createElement('h3')
        const h2 = document.createElement('h3')

        name_div.classList.add('component-name')
        price_div.classList.add('component-price')
        button.setAttribute('id', 'add-button')
        

        h3.innerHTML = `${item.name} processzor (${item.parameter})`
        h2.innerHTML = `${item.price} Ft`
        button.innerHTML = `<button onclick="addComponent('${category}', '${item.name}', '${item.parameter}', '${item.price}Ft')">Hozzáadás</button>`
        
        
        li.appendChild(name_div)
        li.appendChild(price_div)
        li.appendChild(button)
        name_div.appendChild(h3)
        price_div.appendChild(h2)
        optionsList.appendChild(li);
        
    });

    modal.style.display = 'block';

}

function closeModal() {
    document.getElementById('modal').style.display = 'none';
}

let addBtn = document.getElementsByClassName("add-comp")
function addComponent(category, name, parameter, price) {
    console.log(`Hozzáadva: ${name} (${category}) ${parameter}`);
    const selectedDiv = document.getElementById(`selected-${category}`);
    if (selectedDiv) {
        selectedDiv.innerHTML = `<div class="selected-data"><h2>${name}</h2> <h4>(${parameter})</h4></div> <h2>${price}</h2>`;
    }
    closeModal();
}

window.onload = loadComponents;
