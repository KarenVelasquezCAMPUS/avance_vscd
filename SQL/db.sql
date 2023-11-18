CREATE DATABASE avancedb;
USE avancedb;

CREATE TABLE empresa (
    idempresa INT NOT NULL,
    identificacion VARCHAR(16) NOT NULL,
    razonsocial VARCHAR(256) NOT NULL,
    -- Primary Key
    PRIMARY KEY (idempresa)
);

CREATE TABLE tipodocumento (
    idtipodocumento INT NOT NULL,
    descripcion VARCHAR(256) NOT NULL,
    -- Primary Key
    PRIMARY KEY (idtipodocumento)
);

CREATE TABLE numeracion (
    idnumeracion INT NOT NULL,
    idtipodocumento INT NOT NULL , -- fk
    idempresa INT NOT NULL, -- fk
    prefijo VARCHAR(8) NOT NULL,
    consecutivoinicial INT NOT NULL,
    consecutivofinal INT NOT NULL,
    vigenciainicial DATE NOT NULL,
    vigenciafinal DATE NOT NULL,
    -- Primary Key
    PRIMARY KEY (idnumeracion),
    -- Foreign Key
    FOREIGN KEY (idtipodocumento) REFERENCES tipodocumento(idtipodocumento),
    FOREIGN KEY (idempresa) REFERENCES empresa(idempresa)
);

CREATE TABLE estado (
    idestado INT NOT NULL,
    descripcion VARCHAR(256) NOT NULL,
    exitoso BIT NOT NULL,
    -- Primary Key
    PRIMARY KEY (idestado)
);

CREATE TABLE documento (
    iddocumento INT NOT NULL,
    idestado INT NOT NULL, -- fk
    idnumeracion INT NOT NULL, -- fk
    numero INT NOT NULL,
    fecha DATE NOT NULL,
    base NUMERIC NOT NULL,
    impuestos NUMERIC NOT NULL,
    -- Primary Key
    PRIMARY KEY (iddocumento),
    -- Foreign Key
    FOREIGN KEY (idestado) REFERENCES estado(idestado),
    FOREIGN KEY (idnumeracion) REFERENCES numeracion(idnumeracion)
);