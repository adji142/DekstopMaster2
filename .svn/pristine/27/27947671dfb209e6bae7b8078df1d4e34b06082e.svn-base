USE ISAFinance_JKT
GO



INSERT INTO DBO.SubJournalDetail
(
RowID, HeaderID, RecordID, HRecordID, PartnerID, PartnerNo, NamaPartner, Persen, Currency, Amount, LastUpdatedBy, LastUpdatedTime
)
SELECT RowID, 
(SELECT TOP 1  RowID FROM DBO.SubJournal x WHERE x.RecordID = a.HRecordID ) AS HeaderID, 
RecordID, HRecordID, PartnerID, PartnerNo, NamaPartner, Persen, Currency, Amount, LastUpdatedBy, LastUpdatedTime
FROM ISAFinance.DBO.SubJournalDetail a
WHERE RecordID NOT IN (SELECT RecordID FROM DBO.SubJournalDetail)

GO 