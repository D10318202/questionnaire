USE [questionnaire]
GO
INSERT [dbo].[MainQues] ([quesID], [quesTitle], [quesBody], [quesstart], [quesend], [quesstates], [CreateTime]) VALUES (N'b0da424f-f644-4cc6-affa-b1964b9b78c4', N'東京去過哪裡', N'有沒有喜歡去日本東京遊玩的朋友啊', CAST(N'2022-04-24T15:28:00.000' AS DateTime), CAST(N'2022-04-30T15:28:00.000' AS DateTime), 1, CAST(N'2022-04-24T15:28:36.477' AS DateTime))
INSERT [dbo].[MainQues] ([quesID], [quesTitle], [quesBody], [quesstart], [quesend], [quesstates], [CreateTime]) VALUES (N'67e0024b-78a4-45c8-9ed4-e09280e56e6b', N'北海道哪裡好玩', N'有沒有喜歡去北海道遊玩的朋友啊', CAST(N'2022-04-24T15:17:00.000' AS DateTime), CAST(N'2022-04-30T15:17:00.000' AS DateTime), 1, CAST(N'2022-04-24T15:17:36.770' AS DateTime))
GO
INSERT [dbo].[QuestionsDetail] ([quesID], [quesDetailID], [quesDetailTitle], [quesDetailBody], [quesDetailType], [quesDetailMustKeyIn], [quesNumber]) VALUES (N'67e0024b-78a4-45c8-9ed4-e09280e56e6b', N'95369954-598b-4936-8cfc-72646551e7fd', N'北海道哪裡好玩', N'', 2, 1, NULL)
INSERT [dbo].[QuestionsDetail] ([quesID], [quesDetailID], [quesDetailTitle], [quesDetailBody], [quesDetailType], [quesDetailMustKeyIn], [quesNumber]) VALUES (N'b0da424f-f644-4cc6-affa-b1964b9b78c4', N'f5ada18c-0af9-40bd-973d-72f7a6ba0175', N'涉谷區哪裡好玩', N'涉谷;中目黑;代官山', 1, 1, NULL)
GO
