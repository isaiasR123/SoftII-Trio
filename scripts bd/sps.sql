DELIMITER $$

DROP PROCEDURE IF EXISTS sp_registrar_laboratorio

create procedure sp_registrar_laboratorio( unidLaboratorio int,
unnombre varchar(45),
unubicacion varchar(45)
)

BEGIN
  INSERT into Laboratorio(idLaboratorio,nombre,ubicacion)
      VALUES(unidLaboratorio, unnombre ,unubicacion);
END $$

DROP PROCEDURE IF EXISTS sp_registrar_modelo_pc

CREATE PROCEDURE sp_registrar_modelo_pc  (unidModelo int,
unmarca varchar(45),
unmodelo varchar(45),
unprocesador varchar(45),
unram int)

BEGIN
  INSERT INTO Modelo(idModelo,
  marca,
  modelo,
  procesaodr,
  ram)
  VALUES(unidModelo,
  unmarca,
  unmodelo,
  unprocesador,
  unram);
END $$

DROP PROCEDURE IF EXISTS sp_registrar_computadora

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
  nombre_equipo)
  VALUES(
  unidLaboratorio,
  unidModelo,
  unidComputadora,
  unnombre_equipo
  )
END $$



DELIMITER $$

