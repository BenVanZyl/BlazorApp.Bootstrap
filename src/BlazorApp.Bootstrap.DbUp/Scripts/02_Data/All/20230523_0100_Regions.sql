Begin

	Declare @data table ([RegionID] [int] NOT NULL, [RegionDescription] [varchar](50) NOT NULL)
	Insert into @data(RegionID, RegionDescription) Values
		(1,	'Eastern'),                                           
		(2,	'Western'),                                          
		(3,	'Northern'),
		(4,	'Southern')

	SET IDENTITY_INSERT dbo.Region ON

	Insert Into dbo.Region (Id, RegionName, CreatedOn, ModifiedOn)
		Select d.RegionID, d.RegionDescription, GetDate(), GetDate()
		From @data d
		Where NOT EXISTS(
				Select 1 From dbo.Region r Where r.Id = d.RegionID
		)

	SET IDENTITY_INSERT dbo.Region OFF

End