USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetSearchResultsPersonalUsers')
DROP PROCEDURE [spGetSearchResultsPersonalUsers]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSearchResultsPersonalUsers]
	 (@IsAllUsers BIT,
	 @SearchQuery NVARCHAR(MAX),
	 @Take INT,
	 @Skip INT)
        AS
        BEGIN

		IF (@IsAllUsers = 0)
		    SELECT TOP 3
				UD.UserDetailId,
				UD.UserId,
				UD.FirstName,
				UD.LastName,
				UD.ProfileImage,
				UD.ProfileCover,
				UD.Region,
				UD.Specialization,
				uD.UserBio,
				UD.ConnectionsCount,
				UD.CountryId,
				UD.Gender,
				UD.StateId,
				UD.CreatedBy,
				UD.CreatedDate,
				UD.ModifiedBy,
				UD.ModifiedDate
				FROM UserDetails UD
				WHERE UD.FirstName LIKE '%'+@SearchQuery+'%'
					OR UD.FirstName + Ud.LastName LIKE '%'+@SearchQuery+'%'
					OR UD.LastName LIKE '%'+@SearchQuery+'%'
					OR UD.UserBio LIKE '%'+@SearchQuery+'%'
					OR UD.Specialization LIKE '%'+@SearchQuery+'%'
		ELSE
		SELECT
				UD.UserDetailId,
				UD.UserId,
				UD.FirstName,
				UD.LastName,
				UD.ProfileImage,
				UD.ProfileCover,
				UD.Region,
				UD.Specialization,
				uD.UserBio,
				UD.ConnectionsCount,
				UD.CountryId,
				UD.Gender,
				UD.StateId,
				UD.CreatedBy,
				UD.CreatedDate,
				UD.ModifiedBy,
				UD.ModifiedDate
				FROM UserDetails UD
				WHERE UD.FirstName LIKE '%'+@SearchQuery+'%'
					OR UD.FirstName + Ud.LastName LIKE '%'+@SearchQuery+'%'
					OR UD.LastName LIKE '%'+@SearchQuery+'%'
					OR UD.UserBio LIKE '%'+@SearchQuery+'%'
					OR UD.Specialization LIKE '%'+@SearchQuery+'%'
				ORDER BY CreatedDate DESC
				OFFSET @Skip ROWS
				FETCH NEXT @Take ROWS ONLY
		END

GO