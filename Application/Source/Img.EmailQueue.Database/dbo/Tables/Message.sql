CREATE TABLE [dbo].[Message] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Subject]    VARCHAR (255)  NOT NULL,
    [Body]       VARCHAR (8000) NOT NULL,
    [CC]         VARCHAR (150)  NULL,
    [Bcc]        VARCHAR (150)  NULL,
    [IsBodyHtml] BIT            NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] ASC)
);

