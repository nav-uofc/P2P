/************************************
* CPSC471 - Group 19
* Project: P2P
* Database creation/seeding
* Developer: Ahmad Naveed Sorush & Lauren Howard
************************************/

USE master;
GO

-- Create the database

CREATE DATABASE P2P
ON 
( NAME = P2P_dat,
    FILENAME = 'C:\P2P\DB\p2pdat.mdf',
    SIZE = 10,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 5 )
LOG ON
( NAME = Sales_log,
    FILENAME = 'C:\P2P\DB\p2plog.ldf',
    SIZE = 5MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 5MB ) ;
GO

-- Switch to the newly created database
USE [P2P];
GO

-- Create schema
CREATE SCHEMA common;
GO

-- Create table
CREATE TABLE [common].[GROUPS](
	[PK_GROUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[GROUP_OWNER_ID] [int] NOT NULL,
	[NAME] [nvarchar](100) NULL,
	[DESCRIPTION] [nvarchar](100) NULL,
	[DT_CLIENT_CAPTURED_DATA] [datetime] NOT NULL,
	[DT_CREATED] [datetime] NOT NULL CONSTRAINT [DF_GROUPS_DT_CREATED]  DEFAULT (getutcdate()),
CONSTRAINT [PK_GROUP_ID] PRIMARY KEY CLUSTERED
(
	[PK_GROUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [common].[GROUPS]  WITH CHECK ADD  CONSTRAINT [FK_GROUPS_USERS] FOREIGN KEY([GROUP_OWNER_ID])
REFERENCES [common].[USERS] ([GROUP_OWNER_ID])
GO

ALTER TABLE [common].[GROUPS] CHECK CONSTRAINT [FK_GROUPS_USERS]
GO

