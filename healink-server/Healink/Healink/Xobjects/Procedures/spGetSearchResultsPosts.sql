USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetSearchResultsPosts')
DROP PROCEDURE [spGetSearchResultsPosts]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSearchResultsPosts]
	 (@SearchQuery NVARCHAR(MAX),
	 @UserId BIGINT,
	 @Take INT,
	 @Skip INT)
        AS
        BEGIN

		CREATE TABLE #CommentCount (PostId BIGINT, CommentCount INT)

		INSERT INTO #CommentCount
			SELECT 
				PostId,
				COUNT(CommentID) CommentCount
			FROM Comments
			GROUP BY
			PostId

			SELECT DISTINCT
				P.PostId,
				P.Content,
				P.ContentImage,
				P.LikeCount,
				P.UserId,
				CAST(CASE WHEN LK.UserId = @UserId THEN 1 ELSE 0 END AS BIT) IsLikedByMe,
				P.CreatedBy,
				P.CreatedDate,
				P.ModifiedBy,
				P.ModifiedDate,
				CONCAT(UD.FirstName, UD.LastName) FullName,
				UD.ProfileImage ProfileLogo,
				ISNULL(CC.CommentCount, 0) CommentCount
				FROM [HlOperational].dbo.Posts P
				INNER JOIN [HlOperational].dbo.UserDetails UD ON UD.UserId = P.UserId
				LEFT JOIN [HlOperational].dbo.Likes LK ON LK.PostId = P.PostId
				LEFT JOIN #CommentCount CC ON CC.PostId = P.PostId
				LEFT JOIN [HLOperational].dbo.Comments C ON C.UserId = P.UserId
				WHERE P.Content LIKE '%'+@SearchQuery+'%'
			UNION ALL
			SELECT DISTINCT
				P.PostId,
				P.Content,
				P.ContentImage,
				P.LikeCount,
				P.UserId,
				CAST(CASE WHEN LK.UserId = @UserId THEN 1 ELSE 0 END AS BIT) IsLikedByMe,
				P.CreatedBy,
				P.CreatedDate,
				P.ModifiedBy,
				P.ModifiedDate,
				OD.OrganizationName FullName,
				OD.OrganizationLogo ProfileLogo,
				ISNULL(CC.CommentCount, 0) CommentCount
				FROM [HlOperational].dbo.Posts P
				INNER JOIN [HlOperational].dbo.OrganizationDetails OD ON OD.UserId = P.UserId
				LEFT JOIN [HlOperational].dbo.Likes LK ON LK.PostId = P.PostId
				LEFT JOIN #CommentCount CC ON CC.PostId = P.PostId
				LEFT JOIN [HLOperational].dbo.Comments C ON C.UserId = P.UserId
				WHERE P.Content LIKE '%'+@SearchQuery+'%'

				ORDER BY CreatedDate DESC
				OFFSET @Skip ROWS
				FETCH NEXT @Take ROWS ONLY

		DROP TABLE #CommentCount
		END

GO