-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: platform_fighter
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `accessories`
--

DROP TABLE IF EXISTS `accessories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accessories` (
  `accessoryId` int NOT NULL,
  `accessoryName` varchar(30) DEFAULT NULL,
  `slotId` int DEFAULT NULL,
  PRIMARY KEY (`accessoryId`),
  KEY `slotId` (`slotId`),
  CONSTRAINT `accessories_ibfk_1` FOREIGN KEY (`slotId`) REFERENCES `accessoryslots` (`slotId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accessories`
--

LOCK TABLES `accessories` WRITE;
/*!40000 ALTER TABLE `accessories` DISABLE KEYS */;
INSERT INTO `accessories` VALUES (0,'cowboy_hat',0),(1,'rainbow_afro',0),(2,'clown_nose',1),(3,'goatee',3),(4,'sunglasses',2),(5,'bowtie',4),(6,'moon boots',6),(7,'champion belt',8),(8,'cartoon gloves',7),(9,'rollex',5),(10,'nerd glasses',2);
/*!40000 ALTER TABLE `accessories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accessoryslots`
--

DROP TABLE IF EXISTS `accessoryslots`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accessoryslots` (
  `slotId` int NOT NULL,
  `slotDesc` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`slotId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accessoryslots`
--

LOCK TABLES `accessoryslots` WRITE;
/*!40000 ALTER TABLE `accessoryslots` DISABLE KEYS */;
INSERT INTO `accessoryslots` VALUES (0,'hat'),(1,'nose'),(2,'glassess'),(3,'mouth'),(4,'collor'),(5,'wrists'),(6,'shoes'),(7,'gloves'),(8,'belt');
/*!40000 ALTER TABLE `accessoryslots` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characters`
--

DROP TABLE IF EXISTS `characters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characters` (
  `charId` int NOT NULL,
  `charName` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`charId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characters`
--

LOCK TABLES `characters` WRITE;
/*!40000 ALTER TABLE `characters` DISABLE KEYS */;
INSERT INTO `characters` VALUES (0,'Komo'),(1,'Pufferwinkle'),(2,'Gigachad');
/*!40000 ALTER TABLE `characters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `userId` int NOT NULL,
  `passHash` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`userId`),
  CONSTRAINT `login_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES (0,'4731450a2f221e57abdefa92c7815f2e2ddc62c2e90865201bb0a51f2c439b6d'),(1,'9fdce5249f4af9f37a3f29026af802ce844ec9252eb3902768b4261d4e0c2b05'),(2,'fc4c9df96999e6e04bac74655c1a091bf2275a01c6e95f4d3cf930fe1ee14a54'),(3,'27efe35e8c08404b9fe2689242de3b28277a81273c4d282002c7e97e639e983e'),(4,'185673d578fbf33fd17836e584de8ffbc8dd5ffa4a62c186d06db52d4644088e'),(5,'278d45f69aba7877e9ebae9c7045e07b0d46bba6ddadf038a48fc5108681571b');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skins`
--

DROP TABLE IF EXISTS `skins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skins` (
  `skinId` int NOT NULL,
  `charId` int NOT NULL,
  `skinName` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`skinId`,`charId`),
  KEY `charId` (`charId`),
  CONSTRAINT `skins_ibfk_1` FOREIGN KEY (`charId`) REFERENCES `characters` (`charId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skins`
--

LOCK TABLES `skins` WRITE;
/*!40000 ALTER TABLE `skins` DISABLE KEYS */;
INSERT INTO `skins` VALUES (0,0,'golden'),(0,1,'balloon'),(0,2,'royalty'),(1,0,'dark'),(1,1,'sumo'),(1,2,'all powerful'),(2,0,'inferno'),(2,1,'shaman'),(2,2,'zues');
/*!40000 ALTER TABLE `skins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unlocked_accessories`
--

DROP TABLE IF EXISTS `unlocked_accessories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unlocked_accessories` (
  `userId` int NOT NULL,
  `accessoryId` int NOT NULL,
  PRIMARY KEY (`accessoryId`,`userId`),
  KEY `userId` (`userId`),
  CONSTRAINT `unlocked_accessories_ibfk_1` FOREIGN KEY (`accessoryId`) REFERENCES `accessories` (`accessoryId`),
  CONSTRAINT `unlocked_accessories_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unlocked_accessories`
--

LOCK TABLES `unlocked_accessories` WRITE;
/*!40000 ALTER TABLE `unlocked_accessories` DISABLE KEYS */;
INSERT INTO `unlocked_accessories` VALUES (0,0),(0,1),(0,2),(0,3),(0,4),(0,5),(0,6),(0,7),(0,8),(0,9),(0,10),(1,0),(1,5),(1,6),(2,0),(2,1),(2,2),(3,8),(3,9),(3,10),(4,4),(4,5),(4,6),(5,1),(5,2),(5,7);
/*!40000 ALTER TABLE `unlocked_accessories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unlockedchars`
--

DROP TABLE IF EXISTS `unlockedchars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unlockedchars` (
  `userId` int NOT NULL,
  `charId` int NOT NULL,
  PRIMARY KEY (`userId`,`charId`),
  KEY `charId` (`charId`),
  CONSTRAINT `unlockedchars_ibfk_2` FOREIGN KEY (`charId`) REFERENCES `characters` (`charId`),
  CONSTRAINT `unlockedchars_ibfk_3` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unlockedchars`
--

LOCK TABLES `unlockedchars` WRITE;
/*!40000 ALTER TABLE `unlockedchars` DISABLE KEYS */;
INSERT INTO `unlockedchars` VALUES (0,0),(1,0),(3,0),(0,1),(1,1),(2,1),(4,1),(0,2),(2,2),(5,2);
/*!40000 ALTER TABLE `unlockedchars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unlockedskins`
--

DROP TABLE IF EXISTS `unlockedskins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unlockedskins` (
  `userId` int NOT NULL,
  `charId` int NOT NULL,
  `skinId` int NOT NULL,
  PRIMARY KEY (`userId`,`charId`,`skinId`),
  KEY `charId` (`charId`),
  KEY `skinId` (`skinId`),
  CONSTRAINT `unlockedskins_ibfk_2` FOREIGN KEY (`charId`) REFERENCES `characters` (`charId`),
  CONSTRAINT `unlockedskins_ibfk_3` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`),
  CONSTRAINT `unlockedskins_ibfk_4` FOREIGN KEY (`skinId`) REFERENCES `skins` (`skinId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unlockedskins`
--

LOCK TABLES `unlockedskins` WRITE;
/*!40000 ALTER TABLE `unlockedskins` DISABLE KEYS */;
INSERT INTO `unlockedskins` VALUES (0,0,0),(0,0,1),(0,0,2),(1,0,0),(0,1,0),(0,1,1),(0,1,2),(2,1,1),(4,1,1),(0,2,0),(0,2,1),(0,2,2),(5,2,2);
/*!40000 ALTER TABLE `unlockedskins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `userId` int NOT NULL,
  `username` varchar(15) NOT NULL,
  `gold` int DEFAULT NULL,
  PRIMARY KEY (`userId`,`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (0,'admin',9999999),(1,'betaTester1',9999),(2,'betaTester2',9999),(3,'betaTester3',9999),(4,'betaTester4',9999),(5,'betaTester5',9999);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-27 13:18:55
