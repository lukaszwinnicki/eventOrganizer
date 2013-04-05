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
    [Name]        NVARCHAR (500) NULL,
    [When]        DATETIME       NULL,
    [Duration]    TIME (7)       NULL,
    [Country]     NVARCHAR (250) NULL,
    [City]        NVARCHAR (250) NULL,
    [Street]      NVARCHAR (250) NULL,
    [HouseNumber] NVARCHAR (50)  NULL,
    [GroupId]     INT            NULL,
    [UserId]      INT            NULL,
    [Description] TEXT           NULL,
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
    [PhotoUrl] NVARCHAR (350) NULL,
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