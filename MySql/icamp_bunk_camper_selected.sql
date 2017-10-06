-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: icamp
-- ------------------------------------------------------
-- Server version	5.7.19-log

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
-- Table structure for table `bunk_camper_selected`
--

DROP TABLE IF EXISTS `bunk_camper_selected`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bunk_camper_selected` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `camper_id` int(11) DEFAULT NULL,
  `camper_name` varchar(45) NOT NULL,
  `bunk_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `activities_1` varchar(255) NOT NULL,
  `activities_2` varchar(255) NOT NULL,
  `activities_3` varchar(255) NOT NULL,
  `activities_4` varchar(255) NOT NULL,
  `activities_5` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bunk_camper_selected`
--

LOCK TABLES `bunk_camper_selected` WRITE;
/*!40000 ALTER TABLE `bunk_camper_selected` DISABLE KEYS */;
INSERT INTO `bunk_camper_selected` VALUES (5,NULL,'Andrew',1,'2017-10-07','Football','numm','Game!','ice','XboxOne'),(6,NULL,'Sada',4,'2017-10-07','Football','numm','Game!','awsome','PS3'),(7,NULL,'Apiporn',1,'2017-10-07','swim','numm','Game!','awsome','PS3'),(8,NULL,'Mihoyo',2,'2017-10-07','Football','Choose me','Football','awsome','PS4'),(9,NULL,'555',5,'2017-10-07','swim','numm','Game!','awsome','PS3');
/*!40000 ALTER TABLE `bunk_camper_selected` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-06  8:39:19
