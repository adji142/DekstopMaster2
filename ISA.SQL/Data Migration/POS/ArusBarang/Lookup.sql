USE ISAdb

DELETE FROM dbo.Lookup

INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'PASSWORD_AGE', 
		'SECURITY', 
		'90', 
		'',
		0, 
		'System', 
		GETDATE()
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'PASSWORD_HISTORY', 
		'SECURITY', 
		'3', 
		'',
		0, 
		'System', 
		GETDATE()		
		
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'MAX_LOGIN_ATTEMPT', 
		'SECURITY', 
		'3', 
		'',
		0, 
		'System', 
		GETDATE()		
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'PASSWORD_ZIP', 
		'ZIP', 
		'abcde', 
		'',
		0, 
		'System', 
		GETDATE()			
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'PASSWORD_ENABLED', 
		'ZIP', 
		'True', 
		'',
		0, 
		'System', 
		GETDATE()			
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'FTP_ADDRESS', 
		'FTP', 
		'ftp://ftp.sas-autoparts.com/domain/download.sas-autoparts.com/web/ISA/', 
		'',
		0, 
		'System', 
		GETDATE()	
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'FTP_USER', 
		'FTP', 
		'u6587', 
		'',
		0, 
		'System', 
		GETDATE()	
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'FTP_PASSWORD', 
		'FTP', 
		'???ll?????', 
		'',
		0, 
		'System', 
		GETDATE()	
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'FTP_DIRECTORY_UPLOAD', 
		'FTP', 
		'D:\ISA\FTP\UPLOAD', 
		'',
		0, 
		'System', 
		GETDATE()		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'FTP_DIRECTORY_DOWNLOAD', 
		'FTP', 
		'D:\ISA\FTP\DOWNLOAD', 
		'',
		0, 
		'System', 
		GETDATE()		
		
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'PIUTANG_PATH', 
		'WINSERVICES', 
		'Z:\DBF Stok Piutang', 
		'',
		0, 
		'System', 
		GETDATE()		
		
		
INSERT INTO dbo.Lookup
	(
		LookupCode, 
		LookupType, 
		Value, 
		AdditionalInfo, 
		RowOrder, 
		LastUpdatedBy, 
		LastUpdatedTime
	)
SELECT
		'NET_USE', 
		'WINSERVICES', 
		'net use Z: \\jktdev\sasapp', 
		'\\jktdev\sasapp$\DBF Stok Piutang', 
		0, 
		'System', 
		GETDATE()		
		
		
INSERT into [lookup] values('FOXPRO_PATH','FOXPRO_ENGINE','\\jktdev\sasapp$\SAS\database','',0,'System',getdate())

INSERT INTO [LOOKUP] VALUES('DOT_MATRIX','PRINTER','\\apw-new\Epson LQ-2180 ESC/P 2','',0,'System',GETDATE())