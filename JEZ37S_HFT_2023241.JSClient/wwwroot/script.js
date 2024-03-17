fetch('http://localhost:13009/book')
    .then(x => x.json())
    .then(y => console.log(y));