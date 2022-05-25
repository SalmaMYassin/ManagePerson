CREATE TABLE [dbo].[Persons] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [Gender]  NVARCHAR (50)    NULL,
    [IsAdult] BIT              NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

