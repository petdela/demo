const db = require("../models");
const Personaje = db.personaje;
const Partes = db.parte;
const Versiones = db.version;
const Op = db.Sequelize.Op;


exports.save = (req, res) => {
  if(!req.body.contenido){
    res.status(400).send({
      message: "Error"
    });
    return;
  }
};


exports.findAll = (req, res) => {
  Personaje.findAll({
      include: [{
        model: Versiones,
        include: [{
             model: Partes,
            }]
        }]
    })
    .then(data => {
      res.send(data)
      })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Error ocurrio."
         });
    });
};