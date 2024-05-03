USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetSinglePostDetails')
DROP PROCEDURE [spGetSinglePostDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSinglePostDetails]
	@PostId BIGINT = NULL
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

			IF EXISTS (SELECT UserDetailId FROM [HLOperational]..UserDetails 
							INNER JOIN [HLOperational]..Posts P ON P.PostId = @PostId)
			BEGIN
			SELECT 
				P.PostId,
				P.Content,
				P.ContentImage,
				P.LikeCount,
				P.UserId,
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
				WHERE P.PostId = @PostId
			END
			ELSE
			BEGIN
			SELECT 
				P.PostId,
				P.Content,
				P.ContentImage,
				P.LikeCount,
				P.UserId,
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
				WHERE P.PostId = @PostId
			END
			
			DROP TABLE #CommentCount
        END
GO

