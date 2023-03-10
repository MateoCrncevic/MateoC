USE [AdventureWorksOBP]
GO
/****** Object:  StoredProcedure [dbo].[CreateOrUpdatePotKategorija]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CreateOrUpdatePotKategorija]
@IdPotkategorija int,
@KategorijaId int,
@Naziv nvarchar(50)
as
begin
if @IdPotkategorija is not null begin
	update Potkategorija 
		set KategorijaId=@KategorijaID, Naziv=@Naziv
			where IDPotkategorija=@IdPotkategorija 
end
else 
	insert into Potkategorija values (@KategorijaId,@Naziv)
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteCategory]
@IdKategorija int
as
delete from Kategorija where IDKategorija=@IdKategorija
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteProduct]
@IdProduct int
as

delete from Proizvod where Proizvod.IDProizvod=@IdProduct
GO
/****** Object:  StoredProcedure [dbo].[DeleteSubCategory]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE proc [dbo].[DeleteSubCategory]
 @IDPotkategorija int
 as

  Update Proizvod set PotkategorijaID=null where PotkategorijaID=@IDPotkategorija
 Delete from Potkategorija where IDPotkategorija=@IDPotkategorija
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomers]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllCustomers]
as

select* from Kupac
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCategories]
as
select* from Kategorija
GO
/****** Object:  StoredProcedure [dbo].[GetCountries]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCountries]
as

select* from Drzava
GO
/****** Object:  StoredProcedure [dbo].[GetCountry]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCountry]
@DrzavaId nvarchar(50)
as
select* from Drzava where Drzava.IDDrzava=@DrzavaId
GO
/****** Object:  StoredProcedure [dbo].[GetCustomer]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCustomer] 
@IdKupac int 
as

begin
Select k.*,g.Naziv ,g.DrzavaID	
from Kupac as k join Grad as g on k.GradID=g.IDGrad
	where IDKupac=@IdKupac
end
GO
/****** Object:  StoredProcedure [dbo].[GetCustomersBills]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCustomersBills]
@IDKupac int
as

select* 
from Racun
where racun.KupacID=@IDKupac
GO
/****** Object:  StoredProcedure [dbo].[GetFilteredCustomers]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFilteredCustomers]
@townID int
as

select* 
from Kupac as k 
where k.GradID=@townID
GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetProducts]
as
select* from Proizvod
GO
/****** Object:  StoredProcedure [dbo].[GetSubCategories]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetSubCategories]
as
select*
from Potkategorija
GO
/****** Object:  StoredProcedure [dbo].[GetTown]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTown]
@IdGrad int

as 

select*
from Grad
where grad.IDGrad=@IdGrad
GO
/****** Object:  StoredProcedure [dbo].[GetTowns]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTowns]
@drzavaId int
as
select *
from Grad where DrzavaID=@drzavaId order by Naziv
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsertCategory]
@Naziv nvarchar(50)
as
Insert into Kategorija values(@Naziv)
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[InsertProduct]
@Naziv nvarchar(50),
@BrojProizvoda nvarchar(50),
@Boja nvarchar(50),
@MinimalnaKolicinaNaSkladistu smallint,
@CijenaBezPdv decimal,
@PotkategorijaID int
as

Insert into Proizvod values (@Naziv,@BrojProizvoda,@Boja,@MinimalnaKolicinaNaSkladistu,@CijenaBezPdv,@PotkategorijaID)
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertStudent]
	@IDStudent int OUTPUT, 
	@Ime nvarchar(50), 
	@Prezime nvarchar(50), 
	@JMBAG char(11)
AS
INSERT INTO Student (Ime, Prezime, JMBAG) VALUES (@Ime, @Prezime, @JMBAG)
SET @IDStudent = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[InsertSubCategory]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[InsertSubCategory]
 @Naziv nvarchar(50),
 @KategorijaID int
 as
 Insert into Potkategorija values(@KategorijaID,@Naziv)
GO
/****** Object:  StoredProcedure [dbo].[ReadOrDeletePotKategorija]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReadOrDeletePotKategorija]
@IdPotkategorija int,
@IsDelete bit
as
begin
if @IsDelete=1 begin
	delete from Potkategorija
		where IDPotkategorija=@IdPotkategorija
end
else 
	select* from Potkategorija
		where IDPotkategorija=@IdPotkategorija
end		
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCategory]
@IDKategorija int,
@Naziv nvarchar(50)
as

Update Kategorija set Naziv=@Naziv where IDKategorija=@IDKategorija
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateCustomer]
@id int,
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(50),
	@telefon nvarchar(25),
	@gradID int
as


update Kupac set Ime=@ime, Prezime=@prezime, Email=@email, Telefon=@telefon, GradID=@gradID where IDKupac=@id 

GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[UpdateProduct]
@IDProizvod int,
@Naziv nvarchar(50),
@BrojProizvoda nvarchar(50),
@Boja nvarchar(50),
@MinimalnaKolicinaNaSkladistu smallint,
@CijenaBezPdv decimal,
@PotkategorijaID int
as

Update Proizvod set Proizvod.Naziv=@Naziv,Proizvod.BrojProizvoda=@BrojProizvoda,
Proizvod.Boja=@Boja,Proizvod.MinimalnaKolicinaNaSkladistu=@MinimalnaKolicinaNaSkladistu,
Proizvod.CijenaBezPdv=Convert(decimal,Cast(@CijenaBezPdv as money)), Proizvod.PotkategorijaID=@PotkategorijaID
where Proizvod.IDProizvod=@IDProizvod
GO
/****** Object:  StoredProcedure [dbo].[UpdateSubCategory]    Script Date: 14.9.2021. 22:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateSubCategory]
@IDPotKategorija int,
@Naziv nvarchar(50),
@KategorijaID nvarchar(50)
as
 Update Potkategorija set  KategorijaID=@KategorijaID ,Naziv=@Naziv where IDPotkategorija=@IDPotKategorija

GO


create table UserData(

IDUser int primary key identity,
Email nvarchar(50) not null,
Nickname nvarchar(50) not null,
Passwrd nvarchar(50) not null,

)

go

insert into UserData([Email],[Nickname],[Passwrd])
values ('mateocrncevic@gmail.com','mateo','mateo')


go

create proc GetLogins
as
select *
from UserData

go

create proc RegisterUser
@email nvarchar(50),@nickname nvarchar(50), @pwd nvarchar(50)
as

if(not exists (select * from UserData where Email = @email and Passwrd = @pwd))
	begin
		insert into UserData ([Email],[Nickname],[Passwrd])
		values(@email,@nickname,@pwd);
	end
go
