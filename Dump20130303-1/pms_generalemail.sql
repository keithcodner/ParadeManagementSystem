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
-- Table structure for table `generalemail`
--

DROP TABLE IF EXISTS `generalemail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `generalemail` (
  `generalEmailID` int(11) NOT NULL AUTO_INCREMENT,
  `subjectOne` varchar(500) DEFAULT NULL,
  `subjectTwo` varchar(500) DEFAULT NULL,
  `subjectThree` varchar(500) DEFAULT NULL,
  `subjectFour` varchar(500) DEFAULT NULL,
  `subjectFive` varchar(500) DEFAULT NULL,
  `bodyOne` longtext,
  `bodyTwo` longtext,
  `bodyThree` longtext,
  `bodyFour` longtext,
  `bodyFive` longtext,
  `footerOne` longtext,
  `footerTwo` longtext,
  `footerThree` longtext,
  `footerFour` longtext,
  `footerFive` longtext,
  `fromAddress` varchar(95) DEFAULT NULL,
  `smtphost` varchar(95) DEFAULT NULL,
  `useremail` varchar(95) DEFAULT NULL,
  `userpass` varchar(45) DEFAULT NULL,
  `port` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`generalEmailID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generalemail`
--

LOCK TABLES `generalemail` WRITE;
/*!40000 ALTER TABLE `generalemail` DISABLE KEYS */;
INSERT INTO `generalemail` VALUES (1,'BBoT ParadeMS : Your user Account is now created','BBoT ParadeMS: Your organization is now created','BBoT ParadeMS: Your float is now created',NULL,NULL,'Congratulations! Your User account is now created. You will need to validate your account when you first log in. Here is the code you need to use:  ','Congratulations! Your Organization account is now created.','Congratulations! Your Float account is now created.',NULL,NULL,'Thank you for registering. We look forward to you participating in our celebration!:)','Thank you for registering. We look forward to you participating in our celebration!:)','Thank you for registering. We look forward to you participating in our celebration!:)',NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(4,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(5,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(6,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `generalemail` ENABLE KEYS */;
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
