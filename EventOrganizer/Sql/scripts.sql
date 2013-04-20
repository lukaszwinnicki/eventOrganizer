DROP TABLE [dbo].[UsersEvents]
DROP TABLE [dbo].[UsersGroups]
DROP TABLE [dbo].[Comments]
DROP TABLE [dbo].[Events]
DROP TABLE [dbo].[Groups]
DROP TABLE [dbo].[Users]


CREATE TABLE [dbo].[Comments] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Message] NVARCHAR (MAX) NULL,
    [EventId] INT            NULL,
    [UserId]  INT            NULL,
    [UpdatedAt] DATETIME NULL DEFAULT getdate(), 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Events] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (64)  NOT NULL,
    [StartDate]   DATETIME       NOT NULL,
    [EndDate]     DATETIME       NULL,
    [Address]     NVARCHAR (255) NULL,
    [GroupId]     INT            NOT NULL,
    [Description] TEXT           NULL,
    [PhotoUrl]    NVARCHAR (350) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Groups] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250)  NULL,
    [Description] NVARCHAR (2000) NULL,
    [OwnerId]     INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Email]    NVARCHAR (50)  NULL,
    [Password] NVARCHAR (50)  NULL,
    [Name]     NVARCHAR (50)  NULL,
    [Surname]  NVARCHAR (50)  NULL,
    [PhotoUrl]  NVARCHAR (350) NULL,
    [ThumbnailUrl] NVARCHAR (350) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UsersEvents] (
    [UserId]  INT NOT NULL,
    [EventId] INT NOT NULL
);

CREATE TABLE [dbo].[UsersGroups] (
    [UserId]  INT NOT NULL,
    [GroupId] INT NOT NULL
);

GO
ALTER TABLE [dbo].[Users]
    ADD [ThumbnailUrl] NVARCHAR (350) NULL;

GO
ALTER TABLE [dbo].[Events]
    ADD [PhotoUrl] NVARCHAR (350) NULL;