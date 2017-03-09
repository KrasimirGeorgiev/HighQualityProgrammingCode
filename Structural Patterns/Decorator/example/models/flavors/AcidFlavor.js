/**
 * @module AcidFlavor
 */

var Coffee = require('../Coffee');
var Tastable = require('./Tastable');

/**
 * @implements Coffee
 * @extends Tastable
 * @param {Coffee} coffee
 * @class
 */
function AcidFlavor(coffee) {
    this._coffee = coffee;
    this.price = coffee.price + 1;
}

AcidFlavor.prototype = Object.create(Object.assign({}, Coffee.prototype, Tastable.prototype), {
    constructor: {value: AcidFlavor}
});

AcidFlavor.prototype.taste = function () {
    var addedTaste = 'a distinct taste of sulfuric acid';

    return this.addTaste(addedTaste);
};

module.exports = AcidFlavor;
