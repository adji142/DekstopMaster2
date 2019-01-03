USE ISAFinance 
GO
DELETE FROM dbo.Numerator 
GO
INSERT INTO dbo.Numerator
(
	Doc, 
	Nama,
	Depan, 
	Belakang, 
	Nomor,
	Periode, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	RTrim(Kode_doc),
	RTrim(Nama_doc),
	RTrim(REPLACE(Depan,'"','')),	
	RTrim('SELECT @result = SUBSTRING(@date,3,4)') AS Belakang,
	Numerator,
	'',
	'Import',
	getdate()
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Kasir\'; ' '; ' ', 'SELECT Kode_doc,Nama_doc,Depan,Numerator FROM DOCNMRT')


INSERT INTO DBO.Numerator
(
	Doc, 
	Nama,
	Depan, 
	Belakang, 
	Nomor,
	Periode, 
	LastUpdatedBy, 
	LastUpdatedTime
)
VALUES
(
'GIROIN',
'GIRO INTERNAL',
'',
'SELECT @result = SUBSTRING(@date,3,4)',
'592205',
'',
'Import',
getdate()	

)

INSERT INTO DBO.Numerator
(
	Doc, 
	Nama,
	Depan, 
	Belakang, 
	Nomor,
	Periode, 
	LastUpdatedBy, 
	LastUpdatedTime
)
VALUES
(
'REG',
'NOMOR_REGISTER',
'201',
'',
'114',
'',
'Import',
getdate()	

)

GO

--SELECT * FROM Cabang  