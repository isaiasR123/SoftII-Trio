USE 5to_Monitoreo;

DELIMITER $$


DROP FUNCTION IF EXISTS fn_calcular_estado$$

CREATE FUNCTION fn_calcular_estado(
    p_temperatura DECIMAL(5,2),
    p_conectada BOOLEAN
)
RETURNS VARCHAR(20)
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE v_estado VARCHAR(20);
    
    IF p_conectada = FALSE THEN
        SET v_estado = 'DESCONECTADA';
    ELSEIF p_temperatura > 80 THEN
        SET v_estado = 'CRÍTICA';
    ELSEIF p_temperatura > 60 THEN
        SET v_estado = 'ALERTA';
    ELSEIF p_temperatura > 40 THEN
        SET v_estado = 'NORMAL';
    ELSE
        SET v_estado = 'BAJA';
    END IF;
    
    RETURN v_estado;
END$$


DROP FUNCTION IF EXISTS fn_promedio_temperatura$$

CREATE FUNCTION fn_promedio_temperatura(
    p_idComputadora INT,
    p_fechaInicio DATETIME,
    p_fechaFin DATETIME
)
RETURNS DECIMAL(5,2)
READS SQL DATA
DETERMINISTIC
BEGIN
    DECLARE v_promedio DECIMAL(5,2);
    
    SELECT AVG(temperatura)
    INTO v_promedio
    FROM Mediciones 
    WHERE idComputadora = p_idComputadora
    AND Fechahora BETWEEN p_fechaInicio AND p_fechaFin;
    
  
    IF v_promedio IS NULL THEN
        SET v_promedio = 0.00;
    END IF;
    
    RETURN v_promedio;
END$$

DELIMITER ;
