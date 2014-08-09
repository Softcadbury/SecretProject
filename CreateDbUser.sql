CREATE LOGIN softcadbury WITH PASSWORD = 'softox';
GO

CREATE USER softcadbury FOR LOGIN softcadbury;
GO

EXEC sp_addsrvrolemember @loginame= 'softcadbury', @rolename = 'dbcreator';
GO