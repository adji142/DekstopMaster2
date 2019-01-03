--KARTU PIUTANG
UPDATE KartuPiutang
	SET STATUS = CASE WHEN x.Debet = x.Kredit THEN 'CLOSE' ELSE 'OPEN' END
FROM dbo.KartuPiutang a
OUTER APPLY
	( 
		SELECT ISNULL( SUM(b.Debet),0) as Debet, ISNULL(SUM(Kredit),0) as Kredit
		FROM dbo.KartuPiutangDetail b
		WHERE
			b.HeaderID = a.RowID
	) x
	
	
-- GIRO TOLAK
UPDATE GiroTolak
	SET STATUS = CASE WHEN a.Debet = x.Kredit THEN 'CLOSE' ELSE 'OPEN' END
FROM dbo.GiroTolak a
OUTER APPLY
	( 
		SELECT ISNULL(SUM(Kredit),0) as Kredit
		FROM dbo.GiroTolakDetail b
		WHERE
			b.HeaderID = a.RowID
	) x