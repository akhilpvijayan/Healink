USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetSearchResultsOrganizationalUsers')
DROP PROCEDURE [spGetSearchResultsOrganizationalUsers]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSearchResultsOrganizationalUsers]
	 (@IsAllUsers BIT,
	 @SearchQuery NVARCHAR(MAX),
	 @Take INT,
	 @Skip INT)
        AS
        BEGIN

		IF (@IsAllUsers = 0)
		    SELECT TOP 3
				OD.UserId,
				OD.OrganizationDetailId,
				OD.OrganizationName,
				OD.CountryId,
				OD.OrganizationBio,
				OD.OrganizationLogo,
				OD.OrganizationCover,
				OD.TagLine,
				OD.StateId,
				OD.Region,
				OD.OrganizationWebsite,
				OD.OrganizationSize,
				OD.OrganizationTypeId,
				OD.FollowCount,
				OD.CreatedBy,
				OD.CreatedDate,
				OD.ModifiedBy,
				OD.ModifiedDate
				FROM OrganizationDetails OD
				WHERE OD.OrganizationBio LIKE '%'+@SearchQuery+'%'
					OR OD.OrganizationName LIKE '%'+@SearchQuery+'%'
					OR OD.TagLine LIKE '%'+@SearchQuery+'%'

		ELSE
			SELECT 
				OD.UserId,
				OD.OrganizationDetailId,
				OD.OrganizationName,
				OD.CountryId,
				OD.OrganizationBio,
				OD.OrganizationLogo,
				OD.OrganizationCover,
				OD.TagLine,
				OD.StateId,
				OD.Region,
				OD.OrganizationWebsite,
				OD.OrganizationSize,
				OD.OrganizationTypeId,
				OD.FollowCount,
				OD.CreatedBy,
				OD.CreatedDate,
				OD.ModifiedBy,
				OD.ModifiedDate
				FROM OrganizationDetails OD
				WHERE OD.OrganizationBio LIKE '%'+@SearchQuery+'%'
					OR OD.OrganizationName LIKE '%'+@SearchQuery+'%'
					OR OD.TagLine LIKE '%'+@SearchQuery+'%'
				ORDER BY CreatedDate DESC
				OFFSET @Skip ROWS
				FETCH NEXT @Take ROWS ONLY
		END

GO