Create database [DoAnTotNghiep_ASP]
USE [DoAnTotNghiep_ASP]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Image] [nvarchar](500) NULL,
	[Detail] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Category_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Category_Status]  DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CMT]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CMT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Content_CMT] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_CMT_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_CMT_Status]  DEFAULT ((1)),
	[ID_Product] [bigint] NULL,
	[ID_User] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Phone] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Content] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Feedback_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Feedback_Status]  DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[News]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[News](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Detai_Name] [nvarchar](250) NULL,
	[Content_news] [ntext] NULL,
	[Image] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_NEWS_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_NEWS_Status]  DEFAULT ((1)),
	[ID_Catelogy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order_Details](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 0) NULL CONSTRAINT [DF_ORDER_DETAIL_Price]  DEFAULT ((0)),
	[Note] [nvarchar](250) NULL,
	[Quality] [smallint] NULL CONSTRAINT [DF_ORDER_DETAIL_Quantity]  DEFAULT ((0)),
	[PromotionPrice] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_ORDER_DETAIL_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_ORDER_DETAIL_Status]  DEFAULT ((1)),
	[ID_Order] [bigint] NULL,
	[ID_Size] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name_order] [nvarchar](100) NULL,
	[Type_Ship] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[Note] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
	[ToTal_Money] [decimal](18, 0) NULL CONSTRAINT [DF_ORDER_Price]  DEFAULT ((0)),
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_ORDER_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_ORDER_Status]  DEFAULT ((1)),
	[ID_User] [bigint] NULL,
	[ID_TrangThaiDonHang] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Total_Quality] [int] NULL,
	[Image] [nvarchar](500) NULL,
	[MoreImages] [xml] NULL,
	[Price] [decimal](18, 0) NULL CONSTRAINT [DF_Product_Price]  DEFAULT ((0)),
	[PromotionPrice] [int] NULL,
	[Detail] [ntext] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Product_Status]  DEFAULT ((1)),
	[ID_Catelogy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductSize]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSize](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Size] [varchar](100) NULL,
	[Quality] [int] NULL CONSTRAINT [DF_Product_Detail_Quantity]  DEFAULT ((0)),
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Product_Detail_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Product_Detail_Status]  DEFAULT ((1)),
	[ID_Product] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NULL,
	[Detail] [nvarchar](50) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Role_Status]  DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThaiDonHang]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrangThaiDonHang](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_TrangThaiDonHang_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_TrangThaiDonHang_Status]  DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Image] [nvarchar](500) NULL,
	[Last_Name] [nvarchar](100) NULL,
	[Frist_Name] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_User_Status]  DEFAULT ((1)),
	[ID_Role] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 11/15/2021 10:34:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WishList](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_WishList_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_WishList_Status]  DEFAULT ((1)),
	[ID_Product] [bigint] NULL,
	[ID_User] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Image], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, N'Áo khoác', N'uploads/Category/img/31-12021-11-05-11-13-21.jpg', N'null', CAST(N'2021-11-15 08:10:10.100' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [Image], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (2, N'Áo sơ mi-Polo', N'uploads/Category/img/H21728b-500x5002021-11-05-11-13-33.jpg', N'null', CAST(N'2021-11-15 08:10:10.100' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [Image], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (3, N'Quần Jean', N'uploads/Category/img/300px-Jeans2021-11-05-11-13-43.jpg', N'null', CAST(N'2021-11-15 08:10:10.100' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [Image], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (4, N'Áo Sweater', N'uploads/Category/img/9655904e2ed5c88b91c42021-11-05-11-14-07.jpg', N'null', CAST(N'2021-11-15 08:10:10.100' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [Image], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (5, N'Balo-Túi', N'uploads/Category/img/5e7c169ed486c-55555-1409-15934165322021-11-05-11-14-14.jpg', N'null', CAST(N'2021-11-15 08:10:10.103' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [Image], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (6, N'Ví da', N'uploads/Category/img/Vi-da-bo-lazio-738-lazio-2-300x3002021-11-08-08-45-29.jpg', N'null', CAST(N'2021-11-15 08:10:10.103' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[CMT] ON 

INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (2, NULL, N'san phẩm rất tốt', CAST(N'2021-11-12 08:56:36.003' AS DateTime), N'phungle', NULL, NULL, 1, 1, 6)
INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (3, NULL, N'sản phẩm cực tốt', CAST(N'2021-11-12 08:56:43.717' AS DateTime), N'phungle', NULL, NULL, 1, 1, 6)
INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (4, NULL, N'san phẩm tệ', CAST(N'2021-11-12 08:57:35.863' AS DateTime), N'User2', NULL, NULL, 1, 1, 3)
INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (5, NULL, N'cực tệ', CAST(N'2021-11-12 08:57:41.327' AS DateTime), N'User2', NULL, NULL, 1, 1, 3)
INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (6, NULL, N'san phẩm hay', CAST(N'2021-11-12 08:58:03.723' AS DateTime), N'User2', NULL, NULL, 1, 4, 3)
INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (7, NULL, N'sản phẩm rất hay', CAST(N'2021-11-12 08:58:12.727' AS DateTime), N'User2', NULL, NULL, 1, 4, 3)
INSERT [dbo].[CMT] ([ID], [Name], [Content_CMT], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (10, NULL, N'aaaa', CAST(N'2021-11-14 20:05:20.510' AS DateTime), N'User2', NULL, NULL, 1, 1, 3)
SET IDENTITY_INSERT [dbo].[CMT] OFF
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([ID], [Name], [Phone], [Email], [Title], [Content], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, N'hoa', N'0358655211', N'0306181155@caothang.edu.vn', N'dddddd33', N'qqqqqqqqqqqqq', CAST(N'2021-11-06 22:24:12.963' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Name], [Detai_Name], [Content_news], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (1, N'Có nên mua túi Hermès rẻ hơn nhiều lần từ tội phạm bị bắt?', N'Những chiếc túi xách Birkin được mua lại từ tội phạm thường có giá rẻ hơn 2-3 lần so với thị trường, nhưng không đi kèm chế độ bảo hành hay hoàn trả.', N'Trong bài viết của WWD, một nền tảng phụ của trang đấu giá thương mại điện tử Trung Quốc liệt kê những loại vật phẩm thu 
được từ các tội phạm bị kết án, bắt giữ trong vụ án vi phạm pháp luật.Theo báo cáo từ nhà chức trách, các hành vi phổ biến nhất trong vụ án là buôn lậu. Đối tượng bị bắt và tịch thu tài sản. Tất cả món đồ đều được đưa vào danh mục đấu giá trong danh sách có hơn 1.200 sản phẩm.
Túi xách Birkin và Kelly của Hermès là những món đồ nhận được sự quan tâm nhiều nhất của người mua hàng.Để nhấn mạnh mức giá chiết khấu, WWD lấy ví dụ chiếc túi Himalayan Birkin được bán với giá 63.729 USD, rẻ hơn gấp nhiều lần khi được bán trên những trang thương mại điện tử khác như Sotheby với con số 139.994 USD vào năm 2019.
Tương tự, mẫu ví dài làm từ da cá sấu được đăng bán với mức giá 6.171 USD, nhưng trên thực tế, sản phẩm lại được định giá hơn 15.000 USD.
Hầu hết sản phẩm đều được chứng nhận hợp pháp song trang đấu giá thương mại điện tử không cam kết sản phẩm là hàng giả hay thật. Thậm chí, các chuyên gia cho rằng người tiêu dùng dễ gặp rủi ro khi mua hàng.
Ngoài ra, các sản phẩm bị tịch thu trong vụ án không được bảo hành hay hoàn trả lại nếu người tiêu dùng cảm thấy có bất cứ lỗi nào trong quá trình sử dụng, bởi mức giá được đăng tải trên trang đấu giá điện tử rẻ hơn 2-3 lần so với mức giá hiện tại ở thị trường.Hồi tháng 5, CNN đưa tin các cửa hàng bán Birkin cho biết mẫu túi đang có mức giá cao kỷ lục. Nhà đấu giá Christies nhận định một trong 2 chiếc túi xách bán chạy nhất trong lịch sử là Birkin làm bằng da cá sấu.
Jeffrey Berk - giám đốc điều hành của Privé Porter (đại lý bán lẻ túi Birkin) - cho biết: Mua túi Birkin không giống như đi du lịch, mua nhà hay xe. Đôi khi, các khách hàng có rất nhiều tiền mặt và muốn dùng đến nó.
Sasha Skoda - người đứng đầu bộ phận thời trang nữ của The RealReal - chia sẻ: Có vẻ trong thời gian ở nhà, nhu cầu của mọi người với túi xách có giá trị cao rất mạnh mẽ. Doanh số các sản phẩm của Hermès đã tăng 1/3 so với năm trước. Trong đó, túi xách Birkin là một trong những món phụ kiện được săn đón nhiều nhất.', N'uploads/New/img/z2905083663934_97436e2cdb525159a3f91366e201060c_12021-11-05-01-16-10.jpg', CAST(N'2021-11-15 08:10:10.143' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[News] ([ID], [Name], [Detai_Name], [Content_news], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (2, N'CÒN TRẺ, ĐỪNG NGẠI XÁCH BALO LÊN VÀ ĐI', N'Mỗi chặng đường là một thử thách đối với chúng ta, chờ đợi chúng ta chinh phục nó và cũng tự khám phá chính mình.', N'Du lịch giúp ta tích góp được nhiều trải nghiệm thú vị
Thành phố bạn đang sống dù có rộng lớn đến mấy cũng tựa như một căn phòng khổng lồ, gò bó bởi bốn bức tường. 
Bước ra khỏi căn phòng ấy, bạn sẽ biết được mình bỏ lỡ rất nhiều điều. Bạn sẽ nhận ra khí hậu mỗi vùng miền khác nhau thế nào, thức ăn đặc sản ở đó là món gì, có hợp khẩu vị của bạn hay không. Và đặc biệt bạn sẽ biết thêm nhiều nền văn hóa khác nhau cùng nếp sống sinh hoạt của người dân ở đó ra sao. 
Ở mỗi chuyến du lịch, bạn sẽ học được nhiều kinh nghiệm sống hơn, không còn bị động trong thế giới nhỏ bé của mình. Quan trọng hơn là bạn sẽ tích góp được rất nhiều mối quan hệ. Biết đâu trong tương lai gần, lại có “sợi dây” duyên phận nào đó kết nối bạn với họ thì sao. Cuộc sống vốn dĩ là tổ hợp của những căng thẳng, mệt mỏi áp lên vai bạn. Vậy tại sao sau những bộn bề đó, bạn không thử cất hết vào một góc, xách ba lô lên và đi một chuyến thật xa. 
Ở chuyến đi đó, bạn có thể thoải mái tắt ngúm điện thoại và bỏ ngoài tai những lời dặn dò của sếp. Một chuyến đi mà bạn chẳng cần mang theo gì ngoài balo và một cái đầu rỗng. Nếu bạn có đủ kinh phí, hãy đi lâu và xa, còn không một nơi gần và ngắn cũng là một ý kiến không tồi. Miễn là sau chuyến đi, bạn có thể nạp đủ năng lượng tích cực để chiến tiếp với cuộc sống ngoài kia. 
Tự do tận hưởng cuộc sống, làm những gì mình thích, đến những nơi mình muốn đi chẳng phải là sự xoa dịu tâm hồn mạnh mẽ nhất sao?Không ngạc nhiên khi các công ty, tổ chức luôn có vài đợt du lịch thường niên nhằm gắn kết nhân viên lại gần nhau hơn. Giúp mọi người nạp thêm “enzim” hạnh phúc để đạt kết quả tốt hơn trong công việc. 
Không những các công ty, bạn có nhận thấy những chuyến du lịch hoặc những buổi cắm trại ít tiếng cùng gia đình cũng khiến bạn yêu thương họ nhiều hơn không? Vì khi đó, chúng ta “vứt” đi bận rộn ở ngoài, trong mắt chỉ có những người mà ta yêu thương. Cùng họ chuẩn bị mọi thứ, rồi cùng nhau ăn uống, chụp hình, kể cho nhau nghe những câu chuyện trong thời gian vừa qua. Đó dường như là liều thuốc an thần mạnh nhất cho sự mệt mỏi của chúng ta. ', N'uploads/New/img/z2901189222043_edbbc1ff3e45fa7f6c2d788a3f76e5c2_12021-11-05-01-16-20.jpg', CAST(N'2021-11-15 08:10:10.147' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[News] ([ID], [Name], [Detai_Name], [Content_news], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (3, N'VÌ SAO NGƯỜI GIÀU CÓ XU HƯỚNG SỬ DỤNG VÍ CẦM TAY?', N'Đối với những người giàu có họ luôn muốn thể hiện mình qua những món đồ thời trang mà họ sử dụng. Chính vì thế họ luôn tìm kiếm những sản phẩm thời trang toát lên được sự đẳng cấp và sự giàu có của họ.', N'Vốn dĩ ví tiền là một phụ kiện thời trang nhỏ gọn và được giấu đi trong túi quần hay những chiếc túi xách (đối với phụ nữ). Chính vì vậy, phát minh ví cầm tay là một bước đột phá, góp phần thay đổi định nghĩa và xu hướng thời trang ở cả nam giới lẫn nữ giới.
Không chỉ nữ giới mới có thể sử dụng những chiếc ví cầm tay hay những loại ví mang kiểu dáng dài, đàn ông cũng có thể làm việc đó.
Lần lượt những mẫu ví cầm tay liên tục được các nhãn hàng thời trang đua nhau phát triển, khoác lên mình muôn hình vạn trạng, từ tối giản đến cầu kỳ.
Dù có hàng vạn thiết kế, nhưng chung quy kiểu dáng của những chiếc ví cầm tay cơ bản đã mang một hình ảnh tinh tế và sang trọng.Không thể phủ nhận, nam giới khi mặc lên mình một bộ outfit gọn gàng, thanh lịch đi cùng một chiếc ví cầm tay bao giờ cũng tôn lên vẻ lịch lãm khó diễn tả bằng lời
Mặt khác, chiếc ví cầm tay sang trọng còn là một điểm nhấn rất đặc biệt dành cho cánh mày râu trong những sự kiện quan trọng.
Giờ thì bạn đã hiểu vì sao những người danh tiếng hoặc có địa vị, thu nhập cao thường sẽ có xu hướng chọn ví cầm tay chưa? 
Bởi lẽ đơn giản, nó tương xứng và định nghĩa được với vị thế của họ!Như một lẽ thường tình, bạn sẽ quan sát thói quen, phong cách ăn mặc và tính cách của những người đó để tìm kiếm sự tương đồng (theo mặt tích cực).
Đơn giản khi bạn có những nét tương đồng với họ, cơ hội "lọt vào mắt xanh" của bạn cũng sẽ cao hơn và họ sẽ có suy nghĩ bạn xứng tầm với những dự án hoặc kế hoạch hợp tác sắp tới của họ (nếu có).
Bởi lẽ chúng ta thường sẽ dễ có cảm tình với những người giống mình, có thể là cách nói chuyện, gout ăn mặc hay chung một đam mê nào đó.
Lúc đó, bạn sẽ nhận ra rằng hầu hết những người có địa vị và thu nhập cao đều sử dụng những mẫu ví cầm tay sang trọng, lịch lãm.
Ví cầm tay không chỉ là điểm nhấn của những quý ông, nó còn là một bản tuyên ngôn không chính thức để khẳng định vị thế của người sở hữu.', N'uploads/New/img/ezgif_2_8b4c7dbf0132_12021-11-05-01-16-27.jpg', CAST(N'2021-11-15 08:10:10.147' AS DateTime), NULL, NULL, NULL, 1, 6)
INSERT [dbo].[News] ([ID], [Name], [Detai_Name], [Content_news], [Image], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (4, N'TIÊU CHÍ CHỌN BÓP DA NAM CAO CẤP, ĐẸP, CHẤT LƯỢNG VÀ PHÙ HỢP', N'Rất nhiều người khi chọn mua bóp da nam cao cấp thường bỏ qua hoặc không chú ý đến điều này. Trong khi đó, chất liệu da được sử dụng để làm ví cũng như đường chỉ may bên trong ảnh hưởng lớn đến độ bền cũng như sự sang trọng của sản phẩm.', N'Nếu bạn là người chưa biết cách phân biệt đâu là da thật, đâu là da giả thì hãy mạnh dạn chọn những thương hiệu bóp da có tiếng và mua sắm để nâng cao sự đảm bảo, uy tín.Chọn lựa một chiếc bóp da với chất liệu thật 100% rất quan trọng. Vì đây là yếu tố tiên quyết đến độ bền và tuổi thọ của sản phẩm.
Bạn sẽ không phải lo lắng về việc sử dụng ví vài tháng đã bung chỉ hay nứt da, vì những chiếc bóp da chính hãng sẽ có độ bền lên đến 2-3 năm.Không như xưa, thời trang ngày nay thay đổi đến chóng mặt khi hàng loạt những ý tưởng đột phá trong sản phẩm ra đời mỗi ngày.
Điển hình như bóp da, không chỉ dừng lại ở những thiết kế phổ thông và rập khuôn, lần lượt những mẫu bóp dài, bóp khoá kéo, bóp đựng card ra mắt liên tục.
Nếu không có thói quen mang nhiều tiền mặt khi ra đường và thường thanh toán bằng thẻ, bóp mini hoặc những mẫu cardholder sẽ là sự lựa chọn sáng suốt dành cho bạn.
Không phải ngẫu nhiên mà rất nhiều người khi chọn mua bóp da lại đặt tiêu chí màu sắc lên hàng đầu.
Cũng như trang sức, màu sắc của bóp da cũng cần phải hợp mệnh với người sử dụng - đặc biệt với những người làm những công việc trong lĩnh vực kinh doanh. ', N'uploads/New/img/COACH1_12021-11-05-01-16-33.jpeg', CAST(N'2021-11-15 08:10:10.147' AS DateTime), NULL, NULL, NULL, 1, 6)
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[Order_Details] ON 

INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (1, CAST(300000 AS Decimal(18, 0)), N'Áo Khoác Hoodie Đơn Giản A04', 1, 2, CAST(N'2021-11-15 09:52:29.163' AS DateTime), NULL, CAST(N'2021-11-15 09:52:29.163' AS DateTime), NULL, 1, 1, 3)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (2, CAST(450000 AS Decimal(18, 0)), N'Áo khoác phao màu xanh lá', 1, 50, CAST(N'2021-11-15 09:52:29.167' AS DateTime), NULL, CAST(N'2021-11-15 09:52:29.167' AS DateTime), NULL, 1, 1, 13)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (3, CAST(450000 AS Decimal(18, 0)), N'Áo khoác phao màu xanh lá', 1, 50, CAST(N'2021-11-15 09:52:29.167' AS DateTime), NULL, CAST(N'2021-11-15 09:52:29.167' AS DateTime), NULL, 1, 1, 16)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (4, CAST(320000 AS Decimal(18, 0)), N'Áo Sweater Nam MSW 1004', 1, 2, CAST(N'2021-11-15 09:52:53.083' AS DateTime), NULL, CAST(N'2021-11-15 09:52:53.083' AS DateTime), NULL, 1, 2, 101)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (5, CAST(330000 AS Decimal(18, 0)), N'Áo Sweater Nam MSW 1004', 1, 2, CAST(N'2021-11-15 09:52:53.087' AS DateTime), NULL, CAST(N'2021-11-15 09:52:53.087' AS DateTime), NULL, 1, 2, 88)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (6, CAST(520000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam QN2-KJ1L/19-017', 1, 10, CAST(N'2021-11-15 09:53:21.607' AS DateTime), NULL, CAST(N'2021-11-15 09:53:21.607' AS DateTime), NULL, 1, 3, 22)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (7, CAST(520000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam QN2-KJ1L/19-017', 1, 10, CAST(N'2021-11-15 09:53:21.607' AS DateTime), NULL, CAST(N'2021-11-15 09:53:21.607' AS DateTime), NULL, 1, 3, 24)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (8, CAST(360000 AS Decimal(18, 0)), N'Balo Túi Rút Trượt Nước ABA 6005', 1, 2, CAST(N'2021-11-15 09:53:43.430' AS DateTime), NULL, CAST(N'2021-11-15 09:53:43.430' AS DateTime), NULL, 1, 4, 104)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (9, CAST(100000 AS Decimal(18, 0)), N'Túi Bao Tử In Họa Tiết Summer MBA 1007', 1, 2, CAST(N'2021-11-15 09:53:43.433' AS DateTime), NULL, CAST(N'2021-11-15 09:53:43.433' AS DateTime), NULL, 1, 4, 106)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (10, CAST(320000 AS Decimal(18, 0)), N'Quần Jeans Dài Body Fit Nam MJE 1002', 3, 2, CAST(N'2021-11-15 09:56:21.587' AS DateTime), NULL, CAST(N'2021-11-15 09:56:21.587' AS DateTime), NULL, 1, 5, 75)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (11, CAST(740000 AS Decimal(18, 0)), N'Quần Jean Nam Ngắn MSR 1008', 1, 2, CAST(N'2021-11-15 09:56:21.587' AS DateTime), NULL, CAST(N'2021-11-15 09:56:21.587' AS DateTime), NULL, 1, 5, 68)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (12, CAST(444000 AS Decimal(18, 0)), N'Áo Sweater Nam Stay Together MSW 1006', 1, 2, CAST(N'2021-11-15 09:56:43.067' AS DateTime), NULL, CAST(N'2021-11-15 09:56:43.067' AS DateTime), NULL, 1, 6, 84)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (13, CAST(110000 AS Decimal(18, 0)), N'Áo Sweater Nam Stay Together Cánh Đồng MSW 1005', 1, 2, CAST(N'2021-11-15 09:56:43.067' AS DateTime), NULL, CAST(N'2021-11-15 09:56:43.067' AS DateTime), NULL, 1, 6, 96)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (14, CAST(520000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam QN2-KJ1L/19-017', 1, 10, CAST(N'2021-11-15 09:57:14.137' AS DateTime), NULL, CAST(N'2021-11-15 09:57:14.137' AS DateTime), NULL, 1, 7, 24)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (15, CAST(520000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam QN2-KJ1L/19-017', 1, 10, CAST(N'2021-11-15 09:57:14.137' AS DateTime), NULL, CAST(N'2021-11-15 09:57:14.137' AS DateTime), NULL, 1, 7, 23)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (16, CAST(400000 AS Decimal(18, 0)), N'Áo Khoác Gió Nam BLUE EXCHANGE', 1, 5, CAST(N'2021-11-15 09:57:14.137' AS DateTime), NULL, CAST(N'2021-11-15 09:57:14.137' AS DateTime), NULL, 1, 7, 12)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (17, CAST(250000 AS Decimal(18, 0)), N'Quần Jeans Dài Nam MJL 3015', 1, 2, CAST(N'2021-11-15 09:57:28.560' AS DateTime), NULL, CAST(N'2021-11-15 09:57:28.560' AS DateTime), NULL, 1, 8, 80)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (18, CAST(444000 AS Decimal(18, 0)), N'Áo Sweater Nam Stay Together MSW 1006', 1, 2, CAST(N'2021-11-15 09:58:04.120' AS DateTime), NULL, CAST(N'2021-11-15 09:58:04.120' AS DateTime), NULL, 1, 9, 83)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (19, CAST(220000 AS Decimal(18, 0)), N'Áo Sweater Nam Len Dệt Gân Ngang OSM 1011', 1, 2, CAST(N'2021-11-15 09:58:04.120' AS DateTime), NULL, CAST(N'2021-11-15 09:58:04.120' AS DateTime), NULL, 1, 9, 89)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (20, CAST(110000 AS Decimal(18, 0)), N'Áo Sweater Nam Stay Together Cánh Đồng MSW 1005', 1, 2, CAST(N'2021-11-15 09:58:26.477' AS DateTime), NULL, CAST(N'2021-11-15 09:58:26.477' AS DateTime), NULL, 1, 10, 95)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (21, CAST(330000 AS Decimal(18, 0)), N'Áo Sweater Nam MSW 1004', 1, 2, CAST(N'2021-11-15 09:58:26.477' AS DateTime), NULL, CAST(N'2021-11-15 09:58:26.477' AS DateTime), NULL, 1, 10, 87)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (22, CAST(520000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam QN2-KJ1L/19-017', 1, 10, CAST(N'2021-11-15 09:59:31.240' AS DateTime), NULL, CAST(N'2021-11-15 09:59:31.240' AS DateTime), NULL, 1, 11, 21)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (23, CAST(400000 AS Decimal(18, 0)), N'Áo Khoác Gió Nam BLUE EXCHANGE', 1, 5, CAST(N'2021-11-15 09:59:31.243' AS DateTime), NULL, CAST(N'2021-11-15 09:59:31.243' AS DateTime), NULL, 1, 11, 11)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (24, CAST(700000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam EXCHANGE', 1, 2, CAST(N'2021-11-15 09:59:31.243' AS DateTime), NULL, CAST(N'2021-11-15 09:59:31.243' AS DateTime), NULL, 1, 11, 20)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (25, CAST(330000 AS Decimal(18, 0)), N'Áo Sweater Nam MSW 1004', 1, 2, CAST(N'2021-11-15 10:00:06.187' AS DateTime), NULL, CAST(N'2021-11-15 10:00:06.187' AS DateTime), NULL, 1, 12, 88)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (26, CAST(250000 AS Decimal(18, 0)), N'Quần Jeans Dài Nam MJL 3015', 1, 2, CAST(N'2021-11-15 10:00:41.087' AS DateTime), NULL, CAST(N'2021-11-15 10:00:41.087' AS DateTime), NULL, 1, 13, 79)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (27, CAST(250000 AS Decimal(18, 0)), N'Quần Jeans Dài Nam MJL 3015', 1, 2, CAST(N'2021-11-15 10:00:41.090' AS DateTime), NULL, CAST(N'2021-11-15 10:00:41.090' AS DateTime), NULL, 1, 13, 80)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (28, CAST(700000 AS Decimal(18, 0)), N'Áo Khoác Phao Nam EXCHANGE', 1, 2, CAST(N'2021-11-15 10:01:31.417' AS DateTime), NULL, CAST(N'2021-11-15 10:01:31.417' AS DateTime), NULL, 1, 14, 19)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (29, CAST(200000 AS Decimal(18, 0)), N'Áo Khoác Thun Nam MOK 1012 - Xanh Đen', 1, 3, CAST(N'2021-11-15 10:08:05.477' AS DateTime), NULL, CAST(N'2021-11-15 10:08:05.477' AS DateTime), NULL, 1, 15, 5)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (30, CAST(450000 AS Decimal(18, 0)), N'Áo khoác phao màu xanh lá', 1, 50, CAST(N'2021-11-15 10:13:51.993' AS DateTime), NULL, CAST(N'2021-11-15 10:13:51.993' AS DateTime), NULL, 1, 16, 13)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (31, CAST(740000 AS Decimal(18, 0)), N'Quần Jean Nam Ngắn MSR 1008', 20, 2, CAST(N'2021-11-15 10:18:16.783' AS DateTime), NULL, CAST(N'2021-11-15 10:18:16.783' AS DateTime), NULL, 1, 17, 65)
INSERT [dbo].[Order_Details] ([ID], [Price], [Note], [Quality], [PromotionPrice], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Order], [ID_Size]) VALUES (32, CAST(320000 AS Decimal(18, 0)), N'Quần Jeans Dài Body Fit Nam MJE 1002', 10, 2, CAST(N'2021-11-15 10:22:41.143' AS DateTime), NULL, CAST(N'2021-11-15 10:22:41.143' AS DateTime), NULL, 1, 18, 73)
SET IDENTITY_INSERT [dbo].[Order_Details] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (1, N'Giỏ hàng ngày 11/15/2021 9:52:28 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'23456789', CAST(744000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:03:31.277' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (2, N'Giỏ hàng ngày 11/15/2021 9:52:53 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'23456789', CAST(637000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:03:35.057' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (3, N'Giỏ hàng ngày 11/15/2021 9:53:21 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'23456789', CAST(936000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:03:38.977' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (4, N'Giỏ hàng ngày 11/15/2021 9:53:43 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'23456789', CAST(450800 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:03:43.337' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (5, N'Giỏ hàng ngày 11/15/2021 9:56:21 AMcủa phungle', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0358963244', CAST(1666000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'phungle', CAST(N'2021-11-15 10:03:46.977' AS DateTime), NULL, 1, 6, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (6, N'Giỏ hàng ngày 11/15/2021 9:56:43 AMcủa phungle', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0358963244', CAST(542920 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'phungle', CAST(N'2021-11-15 10:03:50.683' AS DateTime), NULL, 1, 6, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (7, N'Giỏ hàng ngày 11/15/2021 9:57:14 AMcủa phungle', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0358963244', CAST(1316000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'phungle', CAST(N'2021-11-15 10:03:54.430' AS DateTime), NULL, 1, 6, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (8, N'Giỏ hàng ngày 11/15/2021 9:57:28 AMcủa phungle', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0358963244', CAST(245000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'phungle', CAST(N'2021-11-15 10:03:57.987' AS DateTime), NULL, 1, 6, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (9, N'Giỏ hàng ngày 11/15/2021 9:58:04 AMcủa nhatphung', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0258654522', CAST(650720 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'nhatphung', CAST(N'2021-11-15 10:04:01.870' AS DateTime), NULL, 1, 5, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (10, N'Giỏ hàng ngày 11/15/2021 9:58:26 AMcủa nhatphung', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0258654522', CAST(431200 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'nhatphung', CAST(N'2021-11-15 10:04:05.603' AS DateTime), NULL, 1, 5, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (11, N'Giỏ hàng ngày 11/15/2021 9:59:31 AMcủa nhatphung', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0258654522', CAST(1534000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'nhatphung', CAST(N'2021-11-15 10:04:09.300' AS DateTime), NULL, 1, 5, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (12, N'Giỏ hàng ngày 11/15/2021 10:00:06 AMcủa nhatphung', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0258654522', CAST(323400 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'nhatphung', CAST(N'2021-11-15 10:04:12.937' AS DateTime), NULL, 1, 5, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (13, N'Giỏ hàng ngày 11/15/2021 10:00:41 AMcủa nhatle', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0256314477', CAST(490000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'nhatle', CAST(N'2021-11-15 10:04:16.430' AS DateTime), NULL, 1, 4, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (14, N'Giỏ hàng ngày 11/15/2021 10:01:31 AMcủa nhatle', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'0256314477', CAST(686000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'nhatle', CAST(N'2021-11-15 10:04:20.643' AS DateTime), NULL, 1, 4, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (15, N'Giỏ hàng ngày 11/15/2021 10:08:05 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'test', N'23456789', CAST(194000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:09:43.040' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (16, N'Giỏ hàng ngày 11/15/2021 10:13:51 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'dawd', N'23456789', CAST(225000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:18:37.290' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (17, N'Giỏ hàng ngày 11/15/2021 10:18:16 AMcủa User2', N'Giao hàng nhanh', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'dwdw', N'23456789', CAST(14534000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:18:44.450' AS DateTime), NULL, 1, 3, 3)
INSERT [dbo].[Orders] ([ID], [Name_order], [Type_Ship], [Address], [Email], [Note], [Phone], [ToTal_Money], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_User], [ID_TrangThaiDonHang]) VALUES (18, N'Giỏ hàng ngày 11/15/2021 10:22:41 AMcủa User2', N'Giao hàng thường', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'dwd', N'23456789', CAST(3136000 AS Decimal(18, 0)), CAST(N'2021-11-15 00:00:00.000' AS DateTime), N'User2', CAST(N'2021-11-15 10:24:50.410' AS DateTime), NULL, 1, 3, 3)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (1, N'Áo Khoác Hoodie Đơn Giản A04', 300, N'uploads/Product/img/images (3)2021-11-05-12-30-51.jfif', NULL, CAST(300000 AS Decimal(18, 0)), 2, N'Áo Khoác Hoodie Đơn Giản A04 dành cho nam với thiết kế đơn giãn, dễ mặc phù hợp để sử dụng hàng ngày', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (2, N'Áo Khoác Thun Nam MOK 1012 - Xanh Đen', 300, N'uploads/Product/img/31-12021-11-05-12-34-48.jpg', NULL, CAST(200000 AS Decimal(18, 0)), 3, N'Chiếc áo khoác cả cho ngày nắng và ngày mưa, siêu bền, siêu nhẹ.Áo được thiết kế theo xu hướng thời trang hiện đại, sang trọng và cực sành điệu', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (3, N'Áo Khoác Gió Nam BLUE EXCHANGE', 300, N'uploads/Product/img/ao-khoac-gio-nam-cao-cap-20202021-11-05-12-34-55.jpg', NULL, CAST(400000 AS Decimal(18, 0)), 5, N'Chiếc áo khoác gió trong BST Thu Đông của THE BLUES khoe phong cách khỏe khoắn và chút bụi bặm của các chàng trai.', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (4, N'Áo khoác phao màu xanh lá', 300, N'uploads/Product/img/images (1)2021-11-05-12-35-04.jfif', NULL, CAST(450000 AS Decimal(18, 0)), 50, N'Những ai yêu thích sự tươi mới, màu xanh của chồi non đang lên.Chiếc áo phao đến từ thương hiệu THE BLUES ấm áp cho những ngày đông lạnh.', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (5, N'Áo Khoác Phao Nam EXCHANGE', 300, N'uploads/Product/img/images (2)2021-11-05-12-35-12.jfif', NULL, CAST(700000 AS Decimal(18, 0)), 2, N'Vừa đẹp vừa ấm, chiếc áo khoác phao nam THE EXCHANGE màu đen là phong cách lịch lãm và giữ ấm tuyệt vời cho những ngày đông lạnh.', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (6, N'Áo Khoác Phao Nam QN2-KJ1L/19-017', 300, N'uploads/Product/img/images (3)2021-11-05-12-35-20.jfif', NULL, CAST(520000 AS Decimal(18, 0)), 10, N'Sản xuất tại Việt Nam', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (7, N'Áo khoác phao THE BLUES ', 300, N'uploads/Product/img/images2021-11-05-12-35-28.jfif', NULL, CAST(450000 AS Decimal(18, 0)), 50, N'Là chiếc áo không thể thiếu khi đi du lịch vào nơi khí hậu lạnh. Nhất định bạn phải chuẩn bị sẵn cho mỗi người trong gia đình một chiếc áo phao giữ ấm nhé.', NULL, CAST(N'2021-11-15 08:10:10.107' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (8, N'Áo Sơ Mi Nam Denim HK17-MDS01', 300, N'uploads/Product/img/H21728b-500x5002021-11-05-12-35-36.jpg', NULL, CAST(470000 AS Decimal(18, 0)), 2, N'Áo sơ mi denim không thể thiếu trong tủ đồ của các anh.
Từ lâu chiếc áo đã trở thành một trang phục huyền thoại trong làng thời trang nam giới thế giới. Chiếc áo vừa tạo phong cách mạnh mẽ, vừa toát lên sự phóng khoáng trẻ trung của chàng trai hiện đại.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (9, N'Áo Sơ Mi Nam Tay Dài BLUE', 300, N'uploads/Product/img/tải xuống (2)2021-11-05-12-35-42.jfif', NULL, CAST(200000 AS Decimal(18, 0)), 2, N'Áo sơ mi in họa tiết caro của thương hiệu The Blues mang đến nét trẻ trung và thanh lịch cho các chàng trai. Thiết kế kiểu dáng cổ điển phối gam màu mạnh mẽ khẳng định gu thời trang nam tính của bạn.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (10, N'ÁO SƠ MI NAM TAY DÀI HK1-MS19-D134', 300, N'uploads/Product/img/tải xuống (3)2021-11-05-12-35-50.jfif', NULL, CAST(210000 AS Decimal(18, 0)), 2, N'CHIẾC SƠ MI TAY DÀI VỚI MÀU SẮC VÀ HỌA TIẾT THANH LỊCH.SẴN SÀNG LÀM PHONG PHÚ TỦ ĐỒ VÀ HÀI LÒNG CÁC ANH', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (11, N'ÁO SƠ MI NAM TAY NGẮN HK1-MS19-N59R2', 300, N'uploads/Product/img/tải xuống (4)2021-11-05-12-35-55.jfif', NULL, CAST(310000 AS Decimal(18, 0)), 2, N'Người ta nói xu hướng thời trang luôn xoay vòng. Vậy nên chúng tôi mang thời tiền sử trở lại đây. Đừng lo, bạn mặc được mà. Chỉ cần tận hưởng cảm giác thoải mái đến từ chất vải cotton mềm mại của chiếc áo thun adidas này và để cho cây hài kiêm skater và kẻ nổi loạn trong bạn tỏa sáng. Kỷ Jura hợp với bạn đấy chứ.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (12, N'Áo Polo Nam Basic MPO 1008', 300, N'uploads/Product/img/tải xuống (9)2021-11-05-12-41-22.jfif', NULL, CAST(330000 AS Decimal(18, 0)), 2, N'Áo Polo Nam Basic MPO 1008 Tôn lên vẻ nam tính, giúp cánh mày râu tự tin trong mọi hoàn cảnh.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (13, N'Áo Polo Nam Cafe Bo Sọc MPO 3020', 300, N'uploads/Product/img/tải xuống (5)2021-11-05-12-36-02.jfif', NULL, CAST(440000 AS Decimal(18, 0)), 2, N'Áo Polo Nam Cafe Bo Sọc MPO 3020, được sản xuất từ vải sợi cafe, dòng sản phẩm thân thiên với môi trường', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (14, N'Áo Sơ Mi Nam Sọc Tay Dài MSH 3011', 300, N'uploads/Product/img/tải xuống (6)2021-11-05-12-36-14.jfif', NULL, CAST(990000 AS Decimal(18, 0)), 2, N'Style năng động khi phối với các dòng trang phục như quần dài, quần short.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (15, N'Quần Jeans Dài Slim Nam MJE 1008', 300, N'uploads/Product/img/300px-Jeans2021-11-05-12-36-25.jpg', NULL, CAST(88000 AS Decimal(18, 0)), 2, N'Quần Jeans Dài Slim Nam MJE 1008 là 1 item không thể thiếu trong tủ đồ của những chàng trai.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (16, N'Quần Jean Dài Slim Nam MJE 1006', 300, N'uploads/Product/img/tải xuống (16)2021-11-05-12-36-33.jfif', NULL, CAST(770000 AS Decimal(18, 0)), 2, N'Quần Jean Dài Slim Nam MJE 1006 là 1 item không thể thiếu trong tủ đồ của những chàng trai.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (17, N'Quần Jean Nam Ngắn MSR 1008', 300, N'uploads/Product/img/tải xuống (17)2021-11-05-12-36-41.jfif', NULL, CAST(740000 AS Decimal(18, 0)), 2, N'Quần Jean Nam Ngắn MSR 1008 được thiết kế dành cho các chàng trai trẻ trung, phá cách, là item must-have của mỗi bạn nam.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (18, N'Quần Jeans Nam Ngắn MSR 1006', 300, N'uploads/Product/img/tải xuống (18)2021-11-05-12-36-47.jfif', NULL, CAST(410000 AS Decimal(18, 0)), 2, N'Quần Jeans Nam Ngắn MSR 1006 Độ dài ngang gối, lai tưa, được thiết kế dành cho các chàng trai  trẻ trung, phá cách, là item must-have của mỗi bạn nam.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (19, N'Quần Jeans Dài Body Fit Nam MJE 1002', 300, N'uploads/Product/img/tải xuống (14)2021-11-05-12-36-54.jfif', NULL, CAST(320000 AS Decimal(18, 0)), 2, N'Quần Jeans Dài Body Fit Nam MJE 1002 là item thời trang được nhiều bạn nam ưa chuộng trong thời gian gần đây. Phong cách thời trang phóng khoáng, hiện tại thì chắc hẳn không thể thiếu cho mình những mẫu quần jean đẹp như thế này.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (20, N'Quần Jeans Dài Nam MJL 3015', 300, N'uploads/Product/img/tải xuống (13)2021-11-05-12-37-03.jfif', NULL, CAST(250000 AS Decimal(18, 0)), 2, N'Quần Jeans Dài Nam  MJL 3015 là 1 sản phẩm không thể thiếu, đi kèm bên cạnh bộ trang phục của các bạn trai.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (21, N'Áo Sweater Nam Stay Together MSW 1006', 400, N'uploads/Product/img/tải xuống (22)2021-11-05-12-37-14.jfif', NULL, CAST(444000 AS Decimal(18, 0)), 2, N'Áo Sweater Nam Stay Together MSW 1006 Thông điệp “Friends travel stay together” với họa tiết camo cá tính tạo điểm nhấn, là item được yêu thích', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (22, N'Áo Sweater Nam MSW 1004', 300, N'uploads/Product/img/images (6)2021-11-05-12-37-25.jfif', NULL, CAST(330000 AS Decimal(18, 0)), 2, N'Áo Sweater Nam MSW 1004 Couple TX chắc chắn là sản phẩm phải có trong tủ đồ của các chàng trai năng động, cá tính. Form áo oversize đơn giản nhưng cá tính, có thể dể dàng kết hợp với quần, giày,... mà ko sợ bị rối mắt. Chất liệu cotton 100% giúp Áo Sweater Nam Basic MSW 1004 luôn mềm mại, mang lại cảm giác dễ chịu khi mặc.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (23, N'Áo Sweater Nam Len Dệt Gân Ngang OSM 1011', 300, N'uploads/Product/img/images (7)2021-11-05-12-37-31.jfif', NULL, CAST(220000 AS Decimal(18, 0)), 2, N'Áo Sweater Nam Len Dệt Gân Ngang OSM 1011 với bề mặt vải lông mịn màng và ấm áp phù hợp tiết trời thu đông. Áo dệt gân nên rất dễ mặc và phối đồ.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (24, N'Áo Sweater Nam Stay Together Cánh Đồng MSW 1005', 300, N'uploads/Product/img/images (8)2021-11-05-12-37-39.jfif', NULL, CAST(110000 AS Decimal(18, 0)), 2, N'Áo sweater nam Stay Together Cánh đồng MSW 1005 Thông điệp “Friends travel stay together” với họa tiết cánh đồng lúa chín vàng tạo điểm nhấn, là item được yêu thích và sử dụng phổ biến trong giới trẻ, mang hơi hướng thời trang đường phổ trẻ trung và hiện đại.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (25, N'Áo Sweater Nam Len Dệt Gân Ngang OSM 1011', 300, N'uploads/Product/img/tải xuống (1)2021-11-05-12-37-46.jfif', NULL, CAST(440000 AS Decimal(18, 0)), 2, N'Áo Sweater Nam Len Dệt Gân Ngang OSM 1011 với bề mặt vải lông mịn màng và ấm áp phù hợp tiết trời thu đông. Áo dệt gân nên rất dễ mặc và phối đồ.', NULL, CAST(N'2021-11-15 08:10:10.110' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (26, N'Áo Sweater Nam MSW 1004', 300, N'uploads/Product/img/images (5)2021-11-05-12-37-54.jfif', NULL, CAST(320000 AS Decimal(18, 0)), 2, N'Áo Sweater Nam MSW 1004 Couple TX chắc chắn là sản phẩm phải có trong tủ đồ của các chàng trai năng động, cá tính. Form áo oversize đơn giản nhưng cá tính, có thể dể dàng kết hợp với quần, giày,... mà ko sợ bị rối mắt. Chất liệu cotton 100% giúp Áo Sweater Nam Basic MSW 1004 luôn mềm mại, mang lại cảm giác dễ chịu khi mặc.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (27, N'Túi Đeo Chéo In Sogan Phối Lưới MBA 1006', 300, N'uploads/Product/img/tải xuống (23)2021-11-05-12-38-05.jfif', NULL, CAST(120000 AS Decimal(18, 0)), 2, N'Túi Đeo Chéo In Sogan Phối Lưới MBA 1006 Thiết kế thời trang, trẻ trung.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (28, N'Túi Đeo Chéo Unisex MBA 1003', 300, N'uploads/Product/img/tải xuống (24)2021-11-05-12-38-12.jfif', NULL, CAST(110000 AS Decimal(18, 0)), 2, N'Túi đeo chéo Unisex MBA 1003, túi đeo chéo, pocket trong suốt, ép logo, khóa kim loại.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (29, N'Balo Túi Rút Trượt Nước ABA 6005', 300, N'uploads/Product/img/tải xuống (25)2021-11-05-12-38-18.jfif', NULL, CAST(360000 AS Decimal(18, 0)), 2, N'Balo Túi Rút Trượt Nước ABA 6005 là một trong những vật dụng hữu và cũng không kém phần thời trang giúp thể hiện được sự cá tính cho bạn trẻ.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (30, N'Túi Đeo Chéo Trong Suốt MBA 1008', 300, N'uploads/Product/img/tải xuống (26)2021-11-05-12-38-26.jfif', NULL, CAST(410000 AS Decimal(18, 0)), 2, N'Túi Đeo Chéo Trong Suốt MBA 1008 Thiết kế thời trang, trẻ trung.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (31, N'Túi Bao Tử In Họa Tiết Summer MBA 1007', 300, N'uploads/Product/img/tải xuống (27)2021-11-05-12-38-32.jfif', NULL, CAST(100000 AS Decimal(18, 0)), 2, N'Túi Bao Tử In Họa Tiết Summer MBA 1007 họa tiết in cho mùa hè sôi động.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (32, N'Ví Card Feasty', 300, N'uploads/Product/img/tải xuống (28)2021-11-05-12-38-44.jfif', NULL, CAST(100000 AS Decimal(18, 0)), 2, N'Một chiếc ví card cánh gập cơ bản, tối giản nhất, mọi chi tiết thêm vào là sự thừa thãi không cần thiết.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (33, N'Ví Card Mori', 300, N'uploads/Product/img/tải xuống (29)2021-11-05-12-38-50.jfif', NULL, CAST(110000 AS Decimal(18, 0)), 2, N'Khi nét đẹp cổ điển kết hợp cùng thiết kế tinh tế, Ví Card Mori đã ra đời. Với thiết kế nhỏ vừa lòng bàn tay  thì chiếc ví này sẽ giúp bạn bắt đầu làm quen với cuộc sống tối giản.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (34, N'Ví Mini Vintage', 300, N'uploads/Product/img/tải xuống (30)2021-11-05-12-38-57.jfif', NULL, CAST(200000 AS Decimal(18, 0)), 2, N'Thiết kế đơn giản nhằm tạo độ mỏng tối đa, giúp việc bỏ ví vào túi không còn là vấn đề lớn nữa. Sẵn sàng dạo một vòng quanh thành phố với chiếc ví mỏng này.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (35, N'Ví Card Feasty', 300, N'uploads/Product/img/tải xuống (31)2021-11-05-12-39-03.jfif', NULL, CAST(111000 AS Decimal(18, 0)), 2, N'Một chiếc ví card cánh gập cơ bản, tối giản nhất, mọi chi tiết thêm vào là sự thừa thãi không cần thiết', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 6)
INSERT [dbo].[Product] ([ID], [Name], [Total_Quality], [Image], [MoreImages], [Price], [PromotionPrice], [Detail], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Catelogy]) VALUES (36, N'Ví MIB - Ngang', 300, N'uploads/Product/img/tải xuống (32)2021-11-05-12-39-16.jfif', NULL, CAST(300000 AS Decimal(18, 0)), 2, N'Mẫu ví MIB sử dụng loại da sáp nên trong quá trình sử dụng sẽ để lại những vết trầy rất đặc trưng của loại da này.', NULL, CAST(N'2021-11-15 08:10:10.113' AS DateTime), NULL, NULL, NULL, 1, 6)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductSize] ON 

INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (1, N'L', 70, CAST(N'2021-11-15 08:10:10.120' AS DateTime), NULL, CAST(N'2021-11-08 10:49:26.653' AS DateTime), NULL, 1, 1)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (2, N'M', 75, CAST(N'2021-11-15 08:10:10.120' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (3, N'S', 71, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 09:52:29.010' AS DateTime), NULL, 1, 1)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (4, N'XL', 65, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-14 21:55:58.200' AS DateTime), NULL, 1, 1)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (5, N'L', 73, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 10:08:05.327' AS DateTime), NULL, 1, 2)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (6, N'M', 74, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-10 09:28:38.920' AS DateTime), NULL, 1, 2)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (7, N'S', 73, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-14 20:48:28.803' AS DateTime), NULL, 1, 2)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (8, N'XL', 72, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-14 19:20:03.327' AS DateTime), NULL, 1, 2)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (9, N'L', 75, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (10, N'M', 75, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, NULL, NULL, 1, 3)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (11, N'S', 74, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 09:59:31.237' AS DateTime), NULL, 1, 3)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (12, N'XL', 74, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 09:57:14.130' AS DateTime), NULL, 1, 3)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (13, N'L', 73, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 10:13:51.987' AS DateTime), NULL, 1, 4)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (14, N'M', 74, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-07 14:05:41.170' AS DateTime), NULL, 1, 4)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (15, N'S', 75, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, NULL, NULL, 1, 4)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (16, N'XL', 74, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 09:52:29.123' AS DateTime), NULL, 1, 4)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (17, N'L', 75, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (18, N'M', 75, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, NULL, NULL, 1, 5)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (19, N'S', 74, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 10:01:31.413' AS DateTime), NULL, 1, 5)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (20, N'XL', 73, CAST(N'2021-11-15 08:10:10.123' AS DateTime), NULL, CAST(N'2021-11-15 09:59:31.237' AS DateTime), NULL, 1, 5)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (21, N'L', 74, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, CAST(N'2021-11-15 09:59:31.240' AS DateTime), NULL, 1, 6)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (22, N'M', 74, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, CAST(N'2021-11-15 09:53:21.597' AS DateTime), NULL, 1, 6)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (23, N'S', 74, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, CAST(N'2021-11-15 09:57:14.133' AS DateTime), NULL, 1, 6)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (24, N'XL', 73, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, CAST(N'2021-11-15 09:57:14.133' AS DateTime), NULL, 1, 6)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (25, N'L', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 7)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (26, N'M', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 7)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (27, N'S', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 7)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (28, N'XL', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 7)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (29, N'L', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 8)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (30, N'M', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 8)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (31, N'S', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 8)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (32, N'XL', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 8)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (33, N'L', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 9)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (34, N'M', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 9)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (35, N'S', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 9)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (36, N'XL', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 9)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (37, N'L', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 10)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (38, N'M', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 10)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (39, N'S', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 10)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (40, N'XL', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 10)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (41, N'L', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 11)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (42, N'M', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 11)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (43, N'S', 75, CAST(N'2021-11-15 08:10:10.127' AS DateTime), NULL, NULL, NULL, 1, 11)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (44, N'XL', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 11)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (45, N'L', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 12)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (46, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 12)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (47, N'S', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 12)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (48, N'XL', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 12)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (49, N'L', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 13)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (50, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 13)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (51, N'S', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 13)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (52, N'XL', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 13)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (53, N'L', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 14)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (54, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 14)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (55, N'S', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 14)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (56, N'XL', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 14)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (57, N'L', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 15)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (58, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 15)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (59, N'S', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 15)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (60, N'XL', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 15)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (61, N'L', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 16)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (62, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 16)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (63, N'S', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 16)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (64, N'XL', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 16)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (65, N'L', 55, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, CAST(N'2021-11-15 10:18:16.760' AS DateTime), NULL, 1, 17)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (66, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 17)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (67, N'S', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 17)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (68, N'XL', 74, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, CAST(N'2021-11-15 09:56:21.580' AS DateTime), NULL, 1, 17)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (69, N'L', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 18)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (70, N'M', 75, CAST(N'2021-11-15 08:10:10.130' AS DateTime), NULL, NULL, NULL, 1, 18)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (71, N'S', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 18)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (72, N'XL', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 18)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (73, N'L', 65, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 10:22:41.140' AS DateTime), NULL, 1, 19)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (74, N'M', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 19)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (75, N'S', 72, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 09:56:21.583' AS DateTime), NULL, 1, 19)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (76, N'XL', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 19)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (77, N'L', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 20)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (78, N'M', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 20)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (79, N'S', 74, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 10:00:41.083' AS DateTime), NULL, 1, 20)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (80, N'XL', 73, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 10:00:41.087' AS DateTime), NULL, 1, 20)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (81, N'L', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 21)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (82, N'M', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 21)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (83, N'S', 74, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 09:58:04.110' AS DateTime), NULL, 1, 21)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (84, N'XL', 74, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 09:56:43.060' AS DateTime), NULL, 1, 21)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (85, N'L', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 22)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (86, N'M', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 22)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (87, N'S', 73, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 09:58:26.470' AS DateTime), NULL, 1, 22)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (88, N'XL', 72, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 10:00:06.183' AS DateTime), NULL, 1, 22)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (89, N'L', 74, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, CAST(N'2021-11-15 09:58:04.113' AS DateTime), NULL, 1, 23)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (90, N'M', 75, CAST(N'2021-11-15 08:10:10.133' AS DateTime), NULL, NULL, NULL, 1, 23)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (91, N'S', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:32:37.130' AS DateTime), NULL, 1, 23)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (92, N'XL', 72, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:32:37.133' AS DateTime), NULL, 1, 23)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (93, N'L', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:31:28.530' AS DateTime), NULL, 1, 24)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (94, N'M', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 24)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (95, N'S', 73, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-15 09:58:26.473' AS DateTime), NULL, 1, 24)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (96, N'XL', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-15 09:56:43.063' AS DateTime), NULL, 1, 24)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (97, N'L', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 25)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (98, N'M', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 25)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (99, N'S', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 25)
GO
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (100, N'XL', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 25)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (101, N'L', 73, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-15 09:52:53.080' AS DateTime), NULL, 1, 26)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (102, N'nosize', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-14 20:10:01.033' AS DateTime), NULL, 1, 27)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (103, N'nosize', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:33:36.883' AS DateTime), NULL, 1, 28)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (104, N'nosize', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-15 09:53:43.423' AS DateTime), NULL, 1, 29)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (105, N'nosize', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:33:36.883' AS DateTime), NULL, 1, 30)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (106, N'nosize', 73, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-15 09:53:43.427' AS DateTime), NULL, 1, 31)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (107, N'nosize', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 32)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (108, N'nosize', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:29:23.157' AS DateTime), NULL, 1, 33)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (109, N'nosize', 74, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, CAST(N'2021-11-10 09:29:23.160' AS DateTime), NULL, 1, 34)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (110, N'nosize', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 35)
INSERT [dbo].[ProductSize] ([ID], [Size], [Quality], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product]) VALUES (111, N'nosize', 75, CAST(N'2021-11-15 08:10:10.137' AS DateTime), NULL, NULL, NULL, 1, 36)
SET IDENTITY_INSERT [dbo].[ProductSize] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [NameRole], [Detail], [Status]) VALUES (1, N'Admin', N'Quản lý trang web', 1)
INSERT [dbo].[Role] ([ID], [NameRole], [Detail], [Status]) VALUES (2, N'User', N'Khách hàng', 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[TrangThaiDonHang] ON 

INSERT [dbo].[TrangThaiDonHang] ([ID], [Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, N'Chưa duyệt', CAST(N'2021-11-14 19:10:12.140' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TrangThaiDonHang] ([ID], [Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (2, N'Đang giao hàng', CAST(N'2021-11-14 19:10:44.130' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TrangThaiDonHang] ([ID], [Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (3, N'Giao thành công', CAST(N'2021-11-14 19:10:50.540' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[TrangThaiDonHang] ([ID], [Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (4, N'Hủy đơn hàng', CAST(N'2021-11-14 19:10:56.437' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[TrangThaiDonHang] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [Image], [Last_Name], [Frist_Name], [Address], [Email], [Phone], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Role]) VALUES (1, N'Admin', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'admin', N'admin', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'23456789', CAST(N'2021-11-15 08:10:10.140' AS DateTime), NULL, NULL, NULL, 1, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Image], [Last_Name], [Frist_Name], [Address], [Email], [Phone], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Role]) VALUES (3, N'User2', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'Phụng', N'Lê tuấn', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'23456789', CAST(N'2021-11-15 08:10:10.140' AS DateTime), NULL, CAST(N'2021-11-10 09:36:26.360' AS DateTime), NULL, 1, 2)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Image], [Last_Name], [Frist_Name], [Address], [Email], [Phone], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Role]) VALUES (4, N'nhatle', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'Nhật', N'Nguyễn', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'0256314477', CAST(N'2021-11-15 08:11:28.813' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Image], [Last_Name], [Frist_Name], [Address], [Email], [Phone], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Role]) VALUES (5, N'nhatphung', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'Nhật', N'Nguyễn', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'0258654522', CAST(N'2021-11-15 08:18:25.750' AS DateTime), NULL, NULL, NULL, 1, 2)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Image], [Last_Name], [Frist_Name], [Address], [Email], [Phone], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Role]) VALUES (6, N'phungle', N'e10adc3949ba59abbe56e057f20f883e', NULL, N'Lê', N'Phụng', N'Quân bình tân,tphcm', N'0306181155@caothang.edu.vn', N'0358963244', CAST(N'2021-11-06 22:21:49.863' AS DateTime), NULL, NULL, NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[WishList] ON 

INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (1, CAST(N'2021-11-10 09:27:34.330' AS DateTime), N'User2', NULL, NULL, 1, 1, 3)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (2, CAST(N'2021-11-10 09:27:36.283' AS DateTime), N'User2', NULL, NULL, 1, 2, 3)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (3, CAST(N'2021-11-10 09:31:36.880' AS DateTime), N'nhatle', NULL, NULL, 1, 2, 4)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (4, CAST(N'2021-11-10 09:31:38.973' AS DateTime), N'nhatle', NULL, NULL, 1, 3, 4)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (5, CAST(N'2021-11-10 09:31:44.330' AS DateTime), N'nhatle', NULL, NULL, 1, 6, 4)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (6, CAST(N'2021-11-10 09:32:42.003' AS DateTime), N'nhatphung', NULL, NULL, 1, 4, 5)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (7, CAST(N'2021-11-10 09:32:44.170' AS DateTime), N'nhatphung', NULL, NULL, 1, 5, 5)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (8, CAST(N'2021-11-10 09:33:44.233' AS DateTime), N'phungle', NULL, NULL, 1, 22, 6)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (9, CAST(N'2021-11-10 09:33:46.427' AS DateTime), N'phungle', NULL, NULL, 1, 23, 6)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (10, CAST(N'2021-11-10 09:33:48.683' AS DateTime), N'phungle', NULL, NULL, 1, 21, 6)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (11, CAST(N'2021-11-12 08:59:25.927' AS DateTime), N'User2', NULL, NULL, 1, 6, 3)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (13, CAST(N'2021-11-14 20:05:25.833' AS DateTime), N'User2', NULL, NULL, 1, 3, 3)
INSERT [dbo].[WishList] ([ID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status], [ID_Product], [ID_User]) VALUES (15, CAST(N'2021-11-15 09:46:45.500' AS DateTime), N'User2', NULL, NULL, 1, 36, 3)
SET IDENTITY_INSERT [dbo].[WishList] OFF
ALTER TABLE [dbo].[CMT]  WITH CHECK ADD FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[CMT]  WITH CHECK ADD FOREIGN KEY([ID_User])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD FOREIGN KEY([ID_Catelogy])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([ID_Size])
REFERENCES [dbo].[ProductSize] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([ID_TrangThaiDonHang])
REFERENCES [dbo].[TrangThaiDonHang] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([ID_User])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([ID_Catelogy])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[ProductSize]  WITH CHECK ADD FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[WishList]  WITH CHECK ADD FOREIGN KEY([ID_User])
REFERENCES [dbo].[User] ([ID])
GO
