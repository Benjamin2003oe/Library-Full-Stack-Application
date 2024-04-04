let noncrudcoll = [];

function cleardisplay() {
    document.getElementById('noncrudform').style.display = "none";
    document.getElementById('form_BooksWrittenbyAuthor').style.display = "none";
    document.getElementById('form_AuthorsBornYear').style.display = "none";
    document.getElementById('form_WhoReservedThisBook').style.display = "none";
    document.getElementById('form_HowManyBooksPerCategory').style.display = "none";
}

async function getdata03() {
    cleardisplay();
    document.getElementById('form_BooksWrittenbyAuthor').style.display = "initial";
    document.getElementById('result_BooksWrittenbyAuthor').innerHTML = "";
    await getAuthors();
    authors.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.name;
        o.value = item.name;
        document.getElementById('slctAuthor').appendChild(o);
        console.log(o);
    })
}

let Books = [];
async function getBooks() {
    await fetch('http://localhost:13009/book')
        .then(x => x.json())
        .then(y => {
            Books = y;
            console.log(Books);
        });
}

let Categories = [];
async function getCategories() {
    await fetch('http://localhost:13009/category')
        .then(x => x.json())
        .then(y => {
            Categories = y;
            console.log(Categories);
        });
}

let authors = [];
async function getAuthors() {
    await fetch('http://localhost:13009/author')
        .then(x => x.json())
        .then(y => {
            authors = y;
            console.log(authors);
        });
}

function display03() {
    cleardisplay();
    document.getElementById('form_BooksWrittenbyAuthor').style.display = "initial";
    document.getElementById('result_BooksWrittenbyAuthor').innerHTML = "";
    noncrudcoll.forEach(t => {
        console.log(t.name);
        document.getElementById('result_BooksWrittenbyAuthor').innerHTML +=
            "<tr><td>" + t.name + "</td></tr>";
        console.log(t);
    })
}

async function getdata03_final() {
    let str = document.getElementById('slctAuthor').value;
    str = "http://localhost:13009/Stat/GetAuthorBooks/" + str;
    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display03();
        });
}

async function getdata04() {
    cleardisplay();
    document.getElementById('form_AuthorsBornYear').style.display = "initial";
    document.getElementById('result_AuthorsBornYear').innerHTML = "";
    await getBooks();
    Books.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.name;
        o.value = item.name;
        document.getElementById('slctBook1').appendChild(o);
        console.log(o);
    })
}

function display04() {
    cleardisplay();
    document.getElementById('form_AuthorsBornYear').style.display = "initial";
    document.getElementById('result_AuthorsBornYear').innerHTML = "";
    noncrudcoll.forEach(t => {
        console.log(t.year);
        document.getElementById('result_AuthorsBornYear').innerHTML +=
            "<tr><td>" + t.year + "</td></tr>";
        console.log(t);
    })
}

async function getdata04_final() {
    let str = document.getElementById('slctBook1').value;
    str = "http://localhost:13009/Stat/WhenWasTheAuthorBorn/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display04();
        });
}

async function getdata05() {
    cleardisplay();
    document.getElementById('form_WhoReservedThisBook').style.display = "initial";
    document.getElementById('result_WhoReservedThisBook').innerHTML = "";
    await getBooks();
    Books.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.name;
        o.value = item.name;
        document.getElementById('slctBook2').appendChild(o);
        console.log(o);
    })
}

function display05() {
    cleardisplay();
    document.getElementById('form_WhoReservedThisBook').style.display = "initial";
    document.getElementById('result_WhoReservedThisBook').innerHTML = "";
    noncrudcoll.forEach(t => {
        console.log(t.membername);
        document.getElementById('result_WhoReservedThisBook').innerHTML +=
            "<tr><td>" + t.membername + "</td></tr>";
        console.log(t);
    })
}

async function getdata05_final() {
    let str = document.getElementById('slctBook2').value;
    str = "http://localhost:13009/Stat/Reservedby/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display05();
        });
}

async function getdata06() {
    cleardisplay();
    document.getElementById('form_HowManyBooksPerCategory').style.display = "initial";
    document.getElementById('result_HowManyBooksPerCategory').innerHTML = "";
    await getCategories();
    Categories.forEach(function (item) {
        let o = document.createElement("option");
        o.text = item.category_Name;
        o.value = item.category_Name;
        document.getElementById('slctCategory').appendChild(o);
        console.log(o);
    })
}

async function getdata06_final() {
    let str = document.getElementById('slctCategory').value;
    str = "http://localhost:13009/Stat/CountBooksPerCategory/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrudcoll = y;
            console.log(noncrudcoll)
            display06();
        });
}

function display06() {
    cleardisplay();
    document.getElementById('form_HowManyBooksPerCategory').style.display = "initial";
    document.getElementById('result_HowManyBooksPerCategory').innerHTML = "";
    noncrudcoll.forEach(t => {
        document.getElementById('result_HowManyBooksPerCategory').innerHTML +=
            "<tr><td>" + t.name + "</td></tr>";
    })
}
