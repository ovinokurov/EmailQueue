CREATE TABLE [dbo].[QueueMaster] (
    [Id]             UNIQUEIDENTIFIER CONSTRAINT [DF_Queue_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [OrganizationId] BIGINT           NOT NULL,
    [QueuedOrder]    BIGINT           IDENTITY (1, 1) NOT NULL,
    [QueuedDate]     DATETIME         CONSTRAINT [DF_QueueMaster_QueuedDate] DEFAULT (getdate()) NULL,
    [ProcessedDate]  DATETIME         NULL,
    [Attempts]       INT              CONSTRAINT [DF_QueueMaster_Attempts] DEFAULT ((0)) NULL,
    [Retry]          BIT              NOT NULL,
    [MessageId]      BIGINT           NOT NULL,
    [StatusId]       INT              NOT NULL,
    CONSTRAINT [PK_Queue_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QueueMaster_Message] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([Id]),
    CONSTRAINT [FK_QueueMaster_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id]),
    CONSTRAINT [FK_QueueMaster_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id])
);

