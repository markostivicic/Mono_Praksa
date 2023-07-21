function addLeague() {
    let name = document.getElementById('nameInput').value;
    let sport = document.getElementById('sportInput').value;
    let country = document.getElementById('countryInput').value;

    if (name.trim() === '' || sport.trim() === '' || country.trim() === '') {
        alert('Please fill in all the fields.');
        return;
    }

    let league = {
        name: name,
        sport: sport,
        country: country
    };

    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];
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
        actionCell.innerHTML = '<button onclick="editLeague(' + i + ')">Edit</button> <button onclick="deleteLeague(' + i + ')">Delete</button>';
    }
}

function editLeague(index) {
    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    if (index < 0 || index >= leagues.length) {
        alert('Invalid index.');
        return;
    }

    document.getElementById('nameInput').value = leagues[index].name;
    document.getElementById('sportInput').value = leagues[index].sport;
    document.getElementById('countryInput').value = leagues[index].country;
    window.location.href = 'edit.html?index=' + index;
}

function deleteLeague(index) {
    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    if (index < 0 || index >= leagues.length) {
        alert('Invalid index.');
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

