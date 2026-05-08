DELIMITER $$
    
DROP FUNCTION IF EXISTS CalcularEstado $$

CREATE FUNCTION CalcularEstado(
    untemperatura DECIMAL(5,2),
    unconectada BOOLEAN
)
RETURNS VARCHAR(20)
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE estado VARCHAR(20);
    
    IF conectada = FALSE THEN
        SET estado = 'DESCONECTADA';
    ELSEIF temperatura > 80 THEN
        SET estado = 'CRÍTICA';
    ELSEIF temperatura > 60 THEN
        SET estado = 'ALERTA';
    ELSEIF temperatura > 40 THEN
        SET estado = 'NORMAL';
    ELSE
        SET estado = 'BAJA';
    END IF;
    
    RETURN estado;
END$$


DROP FUNCTION IF EXISTS PromedioTemperatura $$

CREATE FUNCTION PromedioTemperatura(
    unidComputadora INT,
    unfechaInicio DATETIME,
    unfechaFin DATETIME
)
RETURNS DECIMAL(5,2)
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE promedio DECIMAL(5,2);
    
    SELECT AVG(temperatura)
    INTO promedio
    FROM Mediciones 
    WHERE idComputadora = unidComputadora
    AND Fechahora BETWEEN unfechaInicio AND unfechaFin;
    
  
    IF promedio IS NULL THEN
        SET promedio = 0.00;
    END IF;
    
    RETURN promedio;
END$$

DELIMITER ;
