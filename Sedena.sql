create database Sedena;
drop database Sedena
use Sedena;
use master

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


---------------Procedimientos usuario
create proc Insertar_Usuario
@Clave as varchar(max),
@Rango as varchar(max),
@Tipo as varchar(max)
as 
if Exists(Select @Clave from Usuario where Clave=@Clave)
Raiserror('Usuario Registrado',16,1)
else
Insert into Usuario
values (@Clave,@Rango,@Tipo)

create proc Borrar_Usuario
@Clave as int 
as 
if Exists(select @Clave from Usuario where Clave=@Clave)
delete Usuario where Clave=@Clave
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Usuario
@Clave as varchar(max),
@Rango as varchar(max),
@Nombre as varchar(max)
as 
if Exists(Select @Clave from Usuario where Clave=@Clave)
update Usuario set Clave=@Clave,Nombre=@Nombre,Rango=@Rango
where Clave=@Clave
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Usuario
as 
select * from Usuario

---------------Procedimientos Encargado
create proc Insertar_Encargado
@Tipo_Encargado as varchar(max),
@Pass as varchar(max),
@Id_Usuario as varchar(max)
as 
if Exists(Select Id_Usuario from Encargado where Id_Usuario=@Id_Usuario)
Raiserror('Usuario Registrado',16,1)
else
Insert into Usuario
values (@Tipo_Encargado,@Pass,@Id_Usuario)

create proc Borrar_Encargado
@Id_Encargado as int 
as 
if Exists(select Id_Encargado from Encargado where Id_Encargado=@Id_Encargado)
delete Encargado where Id_Encargado=@Id_Encargado
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Encargado
@Tipo_Encargado as varchar(max),
@Pass as varchar(max),
@Id_Usuario as varchar(max)
as 
if Exists(Select Tipo_Encargado from Encargado where Tipo_Encargado=@Tipo_Encargado)
update Encargado set Tipo_Encargado=@Tipo_Encargado,Pass=@Pass,Id_Usuario=@Id_Usuario
where Tipo_Encargado=@Tipo_Encargado
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Encargado
as 
select * from Encargado  

create proc Verificar_Login
@Nombre as varchar(max),
@Pass as varchar(max)
as
select * from Encargado inner join Usuario on
Encargado.Id_usuario =Usuario.Id_Usuario
where Usuario.Nombre = @Nombre and Encargado.Pass= @Pass



---------------Procedimientos Sesion
create proc Insertar_Sesion
@Id_Sesion as int,
@Tipo_Sesion as varchar(max),
@Entorno as varchar(max),
@Id_Encargado as varchar(max)
as 
if Exists(Select Id_Sesion from Sesion where Id_Sesion=@Id_Sesion)
Raiserror('Usuario Registrado',16,1)
else
Insert into Sesion
values (@Tipo_Sesion,@Entorno,@Id_Encargado)

create proc Borrar_Sesion 
@Id_Sesion as int 
as 
if Exists(select Id_Sesion from Sesion where Id_Sesion=@Id_Sesion)
delete Sesion where Id_Sesion=@Id_Sesion
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Sesion
@Id_Sesion as int,
@Tipo_Sesion as varchar(max),
@Entorno as varchar(max),
@Id_Encargado as varchar(max)
as 
if Exists(Select Tipo_Sesion from Sesion where Tipo_Sesion=@Tipo_Sesion)
update Sesion set Tipo_Sesion=@Tipo_Sesion,Entorno=@Entorno,Id_Encargado=@Id_Encargado
where Tipo_Sesion=@Tipo_Sesion
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Sesion
as 
select * from Sesion


---------------Procedimientos Funcion
create proc Insertar_Funcion
@Id_Funcion as int,
@Id_Usuario as int,
@Id_Sesion as int,
@Funcion as varchar(max)
as 
if Exists(Select Id_Funcion from Funcion where Id_Funcion=@Id_Funcion)
Raiserror('Usuario Registrado',16,1)
else
Insert into Funcion
values (@Id_Funcion,@Id_Usuario,@Id_Sesion,@Funcion)

create proc Borrar_Funcion 
@Id_Funcion as int
as 
if Exists(select Id_Funcion from Funcion where Id_Funcion=@Id_Funcion)
delete Funcion where Id_Funcion=@Id_Funcion
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Funcion
@Id_Funcion as int,
@Id_Usuario as int,
@Id_Sesion as int,
@Funcion as varchar(max)
as 
if Exists(Select Id_Funcion from Funcion where Id_Funcion=@Id_Funcion)
update Funcion set Id_Funcion=@Id_Funcion,@Id_Usuario=@Id_Usuario,Id_Sesion=@Id_Sesion,Funcion=@Funcion
where Id_Funcion=@Id_Funcion
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Funcion
as 
select * from Funcion


---------------Procedimientos Carro
create proc Insertar_Vehiculo
@Id_Vehiculo as int,
@Caracteristicas as varchar(max)
as 
if Exists(Select Id_Vehiculo from Vehiculo where Id_Vehiculo=@Id_Vehiculo)
Raiserror('Usuario Registrado',16,1)
else
Insert into Vehiculo
values (@Id_Vehiculo,@Caracteristicas)

