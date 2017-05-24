DELIMITER //
DROP FUNCTION IF EXISTS descifraAccesos//
CREATE FUNCTION descifraAccesos (dato INT, llave VARCHAR(45), vNombre VARCHAR(45)) RETURNS VARCHAR(45)
BEGIN
	DECLARE retorno VARCHAR(45);
	DECLARE cif BLOB;
	SET retorno = "";
	#Si dato es 1 es para usuarios (seguridad), 2 es para clientes, 3 es para pedidos, 4 es para trabajadores
	IF (dato=1) THEN
		SELECT Acceso_Seguridad FROM usuario WHERE Nombre=vNombre INTO cif;
		SET retorno = AES_DECRYPT(cif,llave);
		RETURN retorno;
	ELSE 
		IF (dato=2) THEN
			SELECT Acceso_Clientes FROM usuario WHERE Nombre=vNombre INTO cif;
			SET retorno = AES_DECRYPT(cif,llave);
			RETURN retorno;
		ELSE
			IF (dato=3) THEN
				SELECT Acceso_Pedidos FROM usuario WHERE Nombre=vNombre INTO cif;
				SET retorno = AES_DECRYPT(cif,llave);
				RETURN retorno;
			ELSE
				IF (dato=4) THEN
					SELECT Acceso_Trabajadores FROM usuario WHERE Nombre=vNombre INTO cif;
					SET retorno = AES_DECRYPT(cif,llave);
					RETURN retorno;
				END IF;
			END IF;
		END IF;
	END IF;
	RETURN retorno;
END//
DELIMITER ;