let categories = [];
let connection = null;

let categoryIdtoUpdate = -1;

getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:13009/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CategoryCreated", (user, message) => {
        getData();
    });

    connection.on("CategoryDeleted", (user, message) => {
        getData();
    });

    connection.on("CategoryUpdated", (user, message) => {
        getData();
    });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getData() {
    await fetch('http://localhost:13009/category')
        .then(x => x.json())
        .then(y => {
            categories = y;
            //console.log(categories);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    categories.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.category_Name + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:13009/category/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('categorynametoupdate').value = categories.find(t => t['id'] == id)['category_Name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    categoryIdtoUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let gottenName = document.getElementById('categorynametoupdate').value;
    fetch('http://localhost:13009/category', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { category_Name: gottenName, Id: categoryIdtoUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let gottenName = document.getElementById('categoryname').value;
    fetch('http://localhost:13009/category', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { category_Name: gottenName }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}