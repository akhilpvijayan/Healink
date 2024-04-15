USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetChatDetails')
DROP PROCEDURE [spGetChatDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetChatDetails]
	 (@UserId BIGINT)
        AS
        BEGIN

		SELECT
			CS.ChatId,
			MS.MessageContent,
			CASE WHEN 
			CS.ReceivedUserId = @UserId
			THEN CS.SendUserId
			ELSE
				CS.ReceivedUserId
			END AS ReceiverId,
			CASE WHEN 
			CS.ReceivedUserId = @UserId
			THEN CS.ReceivedUserId
			ELSE
				CS.SendUserId
			END AS SenderId,
			MS.IsRead,
			MS.Timestamp,
			UD.FirstName,
			UD.LastName,
			UD.ProfileImage
		FROM [HLOperational]..Chats CS
		INNER JOIN [HLOperational]..UserDetails UD ON UD.UserId = 
		CASE WHEN 
			CS.ReceivedUserId = @UserId
			THEN CS.SendUserId
		ELSE
			CS.ReceivedUserId
		END
		INNER JOIN [HLOperational]..Messages MS ON MS.ChatId = CS.ChatId
		INNER JOIN (
			SELECT
				ChatId,
				MAX(Timestamp) AS LatestTimestamp
			FROM [HLOperational]..Messages
			GROUP BY ChatId
		) AS LatestMessage ON MS.ChatId = LatestMessage.ChatId AND MS.Timestamp = LatestMessage.LatestTimestamp
		WHERE CS.SendUserId = @UserId OR CS.ReceivedUserId = @UserId
		ORDER BY MS.Timestamp DESC;

		END
GO

--We use a subquery to get the maximum timestamp (LatestTimestamp) for each ChatId from the Messages table.
--Then, we join this subquery result with the Messages table again on both ChatId and Timestamp to retrieve the latest message for each ChatId.
--Finally, we join the Chats and UserDetails tables to retrieve additional information.