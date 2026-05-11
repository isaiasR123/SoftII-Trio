DELIMITER $$

DROP PROCEDURE IF EXISTS sp_registrar_laboratorio $$

CREATE PROCEDURE sp_registrar_laboratorio(
    unidLaboratorio INT,
    unnombre VARCHAR(45),
    unubicacion VARCHAR(45)
)
BEGIN
    INSERT INTO Laboratorio(idLaboratorio, nombre, ubicacion)
    VALUES(unidLaboratorio, unnombre, unubicacion);
END $$

DROP PROCEDURE IF EXISTS sp_registrar_modelo_pc $$

CREATE PROCEDURE sp_registrar_modelo_pc(
    unidModelo INT,
    unmarca VARCHAR(45),
    unmodelo VARCHAR(45),
    unprocesador VARCHAR(45),
    unram INT
)
BEGIN
    INSERT INTO Modelo(idModelo, marca, modelo, procesador, ram) 
    VALUES(unidModelo, unmarca, unmodelo, unprocesador, unram);
END $$

DROP PROCEDURE IF EXISTS sp_registrar_computadora $$

CREATE PROCEDURE sp_registrar_computadora(
    unidLaboratorio INT,
    unidModelo INT,
    unidComputadora INT,
    unnombre_equipo VARCHAR(45)
)
BEGIN
    INSERT INTO Computadora(
        idLaboratorio,
        idModelo,
        idComputadora,
        nombre_equipo
    )
    VALUES(
        unidLaboratorio,
        unidModelo,
        unidComputadora,
        unnombre_equipo
    );  
END $$

DELIMITER ;  
