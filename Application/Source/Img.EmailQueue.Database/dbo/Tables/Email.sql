CREATE TABLE [dbo].[Email] (
    [Id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [MessageId]    BIGINT        NULL,
    [EmailAddress] VARCHAR (255) NOT NULL,
    [IsSender]     BIT           NOT NULL,
    [IsReciever]   BIT           NOT NULL,
    [isBcc]        BIT           NULL,
    [isCc]         BIT           NULL,
    CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Email_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id])
);

