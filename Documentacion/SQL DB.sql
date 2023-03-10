CREATE DATABASE Mundial
GO

USE Mundial
GO

IF OBJECT_ID('Usuario') IS NOT NULL DROP TABLE Usuario
GO

CREATE TABLE Usuario
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(30) NOT NULL,
    Clave VARCHAR(max) NOT NULL,  -- o (MAX) en mayuscula 
    Tipo VARCHAR(30) NOT NULL
)
GO

IF OBJECT_ID('Posicion') IS NOT NULL DROP TABLE Posicion
GO

CREATE TABLE Posicion
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(30) NOT NULL
)
GO

IF OBJECT_ID('Equipo') IS NOT NULL DROP TABLE Equipo
GO

CREATE TABLE Equipo
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(30) UNIQUE,
    Participaciones INT,
    Grupo VARCHAR(1)
)
GO

IF OBJECT_ID('Jugador') IS NOT NULL DROP TABLE Jugador
GO

CREATE TABLE Jugador
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(30) NOT NULL,
    Apellidos VARCHAR(30) NOT NULL,

    FechaNacimiento DATE ,
    Estatura DECIMAL(3,2),
    PosicionId INT
        CONSTRAINT FK_Jugador_Posicion FOREIGN KEY REFERENCES Posicion(Id)
        ON UPDATE CASCADE ON DELETE CASCADE,
    EquipoId INT
        CONSTRAINT FK_Jugador_Equipo FOREIGN KEY REFERENCES Equipo(Id)
        ON UPDATE CASCADE ON DELETE CASCADE
)
GO

IF OBJECT_ID('Goleador') IS NOT NULL DROP TABLE Goleador
GO

CREATE TABLE Goleador
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Goles INT,
    JugadorId INT UNIQUE
        CONSTRAINT FK_Goleador_Jugador FOREIGN KEY REFERENCES Jugador(Id)
        ON UPDATE CASCADE ON DELETE CASCADE
)
GO

IF OBJECT_ID('Resultado') IS NOT NULL DROP TABLE Resultado
GO

CREATE TABLE Resultado
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Gf INT,
    Gc INT,
    NumeroPartido INT,
    EquipoId INT
        CONSTRAINT FK_Resultado_Equipo FOREIGN KEY REFERENCES Equipo(Id)
        ON UPDATE CASCADE ON DELETE CASCADE
)
GO

IF OBJECT_ID('Asistencia') IS NOT NULL DROP TABLE Asistencia
GO

CREATE TABLE Asistencia
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Asistencias INT,
    JugadorId INT UNIQUE
        CONSTRAINT FK_Asistencia_Jugador FOREIGN KEY REFERENCES Jugador(Id)
        ON UPDATE CASCADE ON DELETE CASCADE
)
GO

IF OBJECT_ID('TarjetaRoja') IS NOT NULL DROP TABLE TarjetaRoja
GO

CREATE TABLE TarjetaRoja
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Numero INT,
    JugadorId INT UNIQUE 
        CONSTRAINT FK_Tarjeta_Jugador FOREIGN KEY REFERENCES Jugador(Id)
        ON UPDATE CASCADE ON DELETE CASCADE
)
GO

IF OBJECT_ID('TablaPosiciones') IS NOT NULL DROP TABLE TablaPosiciones
GO

CREATE TABLE TablaPosiciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Pj INT,
    Pg INT,
    Pe INT,
    Pp INT,
    Gf INT,
    Gc INT,
    Puntos INT,
    EquipoId INT UNIQUE
        CONSTRAINT FK_TablaPosciones_Equipo FOREIGN KEY REFERENCES Equipo(Id)
        ON UPDATE CASCADE ON DELETE CASCADE
)