require('colors');

var JsonFactory = require('./factories/json-factory');
var HtmlFactory = require('./factories/html-factory');

var jsonFactory = new JsonFactory();
var htmlFactory = new HtmlFactory();

var testData = {
    h1: 'Виц на деня',
    p: 'Бил Гейтс получил за рождения си ден пистолет с гравирано' +
    ' послание на него: "Press any key".'
};

var asJson = jsonFactory.serialize(testData);
var asHtml = htmlFactory.serialize(testData);

console.log('AS JSON'.underline.green);
console.log('');
console.log(asJson.magenta);

console.log('');
console.log('AS HTML'.underline.green);
console.log('');
console.log(asHtml.grey);
