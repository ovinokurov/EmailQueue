CREATE TABLE [dbo].[QueueArchive] (
    [Id]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [QueueId]        UNIQUEIDENTIFIER NULL,
    [OrganizationId] BIGINT           NULL,
    [QueueOrder]     BIGINT           NULL,
    [QueuedDate]     DATETIME         NULL,
    [ProcessedDate]  DATETIME         NULL,
    [Attempts]       INT              NULL,
    [Retry]          BIT              NULL,
    [MessageId]      BIGINT           NULL,
    [StatusId]       INT              NULL,
    [DeliveredDate]  DATETIME         NULL,
    CONSTRAINT [PK_QueueLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QueueArchive_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id]),
    CONSTRAINT [FK_QueueArchive_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id]),
    CONSTRAINT [FK_QueueArchive_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id])
);

