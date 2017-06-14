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
-- Table structure for table `messagefromuser`
--

DROP TABLE IF EXISTS `messagefromuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `messagefromuser` (
  `messageID` int(11) NOT NULL AUTO_INCREMENT,
  `paradeID` int(11) DEFAULT NULL,
  `uID` int(11) DEFAULT NULL,
  `userName` varchar(45) DEFAULT NULL,
  `messageDate` date DEFAULT NULL,
  `messageName` varchar(90) DEFAULT NULL,
  `messageDesc` longtext,
  `messageStatus` varchar(45) DEFAULT 'new',
  `blacklist` varchar(45) DEFAULT 'no',
  PRIMARY KEY (`messageID`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messagefromuser`
--

LOCK TABLES `messagefromuser` WRITE;
/*!40000 ALTER TABLE `messagefromuser` DISABLE KEYS */;
INSERT INTO `messagefromuser` VALUES (10,5,4,'smitty','2012-10-27','test4','test4','old','no'),(11,5,4,'smitty','2012-10-27','test5','test5','old','no'),(12,5,4,'smitty','2012-10-27','Nerdy User TRoll','Hey, i just joined this site and it sucks. I hope that this site gets DDOsed ahahah!!! \r\n\r\np.s. ur a loser!','old','no'),(13,5,5,'candyman','2012-10-27','Heya Bro!','Hey I just wanna say that i love this site!','old','no'),(14,5,5,'candyman','2012-10-27','test','testing characters <','old','no'),(16,5,4,'smitty','2012-10-28','This is such a good website','I would like to thank you, this is also a test btw','old','no'),(17,5,4,'smitty','2012-10-28','HEY','I AM AN ANGRY USER!!!!','old','no'),(24,6,4,'smitty','2012-10-28','the problem should be fixed now','the problem should be fixed now','old','no'),(26,5,4,'smitty','2012-10-29','im blacklisted','im blacklisted but i need to contact admin to test','old','no'),(27,5,4,'smitty','2012-10-29','messages still show if black listed','messages still show if black listed','old','no'),(28,6,6,'megaman','2012-10-29','did u get my message?','Its the next parade, just wanna know','old','no'),(30,5,7,'ssbrigade','2012-11-03','hey','this is another message i hope this works','old','no'),(31,5,7,'ssbrigade','2012-11-04','Hay','is this workingz?','old','no'),(33,5,4,'smitty','2012-11-16','Email change','Can you please change my emails from its current email to blahblahblah@example.com\r\n\r\nThanks so much! have  nice day :)','old','no'),(34,5,4,'smitty','2012-11-16','This is to test if the ','button is disabled after the page is submitted, hope it works','old','no'),(35,6,4,'smitty','2013-01-06','Hi, my status is now complete','Just wanted to let you know that my status is now complete and you can look at it in the uploads i sent you. thanks','old','no'),(36,5,95,'mdice','2013-03-01','Organization Request','Hi,\r\n\r\nI would like to request an additional organization for my account.\r\n\r\nThanks,\r\nMark','old','no');
/*!40000 ALTER TABLE `messagefromuser` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-06 18:49:28
