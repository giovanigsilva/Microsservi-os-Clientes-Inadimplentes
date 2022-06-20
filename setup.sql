CREATE DATABASE  IF NOT EXISTS `vshopdb`;
USE `vshopdb`;
DROP TABLE IF EXISTS `Titulos`;
CREATE TABLE `Titulos` (
  `TituloId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`TituloId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
LOCK TABLES `Titulos` WRITE;
INSERT INTO `Titulos` VALUES (1,'Duplicata'),(2,'Boleto');
UNLOCK TABLES;
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
LOCK TABLES `__efmigrationshistory` WRITE;
INSERT INTO `__efmigrationshistory` VALUES ('20220608054540_Inicial','6.0.5'),('20220608054813_seedClientes','6.0.5');
UNLOCK TABLES;
DROP TABLE IF EXISTS `Clientes`;
CREATE TABLE `Clientes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Valor` decimal(12,2) NOT NULL,
  `Desde` date NOT NULL,
  `TituloId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Clientes_TituloId` (`TituloId`),
  CONSTRAINT `FK_Clientes_Titulos_TituloId` FOREIGN KEY (`TituloId`) REFERENCES `Titulos` (`TituloId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
LOCK TABLES `Clientes` WRITE;
INSERT INTO `Clientes` VALUES (1,'Giovani',45.50,'2021-12-04',1),(2,'Marcos',335.50,'2021-12-23',2),(3,'Alex',451.00,'2022-02-12',1);
UNLOCK TABLES;

