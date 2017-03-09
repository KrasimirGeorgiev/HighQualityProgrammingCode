/**
 * @module MilkFlavor
 */

var Coffee = require('../Coffee');
var Tastable = require('./Tastable');

/**
 * @implements Coffee
 * @extends Tastable
 * @param {Coffee} coffee
 * @class
 */
function MilkFlavor(coffee) {
    this._coffee = coffee;
    this.price = coffee.price + 0.5;
}

MilkFlavor.prototype = Object.create(Object.assign({}, Coffee.prototype, Tastable.prototype), {
    constructor: {value: MilkFlavor}
});

MilkFlavor.prototype.taste = function () {
    var addedTaste = 'a bit of milk';

    return this.addTaste(addedTaste);
};

module.exports = MilkFlavor;
