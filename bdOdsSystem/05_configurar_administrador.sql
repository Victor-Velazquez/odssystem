/****** Antes de ejecutar el script verificar los comentarios entre <>   ******/ 
/****** la contraseña es ods2019                                         ******/

insert into ods_interesado(Interesado, Nombre, Usuario, Contrasenia, CorreoRecuperacion, UltimaSesion, IPUltimaSesion,Administrador,SuperUsuario,Bloqueado,Activo,IdMunicipio)
values('Super Administrador ODS System','Administrador ODS System','sadmin','yFWNcxZ6QfWiRbZaD0eio+sTuIUMm2cU0g0skxgT6UQ=','sadmin@odssytem.org',getdate(),'1.0.0.1',0,1,0,1,1)
GO

insert into ods_interesado(Interesado, Nombre, Usuario, Contrasenia, CorreoRecuperacion, UltimaSesion, IPUltimaSesion,Administrador,SuperUsuario,Bloqueado,Activo,IdMunicipio)
values('Admin ODS System','Administrador ODS System','admin','yFWNcxZ6QfWiRbZaD0eio+sTuIUMm2cU0g0skxgT6UQ=','admin@odssystem.org',getdate(),'1.0.0.1',1,0,0,1,1)

insert into ods_interesado(Interesado, Nombre, Usuario, Contrasenia, CorreoRecuperacion, UltimaSesion, IPUltimaSesion,Administrador,SuperUsuario,Bloqueado,Activo,IdMunicipio)
values('User ODS System','User ODS System','user','yFWNcxZ6QfWiRbZaD0eio+sTuIUMm2cU0g0skxgT6UQ=','usuario@odssystem.org',getdate(),'1.0.0.1',0,0,0,1,1)

