function getLeagueIndexFromURL() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    return parseInt(urlParams.get('index'));
}

function displayLeagueData(index) {
    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    if (index < 0 || index >= leagues.length) {
        alert('Invalid index.');
        return;
    }

    document.getElementById('nameInput').value = leagues[index].name;
    document.getElementById('sportInput').value = leagues[index].sport;
    document.getElementById('countryInput').value = leagues[index].country;
}

function saveEdit() {
    let index = getLeagueIndexFromURL();
    if (isNaN(index)) {
        alert('Invalid league index.');
        return;
    }

    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    if (index < 0 || index >= leagues.length) {
        alert('Invalid index.');
        return;
    }

    let nameInput = document.getElementById('nameInput');
    let sportInput = document.getElementById('sportInput');
    let countryInput = document.getElementById('countryInput');
    let editedName = nameInput.value;
    let editedSport = sportInput.value;
    let editedCountry = countryInput.value;

    if (editedName.trim() === '' || editedSport.trim() === '' || editedCountry.trim() === '') {
        alert('Please fill in all the fields.');
        return;
    }

    leagues[index].name = editedName;
    leagues[index].sport = editedSport;
    leagues[index].country = editedCountry;
    localStorage.setItem('leagues', JSON.stringify(leagues));
    window.location.href = 'index.html';
}

function cancelEdit() {
    window.location.href = 'index.html';
}

window.onload = function () {
    let index = getLeagueIndexFromURL();
    if (isNaN(index)) {
        alert('Invalid league index.');
        return;
    }
    displayLeagueData(index);
};