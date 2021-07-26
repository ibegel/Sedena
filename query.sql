create database Sedena;
use Sedena;

create table Usuario
(
Id_Usuario int identity(1,1) Primary Key,
Clave Varchar(30),
Rango Varchar(30),
Nombre varchar(max)
)

Create table Encargado
(
Id_Encargado int Primary key,
Tipo_Encargado varchar(20),
Pass Varchar(30),
Id_Usuario int
CONSTRAINT fk_Encargado_Usuario
   FOREIGN KEY (Id_Usuario)
   REFERENCES Usuario(Id_Usuario)
   ON DELETE CASCADE
   ON UPDATE CASCADE
)

create table Sesion 
(
Id_Sesion int identity(1,1) primary key,
Tipo_Sesion varchar(30),
Entorno Varchar(max),
Fecha varchar(max),
Id_Encargado int
CONSTRAINT fk_Sesion_Encargado
   FOREIGN KEY (Id_Encargado)
   REFERENCES Encargado(Id_Encargado)
   ON DELETE CASCADE
   ON UPDATE CASCADE
)


Create table Funcion
(
Id_Funcion int primary key,
Id_Usuario int,
Id_Sesion int,
Funcion varchar(30)
CONSTRAINT fk_Funcion_Usuario
   FOREIGN KEY (Id_Usuario)
   REFERENCES Usuario(Id_Usuario ),
CONSTRAINT fk_Funcion_Sesion
   FOREIGN KEY (Id_Sesion)
   REFERENCES Sesion(Id_Sesion)
)

Create table Vehiculo
(
Id_Vehiculo int primary key,
Caracteristicas varchar(max)
)

Create table Arma
(
Id_Arma int Primary key,
Caracteristicas varchar(max)
)

Create table Disparo
(
Id_Funcion int,
Id_Arma int,
Posicion varchar(30),
Acerto int
CONSTRAINT fk_Disparo_Funcion
   FOREIGN KEY (Id_Funcion)
   REFERENCES Funcion(Id_Funcion),
CONSTRAINT fk_Tirador_Arma
   FOREIGN KEY (Id_Arma)
   REFERENCES Arma(Id_Arma)
)

Create table Conductor
(
Id_Funcion int,
Id_Vehiculo int,
Posicion varchar(30),
Anomalia varchar(max)
CONSTRAINT fk_Conductor_Funcion 
   FOREIGN KEY (Id_Funcion)
   REFERENCES Funcion(Id_Funcion),
CONSTRAINT fk_Conductor_Vehiculo
   FOREIGN KEY (Id_Vehiculo)
   REFERENCES Vehiculo(Id_Vehiculo)
)

BULK INSERT Usuario
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Usuario.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

		
BULK INSERT Encargado
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Encargado.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Sesion
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Sesion.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Funcion
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Funcion.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Arma
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Arma.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);


BULK INSERT Disparo
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Disparo.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Conductor
FROM 'C:\Users\ibege\Desktop\Github\Sedena\Conductor.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

Select * from Usuario