create database demirbasTakipDB
go 
use demirbasTakipDB
create table tbl_Kategoriler
(
	kategori_id	int primary key identity,
	kategori_ad	nvarchar(30)
)
create table tbl_personel
(
	Id		int primary key identity,
	ad		nvarchar(20),
	soyad	nvarchar(30),
	sicil	nvarchar(10)
)
create table tbl_urunler
(
	Id			int primary key identity,
	ad			nvarchar(30),
	stokAdet	int,
	kategori_id	int,
	kategori_ad	nvarchar(20),
	zimmet		nvarchar(50)

	CONSTRAINT [FK_tbl_urunler_To_tbl_kategoriler] FOREIGN KEY ([kategori_id]) REFERENCES [dbo].[tbl_kategoriler] ([kategori_id]) 
)
create table tbl_Yönetici
(
	Id		int primary key identity,
	AdSoyad	nvarchar(50),
	Unvan	nvarchar(30),
	Sifre	int,
)
create table tbl_zimmet
(
	zimmet_id		int primary key identity,
	zimmet_ad		nvarchar(30),
	zimmet_tarih	date,
	kategori_id		int,
	kategori_ad		nvarchar(30),
	urunid			int,
	urunad			nvarchar(30),
	perid			int,
	perad			nvarchar(100),
	persoyad		nvarchar(30)

	CONSTRAINT [FK_tbl_zimmet_To_tbl_kategoriler] FOREIGN KEY ([kategori_id]) REFERENCES [dbo].[tbl_kategoriler] ([kategori_id]),
    CONSTRAINT [FK_tbl_zimmet_To_tbl_urunler] FOREIGN KEY ([urunid]) REFERENCES [dbo].[tbl_urunler] ([Id]),
    CONSTRAINT [FK_tbl_zimmet_To_tbl_personel] FOREIGN KEY ([perid]) REFERENCES [dbo].[tbl_personel] ([Id])
)

--KATEGORÝ PROCEDURE ÝÞLEMLERÝ**********************************************************
CREATE PROCEDURE [dbo].[sp_kategori_ekle]
	@kategori_ad	nvarchar(30)
AS
	insert into tbl_kategoriler values(@kategori_ad) select @@IDENTITY

CREATE PROCEDURE [dbo].[sp_kategori_guncelle]
	@kategori_id	int,
	@kategori_ad	nvarchar(30)
AS
	update tbl_kategoriler set kategori_ad=@kategori_ad where kategori_id=@kategori_id

CREATE PROCEDURE [dbo].[sp_kategori_listele]
	
AS
	select k.kategori_ad,
			k.kategori_ad,
			u.Id,
			u.ad,
			u.stokAdet,
			u.zimmet,
			u.kategori_id
	from tbl_kategoriler k inner join tbl_urunler u on u.Id=u.kategori_id

CREATE PROCEDURE [dbo].[sp_kategori_sil]
	@kategori_id	int
	
AS
	delete from tbl_kategoriler where kategori_id=@kategori_id

--PERSONEL GÝRÝÞ PROCEDURE**********************************************************
CREATE PROCEDURE [dbo].[sp_per_giris]
	@ad		nvarchar(30),
	@sicil	nvarchar(10)
AS
	if(select count(*)from tbl_personel where ad=@ad and sicil=@sicil)>0
	select 1
	else
	select 0

--PERSONEL PROCEDURE ÝÞLEMLERÝ***********************************************************
CREATE PROCEDURE [dbo].[sp_personel_ekle]
	@ad		nvarchar(20),
	@soyad	nvarchar(30),
	@sicil	nvarchar(10)
AS
	insert into tbl_personel values(@ad,@soyad,@sicil)
	select @@IDENTITY

CREATE PROCEDURE [dbo].[sp_personel_guncelle]
	@id		int,
	@ad		nvarchar(20),
	@soyad	nvarchar(30),
	@sicil	nvarchar(10)
AS
	update tbl_personel set ad=@ad,soyad=@soyad,sicil=@sicil where id=@id

CREATE PROCEDURE [dbo].[sp_personel_listele]
as
	select * from tbl_personel

CREATE PROCEDURE [dbo].[sp_personel_sil]
	@id		int
AS
	delete from tbl_personel where Id=@id

--URUN PROCEDURE ÝÞLEMLERÝ****************************************************
CREATE PROCEDURE [dbo].[sp_urun_ekle]
	@ad		nvarchar(30),
	@stokAdet	int,
	@kategori_id int,
	@kategori_ad	nvarchar(30),
	@zimmet		nvarchar(50)
AS
	insert into tbl_urunler values(@ad,@stokAdet,@kategori_id,@kategori_ad,@zimmet)
	select @@IDENTITY

CREATE PROCEDURE [dbo].[sp_urun_guncelle]
	@id		int,
	@ad		nvarchar(30),
	@stokAdet	int,
	@kategori_id int,
	@kategori_ad	nvarchar(30),
	@zimmet		nvarchar(30)
AS
	update tbl_urunler set ad=@ad,stokAdet=@stokAdet,kategori_id=@kategori_id,kategori_ad=@kategori_ad,zimmet=@zimmet
	where Id=@id

