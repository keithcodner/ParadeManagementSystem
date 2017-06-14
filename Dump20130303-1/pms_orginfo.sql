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
-- Table structure for table `orginfo`
--

DROP TABLE IF EXISTS `orginfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orginfo` (
  `pOrgID` int(11) NOT NULL AUTO_INCREMENT,
  `uID` int(11) DEFAULT NULL,
  `paradeID` int(11) DEFAULT NULL,
  `oContact` varchar(45) DEFAULT NULL,
  `oOrganization` varchar(45) NOT NULL,
  `oAddress1` varchar(45) DEFAULT NULL,
  `oAddress2` varchar(45) DEFAULT NULL,
  `oCity` varchar(45) DEFAULT NULL,
  `oProvince` varchar(45) DEFAULT NULL,
  `oCountry` varchar(45) DEFAULT NULL,
  `oPostal` varchar(45) DEFAULT NULL,
  `oPhone` varchar(24) DEFAULT NULL,
  `oFax` bigint(11) DEFAULT NULL,
  `oWebsite` varchar(45) DEFAULT NULL,
  `oSeminarAtt` varchar(45) DEFAULT 'Mandatory',
  `oActivation` varchar(45) DEFAULT 'In-Active',
  `oProposal` varchar(500) DEFAULT NULL,
  `oEmail` varchar(45) DEFAULT NULL,
  `oStatus` varchar(45) DEFAULT NULL,
  `oDateJoined` date DEFAULT NULL,
  `oDateExpire` date DEFAULT '2012-11-30',
  `oFileName` varchar(250) DEFAULT 'N/A',
  PRIMARY KEY (`pOrgID`),
  KEY `fk_uID` (`uID`),
  KEY `fk_paradeID` (`paradeID`),
  CONSTRAINT `fk_paradeID` FOREIGN KEY (`paradeID`) REFERENCES `parade` (`paradeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_uID` FOREIGN KEY (`uID`) REFERENCES `user` (`uID`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orginfo`
--

LOCK TABLES `orginfo` WRITE;
/*!40000 ALTER TABLE `orginfo` DISABLE KEYS */;
INSERT INTO `orginfo` VALUES (5,6,5,'kjblue','The Light Corp','4193 Eden Place',NULL,'Milton','Ontario','Canada','l0l 7y7','9876543211',NULL,'123abc.com','Mandatory','Active',NULL,'codnerk@gmail.com',NULL,'2012-10-29','2049-02-07',NULL),(9,10,5,'','markpb Org','6 Queen Street',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markpa.com','','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(11,13,5,'markpe','markpe Org','99 markpe Street',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(12,14,5,'markpf','markpf Org','34 markpf Boulevard',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(13,15,5,'markpg','markpg Org','23 markpg Road',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(14,16,5,'markph','markph Org','34 markph Road',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(16,18,5,'markpj','markpj Org','245 markpj Street',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(19,23,5,'markpm','markpm','7 markpm Road',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(20,24,5,'markpn','markpm Org','markpm Road',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(21,25,5,'markpo','markpo Org','markpo Road',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(22,26,5,'markpp','markpp Org','13 markpp Road',NULL,'Buffolo','Ontario','Canada','L5D 5L5','(905) 555-5555',NULL,'www.markp.com','Mandatory','Active',NULL,'pllo@hotmail.com',NULL,'2012-11-06','2049-02-07',NULL),(33,4,5,'Doug','Jims and Jones','1111 Arrow Rd.',NULL,'Toronto','Ontario','Canada','l0l 7y7','6478310307',NULL,'123abc.com','Mandatory','In-Active',NULL,'codnerk@gmail.com',NULL,'2012-11-17','2049-02-07','smitty_Jims_and_Jones_ParadeMSOrganizationTable_2013-2-19_21-35-47.csv'),(36,48,5,'Aran ','Larx','1111 Arrow Rd.',NULL,'Ajax','Ontario','Canada','l0l 7y7','6478310307',NULL,'helloworld.com','Mandatory','In-Active',NULL,'codnerk@gmail.com',NULL,'2013-01-06','2049-02-07','N/A'),(37,63,5,'Kiteh','Jims and Jonesy','1111 Arrow Rd.',NULL,'Inner-GTA','Ontario','Canada','l0l 7y7','6478310307',NULL,'helloworld.com','Mandatory','Active',NULL,'codnerk@gmail.com',NULL,'2013-01-15','2049-02-07','kjbluex_Jims_and_Jonesy_calc.exe'),(39,65,7,'Leslie','St. Thomas Acquinas SS','123 Somewhere St.',NULL,'Buffolo','Ontario','Canada','L7Y 6T6','2323232323',NULL,'','Mandatory','Active',NULL,'barbara@barbaraschembri.com',NULL,'2013-01-16','2049-02-07','lmarchand_St._Thomas_Acquinas_SS_ds.txt'),(40,65,9,'Leslie','St. Thomas Acquinas SS','1111 Arrow Rd.',NULL,'Buffolo','Ontario','Canada','l0l 7y7','6478310307',NULL,'123abc.com','Mandatory','Active',NULL,'codnerk@gmail.com',NULL,'2013-01-17','2049-02-07','N/A'),(43,4,6,'Doug Codners','Jims and Jones','4193 Eden Place',NULL,'Milton','Ontario','Canada','l0l 7y7','6478310307',NULL,'abc.com','Manditory','In-Active',NULL,'codnerk@gmail.com',NULL,'2013-01-22','2049-02-07','N/A'),(44,51,6,'Debbie Watson','Jims and Jones','4193 Eden Place',NULL,'Milton','Ontario','Canada','l0l 7y7','6478310307',NULL,'ddd','','Active',NULL,'codnerk@gmail.com',NULL,'2013-01-26','2049-02-07','N/A'),(45,50,6,'Mark Essaye','Jims and Jones','614 Eden Place',NULL,'Milton','Ontario','Canada','L9T 5V2','6478310307',NULL,'','Mandatory','Active',NULL,'codnerk@gmail.com',NULL,'2013-01-26','2049-02-07','N/A'),(46,93,5,'Scott Summers','x-men','1111 Arrow Rd.',NULL,'Toronto','Ontario','Canada','l0l 7y7','6478310307',NULL,'helloworld.com','Manditory','In-Active',NULL,'codnerk@gmail.com',NULL,'2013-01-27','2049-02-07','cyclops_x-men_31gFrst.png'),(47,4,7,'Doug Codners','Jims and Jones','1111 Arrow Rd.',NULL,'Toronto','Ontario','Canada','l0l 7y7','6478310307',NULL,'helloworld.com','Mandatory','In-Active',NULL,'codnerk@gmail.com',NULL,'2013-01-28','2049-02-07','N/A'),(48,95,5,'mark  dice','Star Wars','1111 Arrow Rd.',NULL,'Toronto','Ontario','Canada','l0l 7y7','6478310307',NULL,'helloworld.com','Manditory','Active',NULL,'codnerk@gmail.com',NULL,'2013-03-01','2049-02-07','mdice_Star_Wars_Batch.Picture.Protector.v2.1-GAOTD.rar');
/*!40000 ALTER TABLE `orginfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-06 18:49:26
