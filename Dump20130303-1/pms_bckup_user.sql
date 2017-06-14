CREATE DATABASE  IF NOT EXISTS `pms` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `pms`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: pms
-- ------------------------------------------------------
-- Server version	5.5.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bckup_user`
--

DROP TABLE IF EXISTS `bckup_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bckup_user` (
  `uID` int(11) NOT NULL AUTO_INCREMENT,
  `paradeID` int(11) DEFAULT NULL,
  `pOrgID` int(11) DEFAULT NULL,
  `uUsername` varchar(30) NOT NULL,
  `uPassword` varchar(256) NOT NULL,
  `uFName` varchar(30) NOT NULL,
  `uLName` varchar(30) NOT NULL,
  `uHPhone` varchar(19) DEFAULT NULL,
  `uBPhone` varchar(19) DEFAULT NULL,
  `uStreet` varchar(30) DEFAULT NULL,
  `uCity` varchar(30) DEFAULT NULL,
  `uProv` varchar(25) DEFAULT NULL,
  `uPostal` varchar(7) DEFAULT NULL,
  `uEmail` varchar(80) DEFAULT NULL,
  `uStatus` varchar(20) DEFAULT NULL,
  `uActivation` varchar(25) DEFAULT 'In-Active',
  `uDateJoined` date DEFAULT NULL,
  `uDateExpire` datetime DEFAULT '2013-11-30 00:00:00',
  `uOrgName` varchar(90) DEFAULT NULL,
  `uLocked` varchar(45) DEFAULT NULL,
  `uEmailValidator` varchar(45) DEFAULT NULL,
  `uValidCode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bckup_user`
--

LOCK TABLES `bckup_user` WRITE;
/*!40000 ALTER TABLE `bckup_user` DISABLE KEYS */;
INSERT INTO `bckup_user` VALUES (20,5,NULL,'Buffolopl','E7C028330A559B1BD6389EA79777ABEBBF782A44','Buffolopl','Dornapl','(905) 555-5555','(416) 555-6666','34 Main Street','Buffolo','Ontario','L5X4J3','polskasokola@hotmail.com','Participant','Active','2012-11-06','2021-04-02 00:00:00','Buffolopl Org',NULL,'notValid',NULL);
/*!40000 ALTER TABLE `bckup_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `pms`.`recOrDel`
BEFORE DELETE ON `pms`.`bckup_user`
FOR EACH ROW
BEGIN

IF old.uActivation = 'Active' THEN

    INSERT INTO user VALUEs (old.uID,
  old.paradeID,
  old.pOrgID,
  old.uUsername,
  old.uPassword,
  old.uFName,
  old.uLName,
  old.uHPhone,
  old.uBPhone,
  old.uStreet,
  old.uCity,
  old.uProv,
  old.uPostal,
  old.uEmail,
  old.uStatus,
  old.uActivation,
  old.uDateJoined,
  old.uDateExpire,
  old.uOrgName,
  old.uLocked,
  old.uEmailValidator,
  old.uValidCode);
  
  ELSEIF old.uActivation = 'In-Active' THEN
  
  DELETE FROM bckup_user;
  
  END IF;
  
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-06 18:49:27
