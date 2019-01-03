 /* Note
 * Rubah tmt1 dan tmt2 datatype jadi character
 */

USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PeriodeGroup
GO
INSERT INTO ISAdb.dbo.PeriodeGroup
(
	StokGroupID, 
	TglAktif, 
	TglPasif, 
	Qty, 
	Prosen, 
	Tempo
)
SELECT 
	RTRIM(id_grstok),
	CAST((CASE WHEN tmt1 = '  /  /  ' THEN NULL
			ELSE (CASE WHEN CONVERT(INT, LEFT(LTRIM(tmt1), 4)) < 1900 
					THEN NULL ELSE tmt1 END)
			END) AS DATETIME),
	CAST((CASE WHEN tmt2 = '  /  /  ' THEN NULL
			ELSE (CASE WHEN CONVERT(INT, LEFT(LTRIM(tmt2), 4)) < 1900 
					THEN NULL ELSE tmt2 END)
			END) AS DATETIME),
	qty,
	prosen,
	tempo
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 
'SELECT id_grstok, DTOS(tmt1) as tmt1, DTOS(tmt2) as tmt2, qty, prosen, tempo FROM gr_priod')


--GO
--SELECT * FROM dbo.PeriodeGroup
