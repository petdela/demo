const dbConfig = require("../config/db.config.js");

const Sequelize = require("sequelize");
const sequelize = new Sequelize(dbConfig.DB, dbConfig.USER, dbConfig.PASSWORD, {
  host: dbConfig.HOST,
  dialect: dbConfig.dialect,
  operatorsAliases: false,

  pool: {
    max: dbConfig.pool.max,
    min: dbConfig.pool.min,
    acquire: dbConfig.pool.acquire,
    idle: dbConfig.pool.idle
  }
});

const db = {};

db.Sequelize = Sequelize;
db.sequelize = sequelize;

db.personaje = require("./personaje.model.js")(sequelize, Sequelize);
db.parte = require("./parte.model.js")(sequelize, Sequelize);
db.version = require("./version.model.js")(sequelize, Sequelize);

db.personaje.hasMany(db.version);
db.version.belongsTo(db.personaje, {
  foreignKey: "personajeId",
});
db.version.hasMany(db.parte);
db.parte.belongsTo(db.version, {
  foreignKey: "versionIdV",
});


module.exports = db;
