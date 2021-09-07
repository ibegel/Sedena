use sedena

select * from Actividad 
inner join Sesion on Actividad.Id_Actividad=Sesion.Id_Actividad
inner join Funcion on Sesion.Id_Sesion=Funcion.Id_Sesion
inner join Conductor on Conductor.Id_Funcion=Funcion.Id_Funcion
inner join Incidentes_Conductor on Conductor.Id_Funcion=Incidentes_Conductor.Id_Funcion
inner join Catalogo_IC on Catalogo_IC.Id_Incidente=Incidentes_Conductor.Id_Incidente
inner join Agente on Agente.Id_Agente=Funcion.Id_Agente

select * from Agente
Select * from Funcion

select * from Agente
inner join Funcion on Agente.Id_Agente= Funcion.Id_Usuario