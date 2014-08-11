CREATE LOGIN softcadbury WITH PASSWORD = 'softoxsoftox';
GO

CREATE USER softcadbury FOR LOGIN softcadbury;
GO

EXEC sp_addsrvrolemember @loginame= 'softcadbury', @rolename = 'dbcreator';
GO