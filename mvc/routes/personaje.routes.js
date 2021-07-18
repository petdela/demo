var express = require('express');
var router = express.Router();

const personajeController = require("../controllers/personaje.controller.js");

/* GET maestros listing. */
router.get('/', personajeController.findAll);


/* post add maestro */ 
router.post('/save', personajeController.save);

module.exports = router;