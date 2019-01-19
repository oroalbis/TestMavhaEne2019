# **Test Técnico de Mavha - Albis oro**

# **Problema**

Implementar una solución visual (Web y Winform) con Alta-Listado  de una Entidad Persona con las siguientes características:

PERSONA

- Nombre Completo
- Fecha de nacimiento
- Edad
- Sexo

Implementar:

1. 1)Listado de personas en una tabla con todos los campos de la entidad.
2. 2)Alta de persona con todos los campos de la entidad.
3. 3)Edicion de persona con todos los campos de la entidad.
4. 4)Baja lógica de persona. PENDIENTE

# Se creó una base de datos en un Servidor Sql Server online.

# _Datos de ingreso a la base de datos:_

- Server: mavhatestaoro.db.8804041.c3a.hostedresource.net 
- User: mavhatestaoro 
- database: mavhatestaoro 
- password: enviado en el correo.

# Adicional dejo el script de la tabla.

USE [mavhatestaoro]  
GO  
SET ANSI\_NULLS ON  
GO  
SET QUOTED\_IDENTIFIER ON  
GO  
CREATE TABLE [dbo].[personas](  
        [id] [int] IDENTITY(1,1) NOT NULL,  
        [nombre\_apellido] [varchar](50) NOT NULL,  
        [fecha\_nacimiento] [date] NOT NULL,  
        [edad] [int] NOT NULL,  
        [sexo] [nchar](1) NOT NULL,  
        [sn\_activo] [bit] NULL  
) ON [PRIMARY]  
GO  

Consideraciones:

- **--** Construir una Solución .Net con los siguientes proyectos:
-
**--**** Solución con los proyectos:**
 
  -
--Proyecto VB.Net con la Lógica de negocio del ABML.
 
  -
--Proyecto de WebServices SOAP que reuse el proyecto de Logica.
 
  -
--Proyecto WinForms en VB.Net para ABML de Personas, que consuma los servicios del proyecto SOAP.
 
- **--** Utilizar VisualStudio 2013 o superior.  
**SE UTILIZÓ VISUAL STUDIO 2017**
- **--** Utilizar .Net 3.5  
**SE UTILIZÓ net framework 3.5 en todos los proyectos, excepto en la aplicación web.**
- **--** Persistencia en DB SQLServer.  
**SE DEJÓ UNA BD ONLINE Y EL SCRIPT DE LA TABLA**
- **--** Publicar el proyecto en github o bitbucket y enviar el link por correo a [marlatto@mavha.com](mailto:martin.marlatto@mavha.com) y [mattig@mavha.com](mailto:maximiliano.mattig@mavha.com)  
**Publicado en:**[**https://github.com/oroalbis/TestMavhaEne2019**](https://github.com/oroalbis/TestMavhaEne2019)
