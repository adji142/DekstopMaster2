 USE ISAdb 
GO
DELETE FROM ISAdb.dbo.Numerator
GO


INSERT INTO ISAdb.dbo.Numerator
(
	Doc,
	Depan,
	Belakang,
	Nomor,
	Lebar,
	LastUpdatedBy,
	LastupdatedTime
)
SELECT 
	RTRIM(doc), 
	RTRIM(depan), 
	RTRIM(belakang),
	RTRIM(nomor),
	RTRIM(lebar) , 
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Numerator')
where RTRIM(doc) in (SELECT RTRIM(doc) doc FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT doc FROM Numerator')
group by doc having COUNT(doc) = 1
)

INSERT INTO ISAdb.dbo.Numerator
(
	Doc,
	Depan,
	Belakang,
	Nomor,
	Lebar,
	LastUpdatedBy,
	LastupdatedTime
)
SELECT 
	RTRIM(a.doc) as doc, 
	RTRIM(a.depan) as depan, 
	RTRIM(a.belakang) as belakang,
	RTRIM(a.nomor) as nomor,
	RTRIM(a.lebar) as lebar, 
	'Admin',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM Numerator') as a
inner join 
(select doc as doc,max(nomor) as nomor FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT nomor,doc FROM Numerator')
group by doc having COUNT(doc) = 2) as b
on a.doc = b.doc and a.nomor = b.nomor

GO


INSERT INTO dbo.Numerator
(
	Doc,
	Depan,
	Nomor,
	Belakang,
	Lebar,
	LastUpdatedBy,
	LastUpdatedTime
)
SELECT
	RTRIM(kode_doc),
	RTRIM(depan),
	RTRIM(numerator),
	(CASE WHEN belakang = '' THEN '' ELSE 'Formula' END),
	0,
	'Admin',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', '
SELECT kode_doc, depan,numerator,belakang  FROM docnmrt')

--SELECT * FROM Numerator