use Crowdfunding

begin transaction;

begin try

	if not exists (select * from sys.tables where name = 'User')

	create table [User]
	(
		Id int primary key,
		Name nvarchar(100) not null,
		SecondName nvarchar(100) not null
	);

	if not exists (select * from sys.tables where name = 'Project')

	create table Project
	(
		Id int primary key,
		Name nvarchar(100) not null,
		Description nvarchar(256) default('Description not provided'),
		CreationDate date,
		CreatorID int,
		CategoryID int,
		constraint P_CreatorId foreign key (CreatorId) references [User](id)
	);

	if not exists (select * from sys.tables where name = 'Category')

	create table Category
	(
		Id int primary key,
		Description nvarchar(256) default('Description not provided')
	);

	if not exists (select * from sys.tables where name = 'ProjectCategory')

	create table ProjectCategory
	(
		ProjectId int,
		CategoryId int,
		constraint PC_ProjectId foreign key (ProjectId) references Project(Id) on delete cascade,
		constraint PC_CategoryId foreign key (CategoryId) references Category(Id) on delete cascade
	)

	if not exists (select * from sys.tables where name = 'Comment')

	create table Comment
	(
		Id int primary key,
		Text nvarchar(256) not null,
		Date date,
		UserId int,
		ProjectId int
		constraint C_UserId foreign key (UserId) references [User](id) on delete cascade,
		constraint C_ProjectId foreign key (ProjectId) references Project(id) on delete cascade
	);

	if not exists (select * from sys.tables where name = 'Vote')

	create table Vote
	(
		Id int primary key,
		UserId int not null,
		ProjectId int not null,
		constraint V_UserId foreign key (UserId) references [User](Id),
		constraint V_ProjectId foreign key (ProjectId) references Project(Id)
	);

	commit transaction;

end try
begin catch
	
	rollback transaction;

	print 'Migratiion failed: ' + ERROR_MESSAGE();

end catch;

set ansi_nulls on
go
set quoted_identifier on
go

create procedure CreateProject
	@Id int,
	@Name nvarchar(100),
	@Description nvarchar(256) = null,
	@CreationDate date,
	@CreatorId int,
	@CategoryId int = null
as
begin
	set nocount on

	begin transaction

	begin try

		if(@Id is null)
		begin
			commit transaction
			return
		end

		if((select count(*) from Project where Id = @Id) > 0)
		begin
			commit transaction
			return
		end

		if(@CreatorId is null)
		begin
			commit transaction
			return
		end

		insert into Project(Id, Name, Description, CreationDate, CreatorId, CategoryId)
		values (@Id, @Name, @Description, @CreationDate, @CreatorId, @CategoryId)

		commit transaction

		select * from Project
		where Id = @Id

	end try
	begin catch
	
		rollback transaction

	end catch
end
go

create procedure CreateComment
	@Id int,
	@Text nvarchar(256),
	@Date date,
	@UserId int,
	@ProjectId int
as
begin
	set nocount on

	begin transaction

	begin try

		if(@Id is null)
		begin
			commit transaction
			return
		end

		if((select count(*) from Comment where Id = @Id) > 0)
		begin
			commit transaction
			return
		end

		insert into Comment(Id, Text, Date, UserId, ProjectId)
		values (@Id, @Text, @Date, @UserId, @ProjectId)

		commit transaction

		select * from Comment
		where Id = @Id

	end try
	begin catch
	
		rollback transaction

	end catch
end
go

create procedure GetProjectAllInfo
	@ProjectId int

as
begin
	set nocount on

	begin transaction

	begin try

		if(@ProjectId is null)
		begin
			commit transaction
			return
		end

		select p.*, c.*, u.*, com.*, (select count(*) from Vote where ProjectId = p.Id) as AllVote
		from Project as p
		inner join Category as c
		on p.CategoryID = c.Id
		inner join [User] as u
		on p.CreatorID = u.Id
		inner join Comment as com
		on com.ProjectId = p.Id
		where p.Id = @ProjectId
		order by com.Date

		commit transaction

	end try
	begin catch
	
		rollback transaction

	end catch
end
go

create procedure ProjectPagination
	@CategoryId int,
	@PageNumber int,
	@PageRows int,
	@DateStart date = null,
	@DateEnd date = null

as
begin
	set nocount on

	begin transaction

	begin try

		if(@CategoryId is null)
		begin
			commit transaction
			return
		end

		if(@PageNumber is null and @PageRows is null)
		begin
			commit transaction
			return
		end

		select p.*, c.* 
		from Project as p
		inner join Category as c
		on p.CategoryID = c.Id
		where
			(p.CategoryID = @CategoryId) and
			(@DateStart is null or @DateEnd is null or p.CreationDate between @DateStart and @DateEnd)
		order by p.CreationDate desc
		offset (@PageNumber - 1) * @PageRows rows
		fetch next @PageRows rows only

		commit transaction

	end try
	begin catch
	
		rollback transaction

	end catch
end
go

create procedure AddVote
	@Id int,
	@UserId int,
	@ProjectId int

as
begin
	set nocount on

	begin transaction

	begin try

		if(@UserId is null)
		begin
			commit transaction
			return
		end

		if(@ProjectId is null)
		begin
			commit transaction
			return
		end

		if((select count(*) from Vote where Id = @UserId and Id = @ProjectId) > 0)
		begin
			commit transaction
			return
		end

		insert into Vote(Id, UserId, ProjectId)
		values (@Id, @UserId, @ProjectId)

		commit transaction

		select * from Comment
		where Id = @Id

	end try
	begin catch
	
		rollback transaction

	end catch
end
go

