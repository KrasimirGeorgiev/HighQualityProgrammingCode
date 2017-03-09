/**
 * @module Tastable
 */

/**
 * Extracted common to all taste methods
 * @constructor
 */
function Tastable() {}

Tastable.prototype.addTaste = function (flavor) {
    var result;

    if (this._coffee.isDecorated) {
        result = this._coffee.taste() + ', ' + flavor;
    }
    else {
        result = this._coffee.taste() + ' with ' + flavor;
    }

    this.isDecorated = true;

    return result;
};

module.exports = Tastable;