CREATE SCHEMA IF NOT EXISTS `open_fluency` DEFAULT CHARACTER SET utf8;

CREATE TABLE IF NOT EXISTS `open_fluency`.`papel` (
  `papel_id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`papel_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `open_fluency`.`usuario` (
  `usuario_id` INT NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(50) NOT NULL,
  `senha` VARCHAR(50) NOT NULL,
  `papel_id` INT NOT NULL,
  PRIMARY KEY (`usuario_id`),
  CONSTRAINT `usuario_papel`
    FOREIGN KEY (`papel_id`)
    REFERENCES `open_fluency`.`papel` (`papel_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `open_fluency`.`professor` (
  `professor_id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  `email` VARCHAR(60) NOT NULL,
  `usuario_id` INT NOT NULL,
  PRIMARY KEY (`professor_id`),
  CONSTRAINT `professor_usuario`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `open_fluency`.`usuario` (`usuario_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `open_fluency`.`turma` (
  `turma_id` INT NOT NULL AUTO_INCREMENT,
  `semestre` INT NOT NULL,
  `ano` INT NOT NULL,
  `periodo` VARCHAR(150) NOT NULL,
  `nivel` VARCHAR(45) NOT NULL,
  `professor_id` INT NOT NULL,
  PRIMARY KEY (`turma_id`),
  CONSTRAINT `turma_professor`
    FOREIGN KEY (`professor_id`)
    REFERENCES `open_fluency`.`professor` (`professor_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `open_fluency`.`aluno` (
  `aluno_id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(200) NOT NULL,
  `email` VARCHAR(60) NOT NULL,
  `usuario_id` INT NOT NULL,
  PRIMARY KEY (`aluno_id`),
  CONSTRAINT `aluno_usuario`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `open_fluency`.`usuario` (`usuario_id`))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `open_fluency`.`aluno_turma_boletim` (
  `aluno_turma_boletim_id` INT NOT NULL AUTO_INCREMENT,
  `nota_bim1` DECIMAL(4,2) NULL,
  `nota_bim1_escrita` DECIMAL(4,2) NULL,
  `nota_bim1_leitura` DECIMAL(4,2) NULL,
  `nota_bim1_conversacao` DECIMAL(4,2) NULL,
  `nota_bim1_final` DECIMAL(4,2) NULL,
  `nota_bim2_leitura` DECIMAL(4,2) NULL,
  `nota_bim2_escrita` DECIMAL(4,2) NULL,
  `nota_bim2_conversacao` DECIMAL(4,2) NULL,
  `nota_bim2_final` DECIMAL(4,2) NULL,
  `nota_final_semestre` DECIMAL(4,2) NULL,
  `faltas_semestre` INT NULL,
  `aluno_id` INT NOT NULL,
  `turma_id` INT NOT NULL,
  PRIMARY KEY (`aluno_turma_boletim_id`),
  CONSTRAINT `aluno_boletim`
    FOREIGN KEY (`aluno_id`)
    REFERENCES `open_fluency`.`aluno` (`aluno_id`),
  CONSTRAINT `turma_boletim`
    FOREIGN KEY (`turma_id`)
    REFERENCES `open_fluency`.`turma` (`turma_id`))
ENGINE = InnoDB;

INSERT INTO `open_fluency`.`papel`
(`papel_id`,
`nome`)
VALUES
(1,
"Administrador");

INSERT INTO `open_fluency`.`papel`
(`papel_id`,
`nome`)
VALUES
(2>,
"Professor");

INSERT INTO `open_fluency`.`papel`
(`papel_id`,
`nome`)
VALUES
(3>,
"Aluno");

INSERT INTO `open_fluency`.`usuario`
(`usuario_id`,
`login`,
`senha`,
`papel_id`)
VALUES
(1,
"admin",
"123",
1);
