USE [ProjectManagement]
GO
/****** Object:  Table [dbo].[tblParentTask]    Script Date: 2/28/2019 3:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblParentTask](
	[ParentID] [int] IDENTITY(1,1) NOT NULL,
	[ParentTask] [varchar](30) NULL,
 CONSTRAINT [PK_tblParentTask] PRIMARY KEY CLUSTERED 
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProject]    Script Date: 2/28/2019 3:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProject](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](30) NULL,
	[StartDt] [date] NULL,
	[EndDt] [date] NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_tblProject] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTask]    Script Date: 2/28/2019 3:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTask](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[ProjectID] [int] NULL,
	[Task] [varchar](30) NULL,
	[StartDt] [date] NULL,
	[EndDt] [date] NULL,
	[Priority] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblTask] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 2/28/2019 3:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[EmployeeID] [varchar](30) NULL,
	[ProjectID] [int] NULL,
	[TaskID] [int] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblTask]  WITH CHECK ADD  CONSTRAINT [FK_tblTask_tblParentTask_ParentID] FOREIGN KEY([ParentID])
REFERENCES [dbo].[tblParentTask] ([ParentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTask] CHECK CONSTRAINT [FK_tblTask_tblParentTask_ParentID]
GO
ALTER TABLE [dbo].[tblTask]  WITH CHECK ADD  CONSTRAINT [FK_tblTask_tblProject_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[tblProject] ([ProjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTask] CHECK CONSTRAINT [FK_tblTask_tblProject_ProjectID]
GO
ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD  CONSTRAINT [FK_tblUser_tblProject_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[tblProject] ([ProjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblUser] CHECK CONSTRAINT [FK_tblUser_tblProject_ProjectID]
GO
ALTER TABLE [dbo].[tblUser]  WITH CHECK ADD  CONSTRAINT [FK_tblUser_tblTask_TaskID] FOREIGN KEY([TaskID])
REFERENCES [dbo].[tblTask] ([TaskID])
GO
ALTER TABLE [dbo].[tblUser] CHECK CONSTRAINT [FK_tblUser_tblTask_TaskID]
GO
