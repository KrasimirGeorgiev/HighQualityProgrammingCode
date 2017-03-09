/**
 * @module CoffeeDecoration
 */

require('colors');
var prompter = require('inquirer');

// Models
var Espresso = require('./models/Espresso');
var BrownSugar = require('./models/flavors/BrownSugarFlavor');
var Milk = require('./models/flavors/MilkFlavor');
var Acid = require('./models/flavors/AcidFlavor');

var coffee = null;

startUp();

function startUp() {
    console.log('Welcome!!!'.underline.cyan);
    console.log('');

    var prompt = {
        type: 'confirm',
        name: 'coffee',
        message: 'Would you like an espresso'.green
    };

    prompter
        .prompt(prompt)
        .then(function(choices) {
            if (choices.coffee) {
                coffee = new Espresso();
                playBall();
            }
            else {
                quit();
            }
        });
}

function playBall() {

    printState();
    chooseDecoration();
}

function printState() {
    console.log('');
    console.log('Coffee cost: %s', coffee.price);
    console.log('');

    console.log('Your coffee tastes like:');
    console.log(coffee.taste().magenta);
    console.log('');

}

function chooseDecoration() {
    var prompt = {
        type: 'list',
        name: 'decoration',
        message: 'What would you like to add'.green,
        choices: ['sugar', 'milk', 'acid', 'quit']
    };

    prompter
        .prompt(prompt)
        .then(function(choices) {
            if (choices.decoration !== 'quit') {
                wrap(choices.decoration);
                playBall();
            }
            else {
                quit();
            }
        });
}

function wrap(decoration) {
    console.log('Adding... ' + decoration.cyan);

    switch (decoration) {
        case 'sugar':
            coffee = new BrownSugar(coffee);
            break;
        case 'milk':
            coffee = new Milk(coffee);
            break;
        case 'acid':
            coffee = new Acid(coffee);
            break;
        default:
            throw new Error('El panadero no come pan')
    }
}

function quit() {
    console.log('Game over, you lose'.bold.red);
    process.exit(0);
}
