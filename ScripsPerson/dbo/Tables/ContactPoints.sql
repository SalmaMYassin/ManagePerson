CREATE TABLE [dbo].[ContactPoints] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [System]    NVARCHAR (20)    NOT NULL,
    [Value]     NVARCHAR (200)   NOT NULL,
    [PersonId]  UNIQUEIDENTIFIER NOT NULL,
    [IsArchive] BIT              NOT NULL,
    CONSTRAINT [PK_ContactPoints] PRIMARY KEY CLUSTERED ([Id] ASC)
);

