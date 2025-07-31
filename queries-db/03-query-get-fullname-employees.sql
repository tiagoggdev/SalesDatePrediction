USE StoreSample;
GO

SELECT 
    Empid,
    Firstname + ' ' + Lastname AS FullName
FROM HR.Employees;