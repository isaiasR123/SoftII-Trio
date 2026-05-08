DROP DATABASE IF EXISTS 5to_Monitoreo;
CREATE DATABASE 5to_Monitoreo;
USE 5to_Monitoreo;


CREATE TABLE Laboratorio (
    idLaboratorio INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(45) NOT NULL,
    ubicacion VARCHAR(45) NOT NULL
);


CREATE TABLE Modelo (
    idModelo INT NOT NULL PRIMARY KEY,
    marca VARCHAR(45) NOT NULL,
    modelo VARCHAR(45) NOT NULL,
    procesador VARCHAR(45) NOT NULL,
    ram INT NOT NULL
);


CREATE TABLE Computadoras (
    idComputadora INT NOT NULL PRIMARY KEY,
    idLaboratorio INT NOT NULL,
    idModelo INT NOT NULL,
    nombre_equipo VARCHAR(45) NOT NULL,
    FOREIGN KEY (idLaboratorio) REFERENCES Laboratorio(idLaboratorio),
    FOREIGN KEY (idModelo) REFERENCES Modelo(idModelo)
);


CREATE TABLE Mediciones (
    idMedicion INT NOT NULL PRIMARY KEY,
    idComputadora INT NOT NULL,
    CPU INT NOT NULL,
    ram INT NOT NULL,
    temperatura DECIMAL(5,2) NOT NULL,
    conectada BOOLEAN NOT NULL,
    Fechahora DATETIME NOT NULL,
    FOREIGN KEY (idComputadora) REFERENCES Computadoras(idComputadora)
);
