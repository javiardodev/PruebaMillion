IF DB_ID('$(MSSQL_DB)') IS NOT NULL
  set noexec on

CREATE DATABASE $(MSSQL_DB);
GO

USE $(MSSQL_DB);
GO


EXEC('CREATE SCHEMA reo')
EXEC sp_addextendedproperty 
	@name = N'MS_Description', @value = 'Owner''s transactions schema',
	@level0type = N'Schema',   @level0name = 'reo'
GO

EXEC('CREATE SCHEMA rep')
EXEC sp_addextendedproperty 
	@name = N'MS_Description', @value = 'Properties transactions schema',
	@level0type = N'Schema',   @level0name = 'rep'
GO

EXEC('CREATE SCHEMA res')
EXEC sp_addextendedproperty 
	@name = N'MS_Description', @value = 'Security transactions schema',
	@level0type = N'Schema',   @level0name = 'res'
GO

EXEC('CREATE SCHEMA rel')
EXEC sp_addextendedproperty 
	@name = N'MS_Description', @value = 'Logger transactions schema',
	@level0type = N'Schema',   @level0name = 'rel'
GO

CREATE LOGIN $(MSSQL_USER) WITH PASSWORD = '$(MSSQL_PASSWORD)'
GO

CREATE USER $(MSSQL_USER) FOR LOGIN $(MSSQL_USER) WITH DEFAULT_SCHEMA=[res]
GO

ALTER ROLE db_owner ADD MEMBER $(MSSQL_USER)
GO
	
