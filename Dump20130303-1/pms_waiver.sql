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
-- Table structure for table `waiver`
--

DROP TABLE IF EXISTS `waiver`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `waiver` (
  `waiverID` int(11) NOT NULL AUTO_INCREMENT,
  `wName` varchar(45) DEFAULT NULL,
  `wWaiver` longtext,
  `wType` varchar(45) DEFAULT 'Waiver',
  PRIMARY KEY (`waiverID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `waiver`
--

LOCK TABLES `waiver` WRITE;
/*!40000 ALTER TABLE `waiver` DISABLE KEYS */;
INSERT INTO `waiver` VALUES (1,'WAIVER 1','WAIVER RELEASE AND INDEMNIFICATION\r\nIn consideration of the Santa Claus Parade Committee\'s accepting this entry, I, myself, my heirs, executors, administrators, successors and assigns do hereby remise, release and forever discharge, waive and save harmless, protect and keep indemnified the Peel Regional Police Force, the City of Boston, The Boston Board of Trade, members of the Santa Claus Parade Committee, all parade volunteers, and any and all clubs, associations, sanctioning bodies and sponsoring companies, participants, competitors, entrants, officials, servants and representatives from and against any and all kinds of actions, claims, costs and expenses and demands in respect of death, injury, loss or damage, to my person or property, howsoever caused arising out of my (or my child\'s or representatives) participation in, both during and subsequent to this event and notwithstanding that the same may have been contributed to or occasioned by the negligence of any of the aforesaid. I attest that by submitting this entry, I acknowledge having read and agreed to the above waiver, release, and indemnification.\r\nWaiver Acceptor:	\r\n\r\nI have read and accept the above waiver','Waiver'),(2,'A Great Story','Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.','About'),(3,'c','c','Waiver'),(4,'d','d','Waiver'),(5,'USER ABOUT 1','The Boston Board of Trade Santa Claus Parade lights up downtown Boston on Saturday, November 20, 2010. The parade is the largest single day event in Peel Region and Ontario’s grandest nighttime parade.\r\n\r\nGiant inflatable floats will help mark the 25th Anniversary of the parade in celebration of the major sponsors: Rotary, the Boston Downtown Development Corporation and 407 ETR, as well as, the Boston Board of Trade – event host organization.\r\n\r\nThis not-to-miss holiday treat features unique floats decorated with thousands of lights, a record number of bands and performing groups, over 200 costumed characters, and, of course, Santa Claus and his elves.\r\n\r\nSo grab a chair and a thermos of hot chocolate and come enjoy a special evening for all ages. Don’t forget – along the route, letters to Santa will be collected by the Boston Guardian Elves and non-perishable food items will be collected by the Progress Club for their food drive.','About'),(8,'My name is Kiteh','And this is my descriptionssss','About');
/*!40000 ALTER TABLE `waiver` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-06 18:49:29
