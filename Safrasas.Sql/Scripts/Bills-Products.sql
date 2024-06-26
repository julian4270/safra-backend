USE [CRUD]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 25/06/2024 5:27:59 p.�m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bills-Products](
	[Id] int IDENTITY(1,1) NOT NULL,
	[Bill_id] Int NULL,
	[Product_id] int NULL,
 CONSTRAINT [PK_Bills-Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
