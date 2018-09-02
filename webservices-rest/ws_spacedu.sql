-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.7.22-0ubuntu0.16.04.1


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema elias_spacedu
--

CREATE DATABASE IF NOT EXISTS elias_spacedu;
USE elias_spacedu;

DROP TABLE IF EXISTS `ws_xf2018_chat`;
CREATE TABLE `ws_xf2018_chat` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ws_xf2018_chat`
--

/*!40000 ALTER TABLE `ws_xf2018_chat` DISABLE KEYS */;
INSERT INTO `ws_xf2018_chat` (`id`,`nome`,`created_at`,`updated_at`) VALUES 
 (6,'Como declara IRPF','2018-04-15 18:24:33','2018-04-15 18:24:33'),
 (8,'Grupo de PS4','2018-04-15 18:57:09','2018-04-15 18:58:16'),
 (9,'Grupo de Jogos','2018-04-16 22:30:58','2018-04-16 22:30:58'),
 (10,'Síria','2018-04-16 23:39:56','2018-04-16 23:39:56'),
 (11,'Brasil','2018-04-16 23:45:22','2018-04-16 23:45:22'),
 (12,'futebol','2018-04-25 23:38:55','2018-04-25 23:38:55'),
 (13,'volei','2018-04-25 23:50:09','2018-04-25 23:50:09'),
 (14,'basquet','2018-04-25 23:55:53','2018-04-25 23:55:53'),
 (15,'bola','2018-04-25 23:59:59','2018-04-25 23:59:59'),
 (16,'tenis','2018-04-26 00:05:48','2018-04-26 00:05:48'),
 (17,'salão','2018-04-26 00:17:54','2018-04-26 00:17:54'),
 (18,'teste','2018-04-26 00:24:23','2018-04-26 00:24:23'),
 (19,'oo','2018-04-27 23:22:43','2018-04-27 23:22:43'),
 (20,'teste123','2018-05-01 15:24:42','2018-05-01 15:24:42'),
 (21,'skavurska','2018-05-01 15:36:11','2018-05-01 15:36:11'),
 (22,'4','2018-05-03 13:39:07','2018-05-03 13:39:07'),
 (23,'test','2018-05-03 13:39:47','2018-05-03 13:39:47'),
 (24,'fernsndo teste','2018-05-13 13:52:44','2018-05-13 13:52:44'),
 (25,'Games of Sport','2018-05-17 19:28:11','2018-05-17 19:28:11'),
 (26,'Tester132','2018-05-21 19:14:21','2018-05-21 19:14:21'),
 (27,'Danielt','2018-05-21 19:24:32','2018-05-21 19:24:32'),
 (28,'Danieltr','2018-05-21 19:29:05','2018-05-21 19:29:05'),
 (29,'Danieltsd','2018-05-21 19:54:18','2018-05-21 19:54:18'),
 (30,'Daniel0004','2018-05-22 14:39:18','2018-05-22 14:39:18'),
 (31,'01 - Teste','2018-05-23 00:39:45','2018-05-23 00:39:45');
/*!40000 ALTER TABLE `ws_xf2018_chat` ENABLE KEYS */;


--
-- Definition of table `ws_xf2018_messagem`
--

DROP TABLE IF EXISTS `ws_xf2018_messagem`;
CREATE TABLE `ws_xf2018_messagem` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_chat` int(10) unsigned NOT NULL,
  `id_usuario` int(10) unsigned NOT NULL,
  `mensagem` varchar(1000) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_ws_xf2018_messagem_usuario` (`id_usuario`),
  CONSTRAINT `FK_ws_xf2018_messagem_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `ws_xf2018_usuario` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ws_xf2018_messagem`
--

/*!40000 ALTER TABLE `ws_xf2018_messagem` DISABLE KEYS */;
INSERT INTO `ws_xf2018_messagem` (`id`,`id_chat`,`id_usuario`,`mensagem`,`created_at`,`updated_at`) VALUES 
 (7,2,1,'Ola Amigos do grupo!','2018-04-14 02:12:01','2018-04-14 02:12:01'),
 (8,2,1,'Olá Amigos do mundo todo!','2018-04-14 14:10:30','2018-04-14 14:10:30'),
 (10,3,2,'Olá Amigos do mundo todo!','2018-04-15 16:58:15','2018-04-15 16:58:15'),
 (12,6,2,'Olá Amigos do mundo todo!','2018-04-15 19:29:51','2018-04-15 19:29:51'),
 (13,6,2,'Como vai vcs?','2018-04-15 19:36:53','2018-04-15 19:36:53'),
 (14,6,6,'Como vai vcs?','2018-04-17 17:43:42','2018-04-17 17:43:42'),
 (15,6,6,'Tudo bem!','2018-04-17 19:36:16','2018-04-17 19:36:16'),
 (16,6,3,'Gostaria de Saber como baixar o programa da receita federal','2018-04-17 19:37:08','2018-04-17 19:37:08'),
 (17,6,6,'Tudo bem!','2018-04-17 19:37:26','2018-04-17 19:37:26'),
 (18,6,3,'Qual é o site da receita federal?','2018-04-17 19:38:52','2018-04-17 19:38:52'),
 (19,6,3,'Obrigado por me ajudar','2018-04-17 19:39:14','2018-04-17 19:39:14'),
 (20,6,6,'Entre no site www.receita.org.br','2018-04-17 19:39:37','2018-04-17 19:39:37'),
 (21,6,3,'Resolveu o meu problema! Agradeço','2018-04-17 19:44:12','2018-04-17 19:44:12'),
 (30,6,6,'hhhhhhh','2018-04-26 17:18:28','2018-04-26 17:18:28'),
 (31,6,6,'judicial','2018-04-26 17:18:50','2018-04-26 17:18:50'),
 (32,11,15,'tt','2018-04-27 23:23:23','2018-04-27 23:23:23'),
 (33,10,15,'ola ','2018-04-27 23:24:00','2018-04-27 23:24:00'),
 (34,10,15,'pppp','2018-04-27 23:24:15','2018-04-27 23:24:15'),
 (35,8,16,'123','2018-05-03 00:23:08','2018-05-03 00:23:08'),
 (36,10,16,'123','2018-05-03 00:23:28','2018-05-03 00:23:28'),
 (37,8,16,'321','2018-05-03 00:32:14','2018-05-03 00:32:14'),
 (38,9,16,'123','2018-05-03 00:33:20','2018-05-03 00:33:20'),
 (39,21,16,'çalsdkfjlkad','2018-05-03 00:40:09','2018-05-03 00:40:09'),
 (40,10,18,'hit','2018-05-03 13:38:22','2018-05-03 13:38:22'),
 (41,10,18,'bit','2018-05-03 13:38:33','2018-05-03 13:38:33'),
 (42,6,16,'coe','2018-05-03 18:57:13','2018-05-03 18:57:13'),
 (43,6,16,'blz negada?','2018-05-03 18:57:25','2018-05-03 18:57:25'),
 (44,6,16,'tudo de boa na lagoa?','2018-05-03 18:57:50','2018-05-03 18:57:50'),
 (45,15,16,'e aí','2018-05-03 18:59:09','2018-05-03 18:59:09'),
 (46,15,16,'tudo de boa?','2018-05-03 18:59:17','2018-05-03 18:59:17'),
 (47,11,16,'hue br','2018-05-04 21:33:20','2018-05-04 21:33:20'),
 (48,11,16,'hue hue','2018-05-04 21:33:41','2018-05-04 21:33:41'),
 (49,6,30,'Soladomaluko','2018-05-22 18:34:52','2018-05-22 18:34:52'),
 (50,6,29,'Soladomaluko','2018-05-22 18:35:49','2018-05-22 18:35:49'),
 (51,6,28,'Soladomaluko','2018-05-22 18:36:17','2018-05-22 18:36:17'),
 (52,6,27,'Soladomaluko','2018-05-22 18:36:26','2018-05-22 18:36:26'),
 (53,6,27,'Soladomaluko','2018-05-22 18:36:30','2018-05-22 18:36:30'),
 (54,6,26,'Soladomaluko','2018-05-22 18:36:40','2018-05-22 18:36:40'),
 (55,6,31,'Soladomaluko','2018-05-22 18:37:36','2018-05-22 18:37:36'),
 (56,6,31,'Hello','2018-05-22 19:47:35','2018-05-22 19:47:35'),
 (57,9,31,'gg','2018-05-22 19:48:12','2018-05-22 19:48:12');
/*!40000 ALTER TABLE `ws_xf2018_messagem` ENABLE KEYS */;


--
-- Definition of table `ws_xf2018_usuario`
--

DROP TABLE IF EXISTS `ws_xf2018_usuario`;
CREATE TABLE `ws_xf2018_usuario` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `password` varchar(20) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ws_xf2018_usuario`
--

