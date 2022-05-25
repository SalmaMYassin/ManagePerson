CREATE TABLE [dbo].[HumanNames] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (300)   NULL,
    [Family]   NVARCHAR (50)    NULL,
    [Given]    NVARCHAR (100)   NULL,
    [PersonId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_HumanNames] PRIMARY KEY CLUSTERED ([Id] ASC)
);

