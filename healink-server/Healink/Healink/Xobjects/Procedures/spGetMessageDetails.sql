USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetMessageDetails')
DROP PROCEDURE [spGetMessageDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetMessageDetails]
	 (@ChatId BIGINT,
	 @UserId BIGINT)
        AS
        BEGIN

		SELECT
			@ChatId ChatId,
			MS.MessageContent,
			MS.ReceiverId,
			MS.IsRead,
			MS.SenderId,
			MS.Timestamp,
			UD.FirstName,
			UD.LastName,
			UD.ProfileImage
		FROM [HLOperational]..Chats CS
		INNER JOIN [HLOperational]..Messages MS ON MS.ChatId = CS.ChatId
		INNER JOIN UserDetails UD ON UD.UserId =
		CASE WHEN 
			MS.ReceiverId = @UserId
			THEN MS.SenderId
		ELSE
			MS.ReceiverId
		END
		WHERE CS.ChatId = @ChatId
		ORDER BY MS.Timestamp;

		END
GO