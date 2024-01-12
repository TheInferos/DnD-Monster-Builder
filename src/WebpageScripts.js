const URL_BASE = "https://localhost:7050/api/"

function main() {
    addCreateFunctionToSubmitButton();
    addUpdateFunctiontoUpdateButton();
    handleArmourArray();
}
function updateStats(montser) {
    setElement('monsterID', montser.ID);
    setElement('health', montser.Stats.Health);
    setElement('ac', montser.Stats.AC);
    setElement('str', montser.Stats.Strength);
    setElement('dex', montser.Stats.Dexterity);
    setElement('con', montser.Stats.Consitution);
    setElement('int', montser.Stats.Intelligence);
    setElement('wis', montser.Stats.Wisdom);
    setElement('cha', montser.Stats.Charisma);
    document.getElementById('responseDisplay').innerHTML = `<pre>${JSON.stringify(montser, null, 2)}</pre>`;
}

function getStatblock() {
    return {
        Strength: getElement('str'),
        Dexterity: getElement('dex'),
        Consitution: getElement('con'),
        Intelligence: getElement('int'),
        Wisdom: getElement('wis'),
        Charisma: getElement('cha')
    };
}

function setElement(id, valueToSet) {
    document.getElementById(id).value = valueToSet
}

function getElement(id) {
    return document.getElementById(id).value
}

function simplifiedFetch(apiRoute, method, body) {
    let request = {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: body
    }
    return fetch(URL_BASE + apiRoute, request)
}

function handleJSONResponse(apiReturn) {
    return apiReturn
        .then(response => response.json())
        .then(data => {
            updateStats(data)
        })
        .catch(error => {
            console.error('Error:', error);
            // Handle error
        })
}

function addCreateFunctionToSubmitButton (){
    document.getElementById('coreDetails').addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent the default form submission
        const formData = {
            name: getElement('name'),
            cr: parseInt(getElement('cr')),
            hd: parseInt(getElement('hd'))
        };
        handleJSONResponse(simplifiedFetch('Monster/MakeMonster', 'POST', JSON.stringify(formData)))
        const radioContainer = document.getElementById('armourSelector');
        radioContainer.style.display = 'block';
    });
}

function addUpdateFunctiontoUpdateButton() {
    document.getElementById('update').addEventListener('click', function (event) {
        event.preventDefault(); // Prevent the default form submission
        let monsterID = document.getElementById('monsterID').value;
        const formData = getStatblock();
        handleJSONResponse(simplifiedFetch(`Monster/${monsterID}/ChangeStats`), 'POST', JSON.stringify(formData));
    })
}

function handleDropdownItemClick(armourName) {
    // Perform an action based on the selected dropdown item
    console.log(`Selected item: ${armourName}`);
    let monsterID = document.getElementById('monsterID').value;
    handleJSONResponse(simplifiedFetch(`Monster/${monsterID}/SwitchArmour?armourString=${armourName}`, 'POST'));
}

function handleArmourArray() {
    const armorArray = simplifiedFetch('Armoury/GetArmours', 'Get')
        .then(response => response.json())
        .then(data => {
            const dropdownContainer = document.getElementById('armourSelector');

            Object.keys(data).forEach(category => {
                // Create a new dropdown for each category
                const dropdownDiv = document.createElement('div');
                dropdownDiv.classList.add('dropdown', 'mb-3');

                // Dropdown button
                const dropdownButton = document.createElement('button');
                dropdownButton.classList.add('btn', 'btn-secondary', 'dropdown-toggle');
                dropdownButton.type = 'button';
                dropdownButton.setAttribute('data-bs-toggle', 'dropdown');
                dropdownButton.textContent = category;

                // Dropdown menu
                const dropdownMenu = document.createElement('ul');
                dropdownMenu.classList.add('dropdown-menu');

                // Add items to the dropdown menu
                data[category].forEach(armor => {
                    const listItem = document.createElement('li');
                    const anchor = document.createElement('a');
                    anchor.href = '#';
                    anchor.classList.add('dropdown-item');
                    anchor.textContent = armor;
                    anchor.addEventListener('click', (event) => {
                        event.preventDefault();
                        handleDropdownItemClick(armor);
                    });
                    listItem.appendChild(anchor);
                    dropdownMenu.appendChild(listItem);
                });

                dropdownDiv.appendChild(dropdownButton);
                dropdownDiv.appendChild(dropdownMenu);
                dropdownContainer.appendChild(dropdownDiv);
            });

            const dropdowns = document.querySelectorAll('.dropdown-toggle');
            dropdowns.forEach(dropdown => new bootstrap.Dropdown(dropdown));
        })
        .catch(error => {
            console.error('Error:', error);
        });
}



main()