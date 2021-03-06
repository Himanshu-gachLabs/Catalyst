USE [master]
GO
/****** Object:  Database [CatalystDB]    Script Date: 6/10/2018 5:27:50 PM ******/
CREATE DATABASE [CatalystDB]
GO
ALTER DATABASE [CatalystDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CatalystDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CatalystDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CatalystDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CatalystDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CatalystDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CatalystDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CatalystDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CatalystDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CatalystDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CatalystDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CatalystDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CatalystDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CatalystDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CatalystDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CatalystDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CatalystDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CatalystDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CatalystDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CatalystDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CatalystDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CatalystDB] SET  MULTI_USER 
GO
ALTER DATABASE [CatalystDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CatalystDB] SET ENCRYPTION ON
GO
ALTER DATABASE [CatalystDB] SET QUERY_STORE = OFF
GO
USE [CatalystDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_ONLINE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ELEVATE_RESUMABLE = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET ISOLATE_SECURITY_POLICY_CARDINALITY = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET OPTIMIZE_FOR_AD_HOC_WORKLOADS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_PROCEDURE_EXECUTION_STATISTICS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_QUERY_EXECUTION_STATISTICS = OFF;
GO
USE [CatalystDB]
GO
/****** Object:  Table [dbo].[Demo]    Script Date: 6/10/2018 5:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demo](
	[ID] [int] NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Answer]    Script Date: 6/10/2018 5:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Answer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NULL,
	[Likes] [int] NULL,
	[Accepted] [int] NULL,
	[Author] [nvarchar](50) NULL,
	[Created] [date] NULL,
	[Mentions] [nvarchar](250) NULL,
	[Answer] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[Dislikes] [int] NULL,
	[LikedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Answer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_AnswerLikes]    Script Date: 6/10/2018 5:27:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AnswerLikes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerID] [int] NULL,
	[UserID] [nchar](50) NULL,
	[IsLiked] [bit] NULL,
 CONSTRAINT [PK_tbl_AnswerLikes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Comment]    Script Date: 6/10/2018 5:27:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NULL,
	[Author] [nvarchar](50) NULL,
	[Created] [date] NULL,
	[Mentions] [nvarchar](250) NULL,
	[Comment] [nchar](500) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Error]    Script Date: 6/10/2018 5:27:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Error](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Method] [nchar](50) NULL,
	[Params] [nchar](1000) NULL,
	[StackTrace] [nchar](500) NULL,
	[Message] [nchar](250) NULL,
	[Source] [nchar](250) NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_tbl_Error] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Question]    Script Date: 6/10/2018 5:27:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](4000) NULL,
	[Likes] [int] NULL,
	[Tags] [nvarchar](250) NULL,
	[Author] [nvarchar](250) NULL,
	[Created] [date] NULL,
	[Mentions] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[LikedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Question] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_QuestionLikes]    Script Date: 6/10/2018 5:27:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_QuestionLikes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NULL,
	[UserID] [nchar](50) NULL,
	[IsLiked] [bit] NULL,
 CONSTRAINT [PK_tbl_QuestionLikes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Tag]    Script Date: 6/10/2018 5:27:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Tag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[UserCount] [int] NULL,
	[IsActive] [bit] NULL,
	[IsPopular] [bit] NULL,
 CONSTRAINT [PK_tbl_Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TagSubscription]    Script Date: 6/10/2018 5:27:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TagSubscription](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NULL,
	[UserID] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_TagSubscription] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Demo] ([ID], [Name]) VALUES (1, N'Ram')
SET IDENTITY_INSERT [dbo].[tbl_Answer] ON 

INSERT [dbo].[tbl_Answer] ([ID], [QuestionID], [Likes], [Accepted], [Author], [Created], [Mentions], [Answer], [IsActive], [Dislikes], [LikedBy]) VALUES (24, 43, 0, 0, N'avinash', CAST(N'2018-06-10' AS Date), N'You and You', N'hdsfkjhkhdf hfhsdhf kfhkhfsd  dshfkhsdfh', 1, NULL, NULL)
INSERT [dbo].[tbl_Answer] ([ID], [QuestionID], [Likes], [Accepted], [Author], [Created], [Mentions], [Answer], [IsActive], [Dislikes], [LikedBy]) VALUES (25, 45, 0, 0, N'avinash', CAST(N'2018-06-10' AS Date), N'You and You', N'jfdlksdjf jflsjdf', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Answer] OFF
SET IDENTITY_INSERT [dbo].[tbl_Comment] ON 

INSERT [dbo].[tbl_Comment] ([ID], [QuestionID], [Author], [Created], [Mentions], [Comment], [IsActive]) VALUES (1, 2, N'Inqalab Zindabad', CAST(N'2018-06-08' AS Date), N'BS', NULL, NULL)
INSERT [dbo].[tbl_Comment] ([ID], [QuestionID], [Author], [Created], [Mentions], [Comment], [IsActive]) VALUES (2, 2, N'Inqalab Zindabad', CAST(N'2018-06-09' AS Date), N'BS', NULL, NULL)
INSERT [dbo].[tbl_Comment] ([ID], [QuestionID], [Author], [Created], [Mentions], [Comment], [IsActive]) VALUES (3, 20, N'SC BOSE', CAST(N'2018-06-09' AS Date), N'You and You', N'Lamba comment                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Comment] OFF
SET IDENTITY_INSERT [dbo].[tbl_Error] ON 

INSERT [dbo].[tbl_Error] ([ID], [Method], [Params], [StackTrace], [Message], [Source], [Created]) VALUES (1, N'Method                                            ', N'Params                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ', N'StackTrace                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', N'Message                                                                                                                                                                                                                                                   ', N'Source                                                                                                                                                                                                                                                    ', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Error] OFF
SET IDENTITY_INSERT [dbo].[tbl_Question] ON 

INSERT [dbo].[tbl_Question] ([ID], [Title], [Description], [Likes], [Tags], [Author], [Created], [Mentions], [IsActive], [LikedBy]) VALUES (43, N'Can we migrate multiple web page using any migration tool?', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 0, N'SharePoint;Azure', N'Pallav Pandey', CAST(N'2018-06-10' AS Date), N'', 1, NULL)
INSERT [dbo].[tbl_Question] ([ID], [Title], [Description], [Likes], [Tags], [Author], [Created], [Mentions], [IsActive], [LikedBy]) VALUES (44, N'Can we migrate multiple web page using any migration tool SharePoint?', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 0, N'SharePoint', N'Avinash Sah', CAST(N'2018-06-10' AS Date), N'', 1, NULL)
INSERT [dbo].[tbl_Question] ([ID], [Title], [Description], [Likes], [Tags], [Author], [Created], [Mentions], [IsActive], [LikedBy]) VALUES (45, N'Can we migrate multiple web page using any migration tool CSOM?', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 0, N'CSOM', N'Avinash Sah', CAST(N'2018-06-10' AS Date), N'', 1, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Question] OFF
SET IDENTITY_INSERT [dbo].[tbl_Tag] ON 

INSERT [dbo].[tbl_Tag] ([ID], [Name], [Description], [UserCount], [IsActive], [IsPopular]) VALUES (1, N'JQ', N'J Q', 0, 1, NULL)
INSERT [dbo].[tbl_Tag] ([ID], [Name], [Description], [UserCount], [IsActive], [IsPopular]) VALUES (2, N'JS', N'J S', 0, 1, NULL)
INSERT [dbo].[tbl_Tag] ([ID], [Name], [Description], [UserCount], [IsActive], [IsPopular]) VALUES (3, N'CSOM', N'C wala SOM', 0, 1, 1)
INSERT [dbo].[tbl_Tag] ([ID], [Name], [Description], [UserCount], [IsActive], [IsPopular]) VALUES (4, N'SharePoint', N'bjb', 0, 1, 1)
INSERT [dbo].[tbl_Tag] ([ID], [Name], [Description], [UserCount], [IsActive], [IsPopular]) VALUES (5, N'Azure', N'ascsa', 0, 1, 1)
SET IDENTITY_INSERT [dbo].[tbl_Tag] OFF
SET IDENTITY_INSERT [dbo].[tbl_TagSubscription] ON 

INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (1, N'SharePoint', N'1234')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (2, N'AZure', N'1234')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (3, N'hello', NULL)
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (4, N'apple', NULL)
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (5, N'banana', NULL)
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (6, N'pineapple', NULL)
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (7, N'grapes', NULL)
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (8, N'apple', N'1234')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (9, N'banana', N'1234')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (10, N'pineapple', N'1234')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (11, N'grapes', N'1234')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (12, N'newtag', N'skduhfkeiufwe')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (13, N'gachlog', N'skduhfkeiufwe')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (14, N'SharePoint', N'skduhfkeiufwe')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (15, N'Azure', N'skduhfkeiufwe')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (16, N'SharePoint', N'skduhfkeiufwe')
INSERT [dbo].[tbl_TagSubscription] ([ID], [TagName], [UserID]) VALUES (17, N'CSOM', N'skduhfkeiufwe')
SET IDENTITY_INSERT [dbo].[tbl_TagSubscription] OFF
ALTER TABLE [dbo].[tbl_Answer]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Answer_tbl_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[tbl_Question] ([ID])
GO
ALTER TABLE [dbo].[tbl_Answer] CHECK CONSTRAINT [FK_tbl_Answer_tbl_Question]
GO
ALTER TABLE [dbo].[tbl_Comment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Comment_tbl_Comment] FOREIGN KEY([ID])
REFERENCES [dbo].[tbl_Comment] ([ID])
GO
ALTER TABLE [dbo].[tbl_Comment] CHECK CONSTRAINT [FK_tbl_Comment_tbl_Comment]
GO
/****** Object:  StoredProcedure [dbo].[stp_DeleteQuestionByQuestionID]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_DeleteQuestionByQuestionID]
	@questID int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    DELETE from tbl_Question
	WHERE [ID] = @questID
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllQuestions]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetAllQuestions]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT questions.*, (SELECT COUNT(*) FROM tbl_Answer answers WHERE answers.QuestionID = questions.ID) 
	AS AnswersCount FROM tbl_Question questions
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllQuestionsByTag]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetAllQuestionsByTag]

	@Tag nvarchar(50) = null
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT questions.*, (SELECT COUNT(*) FROM tbl_Answer answers WHERE answers.QuestionID = questions.ID) 
	AS AnswersCount, (SELECT COUNT(*) FROM tbl_QuestionLikes questionLikes WHERE questionLikes.QuestionID = questions.ID AND questionLikes.IsLiked = 1) 
	AS QuestionLikeCount FROM tbl_Question questions WHERE Tags LIKE IsNull('%'+@Tag+'%', '%')

END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAllTags]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetAllTags]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * from tbl_Tag
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetAnswerByQuestionID]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetAnswerByQuestionID]
	@questID int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT answers.*, (SELECT COUNT(*) 
		FROM tbl_AnswerLikes answerLikes
		WHERE answerLikes.AnswerID = answers.ID AND answerLikes.IsLiked = 1) 
		AS AnswerLikeCount
	FROM tbl_Answer answers
	WHERE [QuestionID] = @questID
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetCommentByQuestionID]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetCommentByQuestionID]
	@questID int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * from tbl_Comment
	WHERE [QuestionID] = @questID
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetPopulartags]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetPopulartags]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * from tbl_Tag WHERE IsPopular = 1
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetQuestionByQuestionID]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetQuestionByQuestionID]
	@questID int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * from tbl_Question
	WHERE [ID] = @questID
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetSubscribedTags]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- [dbo].[stp_GetSubscribedTags] "1234"
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetSubscribedTags]
	@UserID nvarchar(MAX)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * from tbl_TagSubscription tags
	WHERE tags.UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[stp_GetTagsIfPopular]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_GetTagsIfPopular]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT * from tbl_Tag WHERE IsPopular = 1
END
GO
/****** Object:  StoredProcedure [dbo].[stp_LikeAnswer]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_LikeAnswer]
	@AnsID int,
	@LikerID nvarchar(50),
	@LikerName nvarchar(100)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	
    IF EXISTS (SELECT ID FROM tbl_Answer answer WHERE answer.ID = @AnsID)
		BEGIN
		-- Insert statements for procedure here
			UPDATE dbo.tbl_Answer
			SET 
				Likes = Likes +1
				WHERE ID = @AnsID
				return 1;
		END
	ELSE
		return -1;
END
GO
/****** Object:  StoredProcedure [dbo].[stp_LikeQuestion]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_LikeQuestion]
	@QuestID int,
	@LikerID nvarchar(50),
	@LikerName nvarchar(100)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	
    IF EXISTS (SELECT ID FROM tbl_Question question WHERE question.ID = @QuestID)
		BEGIN
		-- Insert statements for procedure here
			UPDATE dbo.tbl_Question
			SET 
				Likes = Likes +1
				WHERE ID = @QuestID
				return 1;
		END
	ELSE
		return -1;
END
GO
/****** Object:  StoredProcedure [dbo].[stp_SetAnswer]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_SetAnswer]

	@QuestionID int,
	@Author nvarchar(50),
	@Mentions nvarchar(250),
	@Answer nvarchar(4000)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO tbl_Answer (QuestionID, Likes, Accepted, Author, Created, Mentions, Answer, IsActive) VALUES (@QuestionID, 0, 0, @Author, GETDATE(), @Mentions, @Answer, 1);
END
GO
/****** Object:  StoredProcedure [dbo].[stp_SetComment]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_SetComment]

	@QuestionID int,
	@Author nvarchar(50),
	@Mentions nvarchar(250),
	@Comment nvarchar(500)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO tbl_Comment (QuestionID, Author, Created, Mentions, Comment, IsActive) VALUES (@QuestionID, @Author, GETDATE(), @Mentions, @Comment, 1);
END


GO
/****** Object:  StoredProcedure [dbo].[stp_SetError]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_SetError]

	@Method nvarchar(50),
	@Params nvarchar(1000),
	@StackTrace nvarchar(500),
	@Message nvarchar(250),
	@Source nvarchar(250)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO tbl_Error (Method, Params, StackTrace, Message, Source) VALUES (@Method, @Params, @StackTrace, @Message, @Source);
END
GO
/****** Object:  StoredProcedure [dbo].[stp_SetQuestion]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_SetQuestion]
	@Title nvarchar(250),
	@Description nvarchar(4000),
	@Tags nvarchar(250),
	@Author nvarchar(250),
	@Mentions nvarchar(250),
	@UserID nvarchar(250)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO tbl_Question (Title, Description, Likes, Tags, Author, Created, Mentions, IsActive) 
	VALUES (@Title, @Description, 0, @Tags, @Author, GETDATE(), @Mentions, 1);

	Insert   into tbl_TagSubscription(TagName,UserID)
SELECT value,@UserID
FROM   STRING_SPLIT (@Tags, ';') 
END
GO
/****** Object:  StoredProcedure [dbo].[stp_SetSubscribedTags]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
Create PROCEDURE [dbo].[stp_SetSubscribedTags]
	@TagName nvarchar(50),
	@UserID nvarchar(500)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO tbl_TagSubscription(TagName, UserID) VALUES (@TagName, @UserID);
END
GO
/****** Object:  StoredProcedure [dbo].[stp_SetTag]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_SetTag]
	@Name nvarchar(50),
	@Description nvarchar(250),
	@IsPopular bit
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    INSERT INTO tbl_Tag (Name, Description, UserCount,IsActive, IsPopular) VALUES (@Name, @Description, 0, 1, @IsPopular);
END
GO
/****** Object:  StoredProcedure [dbo].[stp_UpdateQuestion]    Script Date: 6/10/2018 5:27:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[stp_UpdateQuestion]
	@QuestID int,
	@Title nvarchar(250) = null,
	@Description nvarchar(4000) = null,
	@Likes int = null,
	@Tags nvarchar(250) = null,
	@Author nvarchar(250) = null,
	@Mentions nvarchar(250) = null,
	@IsActive bit = null
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	
    IF EXISTS (SELECT ID FROM tbl_Question question WHERE question.ID = @QuestID)
		BEGIN
		-- Insert statements for procedure here
			UPDATE dbo.tbl_Question
			SET 
				Title = IsNull(@Title, Title),
				Description = IsNull(@Description, Description),
				Likes = IsNull(@Likes, Likes),
				Tags = IsNull(@Tags, Tags),
				Author = IsNull(@Author, Author),
				Mentions = IsNull(@Mentions, Mentions),
				IsActive = IsNull(@IsActive, IsActive)
				WHERE ID = @QuestID
				return 1;
		END
	ELSE
		return -1;
END
GO
USE [master]
GO
ALTER DATABASE [CatalystDB] SET  READ_WRITE 
GO
