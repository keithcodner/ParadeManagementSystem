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
-- Table structure for table `pageconfig`
--

DROP TABLE IF EXISTS `pageconfig`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pageconfig` (
  `configID` int(11) NOT NULL AUTO_INCREMENT,
  `Option` varchar(2045) DEFAULT NULL,
  `Value` varchar(2045) DEFAULT NULL,
  `Other` varchar(2045) DEFAULT NULL,
  `IDs` varchar(2045) DEFAULT NULL,
  PRIMARY KEY (`configID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pageconfig`
--

LOCK TABLES `pageconfig` WRITE;
/*!40000 ALTER TABLE `pageconfig` DISABLE KEYS */;
INSERT INTO `pageconfig` VALUES (1,'userActive','Active',NULL,NULL),(2,'orgActive','Active',NULL,NULL),(3,'userDateGE',NULL,NULL,NULL),(4,'orgDateGE',NULL,NULL,NULL),(5,'userEditTablePaging',NULL,NULL,NULL),(6,'orgEditTablePAging',NULL,NULL,NULL),(7,'WaiverTitle','WAIVER 1',NULL,NULL),(8,'confirmEnaDis','Disabled',NULL,NULL),(9,'confirmEnaDisOrg','Disabled',NULL,NULL),(10,'currentParade','2013 Buffolo Board of Trade Santa Clause Parade',NULL,'6'),(11,'scrollText','Buffolo Board of Trade Santa Claus Parade','MediumGreen',NULL),(12,'storeSelectedDates',NULL,NULL,NULL),(13,'FloatApproval','Approved',NULL,NULL),(14,'confirmEnaDisFloat','Disabled',NULL,NULL),(15,'GlobalParadeSelect','Global',NULL,NULL),(16,'GroupTransfer','False',NULL,NULL),(17,'GroupTransferWOFloat','False',NULL,NULL),(18,'GroupTrasnferWOOrg','False',NULL,NULL),(19,'GroupTransferDeleteFloat','False',NULL,NULL),(20,'UserAboutDesc','USER ABOUT 1',NULL,'5'),(21,'UserHomeImage','saint nick user',NULL,NULL),(22,'userLockoutCounter','0',NULL,NULL),(23,'adminLockoutCounter','4',NULL,NULL),(24,'excludeErrors','True',NULL,NULL),(25,'lockAllScripts','Locked',NULL,NULL),(26,'disableDownloads','False',NULL,NULL),(27,'snowFlakes','Disabled',NULL,NULL);
/*!40000 ALTER TABLE `pageconfig` ENABLE KEYS */;
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
