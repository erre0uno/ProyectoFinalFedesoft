USE Mundial
GO
  
INSERT INTO Usuario (Nombre, Clave, Tipo) VALUES 
('admin', '$2a$10$XWqU9n.NJfYdKHs6NZpshO6UOisCh0ID1DahzRECQAW/20r4Vg21.', 'admin'),
('user', '$2a$10$XWqU9n.NJfYdKHs6NZpshO6UOisCh0ID1DahzRECQAW/20r4Vg21.', 'admin')
    
INSERT INTO Posicion (Nombre) Values 
('Delantero'),
('Defensa'),
('Medio Campista'),
('Portero')

INSERT INTO Equipo (Nombre, Participaciones, Grupo) VALUES
('Catar',1,'A'),  --1
('Ecuador',4,'A'), --2
('Senegal',3,'A'),--3
('Paises Bajos',11,'A'),--4
('Inglaterra',16,'B'),--5
('Gales',2,'B'),--6
('Iran',6,'B'),--7 
('EEUU',7,'B')--8

INSERT INTO Resultado (Gf, Gc, NumeroPartido, EquipoId) VALUES 
----------- GRUPO A -------------------------
(0, 2, 1, 1), --catar vs Ecuador
(2, 0, 1, 2), 
(1, 3, 2, 1), -- catar vs senegal
(3, 1, 2, 3),
(0, 2, 3, 1), --catar  vs paises bajos
(2, 0, 3, 4),
(1, 1, 4, 2),-- ecuador vs paises bajos
(1, 1, 4, 4),
(1, 2, 5, 2),-- ecuador vs senegal
(2, 1, 5, 3),
(1, 3, 6, 3),-- senegal vs paises bajos
(3, 1, 6, 4)
------------ GRUPO B -------------------------
(6, 2, 7, 5),-- Inglaterra vs Iran
(2, 6, 7, 7),
(0, 0, 8, 5),-- Inglaterra vs EEUU
(0, 0, 8, 8),
(3, 0, 9, 5), -- Inglaterra vs Gales
(0, 3, 9, 6),
(1, 1, 10, 8),-- EEUU vs Gales
(1, 1, 10, 6),
(1, 0, 11, 8),-- EEUU vs Iran
(0, 1, 11, 7),
(2, 0, 12, 7), -- Iran vs Gales
(0, 2, 12, 6) 


INSERT INTO Jugador (Nombre, Apellidos, FechaNacimiento, Estatura,PosicionId,equipoId) VALUES
--Qatar--
('Almoez', 'Ali', '1996-08-19', 1.80, 1, 1),
('Hassan', 'Al-Haidos', '1990-12-11', 1.74, 1, 1),
('Akram', 'Afif', '1996-11-18', 1.76, 1, 1),
('Bassam', 'Al-Rawi', '1997-12-16', 1.75, 2, 1),
('Mohammed', 'Muntari', '1993-12-20', 1.92, 1, 1),
('Saad', 'Al Sheeb', '1990-02-19', 1.88, 4, 1),
('Karim', 'Boudiaf', '1990-09-16', 1.90, 3, 1),
('Abdelkarim', 'Hassan', '1993-08-28', 1.85, 2, 1),
('Boualem', 'Khoukhi', '1990-09-07', 1.83, 2, 1),
('Abdulaziz', 'Hatem', '1990-10-28', 1.82, 3, 1),
--10
--Ecuador--
('Pedro','Ortiz','1998-10-10',1.78,1,2),
('Diego','Palacios','1998-10-10',1.68,2,2),
('Frankin','Guerra','1998-10-10',1.58,2,2),
('Jose','Hurtado','1998-10-10',1.68,2,2),
('Hernan','Galindez','1987-03-30',1.88,2,2),
('Dixon','Arroyo','1998-10-10',1.98,4,2),
('Joao','Rojas','1998-10-10',1.68,2,2),
('Carlos','Gruezo','1998-10-10',1.48,3,2),
('Ener','Valencia','1998-10-10',1.68,4,2),
('Angel','Mena','1998-10-10',1.68,4,2),
--10
--Sennegal--
('Sadio','Mane','1992-04-10',1.82, 1, 3),
('Ansu','Fati','2002-09-14',1.85, 3, 3),
('Kalidou','Koulibaly','1991-06-20',1.86, 2, 3),
('Mamadou','Loum N Diaye','1996-12-30',1.88, 3, 3),
('Nampalys','Mendy','1992-05-23',1.67, 3, 3),
('Édouard','Mendy','1992-03-01',1.94, 4, 3),
('Pape','Gueye','1999-01-24',1.89, 3, 3),
('Idrissa','Gueye','1989-09-26',1.74, 3, 3),
('Cheikhou','Kouyaté','1989-12-21',1.92, 3, 3),
('Moustapha','Name','1995-05-05',1.85, 3, 3),
('Pape','Abou Cissé','1995-09-14',1.97, 2, 3),
--11

