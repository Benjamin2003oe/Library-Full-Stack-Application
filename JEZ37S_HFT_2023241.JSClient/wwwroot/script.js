let books = [];

getData();

async function getData() {
    await fetch('http://localhost:13009/book')
        .then(x => x.json())
        .then(y => {
            books = y;
            console.log(books);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    books.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id){
    fetch('http://localhost:13009/book/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let gottenName = document.getElementById('bookname').value;
    fetch('http://localhost:13009/book', {
        method: 'POST',
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify(
            { name: gottenName }),})
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}