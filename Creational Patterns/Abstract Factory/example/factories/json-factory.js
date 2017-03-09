/**
 * @module JsonFactory
 * AbstractFactory implementation for json strings
 */

var AbstractDocumentFactory = require('./abstarct-document-factory');
var base = AbstractDocumentFactory.prototype;

/**
 * Creates string representation of JSON objects
 * @extends AbstractDocumentFactory
 * @constructor
 */
function JsonFactory() {
    AbstractDocumentFactory.apply(this, arguments);
}

JsonFactory.prototype = Object.create(base, {
    constructor: {value: AbstractDocumentFactory}
});

/**
 * @inheritDoc
 */
JsonFactory.prototype.createElement = function (type) {
    return '{}';
};

/**
 * @inheritDoc
 */
JsonFactory.prototype.serialize = function (data) {
    // We can create our own implementation of this method and since we are using
    // a factory it wont require to modify the application logic that is using the
    // result
    return JSON.stringify(data, null, '\t');
};

/**
 * @inheritDoc
 */
JsonFactory.prototype.createDocument = function () {
    return '{}';
};

/**
 * @inheritDoc
 */
JsonFactory.prototype.createAttribute = function (name, value) {
    throw new Error('Method is not supported for this format');
};

module.exports = JsonFactory;
