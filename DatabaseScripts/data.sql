SET IDENTITY_INSERT [dbo].[Assignee] ON
INSERT INTO [dbo].[Assignee] ([Id], [Name], [Email]) VALUES (1, N'Garry Smith', N'garry@issues.com')
INSERT INTO [dbo].[Assignee] ([Id], [Name], [Email]) VALUES (2, N'John Davis', N'john@issues.com')
SET IDENTITY_INSERT [dbo].[Assignee] OFF
SET IDENTITY_INSERT [dbo].[IssueReporter] ON
INSERT INTO [dbo].[IssueReporter] ([Id], [Name], [Email]) VALUES (1, N'Frank Hardy', N'frank@issues.com')
INSERT INTO [dbo].[IssueReporter] ([Id], [Name], [Email]) VALUES (2, N'Simon Powell', N'simon@issues.com')
INSERT INTO [dbo].[IssueReporter] ([Id], [Name], [Email]) VALUES (3, N'Chris  Walker', N'chris@issues.com')
SET IDENTITY_INSERT [dbo].[IssueReporter] OFF
SET IDENTITY_INSERT [dbo].[Issue] ON
INSERT INTO [dbo].[Issue] ([Id], [AssigneeId], [IssueReporterId], [ReportedDate], [Content]) VALUES (4, 1, 3, N'2019-12-06 15:09:05', N'The Web API fails for large amount of data > 800MB')
INSERT INTO [dbo].[Issue] ([Id], [AssigneeId], [IssueReporterId], [ReportedDate], [Content]) VALUES (5, 1, 3, N'2019-12-06 15:15:33', N'Page load takes more than 3 mins for dashboard')
SET IDENTITY_INSERT [dbo].[Issue] OFF
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b7ad4355-faac-4b9a-bfc6-78c7d0e5b535', N'admin@trackissues.com', N'ADMIN@TRACKISSUES.COM', N'admin@trackissues.com', N'ADMIN@TRACKISSUES.COM', 1, N'AQAAAAEAACcQAAAAEE43FoRSP81GsG/PBp0P93DEu+3zYORZmlgQHxxZQbaj8t+ooQRZPxAi22hEiDIrFQ==', N'QBAA6RWDHOOFDSU22LEFS2WBKXYLSTMM', N'467dfec2-9769-4340-8cc2-4f685fa0bc68', NULL, 0, 0, NULL, 1, 0)


