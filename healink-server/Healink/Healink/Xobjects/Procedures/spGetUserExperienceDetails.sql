USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetUserExperienceDetails')
DROP PROCEDURE [spGetUserExperienceDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserExperienceDetails]
		(@UserId BIGINT)
        AS
        BEGIN
		SELECT 
			EX.ExperienceId,
			EX.Title,
			EX.Company,
			EX.Location,
			EX.StartDate,
			EX.EndDate,
			EX.Description,
			EX.CompanyId,
			CAST(CASE WHEN EX.EndDate IS NULL THEN 1 ELSE 0 END AS BIT) AS [Current],
			OD.OrganizationName OrgCompanyName,
			OD.OrganizationLogo CompanyLogo,
			EX.CreatedBy,
			EX.CreatedDate,
			EX.ModifiedBy,
			EX.ModifiedDate
			FROM [HlOperational].dbo.Experiences EX
			LEFT JOIN [HlOperational].dbo.OrganizationDetails OD ON OD.OrganizationDetailId = EX.CompanyId
			WHERE EX.UserId = @UserId
			ORDER BY EX.ExperienceId
        END
GO

