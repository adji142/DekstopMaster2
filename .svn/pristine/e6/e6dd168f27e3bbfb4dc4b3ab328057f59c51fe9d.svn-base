USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[usp_PPC_LIST]    Script Date: 03/25/2011 19:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =================================================
-- Author:		Stephanie
-- Create date: 25 Mar 11
-- Description:	List data PPC terhadap spesifik toko
-- =================================================
CREATE PROCEDURE [dbo].[usp_PPC_LIST] 
	-- Add the parameters for the stored procedure here
	@kodeToko varchar(19)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    -- Insert statements for procedure here

	SELECT 
		j.RecordID AS JRecID,
		r.RecordID AS RRecID,
		j.KodeBarang,
		j.NamaBarang,
		t.KodeToko,
		(r.QtyAmbil - r.QtyKirim) AS QtySisa
	FROM dbo.TPPC t
		LEFT OUTER JOIN dbo.HPPC h ON t.HPPCRecID = H.recordID
		LEFT OUTER JOIN dbo.RPPC r ON t.RecordID = r.TPPCRecID
		LEFT OUTER JOIN dbo.JPPC j ON r.JPPCRecID = j.RecordID
	WHERE 
		t.KodeToko = @kodeToko
		AND h.LPasif = 0
		AND	(ISNULL(r.NoACC, '') != '' AND r.NoACC != 'TOLAK')
		AND	(r.QtyAmbil - r.QtyKirim) > 0
		AND	j.RecordID IS NOT NULL
		AND EXISTS(SELECT d.KodeToko FROM dbo.DPJPPC d WHERE d.KodeToko = @kodeToko)
	ORDER BY j.NamaBarang ASC	
    
END

/*
  PARAMETERS cKd_Toko
  ZAP IN CursPpc
  IF !USED('Tppc')
     USE Tppc IN 0
  ENDIF
  SET ORDER TO Kd_toko IN Tppc
  IF !USED('Rppc')
     USE Rppc IN 0
  ENDIF
  SET ORDER TO Idtppc IN Rppc
  IF !USED('Jppc')
     USE Jppc IN 0
  ENDIF
  SET ORDER TO Idrec IN Jppc
  IF !USED('Hppc')
     USE Hppc IN 0
  ENDIF
  SET ORDER TO Idrec IN Hppc
  IF SEEK(cKd_Toko,'Tppc')
     DO WHILE Tppc.Kd_toko = cKd_Toko AND !EOF('Tppc')
        IF SEEK(Tppc.Idhppc,'Hppc')
           IF !Hppc.lPasif
              IF SEEK(Tppc.Idrec,'Rppc')
                 DO WHILE Rppc.Idtppc = Tppc.Idrec AND !EOF('Rppc')
                    IF !EMPTY(Rppc.Noacc)
                       IF ALLTRIM(Rppc.noacc) <> 'TOLAK'
                          IF SEEK(Rppc.Idjppc,'Jppc') AND (Rppc.Q_ambil - Rppc.Q_kirim) > 0
                             INSERT INTO CursPpc (Idrecj,Idrecr,Kd_brg,Nm_brg,Kd_toko,;
                             Q_sisa) VALUES (Jppc.Idrec,Rppc.Idrec,Jppc.Kd_brg,;
                             Jppc.Nm_brg,Tppc.Kd_toko,Rppc.Q_ambil-Rppc.Q_kirim)
                           ENDIF
                        ENDIF
                     ENDIF
                     SKIP IN Rppc
                 ENDDO
              ENDIF
           ENDIF
        ENDIF
        SKIP IN Tppc
     ENDDO
  ENDIF
  RETURN
*/



 