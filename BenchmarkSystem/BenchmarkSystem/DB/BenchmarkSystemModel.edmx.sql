
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2012 11:57:33
-- Generated from EDMX file: C:\Users\Nicolai\Documents\GitHub\BDSA-2012\BenchmarkSystem\BenchmarkSystem\DB\BenchmarkSystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BenchmarkDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DB_userSet'
CREATE TABLE [dbo].[DB_userSet] (
    [userId] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DB_JobSet'
CREATE TABLE [dbo].[DB_JobSet] (
    [jobId] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(max)  NOT NULL,
    [user_userId] int  NOT NULL,
    [submitDate] datetime  NOT NULL
);
GO

-- Creating table 'DB_JobLogSet'
CREATE TABLE [dbo].[DB_JobLogSet] (
    [logId] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(max)  NOT NULL,
    [dateTime] datetime  NOT NULL,
    [job_jobId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [userId] in table 'DB_userSet'
ALTER TABLE [dbo].[DB_userSet]
ADD CONSTRAINT [PK_DB_userSet]
    PRIMARY KEY CLUSTERED ([userId] ASC);
GO

-- Creating primary key on [jobId] in table 'DB_JobSet'
ALTER TABLE [dbo].[DB_JobSet]
ADD CONSTRAINT [PK_DB_JobSet]
    PRIMARY KEY CLUSTERED ([jobId] ASC);
GO

-- Creating primary key on [logId] in table 'DB_JobLogSet'
ALTER TABLE [dbo].[DB_JobLogSet]
ADD CONSTRAINT [PK_DB_JobLogSet]
    PRIMARY KEY CLUSTERED ([logId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_userId] in table 'DB_JobSet'
ALTER TABLE [dbo].[DB_JobSet]
ADD CONSTRAINT [FK_jobuser]
    FOREIGN KEY ([user_userId])
    REFERENCES [dbo].[DB_userSet]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_jobuser'
CREATE INDEX [IX_FK_jobuser]
ON [dbo].[DB_JobSet]
    ([user_userId]);
GO

-- Creating foreign key on [job_jobId] in table 'DB_JobLogSet'
ALTER TABLE [dbo].[DB_JobLogSet]
ADD CONSTRAINT [FK_jobLogjob]
    FOREIGN KEY ([job_jobId])
    REFERENCES [dbo].[DB_JobSet]
        ([jobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_jobLogjob'
CREATE INDEX [IX_FK_jobLogjob]
ON [dbo].[DB_JobLogSet]
    ([job_jobId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------