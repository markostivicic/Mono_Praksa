function getLeagueIndexFromURL() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    return parseInt(urlParams.get('index'));
}

function displayLeagueData(id) {
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
}


function saveEdit() {
    let id = getLeagueIdFromURL();
    if (!id) {
        alert('Invalid league ID.');
        return;
    }

    let leagues = localStorage.getItem('leagues');
    leagues = leagues ? JSON.parse(leagues) : [];

    // Find the league with the given ID
    let league = leagues.find(league => league.id === id);

    if (!league) {
        alert('Invalid league.');
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

    league.name = editedName;
    league.sport = editedSport;
    league.country = editedCountry;

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