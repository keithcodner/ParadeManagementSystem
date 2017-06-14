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
-- Table structure for table `floatdetails`
--

DROP TABLE IF EXISTS `floatdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `floatdetails` (
  `floatID` int(11) NOT NULL AUTO_INCREMENT,
  `porgID` int(11) DEFAULT NULL,
  `paradeID` int(11) DEFAULT NULL,
  `uID` int(11) DEFAULT NULL,
  `parade` varchar(95) DEFAULT NULL,
  `Organization` varchar(45) DEFAULT NULL,
  `Contact` varchar(45) DEFAULT NULL,
  `entry` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `vehicleType` varchar(45) DEFAULT NULL,
  `floatLength` varchar(45) DEFAULT NULL,
  `floatHeight` varchar(45) DEFAULT NULL,
  `floatWidth` varchar(45) DEFAULT NULL,
  `marchers` varchar(45) DEFAULT NULL,
  `noOfMarchers` varchar(45) DEFAULT NULL,
  `soundSystem` varchar(45) DEFAULT NULL,
  `floatDesc` varchar(2000) DEFAULT NULL,
  `comments` varchar(2000) DEFAULT NULL,
  `waiver` varchar(2000) DEFAULT NULL,
  `waiverAccepter` varchar(45) DEFAULT NULL,
  `receivedFee` varchar(45) DEFAULT NULL,
  `amount` int(11) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `entryNo` int(11) DEFAULT NULL,
  `entryCode` varchar(45) DEFAULT NULL,
  `approved` varchar(45) DEFAULT 'Not Approved',
  `banner` varchar(600) DEFAULT NULL,
  `scriptLock` varchar(45) DEFAULT 'Unlocked',
  PRIMARY KEY (`floatID`),
  KEY `fk_orginfo` (`porgID`),
  KEY `fk_OrgID` (`porgID`),
  KEY `fk_pOrgID` (`porgID`),
  KEY `fk_paradeIDs` (`paradeID`),
  CONSTRAINT `fk_paradeIDs` FOREIGN KEY (`paradeID`) REFERENCES `parade` (`paradeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_pOrgID` FOREIGN KEY (`porgID`) REFERENCES `orginfo` (`pOrgID`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `floatdetails`
--

LOCK TABLES `floatdetails` WRITE;
/*!40000 ALTER TABLE `floatdetails` DISABLE KEYS */;
INSERT INTO `floatdetails` VALUES (5,5,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','','kjblue','0','','1','2','3','Yes','4','Yes','This is a description','This is a description',NULL,'Buffolo','Yes',250,'Complete',1,'##','Approved','This is a description','Unlocked'),(6,NULL,NULL,NULL,'','',NULL,'0','','','','','No','','No','','',NULL,'0','No',250,'Complete',19,'','Approved','','Unlocked'),(12,9,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopb Org','Buffolopb','Float','Flat Bed Truck','10','10','10','Yes','20','No','Float Description:\r\n(Max 1000 chars.) ','Banner:\r\n(Max 1000 chars.) ',NULL,'Buffolo','Yes',50,'Inspected',4,'','Approved',NULL,'Locked'),(14,11,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolope Org','Buffolope','Band','Car','6','7','9','Yes','40','No',NULL,NULL,NULL,'0','No',NULL,NULL,NULL,NULL,'Not Approved',NULL,'Unlocked'),(15,12,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopf Org','Buffolopf','Float Band','Car','7','9','8','Yes','12','Yes','Float Description:\r\n(Max 1000 chars.) ','Banner:\r\n(Max 1000 chars.) ',NULL,'0','Yes',50,'Inspected',7,'','Approved',NULL,'Unlocked'),(16,13,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopg Org','Buffolopg','Float','Flat Bed Truck','10','10','14','No','','No',NULL,NULL,NULL,'0','No',NULL,NULL,NULL,NULL,'Approved',NULL,'Unlocked'),(17,14,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffoloph Org','Buffoloph','Float Band','Flat Bed Truck','8','7','7','Yes','34','No','Float Description:\r\n(Max 1000 chars.) ','Banner:\r\n(Max 1000 chars.) ',NULL,'0','Yes',50,'Complete',NULL,'','Approved',NULL,'Unlocked'),(19,16,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade',NULL,'Buffolopj',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Approved',NULL,'Unlocked'),(22,16,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopj Org','Buffolopj','Band','Car','5','7','8','Yes','12','No','Float Description:\r\n(Max 1000 chars.)','Banner:\r\n(Max 1000 chars.) ',NULL,'0','No',0,'Inspected',15,'','Approved',NULL,'Unlocked'),(23,16,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopj Org','Buffolopj','Band','Flat Bed Truck','7','8','9','Yes','0','No','Float Description:\r\n(Max 1000 chars.) ','Banner:\r\n(Max 1000 chars.) ',NULL,'Buffolo','No',0,'Complete',13,'','Approved',NULL,'Unlocked'),(24,16,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopj Org','Buffolopj','Float Band','Flat Bed Rig','8','7','9','Yes','34','No','Float Description:\r\n(Max 1000 chars.) ','Banner:\r\n(Max 1000 chars.) ',NULL,'0','No',0,'Complete',16,'','Approved',NULL,'Unlocked'),(27,19,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade',NULL,'Buffolopm',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Approved',NULL,'Unlocked'),(28,20,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade',NULL,'Buffolopn',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Approved',NULL,'Unlocked'),(30,22,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade',NULL,'Buffolopp',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Approved',NULL,'Unlocked'),(32,21,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopo Org','Buffolopo','Float','Car','5','10','15','No','0','Yes','Nice big float with lots of shiny lights and a licorice castle on top with lights and licorice','The Great Hall of Licorice',NULL,'Buffolo','No',0,'Complete',2,'','Approved',NULL,'Unlocked'),(33,21,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopo Org','Buffolopo','Float','Car','5','0','0','No','0','No','Large igloo will be mounted to the roof of my Buick. We will have around 20 mins before it melts so we will need to go first','Mikes Ice',NULL,'0','No',0,'Complete',3,'','Approved',NULL,'Unlocked'),(34,22,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopp Org','Buffolopp','Float','Flat Bed Rig','5','12','5','Yes','12','No','12 foot top hat will be on the rig and my late cat fluffymunchkin will be riding it on the very top','Crazy Bills Crazy Poutinerie. Cats.',NULL,'0','No',0,'Complete',4,'','Approved',NULL,'Unlocked'),(38,20,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopm Org','Buffolopn','Float','Flat Bed Truck','10','15','14','No','0','No','On the road to nowhere. We will be pushing an old Buick slowly along the parade route. There will be no waving as we will be pushing.','Buffolopm and Sons Mechanics',NULL,'0','No',0,'Complete',7,'','Approved',NULL,'Unlocked'),(40,13,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopg Org','Buffolopg','Band','Flat Bed Truck','7','5','6','No','0','No','Some stuff happening as we walk... maybe bring a boombox','The Sideroad Dance Troupe.',NULL,'0','No',0,'Complete',8,'','Approved',NULL,'Unlocked'),(41,12,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopf Org','Buffolopf','Float','Flat Bed Rig','25','6','8','Yes','15','Yes','There will be a medium sized container that we will be using to hold the garbage we pick up along the parade route','Buffolopf Org Volunteer Park Cleaners',NULL,'0','No',0,'Complete',9,'','Approved',NULL,'Unlocked'),(42,12,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopf Org','Buffolopf','Float','Car','6','7','6','No','0','No','Drive a nice car, waving to the crowd','Buffolopf Gourmet Cars',NULL,'0','Yes',50,'Complete',10,'','Approved',NULL,'Unlocked'),(43,9,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolopb Org','Buffolopb','Float','Car','7','7','7','Yes','12','Yes','We will be performing gymnastics routines along the route as well as throwing batons and twirling those thingies with the ribbons','The Professors Lake Gymnastics Team',NULL,'0','No',0,'Complete',11,'','Approved',NULL,'Unlocked'),(46,11,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffolope Org','Buffolope','Band','Car','6','7','15','No','0','No','Our accordion and brass band will be playing fur elise in a loop.','Mayfield Academy Band.',NULL,'0','No',0,'Complete',14,'','Approved',NULL,'Unlocked'),(47,14,5,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Buffoloph Org','Buffoloph','Float','Flat Bed Rig','7','8','9','Yes','12','No','We will have a hot tub rigged up in our flat bed. We will put blow up dolls inside and throw sponges at the audience.','Jack Jump Over The Spa - Because the moons sort of far I guess and when youre done jumping you can have a rest.',NULL,'0','No',0,'Complete',15,'','Approved',NULL,'Unlocked'),(54,33,5,4,'2012 Buffolo Board of Trade Santa Clause Parade','Jims and Jones','Doug','Band','Car','3','2','1','Yes','0','Yes','aaa','bbb',NULL,'','',0,'New',0,'','Not Approved','bbb','Unlocked'),(58,36,5,48,'2013 Buffolo Board of Trade Santa Clause Parade','Larx','Aran ','Float','Car','3','2','1','Yes','0','Yes','This is a description','This is a description',NULL,'0','No',250,'Complete',3,'$#','Not Approved','This is a description','Unlocked'),(59,37,5,63,'2013 Buffolo Board of Trade Santa Clause Parade','Jims and Jonesy','Buffolo','Float','Flat Bed Truck','1','2','3','Yes','12','Yes','The server at en.wikipedia.org can\'t be found, because the DNS lookup failed. DNS is the network service that translates a website\'s name to its Internet address.','The server at en.wikipedia.org can\'t be found, because the DNS lookup failed. DNS is the network service that translates a website\'s name to its Internet address.',NULL,'admin','Yes',250,'New',4,'','Approved','This error is most often caused by having no connection ','Unlocked'),(62,40,9,65,'2016 Buffolo Board of Trade Santa Clause Parade',NULL,'Leslie',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,NULL,'Approved',NULL,'Unlocked'),(65,43,6,4,'2013 Buffolo Board of Trade Santa Clause Parade','Jims and Jones','Doug Codners','Dignitaries','Car','1','2','3','No','0','Yes','this is the description','this is the script, i thought i changed this? yea i guess i did, are you sure? for the love...YES I DID!! Okay and it works',NULL,'0','No',0,'New',0,'','Approved','this is the script, i thought i changed this? yea i guess i did, are you sure? for the love...YES I ','Locked'),(68,44,6,NULL,'2012 Buffolo Board of Trade Santa Clause Parade','Jims and Jones','Debbie','Dignitaries','Car','1','2','3','Yes','4','Yes','test','test',NULL,'admin','Yes',250,'Complete',1,'','Approved','test','Unlocked'),(69,46,5,93,'2012 Buffolo Board of Trade Santa Clause Parade','-Select Organization-','Scott Summers','0','-Select Float Type-','','','','No','','No','','',NULL,'','',0,'New',0,'','Not Approved','','Unlocked'),(70,47,7,4,'2014 Buffolo Board of Trade Santa Clause Parade','Jims and Jones','Doug Codners','Band','Flat Bed Rig','1','2','3','No','12','No','create and deliver applied, research-based, and engaging professional development courses. SheridanCorporate’s Leadership programming incorporates creative process and encourages participants to challenge the status quo in pursuit of authentic behavioural and cultural change. We strive to create a culture of collaboration and innovation by inspiring people and their organizations to create, experiment, perform, and produce strategically.','create and deliver applied, research-based, and engaging professional development courses. SheridanCorporate’s Leadership programming incorporates creative process and encourages participants to challenge the status quo in pursuit of authentic behavioural and cultural change. We strive to create a culture of collaboration and innovation by inspiring people and their organizations to create, experiment, perform, and produce strategically.',NULL,'','',0,'New',0,'','Not Approved','create and deliver applied, research-based, and engaging professional development courses. SheridanCorporate’s Leadership programming incorporates creative process and encourages participants to challenge the status quo in pursuit of authentic behavioural and cultural change. We strive to create a culture of collaboration and innovation by inspiring people and their organizations to create, experiment, perform, and produce strategically.','Unlocked'),(71,48,5,95,'2012 Buffolo Board of Trade Santa Clause Parade','-Select Organization-','mark  dice','0','-Select Float Type-','','','','No','0','No','','This is a description about something ',NULL,'','',0,'New',0,'','Not Approved','','Locked');
/*!40000 ALTER TABLE `floatdetails` ENABLE KEYS */;
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
