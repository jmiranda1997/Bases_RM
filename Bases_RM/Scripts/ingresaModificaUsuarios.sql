DELIMITER //
DROP PROCEDURE IF EXISTS ingresaModificaUsuarios//
CREATE PROCEDURE ingresaModificaUsuarios (usuarios VARCHAR(45), clientes VARCHAR(45), pedidos VARCHAR(45), trabajadores VARCHAR(45), llave VARCHAR(45), vNombre VARCHAR(45))
BEGIN
	DECLARE existe INT UNSIGNED DEFAULT 0;
	SELECT COUNT(*) FROM usuario WHERE Nombre=vNombre INTO existe;
	IF (existe>0) THEN
		UPDATE usuario SET Acceso_Pedidos=AES_ENCRYPT(pedidos,llave), Acceso_Clientes=AES_ENCRYPT(clientes,llave), Acceso_Trabajadores=AES_ENCRYPT(trabajadores,llave), Acceso_Seguridad=AES_ENCRYPT(usuarios,llave) WHERE Nombre=vNombre;
	END IF;
END//
DELIMITER ;