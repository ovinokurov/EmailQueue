CREATE TABLE [dbo].[ApiKey] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [OrganizationId] BIGINT           NOT NULL,
    [ApiKey]         UNIQUEIDENTIFIER NOT NULL,
    [DeletedDate]    DATETIME         NULL,
    [CreatedDate]    DATETIME         NOT NULL,
    CONSTRAINT [PK_ApiKey] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApiKey_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id])
);

