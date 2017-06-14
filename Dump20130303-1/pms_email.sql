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
-- Table structure for table `email`
--

DROP TABLE IF EXISTS `email`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `email` (
  `emailID` int(11) NOT NULL AUTO_INCREMENT,
  `fromaddress` varchar(95) DEFAULT NULL,
  `activesubject` varchar(500) DEFAULT NULL,
  `inactivesubject` varchar(500) DEFAULT NULL,
  `activebody` longtext,
  `inactivebody` longtext,
  `activefooter` longtext,
  `inactivefooter` longtext,
  `smtphost` varchar(95) DEFAULT NULL,
  `useremail` varchar(95) DEFAULT NULL,
  `userpass` varchar(45) DEFAULT NULL,
  `port` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`emailID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `email`
--

LOCK TABLES `email` WRITE;
/*!40000 ALTER TABLE `email` DISABLE KEYS */;
INSERT INTO `email` VALUES (1,'codnerk@sheridanc.on.ca','BBoT ParadeMS : You administrative account has been activated!','BBoT ParadeMS : Your administrative account has been de-activated!','Your administrative account has now been activated. You will be able to log in and manage other users.','Your administrative account has now been de- activated. You will no longer be able to log in and manage other users.','Thank You. We look forward to your help in managing the Parade Management System.','Thank You for your help. :)',NULL,NULL,NULL,NULL),(2,NULL,'BBoT ParadeMS : Your Participant account has been activated!','BBoT ParadeMS : Your Participant account has been de-activated!','Congratulations! Your Participant account is now activated. You will be eligible to edit your organization and float details.','Unfortunately, your Participant account is now de-activated. You are still eligible to edit your  organizations and float details.','Thank you for your time. We look forward to seeing you in our up coming parade.','Thank you for your time. We look forward to seeing you participate in our next parade.',NULL,NULL,NULL,NULL),(3,NULL,'BBoT ParadeMS : Your Volunteer account has been activated!','BBoT ParadeMS : Your Volunteer account has been de-activated!','Congratulations! Your Volunteer account is now activated, and you are eligible to volunteer in the parade. More information will be sent to you, we\'ll keep you posted.','Unfortunately, Your Volunteer account is now de-activated. You are still eligible to edit your  organizations and float details.','Thank you for your time. We look forward to seeing you in our up coming parade.','Thank you for your time. We look forward to seeing you volunteer in our next parade.',NULL,NULL,NULL,NULL),(4,NULL,'BBoT ParadeMS : Your Organization has been activated!','BBoT ParadeMS : Your Organization has been de-activated!','Congratulations! Your Organization  is now activated. You will be eligible to edit your  float details but your organization details are now locked.','Unfortunately, your Organization is now de-activated. You are still eligible to edit your  organizations and float details.','Thank you for your time. We look forward to seeing you in our up coming parade.','Thank you for your time. We look forward to seeing you participate in our next parade.',NULL,NULL,NULL,NULL),(5,NULL,'BBoT ParadeMS : Your Float has been Approved!','BBoT ParadeMS : Your Float has been Disapproved!','Congratulations! Your Float is now activated. You are eligible to be in the upcoming parade! We\'ll keep you updated.','Unfortunately, your Float is now de-activated. You are still eligible to edit your  organizations and float details.','Thank you for your time. We look forward to seeing you in our up coming parade.:)','Thank you for your time. We look forward to seeing you participate in our next parade.:)',NULL,NULL,NULL,NULL),(6,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'smtp.sheridanc.on.ca','codnerk@sheridanc.on.ca','Megaman283518','587');
/*!40000 ALTER TABLE `email` ENABLE KEYS */;
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
