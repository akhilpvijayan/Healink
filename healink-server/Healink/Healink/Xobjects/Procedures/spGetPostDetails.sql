USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetPostDetails')
DROP PROCEDURE [spGetPostDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetPostDetails]
        AS
        BEGIN

		CREATE TABLE #CommentCount (UserId BIGINT, CommentCount INT)

		INSERT INTO #CommentCount
			SELECT 
				UserId,
				COUNT(CommentID) CommentCount
			FROM Comments
			GROUP BY
			UserId

			SELECT 
				P.PostId,
				P.Content,
				P.ContentImage,
				P.LikeCount,
				P.CreatedBy,
				P.CreatedDate,
				P.ModifiedBy,
				P.ModifiedDate,
				CONCAT(UD.FirstName, UD.LastName) FullName,
				UD.ProfileImage ProfileLogo,
				ISNULL(CC.CommentCount, 0) CommentCount
				FROM [HlOperational].dbo.Posts P
				INNER JOIN [HlOperational].dbo.UserDetails UD ON UD.UserId = P.UserId
				LEFT JOIN #CommentCount CC ON CC.UserId = P.UserId
				LEFT JOIN [HLOperational].dbo.Comments C ON C.UserId = P.UserId
			UNION ALL
			SELECT 
				P.PostId,
				P.Content,
				P.ContentImage,
				P.LikeCount,
				P.CreatedBy,
				P.CreatedDate,
				P.ModifiedBy,
				P.ModifiedDate,
				OD.OrganizationName FullName,
				OD.OrganizationLogo ProfileLogo,
				ISNULL(CC.CommentCount, 0) CommentCount
				FROM [HlOperational].dbo.Posts P
				INNER JOIN [HlOperational].dbo.OrganizationDetails OD ON OD.UserId = P.UserId
				LEFT JOIN #CommentCount CC ON CC.UserId = P.UserId
				LEFT JOIN [HLOperational].dbo.Comments C ON C.UserId = P.UserId

			DROP TABLE #CommentCount
        END
GO