CREATE PROCEDURE [dbo].[sp_urun_listele]
AS
	select * from tbl_urunler

CREATE PROCEDURE [dbo].[sp_urun_sil]
	@id		int
AS
	delete from tbl_urunler where Id= @id

--YÖNETÝCÝ PROCEDURE ÝÞLEMLERÝ************************************************
CREATE PROCEDURE [dbo].[sp_yonetici_giris]
	@AdSoyad	nvarchar(50),
	@Sifre		int
AS
	  if(select count(*)from tbl_Yönetici where AdSoyad=@AdSoyad and Sifre=@Sifre)>0
	select 1
	else
	select 0

CREATE PROCEDURE [dbo].[sp_yonetici_guncelle]
	@id			int,
	@AdSoyad	nvarchar(50),
	@Unvan		nvarchar(30),
	@Sifre		int
AS
	update tbl_Yönetici set AdSoyad=@AdSoyad,Unvan=@Unvan,Sifre=@Sifre where Id=@id


CREATE PROCEDURE [dbo].[sp_yonetici_listele]
AS
	select * from tbl_Yönetici


CREATE PROCEDURE [dbo].[sp_yonetici_sil]
	@id			int
	
AS
	delete from tbl_Yönetici  where Id=@id

CREATE PROCEDURE [dbo].[sp_yönetici_ekle]
	@AdSoyad	nvarchar(50),
	@Unvan	nvarchar(30),
	@Sifre int
AS
	insert into tbl_Yönetici values (@AdSoyad,@Unvan,@Sifre) select @@IDENTITY

--ZÝMMET PROCEDURE ÝÞLEMLERÝ************************************************************

CREATE PROCEDURE [dbo].[sp_zimmet_guncelle]
	@zimmet_id		int,
	@zimmet_ad		nvarchar(30),
	@zimmet_tarih	date,
	@kategori_ad	nvarchar(30),
	@urunad			nvarchar(30),
	@perad			nvarchar(20),
	@perSoyad		nvarchar(30)
AS
	update tbl_zimmet set zimmet_ad=@zimmet_ad,zimmet_tarih=@zimmet_tarih,kategori_ad=@kategori_ad,urunad=@urunad,perad=@perad,persoyad=@perSoyad where zimmet_id=@zimmet_id

CREATE PROCEDURE [dbo].[sp_zimmet_listele]
	
AS
	select * from tbl_zimmet

CREATE PROCEDURE [dbo].[sp_zimmet_sil]
	@zimmet_id		int
AS
	delete from tbl_zimmet where zimmet_id=@zimmet_id

insert into tbl_Kategoriler values('Bilgisayar')
insert into tbl_Kategoriler values('Kulaklýk')
insert into tbl_Kategoriler values('Tv')
insert into tbl_Kategoriler values('Cep Telefonu')

select * from tbl_Kategoriler

update tbl_Kategoriler set kategori_ad='Televizyon' where kategori_id=3
delete tbl_Kategoriler where kategori_id=3

select * from tbl_Kategoriler

insert into tbl_personel values('Muharrem',' Albayrakoðlu','12345')
insert into tbl_personel values('Burak Can',' Nas','12356')
insert into tbl_personel values('Enes',' Dorukbaþý','12367')
insert into tbl_personel values('Erkan',' Özkan','12378')

select * from tbl_personel

update tbl_personel set ad='Muharrem',soyad='Albayrakoðlu',sicil='13890' where Id=1
delete tbl_personel where Id=1

select * from tbl_personel

insert into tbl_urunler values('Laptop',250,1,'Bilgisayar ','Muharrem Albayrakoðlu')
insert into tbl_urunler values('Ýphone',15,2,' Cep Telefonu','Enes Dorukbaþý')
insert into tbl_urunler values('Led Tv',50,3,' Tv','Erkan Özkan')

select * from tbl_urunler

update tbl_urunler set ad='Laptop',stokAdet=200,kategori_ad='Bilgisayar',zimmet='Muharrem Albayrakoðlu' where Id=1
delete tbl_urunler where Id=1

select * from tbl_urunler

insert into tbl_Yönetici values('Adem Okumus','Mudur',1234)
insert into tbl_Yönetici values('Tuba Pala','Mudur',1234)

select * from tbl_Yönetici

update tbl_Yönetici set AdSoyad='Adem Okumuþ',Unvan='Mudur', Sifre=8181 where Id=1
delete tbl_Yönetici where Id=1

select * from tbl_Yönetici

insert into tbl_zimmet values('Demirbaþ','2020-11-10',3,'Bilgisayar',3,'Laptop',3,'Muharrem','Albayrakoðlu')
insert into tbl_zimmet values('Demirbaþ','2020-09-15',2,'Tv',2,'Led Tv',2,'Burak Can','Nas')

select * from tbl_zimmet

update tbl_zimmet set zimmet_ad='Demirbaþ',zimmet_tarih='2020-06-13',kategori_id=3,kategori_ad='Bilgisayar',urunid=3,urunad='Laptop',perid=3,perad='Muharrem',persoyad='Albayrakoðlu' where zimmet_id=6
delete tbl_zimmet where zimmet_id=6

select * from tbl_zimmet

