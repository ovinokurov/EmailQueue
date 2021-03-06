USE [master]
GO
/****** Object:  Database [EmailQueue]    Script Date: 7/16/2015 10:45:27 AM ******/
CREATE DATABASE [EmailQueue] ON  PRIMARY 
( NAME = N'EmailQueue', FILENAME = N'C:\SQLServerDataFiles\EmailQueue.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmailQueue_log', FILENAME = N'C:\SQLServerLogFiles\EmailQueue_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmailQueue] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmailQueue].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmailQueue] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmailQueue] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmailQueue] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmailQueue] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmailQueue] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmailQueue] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmailQueue] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmailQueue] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmailQueue] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmailQueue] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmailQueue] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmailQueue] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmailQueue] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmailQueue] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmailQueue] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmailQueue] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmailQueue] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmailQueue] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmailQueue] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmailQueue] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmailQueue] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmailQueue] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmailQueue] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmailQueue] SET  MULTI_USER 
GO
ALTER DATABASE [EmailQueue] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmailQueue] SET DB_CHAINING OFF 
GO
USE [EmailQueue]
GO
/****** Object:  User [WMEENT\svc_OMSQLMonitor]    Script Date: 7/16/2015 10:45:28 AM ******/
CREATE USER [WMEENT\svc_OMSQLMonitor] FOR LOGIN [WMEENT\svc_OMSQLMonitor] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [WMEENT\astepanian]    Script Date: 7/16/2015 10:45:28 AM ******/
CREATE USER [WMEENT\astepanian] FOR LOGIN [WMEENT\astepanian] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [WMEENT\svc_OMSQLMonitor]
GO
/****** Object:  Table [dbo].[ApiKey]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiKey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [bigint] NOT NULL,
	[ApiKey] [uniqueidentifier] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ApiKey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attachment]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attachment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AttachmentUri] [varchar](255) NULL,
	[MessageId] [bigint] NOT NULL,
	[Type] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Email]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageId] [bigint] NULL,
	[EmailAddress] [varchar](255) NOT NULL,
	[IsSender] [bit] NOT NULL,
	[IsReciever] [bit] NOT NULL,
	[isBcc] [bit] NULL,
	[isCc] [bit] NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Message]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](255) NOT NULL,
	[Body] [varchar](8000) NOT NULL,
	[CC] [varchar](150) NULL,
	[Bcc] [varchar](150) NULL,
	[IsBodyHtml] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QueueArchive]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueueArchive](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[QueueId] [uniqueidentifier] NULL,
	[OrganizationId] [bigint] NULL,
	[QueueOrder] [bigint] NULL,
	[QueuedDate] [datetime] NULL,
	[ProcessedDate] [datetime] NULL,
	[Attempts] [int] NULL,
	[Retry] [bit] NULL,
	[MessageId] [bigint] NULL,
	[StatusId] [int] NULL,
	[DeliveredDate] [datetime] NULL,
 CONSTRAINT [PK_QueueLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QueueMaster]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueueMaster](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Queue_Id]  DEFAULT (newid()),
	[OrganizationId] [bigint] NOT NULL,
	[QueuedOrder] [bigint] IDENTITY(1,1) NOT NULL,
	[QueuedDate] [datetime] NULL CONSTRAINT [DF_QueueMaster_QueuedDate]  DEFAULT (getdate()),
	[ProcessedDate] [datetime] NULL,
	[Attempts] [int] NULL CONSTRAINT [DF_QueueMaster_Attempts]  DEFAULT ((0)),
	[Retry] [bit] NOT NULL,
	[MessageId] [bigint] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Queue_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 7/16/2015 10:45:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ApiKey]  WITH CHECK ADD  CONSTRAINT [FK_ApiKey_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[ApiKey] CHECK CONSTRAINT [FK_ApiKey_Organization]
GO
ALTER TABLE [dbo].[Attachment]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Attachment] CHECK CONSTRAINT [FK_Attachment_Message]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Message]
GO
ALTER TABLE [dbo].[QueueArchive]  WITH CHECK ADD  CONSTRAINT [FK_QueueArchive_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[QueueArchive] CHECK CONSTRAINT [FK_QueueArchive_Message]
GO
ALTER TABLE [dbo].[QueueArchive]  WITH CHECK ADD  CONSTRAINT [FK_QueueArchive_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[QueueArchive] CHECK CONSTRAINT [FK_QueueArchive_Organization]
GO
ALTER TABLE [dbo].[QueueArchive]  WITH CHECK ADD  CONSTRAINT [FK_QueueArchive_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[QueueArchive] CHECK CONSTRAINT [FK_QueueArchive_Status]
GO
ALTER TABLE [dbo].[QueueMaster]  WITH CHECK ADD  CONSTRAINT [FK_QueueMaster_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([Id])
GO
ALTER TABLE [dbo].[QueueMaster] CHECK CONSTRAINT [FK_QueueMaster_Message]
GO
ALTER TABLE [dbo].[QueueMaster]  WITH CHECK ADD  CONSTRAINT [FK_QueueMaster_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[QueueMaster] CHECK CONSTRAINT [FK_QueueMaster_Organization]
GO
ALTER TABLE [dbo].[QueueMaster]  WITH CHECK ADD  CONSTRAINT [FK_QueueMaster_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[QueueMaster] CHECK CONSTRAINT [FK_QueueMaster_Status]
GO
USE [master]
GO
ALTER DATABASE [EmailQueue] SET  READ_WRITE 
GO
