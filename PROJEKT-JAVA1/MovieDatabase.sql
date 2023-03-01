create database JavaDB

go

use JavaDB

go

create table Login
(
IDLogin int identity primary key,
Username nvarchar(50) not null,
Pass nvarchar(50) not null,
IsAdmin bit  not null
)

go

insert into Login ([Username],[Pass],[IsAdmin])
values ('Admin','123456',1)


go

create proc getLogin
@name nvarchar(50), @pass nvarchar(50)
as
select * from Login
where Username = @name and Pass = @pass

go

create proc registerLogin
@name nvarchar(50), @pass nvarchar(50)
as
insert into Login ([Username],[Pass],[IsAdmin])
values (@name,@pass,0)

go

create table Movie(

IDMovie int identity primary key,
Title nvarchar(50),
ScreeningDate date,
MovieDescription nvarchar(500),
Duration int,
PicturePath nvarchar(250)
)

go

create table Genre(

IDGenre int identity primary key,
Name nvarchar(50)

)

go

create table Person(

IDPerson int identity primary key,
Firstname nvarchar(50),
Lastname nvarchar(50)
)

go

create table MovieGenreRelation(

IDMovieGenreRelation int identity primary key,
MovieID int foreign key references Movie(IDMovie),
GenreID int foreign key references Genre(IDGenre)
)

go

create table MoviePersonRelation(

IDMoviePersonRelation int identity primary key,
MovieID int foreign key references Movie(IDMovie),
PersonID int foreign key references Person(IDPerson),
isDirector bit
)

go

create proc Purge
as

delete from MoviePersonRelation

delete from MovieGenreRelation

delete from Genre

delete from Person

delete from Movie

go

create proc addMovie
@title nvarchar(50), @desc nvarchar(500), @duration int, @date date, @path nvarchar(250), @id int output
as
insert into Movie ([Title],[MovieDescription],[Duration],[ScreeningDate],[PicturePath])
values (@title, @desc, @duration,@date,@path)
set @id = SCOPE_IDENTITY()

go

create proc addGenre
@name nvarchar(50), @id int output
as
if(not exists (select * from Genre where Name = @name))
	begin

	insert into Genre ([Name])
	values (@name)
	set @id = SCOPE_IDENTITY()
	end
else
	begin
	select @id = IDGenre from Genre where Name = @name
	end

go

create proc addMovieGenreRelation
@movieid int, @genreid int
as
insert into MovieGenreRelation([MovieID],[GenreID])
values (@movieid,@genreid)

go

create proc addPerson
@name nvarchar(50),@lname nvarchar(50), @id int output
as
if(not exists (select * from Person where Firstname = @name and Lastname = @lname))
	begin

	insert into Person([Firstname],[Lastname])
	values (@name,@lname)
	set @id = SCOPE_IDENTITY()
	end
else
	begin
	select @id = IDPerson from Person where Firstname = @name and Lastname = @lname
	end

go

create proc addMoviePersonRelation
@movieid int, @personid int, @role bit
as
insert into MoviePersonRelation([MovieID],[PersonID],[IsDirector])
values(@movieid,@personid,@role)

go

create proc getMovies
as
select * from Movie

go

create proc getMovieGenres
@id int
as
select GenreID as IDGenre, g.Name as GenreName from MovieGenreRelation
inner join Genre as g
on IDGenre = GenreID
where MovieID = @id

go

create proc getMoviePeople
@id int
as
select PersonID as IDPerson, Firstname, Lastname, IsDirector from MoviePersonRelation
inner join Person
on IDPerson = PersonID
where MovieID = @id

go

create proc getAllGenres
as
select * from Genre


go

create proc getAllPeople
as
select * from Person

go

create proc getMovie
@id int
as
select * from Movie
where IDMovie = @id

go

create proc deleteMovie
@id int
as

delete from MovieGenreRelation
where MovieID = @id

delete from MoviePersonRelation
where MovieID = @id

delete from Movie
where IDMovie = @id

go

create proc updateMovie
@id int, @title nvarchar(50), @desc nvarchar(500), @duration int, @date date, @path nvarchar(250)
as

delete from MovieGenreRelation
where MovieID = @id

delete from MoviePersonRelation
where MovieID = @id

update Movie
set Title = @title, MovieDescription = @desc, Duration = @duration, ScreeningDate = @date, PicturePath = @path
where IDMovie = @id

go

create proc getGenre
@id int
as
select * from Genre
where IDGenre = @id

go

create proc deleteGenre
@id int
as

delete from MovieGenreRelation
where GenreID = @id

delete from Genre
where IDGenre = @id

go

create proc updateGenre
@id int, @name nvarchar(50)
as
update Genre
set Name = @name
where IDGenre = @id

go

create proc getPerson
@id int
as
select * from Person
where IDPerson = @id

go

create proc deletePerson
@id int
as

delete from MoviePersonRelation
where PersonID = @id

delete from Person
where IDPerson = @id

go

create proc updatePerson
@id int, @name nvarchar(50), @lastname nvarchar(50)
as

update Person
set Firstname = @name, Lastname = @lastname
where IDPerson = @id