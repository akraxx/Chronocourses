
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/22/2013 16:45:30
-- Generated from EDMX file: D:\Documents\Visual Studio 2010\Projects\Chronocourses\Chronocourses.DataAccess\Chronocourses.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [chronocourses];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductMarque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_ProductMarque];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shop] DROP CONSTRAINT [FK_ShopAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_ShopEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductTypeProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_ProductTypeProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityProduct_Entity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityProduct] DROP CONSTRAINT [FK_EntityProduct_Entity];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityProduct] DROP CONSTRAINT [FK_EntityProduct_Product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Shop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shop];
GO
IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Entity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Entity];
GO
IF OBJECT_ID(N'[dbo].[TypeProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeProduct];
GO
IF OBJECT_ID(N'[dbo].[EntityProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityProduct];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Price] float  NOT NULL,
    [BrandID] int  NOT NULL,
    [TypeProductID] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Available] bit  NOT NULL
);
GO

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Shop'
CREATE TABLE [dbo].[Shop] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Height] smallint  NOT NULL,
    [Width] smallint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AddressID] int  NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Number] smallint  NOT NULL,
    [ZipCode] int  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Entity'
CREATE TABLE [dbo].[Entity] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ShopID] int  NOT NULL,
    [PositionX] int  NOT NULL,
    [PositionY] int  NOT NULL,
    [Label] nvarchar(max)  NOT NULL,
    [Container] bit  NOT NULL
);
GO

-- Creating table 'TypeProduct'
CREATE TABLE [dbo].[TypeProduct] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Label] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EntityProduct'
CREATE TABLE [dbo].[EntityProduct] (
    [Entity_ID] int  NOT NULL,
    [Product_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Brand'
ALTER TABLE [dbo].[Brand]
ADD CONSTRAINT [PK_Brand]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Shop'
ALTER TABLE [dbo].[Shop]
ADD CONSTRAINT [PK_Shop]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Entity'
ALTER TABLE [dbo].[Entity]
ADD CONSTRAINT [PK_Entity]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TypeProduct'
ALTER TABLE [dbo].[TypeProduct]
ADD CONSTRAINT [PK_TypeProduct]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Entity_ID], [Product_ID] in table 'EntityProduct'
ALTER TABLE [dbo].[EntityProduct]
ADD CONSTRAINT [PK_EntityProduct]
    PRIMARY KEY NONCLUSTERED ([Entity_ID], [Product_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BrandID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_ProductMarque]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[Brand]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMarque'
CREATE INDEX [IX_FK_ProductMarque]
ON [dbo].[Product]
    ([BrandID]);
GO

-- Creating foreign key on [AddressID] in table 'Shop'
ALTER TABLE [dbo].[Shop]
ADD CONSTRAINT [FK_ShopAddress]
    FOREIGN KEY ([AddressID])
    REFERENCES [dbo].[Address]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopAddress'
CREATE INDEX [IX_FK_ShopAddress]
ON [dbo].[Shop]
    ([AddressID]);
GO

-- Creating foreign key on [ShopID] in table 'Entity'
ALTER TABLE [dbo].[Entity]
ADD CONSTRAINT [FK_ShopEntity]
    FOREIGN KEY ([ShopID])
    REFERENCES [dbo].[Shop]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopEntity'
CREATE INDEX [IX_FK_ShopEntity]
ON [dbo].[Entity]
    ([ShopID]);
GO

-- Creating foreign key on [TypeProductID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_ProductTypeProduct]
    FOREIGN KEY ([TypeProductID])
    REFERENCES [dbo].[TypeProduct]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductTypeProduct'
CREATE INDEX [IX_FK_ProductTypeProduct]
ON [dbo].[Product]
    ([TypeProductID]);
GO

-- Creating foreign key on [Entity_ID] in table 'EntityProduct'
ALTER TABLE [dbo].[EntityProduct]
ADD CONSTRAINT [FK_EntityProduct_Entity]
    FOREIGN KEY ([Entity_ID])
    REFERENCES [dbo].[Entity]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Product_ID] in table 'EntityProduct'
ALTER TABLE [dbo].[EntityProduct]
ADD CONSTRAINT [FK_EntityProduct_Product]
    FOREIGN KEY ([Product_ID])
    REFERENCES [dbo].[Product]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityProduct_Product'
CREATE INDEX [IX_FK_EntityProduct_Product]
ON [dbo].[EntityProduct]
    ([Product_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------