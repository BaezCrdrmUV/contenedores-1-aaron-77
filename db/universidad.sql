-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema universidad
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema universidad
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `universidad` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `universidad` ;

-- -----------------------------------------------------
-- Table `universidad`.`maestros`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universidad`.`maestros` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NOT NULL,
  `apellido` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `universidad`.`alumnos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universidad`.`alumnos` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fkIdMaestro` INT UNSIGNED NULL DEFAULT NULL,
  `nombre` VARCHAR(100) NOT NULL DEFAULT 'no asignado',
  `apellido` VARCHAR(100) NOT NULL DEFAULT 'no asignado',
  PRIMARY KEY (`id`),
  INDEX `fkmaestros_alumnos_idx` (`fkIdMaestro` ASC) VISIBLE,
  CONSTRAINT `fkmaestros_alumnos`
    FOREIGN KEY (`fkIdMaestro`)
    REFERENCES `universidad`.`maestros` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SET SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
CREATE USER 'juan' IDENTIFIED BY 'Contrasena99';
-- GRANT ALL PRIVILEGES ON *.* TO 'juan'@'localhost' WITH GRANT OPTION;
GRANT ALL PRIVILEGES ON *.* TO 'juan'@'%' WITH GRANT OPTION;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


-- -----------------------------------------------------
-- Data for table `universidad`.`maestros`
-- -----------------------------------------------------
START TRANSACTION;
USE `universidad`;
INSERT INTO `universidad`.`maestros` ( `nombre`,`apellido`) VALUES ('Samuel','Baez');
INSERT INTO `universidad`.`maestros` ( `nombre`,`apellido`) VALUES ('Juan','vazquez mota');
COMMIT;

-- -----------------------------------------------------
-- Data for table `universidad`.`alumnos`
-- -----------------------------------------------------
START TRANSACTION;
USE `universidad`;
INSERT INTO `universidad`.`alumnos` ( `fkidmaestro`,`nombre`,`apellido`) VALUES (2,'Roberto','Sosa Enrriquez');
INSERT INTO `universidad`.`alumnos` (`fkidmaestro`, `nombre`,`apellido`) VALUES (3,'Alondra','Marquez Luna');
COMMIT;



