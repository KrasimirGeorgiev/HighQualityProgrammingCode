/**
 * @module Espresso
 * An implementation of {@link Coffee}
 */

var Coffee = require('./Coffee');

/**
 * @implements Coffee
 * @class
 */
function Espresso() {
    Coffee.apply(this, arguments);
    this.price = 1;
}

Espresso.prototype = Object.create(Coffee.prototype, {
    constructor: {value: Espresso}
});

Espresso.prototype.taste = function () {
    return 'Tastes like espresso coffee';
};

module.exports = Espresso;