--Paises bajos--
('Andries ','Noppert','1994-04-07', 2.03, 4, 4),
('Virgil', 'Van Dijk', '1991-07-08', 1.95, 2, 4),
('Nathan', 'Aké', '1995-02-18',1.8, 2, 4),
('Denzel','Dumfries', '1996-04-18', 1.88, 2, 4),
('Tyrell', 'Malacia', '1999-08-17',1.69, 2, 4),
('Teun', 'Koopmeiners', '1998-02-28', 1.84, 3, 4),
('Marten', 'de Roon', '1991-03-29',1.85, 3, 4),
('Xavi', 'Simons','2003-04-24',1.79, 3, 4),
('Memphis', 'Depay', '1994-02-13', 1.78, 1, 4),
('Vincent', 'Janssen', '1994-06-15',1.83, 1, 4),
('Steven', 'Bergwijn', '1997-10-17',1.75, 1, 4),
--11
--Inglaterra--
('Jordan','Pixford','1998-10-10',1.78,1,5),
('Kyle','Walker','1998-10-10',1.68,2,5),
('John','Stone','1998-10-10',1.58,2,5),
('Mason','Mount','1998-10-10',1.68,3,5),
('Phil','Foden','1998-10-10',1.78,3,5),
('Raheem','Sterling','1998-10-10',1.98,4,5),
--6
--Gales--
('Wayne','Hennesey','1998-10-10',1.78,1,6),
('Ben','Davies','1998-10-10',1.68,2,6),
('Tom','Lockyer','1998-10-10',1.58,2,6),
('Sorba','Thomas','1998-10-10',1.68,3,6),
('Harry','Wilson','1998-10-10',1.78,3,6),
('Gareth','Bale','1998-10-10',1.98,4,6),
--6
--Iran--
('Mehdi', 'Taremi', '1992-06-18', 1.87, 1, 7),
('Sardar', 'Azmoun', '1995-01-01', 1.86, 1, 7),
('Alireza', 'Safar Beiranvand', '1992-09-21', 1.94, 4, 7),
('Ramin', 'Rezaeian', '1990-03-21', 1.80, 2, 7),
('Ehsan', 'Hajsafi', '1990-02-25', 1.78, 3, 7),
--5
--EEUU--
('Ethan','Horvat','1998-10-10',1.78,1,8),
('Cameron','Carter','1998-10-10',1.68,2,8),
('Sahq','Moore','1998-10-10',1.58,2,8),
('Tyler','Adams','1998-10-10',1.68,3,8),
('Kellyn','Acosta','1998-10-10',1.78,3,8),
('Cristian','Pulisich','1998-10-10',1.98,4,8)
--6
/* 
--Argentina--
('Franco', 'Armani', '1986-10-16', 1.89, 4, 9),
('Juan', 'Foyth', '1998-01-12', 1.88, 2, 9),
('Nicolás', 'Tagliafico', '1992-08-31', 1.70, 2, 9),
('Gonzalo', 'Montiel', '1997-01-01', 1.75, 2, 9),
('Leandro', 'Paredes', '1994-06-29', 1.80, 3, 9),
('Germán', 'Pezzella', '1991-06-27', 1.90, 2, 9),
('Julián ', 'Álvarez ', '2000-01-31', 1.70, 1, 9),

-- Arabia Saud --
('Mohammed','Al-Owais','1991-10-10',1.85, 4, 10),
('Yasser','Al-Shahrani','1992-05-25',1.71, 2, 10),
('Salem','Al-Dawsari','1991-08-19',1.71, 3, 10),
('Salman','Al-Faraj','1989-08-1',1.80, 3, 10),
('Nawaf','Al Abed','1990-01-26',1.70, 3, 10),
('Firas','Al-Buraikan','2000-05-14',1.81, 1, 10),
('Saleh','Al-Shehri','1993-11-1',1.84, 1, 10),
('Riyadh','Sharahili','1993-04-28',1.85, 3, 10),
('Saud','Abdulhamid','1999-07-18',1.71, 2, 10),
('Nawaf','Al-Aqidi','2000-05-10',1.85, 4, 10),
('Ali','Al-Bulaihi','1989-11-21',1.82, 2, 10),

  ('Jugador', '1', '2000-01-01', 2, 1, 11),
('Jugador', '2', '2000-01-01', 2, 2, 11),
('Jugador', '3', '2000-01-01', 2, 3, 11),
('Jugador', '4', '2000-01-01', 2, 4, 11),
  ('Jugador', '1', '2000-01-01', 2, 1, 12),
('Jugador', '2', '2000-01-01', 2, 2, 12),
('Jugador', '3', '2000-01-01', 2, 3, 12),
('Jugador', '4', '2000-01-01', 2, 4, 12),
  ('Jugador', '1', '2000-01-01', 2, 1, 13),
('Jugador', '2', '2000-01-01', 2, 2, 13),
('Jugador', '3', '2000-01-01', 2, 3, 13),
('Jugador', '4', '2000-01-01', 2, 4, 13),
  ('Jugador', '1', '2000-01-01', 2, 1, 14),
('Jugador', '2', '2000-01-01', 2, 2, 14),
('Jugador', '3', '2000-01-01', 2, 3, 14),
('Jugador', '4', '2000-01-01', 2, 4, 14),
  ('Jugador', '1', '2000-01-01', 2, 1, 15),
('Jugador', '2', '2000-01-01', 2, 2, 15),
('Jugador', '3', '2000-01-01', 2, 3, 15),
('Jugador', '4', '2000-01-01', 2, 4, 15),
  ('Jugador', '1', '2000-01-01', 2, 1, 16),
('Jugador', '2', '2000-01-01', 2, 2, 16),
('Jugador', '3', '2000-01-01', 2, 3, 16),
('Jugador', '4', '2000-01-01', 2, 4, 16),
  ('Jugador', '1', '2000-01-01', 2, 1, 17),
('Jugador', '2', '2000-01-01', 2, 2, 17),
('Jugador', '3', '2000-01-01', 2, 3, 17),
('Jugador', '4', '2000-01-01', 2, 4, 17),
  ('Jugador', '1', '2000-01-01', 2, 1, 18),
('Jugador', '2', '2000-01-01', 2, 2, 18),
('Jugador', '3', '2000-01-01', 2, 3, 18),
('Jugador', '4', '2000-01-01', 2, 4, 18),
  ('Jugador', '1', '2000-01-01', 2, 1, 18),
('Jugador', '2', '2000-01-01', 2, 2, 18),
('Jugador', '3', '2000-01-01', 2, 3, 18),
('Jugador', '4', '2000-01-01', 2, 4, 18),
  ('Jugador', '1', '2000-01-01', 2, 1, 19),
('Jugador', '2', '2000-01-01', 2, 2, 19),
('Jugador', '3', '2000-01-01', 2, 3, 19),
('Jugador', '4', '2000-01-01', 2, 4, 19),
  ('Jugador', '1', '2000-01-01', 2, 1, 20),
('Jugador', '2', '2000-01-01', 2, 2, 20),
('Jugador', '3', '2000-01-01', 2, 3, 20),
('Jugador', '4', '2000-01-01', 2, 4, 20),
  ('Jugador', '1', '2000-01-01', 2, 1, 21),
('Jugador', '2', '2000-01-01', 2, 2, 21),
('Jugador', '3', '2000-01-01', 2, 3, 21),
('Jugador', '4', '2000-01-01', 2, 4, 21),
  ('Jugador', '1', '2000-01-01', 2, 1, 22),
('Jugador', '2', '2000-01-01', 2, 2, 22),
('Jugador', '3', '2000-01-01', 2, 3, 22),
('Jugador', '4', '2000-01-01', 2, 4, 22),
  ('Jugador', '1', '2000-01-01', 2, 1, 23),
('Jugador', '2', '2000-01-01', 2, 2, 23),
('Jugador', '3', '2000-01-01', 2, 3, 23),
('Jugador', '4', '2000-01-01', 2, 4, 23),
  ('Jugador', '1', '2000-01-01', 2, 1, 24),
('Jugador', '2', '2000-01-01', 2, 2, 24),
('Jugador', '3', '2000-01-01', 2, 3, 24),
('Jugador', '4', '2000-01-01', 2, 4, 24),
  ('Jugador', '1', '2000-01-01', 2, 1, 25),
('Jugador', '2', '2000-01-01', 2, 2, 25),
('Jugador', '3', '2000-01-01', 2, 3, 25),
('Jugador', '4', '2000-01-01', 2, 4, 25),
  ('Jugador', '1', '2000-01-01', 2, 1, 26),
('Jugador', '2', '2000-01-01', 2, 2, 26),
('Jugador', '3', '2000-01-01', 2, 3, 26),
('Jugador', '4', '2000-01-01', 2, 4, 26),
  ('Jugador', '1', '2000-01-01', 2, 1, 27),
('Jugador', '2', '2000-01-01', 2, 2, 27),
('Jugador', '3', '2000-01-01', 2, 3, 27),
('Jugador', '4', '2000-01-01', 2, 4, 27),
  ('Jugador', '1', '2000-01-01', 2, 1, 28),
('Jugador', '2', '2000-01-01', 2, 2, 28),
('Jugador', '3', '2000-01-01', 2, 3, 28),
('Jugador', '4', '2000-01-01', 2, 4, 28),
  ('Jugador', '1', '2000-01-01', 2, 1, 29),
('Jugador', '2', '2000-01-01', 2, 2, 29),
('Jugador', '3', '2000-01-01', 2, 3, 29),
('Jugador', '4', '2000-01-01', 2, 4, 29),
  ('Jugador', '1', '2000-01-01', 2, 1, 30),
('Jugador', '2', '2000-01-01', 2, 2, 30),
('Jugador', '3', '2000-01-01', 2, 3, 30),
('Jugador', '4', '2000-01-01', 2, 4, 30),
  ('Jugador', '1', '2000-01-01', 2, 1, 31),
('Jugador', '2', '2000-01-01', 2, 2, 31),
('Jugador', '3', '2000-01-01', 2, 3, 31),
('Jugador', '4', '2000-01-01', 2, 4, 31),
  ('Jugador', '1', '2000-01-01', 2, 1, 32),
('Jugador', '2', '2000-01-01', 2, 2, 32),
('Jugador', '3', '2000-01-01', 2, 3, 32),
('Jugador', '4', '2000-01-01', 2, 4, 32)
 */


