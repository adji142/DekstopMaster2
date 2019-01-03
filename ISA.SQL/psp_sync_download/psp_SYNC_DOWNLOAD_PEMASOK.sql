USE [ISAdb]
GO
/****** Object:  StoredProcedure [dbo].[psp_SYNC_DOWNLOAD_Pemasok]    Script Date: 10/11/2011 13:48:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nobon
-- Create date: 20 May 2011
-- Description:	<Description,,>
-- exec psp_SYNC_DOWNLOAD_Pemasok '<root><row PemasokID="KP " Nama="KP-SOLO            " Lengkap="KANTOR PUSAT SOLO      " Alamat="                                        " Kota="                                        " Telp="          " Fax="          " Kontak="                     " Keterangan="                                           " SyncFlag="1" LastUpdatedBy="Admin" LastUpdatedTime="2011-01-05T13:21:55.953"/></root>'
-- =============================================
ALTER PROCEDURE [dbo].[psp_SYNC_DOWNLOAD_Pemasok] 
	-- Add the parameters for the stored procedure here
	@doc text = '<root><row/></root>'

AS
BEGIN	
	DECLARE @hdoc INT
	DECLARE @PemasokID VARCHAR(3)
	DECLARE @Nama VARCHAR(19)
	DECLARE @Lengkap VARCHAR(23)
	DECLARE @Alamat VARCHAR(40)
	DECLARE @Kota VARCHAR(40)
	DECLARE @Telp VARCHAR(10)
	DECLARE @Fax VARCHAR(10)
	DECLARE @Kontak VARCHAR(21)
	DECLARE @Keterangan VARCHAR(43)
	DECLARE @SyncFlag BIT
	DECLARE @LastUpdatedBy VARCHAR(250)
	DECLARE @LastUpdatedTime DATETIME

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- INTerfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	
	DECLARE @Temp TABLE
	(
		PemasokID VARCHAR(3),
		Nama VARCHAR(19),
		Lengkap VARCHAR(23),
		Alamat VARCHAR(40),
		Kota VARCHAR(40),
		Telp VARCHAR(10),
		Fax VARCHAR(10),
		Kontak VARCHAR(21),
		Keterangan VARCHAR(43),
		SyncFlag BIT,
		LastUpdatedBy VARCHAR(250),
		LastUpdatedTime DATETIME
	)
		exec sp_xml_preparedocument @hdoc OUTPUT, @doc
	INSERT INTO @Temp
	(
		PemasokID, Nama, Lengkap, Alamat, Kota, Telp, Fax, Kontak, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime
	)
	SELECT 
		PemasokID, 
		Nama, 
		Lengkap, 
		Alamat, 
		Kota, 
		Telp, 
		Fax, 
		Kontak, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM
	OPENXML(@hdoc, 'root/row')
	WITH 
	( 
		PemasokID VARCHAR(3) '@PemasokID',
		Nama VARCHAR(19) '@Nama',
		Lengkap VARCHAR(23) '@Lengkap',
		Alamat VARCHAR(40) '@Alamat',
		Kota VARCHAR(40) '@Kota',
		Telp VARCHAR(10) '@Telp',
		Fax VARCHAR(10) '@Fax',
		Kontak VARCHAR(21) '@Kontak',
		Keterangan VARCHAR(43) '@Keterangan',
		SyncFlag BIT '@SyncFlag',
		LastUpdatedBy VARCHAR(250) '@LastUpdatedBy',
		LastUpdatedTime DATETIME '@LastUpdatedTime'
	)

	exec sp_xml_removedocument @hdoc

	DECLARE data_cursor CURSOR FOR 
	SELECT 
		PemasokID, 
		Nama, 
		Lengkap, 
		Alamat, 
		Kota, 
		Telp, 
		Fax, 
		Kontak, 
		Keterangan, 
		SyncFlag, 
		LastUpdatedBy, 
		LastUpdatedTime
	FROM @Temp
			
	OPEN data_cursor
	
	FETCH NEXT FROM data_cursor INTO
		@PemasokID, @Nama, @Lengkap, @Alamat, @Kota, @Telp, @Fax, @Kontak, @Keterangan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime	

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Insert statements for procedure here
		SET @SyncFlag = 1
		
		IF EXISTS (SELECT PemasokID FROM dbo.Pemasok (NOLOCK) WHERE PemasokID = @PemasokID)
			UPDATE Pemasok WITH (ROWLOCK)
			SET
				PemasokID = @PemasokID,
				Nama = @Nama,
				Lengkap = @Lengkap,
				Alamat = @Alamat,
				Kota = @Kota,
				Telp = @Telp,
				Fax = @Fax,
				Kontak = @Kontak,
				Keterangan = @Keterangan,
				SyncFlag = @SyncFlag,
				LastUpdatedBy = @LastUpdatedBy,
				LastUpdatedTime = @LastUpdatedTime
			WHERE
				PemasokID = @PemasokID
		ELSE
			INSERT INTO Pemasok WITH (ROWLOCK)
			(PemasokID, Nama, Lengkap, Alamat, Kota, Telp, Fax, Kontak, Keterangan, SyncFlag, LastUpdatedBy, LastUpdatedTime)
			VALUES	(
						@PemasokID,
						@Nama,
						@Lengkap,
						@Alamat,
						@Kota,
						@Telp,
						@Fax,
						@Kontak,
						@Keterangan,
						@SyncFlag,
						@LastUpdatedBy,
						@LastUpdatedTime
					)
		FETCH NEXT FROM data_cursor INTO
		@PemasokID, @Nama, @Lengkap, @Alamat, @Kota, @Telp, @Fax, @Kontak, @Keterangan, @SyncFlag, @LastUpdatedBy, @LastUpdatedTime	

	END

	CLOSE data_cursor	
	DEALLOCATE data_cursor
			


END



 