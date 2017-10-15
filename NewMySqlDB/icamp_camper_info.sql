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
-- Table structure for table `camper_info`
--

DROP TABLE IF EXISTS `camper_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `camper_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `preferred_name` varchar(45) DEFAULT NULL,
  `bunk` int(11) NOT NULL,
  `age` int(11) NOT NULL,
  `nationality` varchar(45) NOT NULL,
  `restriction` varchar(255) DEFAULT NULL,
  `medications` varchar(255) DEFAULT NULL,
  `start_date` date NOT NULL,
  `leave_date` date NOT NULL,
  `transportation` varchar(45) NOT NULL,
  `parent1_name` varchar(45) NOT NULL,
  `parent1_phone` varchar(45) NOT NULL,
  `parent1_email` varchar(255) DEFAULT NULL,
  `parent2_name` varchar(45) DEFAULT NULL,
  `parent2_phone` varchar(45) DEFAULT NULL,
  `parent2_email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `camper_info`
--

LOCK TABLES `camper_info` WRITE;
/*!40000 ALTER TABLE `camper_info` DISABLE KEYS */;
INSERT INTO `camper_info` VALUES (11,'Andrew','',1,20,'Chinese','','','2017-10-10','2017-10-20','Air','Father','1234','sdf@kj.com','Mother','',''),(12,'Apiporn','',1,18,'Thai','','','2017-10-10','2017-10-25','BUS','emm','13412414','','yee','122222',''),(13,'Sada','A',3,20,'Japanese','no','no','2017-10-10','2017-10-20','Air','Ssaaddaa','123333444','dfds@ty.com','asd','',''),(14,'Mihoyo','Me',2,16,'No','No','','2017-10-06','2017-10-06','Fly','Noname','000','','Again','234',''),(15,'556','',5,55,'55','','','2017-10-06','2017-10-06','55','55','55','','55','55',''),(16,'New','',2,20,'Thai','','','2017-10-07','2017-10-26','','Htia','21434','sduf@ou.com','','',''),(17,'tee','',2,34,'fgfg','','','2017-10-15','2017-10-15','ere','gdf','3555','','','',''),(18,'sdaa','',2,45,'dfdf','','','2017-10-15','2017-10-15','fggsd','dsd','355','','','',''),(21,'Testid','',4,34,'dfdf','','','2017-10-15','2017-10-15','sdsd','asd','32','','','','');
/*!40000 ALTER TABLE `camper_info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-15 11:32:05
