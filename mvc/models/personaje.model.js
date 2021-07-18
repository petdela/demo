module.exports = (sequelize, DataTypes) => {
  const Personaje = sequelize.define("personaje", {
    id: {
      type: DataTypes.INTEGER,
      primaryKey: true
    },
    nombre: {
      type: DataTypes.STRING
    }
  }, {
    timestamps: false
  });

  return Personaje;
};