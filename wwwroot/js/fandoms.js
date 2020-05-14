const uri = 'api/Fandoms';
let fandoms = [];
function getFandoms() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFandoms(data))

        .catch(error => console.error('Unable to get fandoms.', error));
}
function addFandom() {
    const addNameTextbox = document.getElementById('add-Name');
    const addInfoTextbox = document.getElementById('add-ShortDescription');
    const fandom = {
        Name: addNameTextbox.value.trim(),
        ShortDescription: addInfoTextbox.value.trim(),
    };
    fetch(uri, {
        method: ' POST',
    headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
    },
    body: JSON.stringify(fandom)
})
        .then(response => response.json())
        .then(() => {
    getFandoms();
    addNameTextbox.value = '';
    addInfoTextbox.value = '';
})
        .catch (error => console.error('Unable to add fandom.', error));
}
function deleteFandom(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
})
        .then(() => getFandoms())
        .catch (error => console.error('Unable to delete fandom.', error));
}
function displayEditForm(id) {
    const fandom = fandoms.find(fandom => fandom.id === id);
    document.getElementById('edit-id').value = fandom.id;
    document.getElementById('edit-Name').value = fandom.Name;
    document.getElementById('edit-ShortDescription').value = fandom.ShortDescription;
    document.getElementById('editForm').style.display = 'block';
}
function updateFandom() {
    const fandomId = document.getElementById('edit-id').value;
    const fandom = {
        id: parseInt(fandomId, 10),
        name: document.getElementById('edit-Name').value.trim(),
        info: document.getElementById('edit-ShortDescription').value.trim()
};
fetch('${uri}/${fandomId}', {
    method: 'PUT',
headers: {
            'Accept':'application/json',
            'Content-Type':'application/json'
},
body: JSON.stringify(fandom)
    })

        .then(() => getFandoms())
        .catch (error => console.error('Unable to update fandom.', error));
closeInput();
return false;
}
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}
function _displayFandoms(data) {
    const tBody = document.getElementById('fandoms');
    tBody.innerHTML = '';

    const button = document.createElement('button');
    data.forEach(fandom => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', 'displayEditForm(${fandom.id})');
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', 'deleteFandom(${fandom.id})');
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(fandom.name);
        td1.appendChild(textNode);
        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(fandom.ShortDescription);
        td2.appendChild(textNodeInfo);
        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);
        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });
    fandoms = data;
}