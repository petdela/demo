module.exports = (sequelize, DataTypes) => {
  const Parte = sequelize.define("parte", {
    idP: {
      type: DataTypes.INTEGER,
      primaryKey: true
    },
    numParte: {
      type: DataTypes.INTEGER
    },
    color: {
      type: DataTypes.STRING
    },
    imagen: {
      type: DataTypes.STRING
    },
    versionIdV: {
      type: DataTypes.INTEGER
    }
  }, {
  	timestamps: false
  });

  return Parte;
};

