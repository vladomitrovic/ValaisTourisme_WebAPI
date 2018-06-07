
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2018 16:05:32
-- Generated from EDMX file: C:\Users\Vlado\source\repos\ValaisTourisme_WebAPI\DAL\ValaisBookingModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ValaisBooking];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Booking_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_Booking_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Picture_Room]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Picture] DROP CONSTRAINT [FK_Picture_Room];
GO
IF OBJECT_ID(N'[dbo].[FK_Room_Hotel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_Hotel];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking];
GO
IF OBJECT_ID(N'[dbo].[Hotel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotel];
GO
IF OBJECT_ID(N'[dbo].[Picture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Picture];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Booking'
CREATE TABLE [dbo].[Booking] (
    [IdBooking] int IDENTITY(1,1) NOT NULL,
    [CheckIn] datetime  NOT NULL,
    [CheckOut] datetime  NOT NULL,
    [Firstname] varchar(50)  NOT NULL,
    [Lastname] varchar(50)  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [Date] datetime  NOT NULL,
    [IdRoom] int  NOT NULL
);
GO

-- Creating table 'Hotel'
CREATE TABLE [dbo].[Hotel] (
    [IdHotel] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [Location] nvarchar(50)  NOT NULL,
    [Category] int  NOT NULL,
    [HasWifi] bit  NOT NULL,
    [HasParking] bit  NOT NULL,
    [Phone] varchar(20)  NULL,
    [Email] varchar(50)  NULL,
    [Website] varchar(100)  NULL
);
GO

-- Creating table 'Picture'
CREATE TABLE [dbo].[Picture] (
    [IdPicture] int  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [IdRoom] int  NOT NULL
);
GO

-- Creating table 'Room'
CREATE TABLE [dbo].[Room] (
    [IdRoom] int  NOT NULL,
    [Number] int  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [Type] int  NOT NULL,
    [Price] decimal(5,2)  NOT NULL,
    [HasTV] bit  NOT NULL,
    [HasHairDryer] bit  NOT NULL,
    [IdHotel] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdBooking] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [PK_Booking]
    PRIMARY KEY CLUSTERED ([IdBooking] ASC);
GO

-- Creating primary key on [IdHotel] in table 'Hotel'
ALTER TABLE [dbo].[Hotel]
ADD CONSTRAINT [PK_Hotel]
    PRIMARY KEY CLUSTERED ([IdHotel] ASC);
GO

-- Creating primary key on [IdPicture] in table 'Picture'
ALTER TABLE [dbo].[Picture]
ADD CONSTRAINT [PK_Picture]
    PRIMARY KEY CLUSTERED ([IdPicture] ASC);
GO

-- Creating primary key on [IdRoom] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [PK_Room]
    PRIMARY KEY CLUSTERED ([IdRoom] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdRoom] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [FK_Booking_Room]
    FOREIGN KEY ([IdRoom])
    REFERENCES [dbo].[Room]
        ([IdRoom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Booking_Room'
CREATE INDEX [IX_FK_Booking_Room]
ON [dbo].[Booking]
    ([IdRoom]);
GO

-- Creating foreign key on [IdHotel] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [FK_Room_Hotel]
    FOREIGN KEY ([IdHotel])
    REFERENCES [dbo].[Hotel]
        ([IdHotel])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Room_Hotel'
CREATE INDEX [IX_FK_Room_Hotel]
ON [dbo].[Room]
    ([IdHotel]);
GO

-- Creating foreign key on [IdRoom] in table 'Picture'
ALTER TABLE [dbo].[Picture]
ADD CONSTRAINT [FK_Picture_Room]
    FOREIGN KEY ([IdRoom])
    REFERENCES [dbo].[Room]
        ([IdRoom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Picture_Room'
CREATE INDEX [IX_FK_Picture_Room]
ON [dbo].[Picture]
    ([IdRoom]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------