INSERT INTO TablaPosiciones (Pj, Pg, Pe, Pp, Gf, Gc,Puntos, EquipoId) VALUES
--Grupo A--
(3, 0, 0, 3, 1, 7, 0, 1),
(3, 1, 1, 1, 4, 3, 4, 2),
(3 ,2, 0, 1, 5 ,4, 6, 3),
(3, 2, 1, 0, 5, 1, 7, 4),

--Grupo B--
(3,2,1,0,9,2,7,5),
(3,0,1,2,1,6,1,6),
(3,1,0,2,4,7,3,7),
(3,1,2,0,2,1,5,8)


--Asistencias Insert
SET IDENTITY_INSERT [dbo].[Asistencia] ON 
INSERT [dbo].[Asistencia] ([Id], [Asistencias], [JugadorId]) VALUES (1, 5, 14)
INSERT [dbo].[Asistencia] ([Id], [Asistencias], [JugadorId]) VALUES (2, 4, 51)
INSERT [dbo].[Asistencia] ([Id], [Asistencias], [JugadorId]) VALUES (3, 9, 62)
INSERT [dbo].[Asistencia] ([Id], [Asistencias], [JugadorId]) VALUES (4, 5, 63)
INSERT [dbo].[Asistencia] ([Id], [Asistencias], [JugadorId]) VALUES (5, 4, 3)
INSERT [dbo].[Asistencia] ([Id], [Asistencias], [JugadorId]) VALUES (6, 7, 12)
SET IDENTITY_INSERT [dbo].[Asistencia] OFF
GO

