let books = [];

fetch('http://localhost:13009/book')
    .then(x => x.json())
    .then(y => {
        books = y;
        console.log(books);
        display();
    });


function display() {
    books.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td></tr>";
    });
}