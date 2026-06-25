-- Active: 1779910014312@@127.0.0.1@3306@5to_Monitoreo
DROP FUNCTION IF EXISTS CalcularEstado ;
DROP FUNCTION IF EXISTS PromedioTemperatura ;
DELIMITER $$

CREATE FUNCTION CalcularEstado(
    unIdComputadora INT
)
RETURNS VARCHAR(20)
READS SQL DATA
BEGIN
    RETURN
        (SELECT CASE
            WHEN NOT conectada THEN 'DESCONECTADA'
            WHEN temperatura > 80 THEN 'CRÍTICA'
            WHEN temperatura > 60 THEN 'ALERTA'
            WHEN temperatura > 40 THEN 'NORMAL'
            ELSE 'SIN MEDICION'
        END
        FROM Mediciones
        WHERE   idComputadora = unIdComputadora
        -- Voy a buscar las mediciones de hoy
        AND     DATE(Fechahora) = CURDATE()
        ORDER BY Fechahora DESC
        LIMIT 1);
END $$

CREATE FUNCTION PromedioTemperatura(
    unidComputadora INT,
    unfechaInicio DATETIME,
    unfechaFin DATETIME
)
RETURNS DECIMAL(5,2)
READS SQL DATA
BEGIN
    DECLARE promedio DECIMAL(5,2) DEFAULT 0.0;
    
    SELECT AVG(temperatura)
    INTO promedio
    FROM Mediciones 
    WHERE idComputadora = unidComputadora
    AND Fechahora BETWEEN unfechaInicio AND unfechaFin;
    
    RETURN COALESCE(promedio, 0.0);  
    
END $$

DELIMITER ;
