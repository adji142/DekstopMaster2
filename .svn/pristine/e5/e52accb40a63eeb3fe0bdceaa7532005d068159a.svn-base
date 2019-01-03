USE ISAFinance
GO
TRUNCATE TABLE dbo.DataCustomer
GO
DECLARE @DataCustomer TABLE (KodeToko VARCHAR(23) PRIMARY KEY CLUSTERED , LamaGiro INT DEFAULT(0))

INSERT INTO @DataCustomer(KodeToko, LamaGiro)
SELECT	 a.kd_toko, a.lamaGiro
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM datacust') a
WHERE RTRIM(LTRIM(a.kd_toko))<>''
GROUP BY  a.kd_toko, a.lamaGiro

INSERT INTO dbo.DataCustomer( KodeToko, NamaToko, Alamat, Kota, WilID, LamaGiro)
SELECT d.KodeToko, ISNULL(t.NamaToko,''), ISNULL(t.Alamat,''), ISNULL(t.Kota,''), ISNULL(t.WilID,''), d.LamaGiro
FROM @DataCustomer d
LEFT OUTER JOIN ISAdb.dbo.Toko t (NOLOCK)ON d.KodeToko = t.KodeToko