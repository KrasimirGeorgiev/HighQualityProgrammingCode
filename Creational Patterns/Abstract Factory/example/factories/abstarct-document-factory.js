/**
 * @module AbstractDocumentFactory
 * Defines the interface for creating different web documents like
 * XML, HTML, JSON and others
 * Such factory can be used as serializing/deserialing middleware for HTTP
 * requests/responses without altering the rest of the application implementation
 */

/**
 * @class
 * Defines the interface for creating different web documents
 */
function AbstractDocumentFactory() {}

/**
 * @abstract
 * Creates a new empty document
 */
AbstractDocumentFactory.prototype.createDocument = function () {
    throwNotImplemented();
};

/**
 * @abstract
 * Converts an object to document
 * @param {object} data
 */
AbstractDocumentFactory.prototype.serialize = function (data) {
    throwNotImplemented();
};

/**
 * @abstract
 * Creates a new element of the requested type
 * @param {string} type
 * @throws TypeError - if the type is not supported an error will be thrown
 */
AbstractDocumentFactory.prototype.createElement = function (type) {
    throwNotImplemented();
};

/**
 * @abstract
 * Creates an attribute
 * @param {string} name
 * @param {*} value
 */
AbstractDocumentFactory.prototype.createAttribute = function (name, value) {
    throwNotImplemented();
};

function throwNotImplemented() {
    throw new Error('Method not implemented!');
}

module.exports = AbstractDocumentFactory;