--Goleador insert
SET IDENTITY_INSERT [dbo].[Goleador] ON 
INSERT [dbo].[Goleador] ([Id], [Goles], [JugadorId]) VALUES (1, 3, 1)
INSERT [dbo].[Goleador] ([Id], [Goles], [JugadorId]) VALUES (2, 12, 23)
INSERT [dbo].[Goleador] ([Id], [Goles], [JugadorId]) VALUES (3, 3, 46)
INSERT [dbo].[Goleador] ([Id], [Goles], [JugadorId]) VALUES (4, 3, 37)
INSERT [dbo].[Goleador] ([Id], [Goles], [JugadorId]) VALUES (5, 7, 50)
SET IDENTITY_INSERT [dbo].[Goleador] OFF
GO

--Tarjeta Roja insert
SET IDENTITY_INSERT [dbo].[TarjetaRoja] ON 
INSERT [dbo].[TarjetaRoja] ([Id], [Numero], [JugadorId]) VALUES (1, 2, 8)
INSERT [dbo].[TarjetaRoja] ([Id], [Numero], [JugadorId]) VALUES (2, 5, 14)
INSERT [dbo].[TarjetaRoja] ([Id], [Numero], [JugadorId]) VALUES (3, 2, 17)
INSERT [dbo].[TarjetaRoja] ([Id], [Numero], [JugadorId]) VALUES (4, 1, 33)
INSERT [dbo].[TarjetaRoja] ([Id], [Numero], [JugadorId]) VALUES (5, 2, 45)
SET IDENTITY_INSERT [dbo].[TarjetaRoja] OFF
GO