IF(NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Owner')) 
BEGIN
	CREATE TABLE reo.Owner(
		IdOwner INT IDENTITY(1,1) NOT NULL,
		[Name] VARCHAR(50) NOT NULL,
		[Address] VARCHAR(50) NOT NULL,
		Photo VARCHAR(255) NULL,
		Birthday DATETIME DEFAULT '1900-01-01' NULL,
		IsDeleted BIT DEFAULT 0 NOT NULL,
		CreatedAt DATETIME DEFAULT '1900-01-01 00:00:00' NOT NULL,
		UpdatedAt DATETIME NULL,
		CONSTRAINT IdOwner_pk PRIMARY KEY CLUSTERED (IdOwner)
	);

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Main table for owner data',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner'
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'IdOwner';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Deacription name',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'Name';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Description address',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'Address';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Picture for recognize',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'Photo';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Date of birthday',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'Birthday';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Exists data',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'IsDeleted';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry date',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'CreatedAt';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Modify date',
		@level0type = N'Schema',   @level0name = 'reo',
		@level1type = N'Table',    @level1name = 'Owner',
		@level2type = N'Column',   @level2name = 'UpdatedAt';
END

IF(NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Property')) 
BEGIN
	CREATE TABLE rep.Property(
		IdProperty INT IDENTITY(1,1) NOT NULL,
		[Name] VARCHAR(100) NOT NULL,
		[Address] VARCHAR(50) NOT NULL,
		Price DECIMAL(9,2) DEFAULT 0.00 NOT NULL,
		CodeInternal VARCHAR(20) NOT NULL,
		[Year] INT NOT NULL,
		IsDeleted BIT DEFAULT 0 NOT NULL,
		IdOwner INT NOT NULL,
		CreatedAt DATETIME DEFAULT '1900-01-01 00:00:00' NOT NULL,
		UpdatedAt DATETIME,
		CONSTRAINT IdProperty_pk PRIMARY KEY CLUSTERED (IdProperty),
		CONSTRAINT IdOwner_fk FOREIGN KEY (IdOwner) REFERENCES reo.Owner(IdOwner)
	);

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Main table for property data',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property'
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'IdProperty';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Description name',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'Name';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Description address',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'Address';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Property value',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'Price';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Internal id complementary',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'CodeInternal';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Year of construction',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'Year';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Exists data',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'IsDeleted';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id for table Owner',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'IdOwner';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'CreatedAt';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Modify date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'Property',
		@level2type = N'Column',   @level2name = 'UpdatedAt';
END

IF(NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PropertyImage')) 
BEGIN
	CREATE TABLE rep.PropertyImage(
		IdPropertyImage INT IDENTITY(1,1) NOT NULL,
		[File] VARCHAR(255) NOT NULL,
		[Enabled] BIT DEFAULT 1 NOT NULL,
		IdProperty INT NOT NULL,
		CreatedAt DATETIME DEFAULT GETDATE(),
		UpdatedAt DATETIME,
		CONSTRAINT IdPropertyImage_pk PRIMARY KEY CLUSTERED (IdPropertyImage),
		CONSTRAINT IdProperty_fk FOREIGN KEY (IdProperty) REFERENCES rep.Property(IdProperty)
	);

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Main table for upload property image',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage'
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage',
		@level2type = N'Column',   @level2name = 'IdPropertyImage';

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Description upload path',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage',
		@level2type = N'Column',   @level2name = 'File';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Exists data',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage',
		@level2type = N'Column',   @level2name = 'Enabled';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id for table Property',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage',
		@level2type = N'Column',   @level2name = 'IdProperty';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage',
		@level2type = N'Column',   @level2name = 'CreatedAt';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Modify date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyImage',
		@level2type = N'Column',   @level2name = 'UpdatedAt';
END
	
IF(NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PropertyTrace')) 
BEGIN
	CREATE TABLE rep.PropertyTrace(
		IdPropertyTrace INT IDENTITY(1,1) NOT NULL,
		DateSale DATETIME DEFAULT '1900-01-01 00:00:00' NOT NULL,
		[Name] VARCHAR(50) NOT NULL,
		[Value] DECIMAL(9,2) DEFAULT 0.00 NOT NULL,
		Tax DECIMAL(9,2) DEFAULT 0.00 NOT NULL,
		IdProperty INT NOT NULL,
		CreatedAt DATETIME DEFAULT '1900-01-01 00:00:00' NOT NULL,
		UpdatedAt DATETIME,
		CONSTRAINT IdPropertyTrace_pk PRIMARY KEY CLUSTERED (IdPropertyTrace),
		CONSTRAINT IdProperty_fk2 FOREIGN KEY (IdProperty) REFERENCES rep.Property(IdProperty)
	);

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Main table for registry property trace',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace'

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'IdPropertyTrace';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Sold date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'DateSale';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Description name',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'Name';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Sold value',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'Value';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Sold tax',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'Tax';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id for table property',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'IdProperty';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'CreatedAt';
		
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Modify date',
		@level0type = N'Schema',   @level0name = 'rep',
		@level1type = N'Table',    @level1name = 'PropertyTrace',
		@level2type = N'Column',   @level2name = 'UpdatedAt';
END

IF(NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SecurityUser')) 
BEGIN
	CREATE TABLE res.SecurityUser(
		IdSecurityUser INT IDENTITY(1,1) NOT NULL,
		Username VARCHAR(20) NOT NULL,
		[Password] VARCHAR(255) NOT NULL,
		IsActive BIT DEFAULT 1 NOT NULL,
		CreatedAt DATETIME DEFAULT '1900-01-01 00:00:00' NOT NULL,
		UpdatedAt DATETIME,
		CONSTRAINT IdSecurityUser_pk PRIMARY KEY CLUSTERED (IdSecurityUser)
	);

	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Mainn table for JWT users',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser'
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry id',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser',
		@level2type = N'Column',   @level2name = 'IdSecurityUser';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Description user',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser',
		@level2type = N'Column',   @level2name = 'Username';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'String base-64 encript',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser',
		@level2type = N'Column',   @level2name = 'Password';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Enabled user',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser',
		@level2type = N'Column',   @level2name = 'IsActive';
	
	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Registry date',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser',
		@level2type = N'Column',   @level2name = 'CreatedAt';
		
	EXEC sp_addextendedproperty
		@name = N'MS_Description', @value = 'Modify date',
		@level0type = N'Schema',   @level0name = 'res',
		@level1type = N'Table',    @level1name = 'SecurityUser',
		@level2type = N'Column',   @level2name = 'UpdatedAt';
END

IF(NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LogTransaction')) 
BEGIN
	CREATE TABLE rel.LogTransaction(
		IdLogTransaction INT IDENTITY(1,1) NOT NULL,
		IdRequest VARCHAR(20),
		CodeApp INT NOT NULL,
		Entity VARCHAR(50) NOT NULL,
		Operation VARCHAR(50) NOT NULL,
		Status VARCHAR(10) DEFAULT '' NOT NULL,
		StatusCode INT DEFAULT 0 NOT NULL,
		DataBefore VARCHAR(255) DEFAULT '' NOT NULL,
		DataAfter VARCHAR(255) DEFAULT '' NOT NULL,
		Message VARCHAR(255) DEFAULT '' NOT NULL,
		Exception VARCHAR(255) DEFAULT '' NOT NULL,
		Trace VARCHAR(1000) DEFAULT '' NOT NULL,
		CreatedAt DATETIME DEFAULT '1900-01-01 00:00:00' NOT NULL,
		Url VARCHAR(255) DEFAULT '' NOT NULL,
		CONSTRAINT IdSecurityUser_pk PRIMARY KEY CLUSTERED (IdLogTransaction)
	);


	EXEC sp_addextendedproperty 
		@name = N'MS_Description', @value = 'Main table for log trace',
		@level0type = N'Schema',   @level0name = 'rel',
		@level1type = N'Table',    @level1name = 'LogTransaction'
END