/**
 * @module Coffee
 */

/**
 * @interface
 * A caffeine beverage
 */
function Coffee() {
    this.price = 0;
}

Coffee.prototype.taste = function () {
    throw new Error('Method not implemented');
};

module.exports = Coffee;
