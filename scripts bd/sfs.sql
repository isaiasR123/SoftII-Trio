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
    
    IF unconectada = TRUE THEN 
        SET estado = 'DESCONECTADA';
    ELSEIF untemperatura > 80 THEN
        SET estado = 'CRÍTICA';
    ELSEIF untemperatura > 60 THEN
        SET estado = 'ALERTA';
    ELSEIF untemperatura > 40 THEN
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
    DECLARE promedio DECIMAL(5,2) DEFAULT 0.00;
    
    SELECT AVG(temperatura)
    INTO promedio
    FROM Mediciones 
    WHERE idComputadora = unidComputadora
    AND Fechahora BETWEEN unfechaInicio AND unfechaFin;
    
    RETURN COALESCE(promedio, 0.00);  -- Más elegante que el IF
    
END$$

DELIMITER ;
