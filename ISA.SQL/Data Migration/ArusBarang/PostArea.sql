USE ISAdb 
GO
DELETE FROM ISAdb.dbo.PostArea 
GO
INSERT INTO ISAdb.dbo.PostArea
(
	RecordID, 
	PostID, 
	PostName, 
	[Address], 
	Address1, 
	City, 
	Contact, 
	Phone, 
	Fax, 
	Email
)
SELECT 
	RTRIM(idrec),
	RTRIM(id_post),
	RTRIM(post_name),
	RTRIM([adress]),
	RTRIM(adress1),
	RTRIM(city),
	RTRIM(contact),
	RTRIM(phone),
	RTRIM(fax),
	RTRIM(email)
FROM OPENROWSET('VFPOLEDB', 'C:\SAS_Database\'; ' '; ' ', 'SELECT * FROM postarea')

GO

--SELECT * FROM PostArea 