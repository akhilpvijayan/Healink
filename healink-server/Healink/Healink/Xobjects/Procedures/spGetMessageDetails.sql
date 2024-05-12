USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetMessageDetails')
DROP PROCEDURE [spGetMessageDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetMessageDetails]
	 (@Skip INT,
    @Take INT,
	@ChatId BIGINT,
	@UserId BIGINT)
        AS
        BEGIN

		SELECT *
			FROM (
				SELECT
					@ChatId AS ChatId,
					MS.MessageContent EncryptedMessageContent,
					NULL MessageContent,
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
				ORDER BY MS.Timestamp DESC
				OFFSET @Skip ROWS
				FETCH NEXT @Take ROWS ONLY
			) AS Q
			ORDER BY Timestamp ASC;

		END
GO