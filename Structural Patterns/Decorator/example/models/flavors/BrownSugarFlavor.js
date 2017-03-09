/**
 * @module BrownSugarFlavor
 */

var Coffee = require('../Coffee');
var Tastable = require('./Tastable');

/**
 * @implements Coffee
 * @extends Tastable
 * @param {Coffee} coffee
 * @constructor
 */
function BrownSugarFlavor(coffee) {
    this._coffee = coffee;
    this.price = coffee.price + 0.2;
}

BrownSugarFlavor.prototype = Object.create(Object.assign({}, Coffee.prototype, Tastable.prototype), {
    constructor: {value: BrownSugarFlavor}
});

BrownSugarFlavor.prototype.taste = function () {
    var addedTaste = 'brown sugar';

    return this.addTaste(addedTaste);
};

module.exports = BrownSugarFlavor;
