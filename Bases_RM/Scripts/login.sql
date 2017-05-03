DELIMITER //;
DROP FUNCTION IF EXISTS login//
CREATE FUNCTION login (vNombre VARCHAR(45), vPass VARCHAR(45)) RETURNS INT
BEGIN
	DECLARE comparar INT UNSIGNED DEFAULT 0;
	DECLARE contraTemp LONGTEXT;
	DECLARE contraCif BLOB;
	SELECT COUNT(*) FROM usuario WHERE Nombre=vNombre INTO comparar;
	IF (comparar!=0) THEN
		SELECT Clave FROM usuario WHERE Nombre=vNombre INTO contraCif;
		SET contraTemp=AES_DECRYPT(contraCif,vPass);
		IF(STRCMP(vPass,contraTemp)=0) THEN
			RETURN 1;
		ELSE
			RETURN 0;
		END IF;
	ELSE
		RETURN 0;
	END IF;
END//
DELIMITER ;