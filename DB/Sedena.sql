create database Sedena;
drop database Sedena
use Sedena;
use master

create table Agente
(
Id_Agente int Primary Key,
Matricula Varchar(30),
Grado Varchar(30),
Nombre varchar(40),
Distintivo varchar(30)
)

Create table Encargado
(
Id_Encargado int Primary key,
Tipo_Encargado varchar(20),
Pass Varchar(30),
Id_Agente int
CONSTRAINT fk_Encargado_Agente
   FOREIGN KEY (Id_Agente)
   REFERENCES Agente(Id_Agente)
)

create table Sesion 
(
Id_Sesion int primary key,
Id_Actividad int,
Entorno Varchar(max),
Fecha varchar(max),
Id_Encargado int
CONSTRAINT fk_Sesion_Encargado
   FOREIGN KEY (Id_Encargado)
   REFERENCES Encargado(Id_Encargado),
CONSTRAINT fk_Sesion_Actividad
   FOREIGN KEY (Id_Actividad)
   REFERENCES Actividad(Id_Actividad)
)

create table Actividad
(
Id_Actividad int identity(1,1) primary key,
Nombre varchar(30),
Dificultad varchar(20),
Tipo varchar(20)
)


Create table Funcion
(
Id_Funcion int primary key,
Id_Agente int,
Id_Sesion int,
Funcion varchar(30)
CONSTRAINT fk_Funcion_Agente
   FOREIGN KEY (Id_Agente)
   REFERENCES Agente(Id_Agente),
CONSTRAINT fk_Funcion_Sesion
   FOREIGN KEY (Id_Sesion)
   REFERENCES Sesion(Id_Sesion)
)


Create table Vehiculo
(
Id_Vehiculo int primary key,
Placa varchar(30),
Color varchar(30),
Marca varchar(30)
)

Create table Arma
(
Id_Arma int Primary key,
Nombre varchar(30),
Caracteristicas varchar(max)
)

Create table Tirador
(
Id_Funcion int primary key,
Id_Arma int,
CONSTRAINT fk_Disparo_Funcion
   FOREIGN KEY (Id_Funcion)
   REFERENCES Funcion(Id_Funcion),
CONSTRAINT fk_Tirador_Arma
   FOREIGN KEY (Id_Arma)
   REFERENCES Arma(Id_Arma)
)

create table Incidentes_Tirador
(
Id_Funcion int,
Id_Incidente int,
Numero_Incidente int,
CONSTRAINT fk_Incidentes_Tirador
   FOREIGN KEY (Id_Funcion)
   REFERENCES Tirador(Id_Funcion),
CONSTRAINT fk_Incidentes_CatalogoIT
   FOREIGN KEY (Id_Incidente)
   REFERENCES Catalogo_IT(Id_Incidente)
)

create table Catalogo_IT
(
Id_Incidente int primary key,
Nombre varchar(30)
)


create table Logros_IT
(
Id_Funcion int,
Nombre varchar(30)
)

Create table Conductor
(
Id_Funcion int primary key,
Id_Vehiculo int,
CONSTRAINT fk_Conductor_Funcion 
   FOREIGN KEY (Id_Funcion)
   REFERENCES Funcion(Id_Funcion),
CONSTRAINT fk_Conductor_Vehiculo
   FOREIGN KEY (Id_Vehiculo)
   REFERENCES Vehiculo(Id_Vehiculo)
)

create table Incidentes_Conductor
(
Id_Incidente int,
Id_Funcion int,
Numero_Incidente int,
CONSTRAINT fk_Incidentes_Conductor
   FOREIGN KEY (Id_Funcion)
   REFERENCES Conductor(Id_Funcion),
CONSTRAINT fk_Incidentes_CatalogoIC
   FOREIGN KEY (Id_Incidente)
   REFERENCES Catalogo_IC(Id_Incidente)
)

create table Catalogo_IC
(
Id_Incidente int primary key ,
Nombre varchar(30)
)

create table Logros_IC
(
Id_Funcion int ,
Nombre varchar(50)
)

BULK INSERT Agente
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Agente.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

select * from Agente



BULK INSERT Encargado
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Encargado.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Sesion
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Sesion.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Actividad
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Actividad.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Funcion
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Funcion.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Conductor
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Conductor.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Vehiculo
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Vehiculo.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Incidentes_Conductor
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Incidentes_Conductor.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Catalogo_IC
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Catalogo_IC.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Tirador
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Tirador.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Arma
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Arma.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Catalogo_IT
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Catalogo_IT.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);

BULK INSERT Incidentes_Tirador
FROM 'C:\Users\ibege\Desktop\Github\Sedena\DB\Incidentes_Tirador.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=1);



select * from Incidentes_Tirador