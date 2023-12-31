USE [DB_QA]
GO
/****** Object:  User [LSE_QA]    Script Date: 2023-06-19 오후 5:22:02 ******/
CREATE USER [LSE_QA] FOR LOGIN [LSE_QA] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [LSE_QA]
GO
/****** Object:  Table [dbo].[control]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[control](
	[comname] [varchar](50) NOT NULL,
	[combarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ct]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ct](
	[comname] [varchar](50) NOT NULL,
	[combarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__ct__064F9EB31C8D916B] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diode]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diode](
	[ComName] [varchar](50) NOT NULL,
	[ComBarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__Diode__064F9EB39DF8C2E4] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dm]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dm](
	[comname] [varchar](50) NOT NULL,
	[combarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__dm__064F9EB310E1950A] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drive]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drive](
	[comname] [varchar](50) NOT NULL,
	[combarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__Drive__064F9EB359C338F7] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fuse]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fuse](
	[ComName] [varchar](50) NOT NULL,
	[COmbarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__fuse__064F9EB342E4CC99] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[igbt]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[igbt](
	[ComName] [varchar](50) NOT NULL,
	[ComBarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__igbt__064F9EB39ABFF59E] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inverter]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inverter](
	[Inverter] [varchar](50) NOT NULL,
	[Inverter_barcode] [varchar](50) NOT NULL,
	[idInverter] [int] IDENTITY(1,1) NOT NULL,
	[inverterCategory] [int] NOT NULL,
 CONSTRAINT [PK__Inverter__3ACFBA24BABA8899] PRIMARY KEY CLUSTERED 
(
	[idInverter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InverterCategory]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InverterCategory](
	[Inverter_Category] [varchar](50) NOT NULL,
	[IdInverter_Category] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_InverterCategory] PRIMARY KEY CLUSTERED 
(
	[IdInverter_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mainCap]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mainCap](
	[Comname] [varchar](50) NOT NULL,
	[combarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__mainCap__064F9EB388F252ED] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mapping]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mapping](
	[idInverter] [int] NOT NULL,
	[idigbt] [int] NOT NULL,
	[iddiode] [int] NOT NULL,
	[idfuse] [int] NOT NULL,
	[idct] [int] NOT NULL,
	[idmaincap] [int] NOT NULL,
	[iddrive] [int] NOT NULL,
	[idpower] [int] NOT NULL,
	[iddm] [int] NOT NULL,
	[idcontrol] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[power]    Script Date: 2023-06-19 오후 5:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[power](
	[comname] [varchar](50) NOT NULL,
	[combarcode] [varchar](50) NULL,
	[idcom] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__power__064F9EB39A9EA502] PRIMARY KEY CLUSTERED 
(
	[idcom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inverter]  WITH CHECK ADD  CONSTRAINT [fk_Inverter_Category] FOREIGN KEY([inverterCategory])
REFERENCES [dbo].[InverterCategory] ([IdInverter_Category])
GO
ALTER TABLE [dbo].[Inverter] CHECK CONSTRAINT [fk_Inverter_Category]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_control] FOREIGN KEY([idcontrol])
REFERENCES [dbo].[control] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_control]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_ct] FOREIGN KEY([idct])
REFERENCES [dbo].[ct] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_ct]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_diode] FOREIGN KEY([iddiode])
REFERENCES [dbo].[Diode] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_diode]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_dm] FOREIGN KEY([iddm])
REFERENCES [dbo].[dm] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_dm]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_drive] FOREIGN KEY([iddrive])
REFERENCES [dbo].[igbt] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_drive]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_fuse] FOREIGN KEY([idfuse])
REFERENCES [dbo].[fuse] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_fuse]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_igbt] FOREIGN KEY([idigbt])
REFERENCES [dbo].[igbt] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_igbt]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_inverterCategory] FOREIGN KEY([idInverter])
REFERENCES [dbo].[InverterCategory] ([IdInverter_Category])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_inverterCategory]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_maincap] FOREIGN KEY([idmaincap])
REFERENCES [dbo].[mainCap] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_maincap]
GO
ALTER TABLE [dbo].[mapping]  WITH CHECK ADD  CONSTRAINT [FK_power] FOREIGN KEY([idpower])
REFERENCES [dbo].[Drive] ([idcom])
GO
ALTER TABLE [dbo].[mapping] CHECK CONSTRAINT [FK_power]
GO
