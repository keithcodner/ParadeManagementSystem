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
-- Table structure for table `download`
--

DROP TABLE IF EXISTS `download`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `download` (
  `downloadID` int(11) NOT NULL AUTO_INCREMENT,
  `dFileName` varchar(250) DEFAULT NULL,
  `dDescription` longtext,
  `dFileDate` date DEFAULT NULL,
  `dFileUserType` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`downloadID`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `download`
--

LOCK TABLES `download` WRITE;
/*!40000 ALTER TABLE `download` DISABLE KEYS */;
INSERT INTO `download` VALUES (13,'temp_pms_floatdetails.sql','temp','2013-02-16','Admin'),(14,'test_pms_floatdetails.sql','test','2013-02-17','Admin'),(16,'deliverable_delmeetings_marek_v3.docx','del','2013-02-17','Admin'),(17,'t_crysis_3_links.txt','t','2013-02-18','Admin'),(18,'t_crysis_3_links.txt','t','2013-02-18','Admin'),(19,'t_crysis_3_links.txt','t','2013-02-18','Admin'),(20,'r_crysis_3_links.txt','r','2013-02-18','Admin'),(21,'d_crysis_3_links.txt','d','2013-02-18','Admin'),(22,'t_crysis_3_links.txt_204119','t','2013-02-18','Admin'),(23,'t__20424_crysis_3_links.txt','this is another test','2013-02-18','Admin'),(24,'test2__204237_crysis_3_links.txt','test2','2013-02-18','Admin'),(25,'Crysis Links__21729_crysis_3_links.txt','These are crysis 3 links, enjoy!:)','2013-02-18','Participant'),(26,'hey you!__211714_UYeQULW.gif','guy bumps into pole, then him and his friend start a fight with it.','2013-02-27','Admin');
/*!40000 ALTER TABLE `download` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-06 18:49:27
