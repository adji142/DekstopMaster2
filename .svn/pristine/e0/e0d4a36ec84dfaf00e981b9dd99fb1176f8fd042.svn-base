ALTER PROCEDURE [dbo].psp_GL_DownloadJournal
@idtrans varchar(23), 
@tanggal datetime,
@no_reff varchar(15), 
@uraian varchar(50), 
@src varchar(3), 
@kd_gdg varchar(4), 
@id_match bit,
@LastUpdatedBy varchar(250)
AS
BEGIN

IF EXISTS (SELECT RecordID  FROM DBO.Journal WHERE tanggal = @tanggal 
												AND NoReff = @no_reff 
												AND KodeGudang = @kd_gdg
												AND RecordID = @idtrans
												AND Src = @src )
BEGIN
	UPDATE DBO.Journal
	SET RecordID = @idtrans,
		Tanggal = @tanggal,
		NoReff = @no_reff,
		Uraian = @uraian,
		Src = @src,
		KodeGudang = @kd_gdg,
		SyncFlag = @id_match,
	
		LastUpdatedBy = @LastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE tanggal = @tanggal 
		AND NoReff = @no_reff 
		AND KodeGudang = @kd_gdg
		AND RecordID = @idtrans
		AND Src = @src


END
ELSE
BEGIN

	INSERT INTO DBO.Journal
		(RowID,RecordID, Tanggal, NoReff,
		Uraian, Src, KodeGudang, 
		SyncFlag,LastUpdatedBy,LastUpdatedTime
		)
	VALUES(NEWID(),@idtrans, @tanggal, @no_reff,
		@uraian, @src, @kd_gdg, 
		@id_match, @LastUpdatedBy, GETDATE()
	)

END
END

-- ///////////////////////////////////////////////////////////////////////////////////////////////////
-- ///////////////////////////////////////////////////////////////////////////////////////////////////
-- ///////////////////////////////////////////////////////////////////////////////////////////////////


ALTER PROCEDURE [dbo].psp_GL_DownloadTransact
@idrec varchar(23),
@idtrans varchar(23),
@no_perk varchar(12),
@uraian varchar(50),
@debet money,
@kredit money,
@dk varchar(1),
@LastUpdatedBy varchar(250)
AS
BEGIN

IF EXISTS (SELECT RecordID  FROM DBO.JournalDetail WHERE RecordID = @idrec 
													AND HRecordID = @idtrans 
													AND NoPerkiraan = @no_perk
													AND Debet = @debet
													AND Kredit = @kredit
													AND DK = @dk )
BEGIN
	UPDATE DBO.JournalDetail
	SET RecordID = @idrec,
		HRecordID = @idtrans, 
		NoPerkiraan = @no_perk,
		Debet = @debet,
		Kredit = @kredit,
		DK = @dk,
		LastUpdatedBy = @LastUpdatedBy,
		LastUpdatedTime = GETDATE()
	WHERE RecordID = @idrec 
		AND HRecordID = @idtrans 
		AND NoPerkiraan = @no_perk
		AND Debet = @debet
		AND Kredit = @kredit
		AND DK = @dk


END
ELSE
BEGIN
	INSERT INTO DBO.JournalDetail
		(RowID,RecordID, HRecordID, HeaderID,
		NoPerkiraan, uraian, Debet, 
		Kredit,DK,LastUpdatedBy,
		LastUpdatedTime
		)
	VALUES(NEWID(),@idrec, @idtrans, (SELECT RowID FROM Journal WHERE RecordID = @idtrans ),
		@no_perk, @uraian, @debet, 
		@kredit,@dk, @LastUpdatedBy, 
		GETDATE()
	)

END
END








USE [ISAFinance]
GO
/****** Object:  StoredProcedure [dbo].[usp_UploadDKN_List]    Script Date: 01/03/2013 13:27:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_UploadDKN_List]
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
   
   
    SELECT dkn.RowID as HrowID, dkndt.RowID as dtRowID,
    dkn.Tanggal as Tanggal, dkn.NoDKN as NoDKN, dkn.DK as DK,
    dkn.Cabang as Cabang, dkndt.HRecordID as HRecordID,
    dkn.CD as CD, dkn.Src as Src, dkndt.RecordID as RecordID,
    '' as NoPerkiraan, dkndt.Uraian as Uraian,
    dkndt.Jumlah as Jumlah, dkndt.Dari as Dari,
    dkndt.Tolak as Tolak, dkndt.Alasan as Alasan
    FROM DKN as dkn
    INNER JOIN DKNDetail as dkndt
    ON dkn.RowID = dkndt.HeaderID
    WHERE (dkn.Tanggal >= @fromDate OR @fromDate is NULL)
    AND (dkn.Tanggal <= @toDate OR @toDate IS NULL)
    AND dkn.syncflag = 0
   
END 


