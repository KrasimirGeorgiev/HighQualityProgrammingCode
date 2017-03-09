/**
 * @module HtmlFactory
 * AbstractFactory implementation for html strings
 */

var AbstractDocumentFactory = require('./abstarct-document-factory');
var base = AbstractDocumentFactory.prototype;
var jsdom = require('jsdom').jsdom;

/**
 * Creates string representation of HTML objects
 * @extends AbstractDocumentFactory
 * @constructor
 */
function HtmlFactory() {
    AbstractDocumentFactory.apply(this, arguments);
}

HtmlFactory.prototype = Object.create(base, {
    constructor: {value: AbstractDocumentFactory}
});

HtmlFactory.prototype.createElement = function (type) {
    var doc = this.createDocument();
    var el = doc.createElement(type);
    return el.outerHTML;
};

HtmlFactory.prototype.serialize = function (data) {
    var doc = this.createDocument();

    var wrapper = doc.createElement('div');

    for (var key in data) if (data.hasOwnProperty(key)) {

        var el = doc.createElement(key);
        el.textContent = data[key];
        wrapper.appendChild(el);
    }

    var html =  wrapper.outerHTML;
    return html.split('><').join('>\n<');
};

HtmlFactory.prototype.createDocument = function () {
    return jsdom();
};

HtmlFactory.prototype.createAttribute = function (name, value) {
    var doc = this.createDocument();
    var attr = doc.createAttribute(name, value);

    return attr.toString();
};

module.exports = HtmlFactory;
