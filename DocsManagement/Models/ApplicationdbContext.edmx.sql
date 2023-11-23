create database DocumentsDB



-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/20/2023 22:52:48
-- Generated from EDMX file: C:\Users\Sandrine\Desktop\projet 2\bitbucket\DocsManagement\Models\ApplicationdbContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DocumentsDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Agreement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agreement];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Agreements'
CREATE TABLE [dbo].[Agreements] (
    [RegistrationNomer] int  NOT NULL,
    [RegistrationData] datetime  NOT NULL,
    [TypeDocument] nvarchar(50)  NOT NULL,
    [StateDocument] nvarchar(50)  NOT NULL,
    [TypeAgreement] nvarchar(255)  NOT NULL,
    [DeadlineAgreement] datetime  NOT NULL,
    [Conractor] nvarchar(255)  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [CreatedUser] nvarchar(255)  NOT NULL,
    [SignedUser] nvarchar(255)  NOT NULL,
    [NumberSheets] int  NULL,
    [Summary] nvarchar(400)  NULL,
    [FileName] nvarchar(max)  NULL,
    [FileType] nvarchar(50)  NULL,
    [FileContent] varbinary(max)  NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [ID] int  NOT NULL,
    [Sender] nvarchar(255)  NOT NULL,
    [Reciever] nvarchar(255)  NOT NULL,
    [Message1] nvarchar(max)  NOT NULL,
    [FileName] nvarchar(max)  NULL,
    [FileType] nvarchar(50)  NULL,
    [FileContent] varbinary(max)  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [RegistrationNomer] int  NOT NULL,
    [RegistrationData] datetime  NOT NULL,
    [TypeDocument] nvarchar(50)  NOT NULL,
    [StateDocument] nvarchar(50)  NOT NULL,
    [CreatedUser] nvarchar(255)  NOT NULL,
    [SignedUser] nvarchar(255)  NOT NULL,
    [NumberSheets] int  NULL,
    [Summary] nvarchar(max)  NULL,
    [FileName] nvarchar(max)  NULL,
    [FileType] nvarchar(50)  NULL,
    [FileContent] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RegistrationNomer] in table 'Agreements'
ALTER TABLE [dbo].[Agreements]
ADD CONSTRAINT [PK_Agreements]
    PRIMARY KEY CLUSTERED ([RegistrationNomer] ASC);
GO

-- Creating primary key on [ID] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RegistrationNomer] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([RegistrationNomer] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------