create proc Borrar_Vehiculo 
@Id_Vehiculo as int
as 
if Exists(select @Id_Vehiculo from Vehiculo where Id_Vehiculo=@Id_Vehiculo)
delete Vehiculo where Id_Vehiculo=@Id_Vehiculo
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Vehiculo
@Id_Vehiculo as int,
@Caracteristicas as varchar(max)
as 
if Exists(Select Id_Vehiculo from Vehiculo where Id_Vehiculo=@Id_Vehiculo)
update Vehiculo set Id_Vehiculo=@Id_Vehiculo,Caracteristicas=@Caracteristicas
where Id_Vehiculo=@Id_Vehiculo
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Vehiculo
as 
select * from Vehiculo


---------------Procedimientos arma
create proc Insertar_Arma
@Id_Arma as int,
@Caracteristicas as varchar(max)
as 
if Exists(Select Id_Arma from Arma where Id_Arma=@Id_Arma)
Raiserror('Usuario Registrado',16,1)
else
Insert into Arma
values (@Id_Arma,@Caracteristicas)

create proc Borrar_Arma 
@Id_Arma as int
as 
if Exists(select Id_Arma from Arma where Id_Arma=@Id_Arma)
delete Arma where Id_Arma=@Id_Arma
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Arma
@Id_Arma as int,
@Caracteristicas as varchar(max)
as 
if Exists(Select @Id_Arma from Arma where Id_Arma=@Id_Arma)
update Arma set @Id_Arma=@Id_Arma,Caracteristicas=@Caracteristicas
where Id_Arma=@Id_Arma
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Arma
as 
select * from Arma


---------------Procedimientos Tirador
create proc Insertar_Disparo
@Id_Funcion as int,
@Id_Arma as int,
@Posicion as varchar(max),
@Acerto as int
as 
Insert into Disparo
values (@Id_Funcion,@Id_Arma,@Posicion,@Acerto)

create proc Borrar_Disparo 
@Id_Funcion as int,
@Id_Arma as int
as 
if Exists(select Id_Funcion from Disparo where Id_Funcion=@Id_Funcion and Id_Arma=@Id_Arma)
delete Disparo where Id_Funcion=@Id_Funcion and Id_Arma=@Id_Arma
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Disparo
@Id_Funcion as int,
@Id_Arma as int,
@Posicion as varchar(max),
@Acerto as int
as 
if Exists(select Id_Funcion from Disparo where Id_Funcion=@Id_Funcion and Id_Arma=@Id_Arma)
update Disparo set Id_Funcion=@Id_Funcion,Id_Arma=@Id_Arma,Posicion=@Posicion,Acerto=@Acerto
where Id_Funcion=Id_Funcion and Id_Arma=@Id_Arma
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Disparo
as 
select * from Disparo

---------------Procedimientos Tirador
create proc Insertar_Conductor
@Id_Funcion as int,
@Id_Vehiculo as int,
@Posicion as varchar(max),
@Anomalia as int
as 
Insert into Conductor
values (@Id_Funcion,@Id_Vehiculo,@Posicion,@Anomalia)

create proc Borrar_Conductor
@Id_Funcion as int,
@Id_Vehiculo as int
as 
if Exists(select Id_Funcion from Conductor where Id_Funcion=@Id_Funcion and Id_Vehiculo=@Id_Vehiculo)
delete Conductor where Id_Funcion=@Id_Funcion and Id_Vehiculo=@Id_Vehiculo
else
Raiserror('Usuario no Existente',16,1)

create proc Actualizar_Conductor
@Id_Funcion as int,
@Id_Vehiculo as int,
@Posicion as varchar(max),
@Anomalia as int
as 
if Exists(select Id_Funcion from Conductor where Id_Funcion=@Id_Funcion and Id_Vehiculo=@Id_Vehiculo)
update Conductor set Id_Funcion=@Id_Funcion,Id_Vehiculo=@Id_Vehiculo,Posicion=@Posicion,Anomalia=@Anomalia
where Id_Funcion=@Id_Funcion and Id_Vehiculo=@Id_Vehiculo
else
raiserror('Usuario no encontrado',16,1)

create proc Mostrar_Conductor
as 
select * from Conductor


BULK INSERT Arma
FROM 'C:\Users\ibege\Desktop\sedena\Arma.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Conductor
FROM 'C:\Users\ibege\Desktop\sedena\Conductor.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Disparo
FROM 'C:\Users\ibege\Desktop\sedena\Disparo.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Encargado
FROM 'C:\Users\ibege\Desktop\sedena\Encargado.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Funcion
FROM 'C:\Users\ibege\Desktop\sedena\Funcion.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Sesion
FROM 'C:\Users\ibege\Desktop\sedena\Sesion.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Usuario
FROM 'C:\Users\ibege\Desktop\sedena\Usuario.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

BULK INSERT Vehiculo
FROM 'C:\Users\ibege\Desktop\sedena\Vehiculo.csv'
WITH (FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		ROWTERMINATOR='\n',
		MAXERRORS=5);

select * from Encargado

delete Usuario;

select * from sesion;

insert into Disparo(Id_Funcion,Id_Arma,Posicion,Acerto) 
values (1,1,'1,1',1)

delete Conductor

select * from Conductor