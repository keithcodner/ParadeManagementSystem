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
-- Table structure for table `parade`
--

DROP TABLE IF EXISTS `parade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parade` (
  `paradeID` int(11) NOT NULL AUTO_INCREMENT,
  `paradeName` varchar(95) NOT NULL,
  `paradeYear` varchar(10) DEFAULT NULL,
  `paradeType` varchar(95) DEFAULT NULL,
  `paradeDate` varchar(20) DEFAULT NULL,
  `paradeStartTime` varchar(25) DEFAULT NULL,
  `paradeEndTime` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`paradeID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parade`
--

LOCK TABLES `parade` WRITE;
/*!40000 ALTER TABLE `parade` DISABLE KEYS */;
INSERT INTO `parade` VALUES (5,'2012 Buffolo Board of Trade Santa Clause Parade','2012','Santa Clause','2012-12-12','12:12:12','12:12:12'),(6,'2013 Buffolo Board of Trade Santa Clause Parade','2013','Santa Clause','2013-12-12','12:12:12','12:12:12'),(7,'2014 Buffolo Board of Trade Santa Clause Parade','2014','Santa Clause','2014-12-12','12:12:12','12:12:12'),(9,'2016 Buffolo Board of Trade Santa Clause Parade','2016','Santa Clause','2012-12-12','12:34:00','12:12:12'),(11,'2018 Buffolo Board of Trade Santa Clause Parade','2018','Santa Clause','12/12/2018','12:12:12','12:12:12'),(12,'2022 Buffolo Board of Trade Santa Clause Parade','2022','Sana Clause Parade','12/12/2022','12:12:12','12:12:12'),(13,'2023 Buffolo Board of Trade Santa Clause Parade','2023','Sana Clause Parade','12/12/2023','11:21:21','12:12:12'),(14,'2024 Buffolo Board of Trade Santa Clause Parade','','','','',''),(15,'2025 Buffolo Board of Trade Santa Clause Parade','','','','',''),(17,'2027 Buffolo Board of Trade Santa Clause Parade','2027','Santa Clause','12/12/2027','12:12:12','12:12:12');
/*!40000 ALTER TABLE `parade` ENABLE KEYS */;
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
