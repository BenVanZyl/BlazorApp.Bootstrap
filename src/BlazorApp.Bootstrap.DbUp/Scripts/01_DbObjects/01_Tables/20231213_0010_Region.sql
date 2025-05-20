IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Region') AND type in (N'U'))
BEGIN
	CREATE TABLE dbo.Region
	(
		Id bigint Identity NOT NULL,
		RegionName varchar(50) NOT NULL,
		CreatedOn	datetime NOT NULL,
		ModifiedOn	datetime NOT NULL,
		
		CONSTRAINT PK_Region PRIMARY KEY NONCLUSTERED 
		(
			Id ASC
		)
	)
END