let componentsData = {};

function loadComponents() {
    fetch('alkatreszek.txt')
    .then(response => response.text())
    .then(data => {
        const lines = data.split('\n').filter(line => line.trim() !== '');
        lines.forEach(line => {
            const [category, name, parameter, price] = line.split(';').map(item => item.trim());
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
        

        h3.innerHTML = `${item.name} [${item.parameter}]`
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

let totalPrice = 0
let editingCategory = null;

function addComponent(category, name, parameter, price) {
    const selectedDiv = document.getElementById(`selected-${category}`);
    const addButton = selectedDiv.previousElementSibling;
    
    if (addButton) {
        addButton.style.display = 'none';
    }

    if (selectedDiv) {
        if (editingCategory === category) {
            const priceElement = selectedDiv.querySelector('.component-actions h2');
            if (priceElement) {
                const oldPrice = parseFloat(priceElement.innerText.replace('Ft', '').trim());
                updateTotalPrice(-oldPrice);
            }
        }
 
        selectedDiv.innerHTML = `
            <div class="component-row">
                <div class="component-info">
                    <h2>${name}</h2>
                    <p>${parameter}</p>
                </div>
                <div class="component-actions">
                    <h2>${price}</h2>
                    <button class="edit-btn" onclick="editComponent('${category}')">Szerkesztés</button>
                    <button class="delete-btn" onclick="deleteComponent('${category}')">Törlés</button>
                </div>
            </div>
        `;

        const numericPrice = parseFloat(price.replace('Ft', '').trim());
        updateTotalPrice(numericPrice); 
    }

    editingCategory = null;
    closeModal();
}

function editComponent(category) {
    const selectedDiv = document.getElementById(`selected-${category}`);
    editingCategory = category;

    showOptions(category);

    const modal = document.getElementById('modal');
    modal.addEventListener('click', () => {
        editingCategory = null; 
    });
}

function deleteComponent(category) {
    const selectedDiv = document.getElementById(`selected-${category}`);
    const addButton = selectedDiv.previousElementSibling;

    if(addButton){
        addButton.style.display = 'block';
    }

    if (selectedDiv) {
        const priceElement = selectedDiv.querySelector('.component-actions h2'); 
        let price = 0; 

        if (priceElement) {
            price = parseFloat(priceElement.innerText.replace('Ft', '').trim()); 
        }

        updateTotalPrice(-price);

        selectedDiv.innerHTML = ''; 
        
    }
}

window.onload = loadComponents;

function updateTotalPrice(priceChange) {
    totalPrice += priceChange;
    document.getElementById('total-price').innerText = `${totalPrice} Ft`;
}

function searchOptions() {
    let input = document.getElementById("searchBox").value.toLowerCase()
    let options = document.getElementById("options-list")
    const items = options.getElementsByTagName('li');

    for (let item of items) {
        const text = item.textContent.toLowerCase(); 
        if (text.includes(input)) {
            item.style.display = ""; 
        } else {
            item.style.display = "none"; 
        }
    }

}

function selected(requiredCategories){
    let missingCategories = []

    requiredCategories.forEach(category => {
        const selectedDiv = document.getElementById(`selected-${category}`);
        if (!selectedDiv || selectedDiv.innerHTML.trim() === ''){
            missingCategories.push(category)
        }
    })

    return missingCategories
}

function placeInCart() {
    const requiredCategories = ['Alaplap', 'CPU', 'GPU', 'Memoria', 'SSD'];
    const optionalCategories = ['Monitor', 'Eger', 'Billenytuzet']
    const allCategories = [...requiredCategories, ...optionalCategories];

    const missingCategories = selected(requiredCategories);

    if (missingCategories.length > 0) {
        alert(`A következő alkatrészek nincsenek kiválasztva: ${missingCategories.join(',  ')}`);
    } else {
        const cartItems = [];
        allCategories.forEach(category => {
            const selectedDiv = document.getElementById(`selected-${category}`);
            if (selectedDiv && selectedDiv.innerHTML.trim() !== '') {
                const name = selectedDiv.querySelector('.component-info h2').innerText;
                const price = selectedDiv.querySelector('.component-actions h2').innerText;
                cartItems.push({ category, name, price });
            }
        });

        localStorage.setItem('cartItems', JSON.stringify(cartItems));
        localStorage.setItem('totalPrice', totalPrice);

        window.location.href = 'cart.html';
    }
}