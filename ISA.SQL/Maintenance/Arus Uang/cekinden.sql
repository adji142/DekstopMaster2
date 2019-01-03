--INDEN DETAIL HEADERID
select * from IndenDetail id
inner join Inden i on id.HRecordID =i.RecordID
where id.HeaderID<>i.RowID or id.HeaderID is null
/*
update IndenDetail
set HeaderID = i.rowid
from IndenDetail id
inner join Inden i on id.HRecordID =i.RecordID
where id.HeaderID<>i.RowID or id.HeaderID is null
*/

--INDEN SUB DETAIL
select * from IndenSubDetail isd
inner join IndenDetail id on isd.HRecordID=id.RecordID
where (isd.HeaderID<>id.RowID or isd.HeaderID is null) 
or (isd.IndenID is null or isd.IndenID <> id.HeaderID) and id.HeaderID is not null
/*
update IndenSubDetail 
set HeaderID =id.rowid,
	IndenID =id.headerid
from IndenSubDetail isd
inner join IndenDetail id on isd.HRecordID=id.RecordID
where (isd.HeaderID<>id.RowID or isd.HeaderID is null) 
or (isd.IndenID is null or isd.IndenID <> id.HeaderID) and id.HeaderID is not null
*/

--INDEN SUPER DETAIL
select * from IndenSuperDetail ispd
inner join IndenSubDetail isd on ispd.HRecordID =isd.RecordID
where (ispd.HeaderID<>isd.RowID or ispd.HeaderID is null)
or (ispd.IndenDetailID<>isd.HeaderID or ispd.IndenDetailID is Null)
or (ispd.IndenID <> isd.IndenID or ispd.IndenID is null)
and isd.HeaderID is not null and isd.IndenID is not null
/*
update IndenSuperDetail 
set HeaderID = isd.RowID,
	IndenDetailID = isd.HeaderID,
	IndenID = isd.IndenID
from IndenSuperDetail ispd
inner join IndenSubDetail isd on ispd.HRecordID =isd.RecordID
where (ispd.HeaderID<>isd.RowID or ispd.HeaderID is null)
or (ispd.IndenDetailID<>isd.HeaderID or ispd.IndenDetailID is Null)
or (ispd.IndenID <> isd.IndenID or ispd.IndenID is null)
and isd.HeaderID is not null and isd.IndenID is not null
*/


 