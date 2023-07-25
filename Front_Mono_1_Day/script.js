function addLeague() {
    let name = document.getElementById('nameInput').value;
    let sport = document.getElementById('sportInput').value;
    let country = document.getElementById('countryInput').value;

    if (name.trim() === '' || sport.trim() === '' || country.trim() === '') {
        alert('Please fill in all the fields.');
        return;
    }

    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    let id = Date.now().toString(); 

    let league = {
        id: id, 
        name: name,
        sport: sport,
        country: country
    };

    leagues.push(league);
    localStorage.setItem('leagues', JSON.stringify(leagues));
    displayLeagues();
    clearInputFields();
}

function displayLeagues() {
    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];
    let tableBody = document.getElementById('leagueTable');
    tableBody.innerHTML = '';
    let row = tableBody.insertRow();
    let nameCell = row.insertCell();
    nameCell.textContent = 'NAME';
    let sportCell = row.insertCell();
    sportCell.textContent = 'SPORT';
    let countryCell = row.insertCell();
    countryCell.textContent = 'COUNTRY';
    let actionCell = row.insertCell();
    actionCell.textContent = 'ACTION';

    for (let i = 0; i < leagues.length; i++) {
        let row = tableBody.insertRow();
        let nameCell = row.insertCell();
        nameCell.textContent = leagues[i].name;
        let sportCell = row.insertCell();
        sportCell.textContent = leagues[i].sport;
        let countryCell = row.insertCell();
        countryCell.textContent = leagues[i].country;
        let actionCell = row.insertCell();
        actionCell.innerHTML = '<button onclick="editLeague(' + leagues[i].id + ')">Edit</button> <button onclick="deleteLeague(' + leagues[i].id + ')">Delete</button>';
    }
}

function editLeague(id) {
    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    let league = leagues.find(league => league.id === id);

    if (!league) {
        alert('Invalid ID.');
        return;
    }

    document.getElementById('nameInput').value = league.name;
    document.getElementById('sportInput').value = league.sport;
    document.getElementById('countryInput').value = league.country;

    window.location.href = 'edit.html?id=' + id;
}

function deleteLeague(id) {
    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    let index = leagues.findIndex(league => league.id === id);

    if (index === -1) {
        alert('Invalid ID.');
        return;
    }

    let shouldDelete = window.confirm('Do you want to delete the league?');
    if (shouldDelete) {
        leagues.splice(index, 1);
        localStorage.setItem('leagues', JSON.stringify(leagues));
        displayLeagues();
    }
}


function clearInputFields() {
    document.getElementById('nameInput').value = '';
    document.getElementById('sportInput').value = '';
    document.getElementById('countryInput').value = '';
}

displayLeagues();

