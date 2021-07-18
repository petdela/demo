drop database if exists demo;
create database if not exists DEMO;
use  DEMO;

create table if not exists Personajes(
id int auto_increment,
nombre varchar(255),
primary key(id));

create table if not exists Versions(
idV int auto_increment,
personajeId int,
numVer int,
primary key(idV),
FOREIGN KEY (personajeId)
        REFERENCES Personajes (id)
);

CREATE TABLE IF NOT EXISTS Partes (
    idP int auto_increment,
    numParte INT,
    color VARCHAR(255),
    imagen varchar(255),
    versionIdV int,
    PRIMARY KEY (idP),
    FOREIGN KEY (versionIdV)
        REFERENCES Versions (idV)
);

INSERT into Personajes
(nombre) values ("cabello"),("cara");

INSERT into Versions
(personajeId,numVer) values (1,1),(1,2),(2,1);

INSERT into Partes
(versionIdV, numParte, color, imagen) values 
(1,1,"#ffffff","https://raw.githubusercontent.com/petdela/demo/main/pelog1.png"),
(1,2,"#ffffff","https://raw.githubusercontent.com/petdela/demo/main/ligag1.png"),
(2,3,"#ffffff","https://raw.githubusercontent.com/petdela/demo/main/pelog2.png"), 
(2,4,"#ffffff","https://raw.githubusercontent.com/petdela/demo/main/ligag2.png"), 
(3,5,"#ffffff","https://raw.githubusercontent.com/petdela/demo/main/cabezal1.png"),
(3,6,"#ffffff","https://raw.githubusercontent.com/petdela/demo/main/picol1.png");


