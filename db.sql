SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE DATABASE IF NOT EXISTS `dbtaxi` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `dbtaxi`;

CREATE TABLE `cronologia_posizioni` (
  `targa` varchar(7) NOT NULL,
  `ts` datetime NOT NULL,
  `latitudine` double NOT NULL,
  `longitudine` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `data` (
  `ts` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `posizione` (
  `latitudine` double NOT NULL,
  `longitudine` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `taxi` (
  `targa` varchar(7) NOT NULL,
  `marca` varchar(100) NOT NULL,
  `modello` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `taxi` (`targa`, `marca`, `modello`) VALUES
('GA049WE', 'Ford', 'Puma');

ALTER TABLE `cronologia_posizioni`
  ADD PRIMARY KEY (`targa`,`ts`,`latitudine`,`longitudine`),
  ADD KEY `latitudine` (`latitudine`,`longitudine`),
  ADD KEY `ts` (`ts`);

ALTER TABLE `data`
  ADD PRIMARY KEY (`ts`);

ALTER TABLE `posizione`
  ADD PRIMARY KEY (`latitudine`,`longitudine`);

ALTER TABLE `taxi`
  ADD PRIMARY KEY (`targa`);

ALTER TABLE `cronologia_posizioni`
  ADD CONSTRAINT `cronologia_posizioni_ibfk_1` FOREIGN KEY (`targa`) REFERENCES `taxi` (`targa`),
  ADD CONSTRAINT `cronologia_posizioni_ibfk_2` FOREIGN KEY (`latitudine`,`longitudine`) REFERENCES `posizione` (`latitudine`, `longitudine`),
  ADD CONSTRAINT `cronologia_posizioni_ibfk_3` FOREIGN KEY (`ts`) REFERENCES `data` (`ts`);
COMMIT;
