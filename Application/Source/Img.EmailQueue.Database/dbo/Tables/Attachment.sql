CREATE TABLE [dbo].[Attachment] (
    [Id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [AttachmentUri] VARCHAR (255) NULL,
    [MessageId]     BIGINT        NOT NULL,
    [Type]          VARCHAR (5)   NOT NULL,
    CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attachment_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id])
);

