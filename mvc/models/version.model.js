module.exports = (sequelize, DataTypes) => {
  const Version = sequelize.define("version", {
    idV: {
      type: DataTypes.INTEGER,
      primaryKey: true
    },
    personajeId: {
      type: DataTypes.INTEGER
    },
    numVer: {
      type: DataTypes.INTEGER
    }
  }, {
    timestamps: false
  });

  return Version;
};