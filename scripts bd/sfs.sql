DELIMITER $$

DROP FUNCTION IF EXISTS CalcularEstado $$

CREATE FUNCTION CalcularEstado(
    untemperatura DECIMAL(5,2),
    unconectada BOOLEAN
)
RETURNS VARCHAR(20)
READS SQL DATA
DETERMINISTIC
RETURN (
    SELECT CASE 
        WHEN unconectada = TRUE THEN 'DESCONECTADA'
        WHEN untemperatura > 80 THEN 'CRÍTICA'
        WHEN untemperatura > 60 THEN 'ALERTA'
        WHEN untemperatura > 40 THEN 'NORMAL'
        ELSE 'BAJA'
    END
);

DROP FUNCTION IF EXISTS PromedioTemperatura $$

CREATE FUNCTION PromedioTemperatura(
    unidComputadora INT,
    unfechaInicio DATETIME,
    unfechaFin DATETIME
)
RETURNS DECIMAL(5,2)
READS SQL DATA
DETERMINISTIC
RETURN (
    SELECT COALESCE(AVG(temperatura), 0.00)
    FROM Mediciones 
    WHERE idComputadora = unidComputadora
    AND Fechahora BETWEEN unfechaInicio AND unfechaFin
);

DELIMITER ;
