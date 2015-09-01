CREATE TABLE [dbo].[Organization] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NULL,
    CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED ([Id] ASC)
);

