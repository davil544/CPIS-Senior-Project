/****** This script is used to initialize a SQL database to work with this site ******/

/****** Object:  Table [dbo].[CreditCards]    Script Date: 5/10/2024 11:02:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nvarchar](50) NOT NULL,
	[ExpirationDate] [nvarchar](19) NOT NULL,
	[CVV] [nvarchar](50) NOT NULL,
	[CardOwner] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CreditCards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 5/10/2024 11:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Sender] [nvarchar](100) NOT NULL,
	[Recipient] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](100) NULL,
	[Message] [nvarchar](max) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_AdminMessages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 5/10/2024 11:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Summary] [nvarchar](max) NULL,
	[ReleaseYear] [nvarchar](4) NULL,
	[Genre] [nvarchar](50) NULL,
	[MPA_Rating] [nvarchar](9) NULL,
	[Poster] [varbinary](max) NULL,
	[TheaterID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Showcases]    Script Date: 5/10/2024 11:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Showcases](
	[ShowcaseID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[TheaterID] [nvarchar](50) NOT NULL,
	[TimeSlot] [nvarchar](50) NOT NULL,
	[TicketPrice] [float] NULL,
 CONSTRAINT [PK_Showcases] PRIMARY KEY CLUSTERED 
(
	[ShowcaseID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteRatings]    Script Date: 5/10/2024 11:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteRatings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[customerID] [nvarchar](50) NOT NULL,
	[rating] [int] NOT NULL,
 CONSTRAINT [PK_SiteRatings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 5/10/2024 11:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Purchaser] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TheaterID] [nvarchar](50) NOT NULL,
	[MovieID] [int] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/10/2024 11:02:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nchar](2) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[Hours] [nvarchar](17) NULL,
	[TicketPrice] [float] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_Users] FOREIGN KEY([CardOwner])
REFERENCES [dbo].[Users] ([Username])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_Users]
GO
ALTER TABLE [dbo].[Showcases]  WITH CHECK ADD  CONSTRAINT [FK_Showcases_Movies] FOREIGN KEY([ShowcaseID])
REFERENCES [dbo].[Movies] ([ID])
GO
ALTER TABLE [dbo].[Showcases] CHECK CONSTRAINT [FK_Showcases_Movies]
GO
ALTER TABLE [dbo].[Showcases]  WITH CHECK ADD  CONSTRAINT [FK_Showcases_Theaters] FOREIGN KEY([TheaterID])
REFERENCES [dbo].[Users] ([Username])
GO
ALTER TABLE [dbo].[Showcases] CHECK CONSTRAINT [FK_Showcases_Theaters]
GO
