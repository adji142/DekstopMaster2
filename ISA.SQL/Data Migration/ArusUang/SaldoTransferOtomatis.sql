USE ISAFinance
GO
TRUNCATE TABLE dbo.SaldoTransferOtomatis
GO
INSERT INTO dbo.SaldoTransferOtomatis
(
RowID, 
Bulan,Tahun, rr, T01, T02, T03, T04, T05, T06, T07, T08, T09, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31
)
SELECT	NEWID(),
		a.*
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM SaldoTo') a

GO