/*!40000 ALTER TABLE `ws_xf2018_usuario` DISABLE KEYS */;
INSERT INTO `ws_xf2018_usuario` (`id`,`nome`,`password`,`created_at`,`updated_at`) VALUES 
 (1,'Elias','123','2018-04-14 01:46:48','2018-04-14 01:46:48'),
 (2,'José','123','2018-04-14 14:05:51','2018-04-14 14:05:51'),
 (3,'Felipe123','123','2018-04-15 16:26:56','2018-04-15 16:26:56'),
 (4,'Jose123','123','2018-04-15 18:34:54','2018-04-15 18:34:54'),
 (5,'Marcos','123','2018-04-15 18:54:03','2018-04-15 18:54:03'),
 (6,'Elias123','123','2018-04-16 16:08:30','2018-04-16 16:08:30'),
 (7,'Eliane123','123','2018-04-21 03:32:37','2018-04-21 03:32:37'),
 (8,'elias12','123','2018-04-21 06:01:48','2018-04-21 06:01:48'),
 (9,'mcastro','123','2018-04-21 06:02:21','2018-04-21 06:02:21'),
 (10,'Marcelo Castro','123','2018-04-24 12:36:01','2018-04-24 12:36:01'),
 (11,'elias124','123','2018-04-26 02:32:24','2018-04-26 02:32:24'),
 (12,'elias223','123','2018-04-26 09:37:46','2018-04-26 09:37:46'),
 (13,'eliad123','123','2018-04-26 16:40:31','2018-04-26 16:40:31'),
 (14,'Diego','123','2018-04-27 01:21:41','2018-04-27 01:21:41'),
 (15,'test','test','2018-04-27 23:22:23','2018-04-27 23:22:23'),
 (16,'vieira','123','2018-04-27 23:52:17','2018-04-27 23:52:17'),
 (17,'a','123','2018-04-28 01:09:46','2018-04-28 01:09:46'),
 (18,'ee','eee','2018-05-03 13:37:58','2018-05-03 13:37:58'),
 (19,'ddd','tttt','2018-05-03 13:39:29','2018-05-03 13:39:29'),
 (20,'usuario','senha','2018-05-12 10:02:15','2018-05-12 10:02:15'),
 (21,'3ssi','123456','2018-05-12 10:04:13','2018-05-12 10:04:13'),
 (22,'3ssiyfj','elife2008','2018-05-12 10:05:07','2018-05-12 10:05:07'),
 (23,'fe123456','fe123456','2018-05-13 13:52:26','2018-05-13 13:52:26'),
 (24,'fer123','fer123','2018-05-13 13:55:10','2018-05-13 13:55:10'),
 (25,'feteste','1234','2018-05-16 14:20:25','2018-05-16 14:20:25'),
 (26,'feee','feee','2018-05-16 17:28:13','2018-05-16 17:28:13'),
 (27,'fhfhc','1234','2018-05-16 17:42:19','2018-05-16 17:42:19'),
 (28,'fernandobsilva','1234','2018-05-16 20:38:22','2018-05-16 20:38:22'),
 (29,'fernand','1234','2018-05-16 20:38:48','2018-05-16 20:38:48'),
 (30,'fe123','fe123','2018-05-18 15:21:08','2018-05-18 15:21:08'),
 (31,'daniel','password','2018-05-21 16:33:17','2018-05-21 16:33:17'),
 (32,'Dnaisba','123','2018-05-21 17:10:29','2018-05-21 17:10:29'),
 (33,'Elias132','132','2018-05-21 19:14:01','2018-05-21 19:14:01');
/*!40000 ALTER TABLE `ws_xf2018_usuario` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
