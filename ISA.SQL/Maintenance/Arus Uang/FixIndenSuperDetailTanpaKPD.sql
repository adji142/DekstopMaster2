insert into KartuPiutangDetail
select
RowID,
KPID,
RecordID,
KPrecID,
TglInden,
Ref,
0,
RpInden,
(case when RTRIM(ref)='TRN' then c.TglTrf when RTRIM(ref)='BGC' then c.TglJt else b.TglBPP end),
d.NoBukti + '.' + b.noBPP + '/' + ref + ':' + 
RTRIM(replace(convert(varchar(50),(case when RTRIM(ref)='TRN' then c.RpTrf when RTRIM(ref)='BGC' then c.RpGiro
when RTRIM(ref)='KAS' then c.RpCash when RTRIM(ref)='CRD' then c.RpCrd else c.RpDbt end)),'.00','')),
0,
RIGHT(rtrim(b.noreg),5),
c.Nomor,
c.NamaBank,
c.NoAcc,
0,
'INJECT',
GETDATE()
from IndenSuperDetail a
outer apply
(
	select TglBPP, NoBPP, NoReg from IndenSubDetail where RowID=a.HeaderID
)b
outer apply
(
	select RpCash, RpTrf,RpGiro, RpCrd, RpDbt, TglTrf, c.TglJt, NoAcc, Nomor, NamaBank
	from IndenDetail c where RowID=a.IndenDetailID
)c
outer apply
(
	select NoBukti from Inden where RowID=a.IndenID
)d
 where RowID='E5151C52-860B-457A-A5F9-507FD0B7AD4A'
 --INI WHERE nya RowID IndenSuperDetail.. 
 -- Kalau RowID Inden -> IndenID = .....
 -- Kalau RowID IndenDetail -> IndenDetailID = ....
 -- Kalau RowID IndenSubDetail -> HeaderID = .... 