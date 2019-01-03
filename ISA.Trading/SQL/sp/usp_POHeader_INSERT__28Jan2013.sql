
-- =============================================        
-- Author:  csw        
-- Create date:  28 Januari 2013        
-- Description: List data on table Numerator        
-- Example : [usp_POHeader_INSERT]
-- =============================================        
ALTER PROCEDURE [dbo].[usp_POHeader_INSERT]         
	@idtr varchar(50)
	,@no_po varchar(50)
	,@admin varchar(50)
	,@gudang varchar(50)
	,@keterangan varchar(MAX)
AS        
BEGIN        
	INSERT INTO [RefilPO]
	(RowID, idtr, tgl_po
	,no_po,[admin],gudang
    ,keterangan,SyncFlag
     )

	VALUES(NEWID(),@idtr,GETDATE()
	,@no_po,@admin, @gudang
	,@keterangan,0 )
     
	    
   
 END
