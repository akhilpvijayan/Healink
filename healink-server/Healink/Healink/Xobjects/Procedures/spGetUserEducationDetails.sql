USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetUserEducationDetails')
DROP PROCEDURE [spGetUserEducationDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserEducationDetails]
		(@UserId BIGINT)
        AS
        BEGIN
		SELECT 
			ED.EducationId,
			ED.Institution,
			ED.Degree,
			ED.FieldOfStudy,
			ED.GraduationstartDate,
			ED.GraduationEndDate,
			ED.GraduationDescription,
			ED.OrgId,
			CAST(CASE WHEN ED.GraduationEndDate IS NULL THEN 1 ELSE 0 END AS BIT) AS [Current],
			OD.OrganizationName OrgInstitutionName,
			OD.OrganizationLogo OrgLogo,
			ED.CreatedBy,
			ED.CreatedDate,
			ED.ModifiedBy,
			ED.ModifiedDate
			FROM [HlOperational].dbo.Educations ED
			LEFT JOIN [HlOperational].dbo.OrganizationDetails OD ON OD.OrganizationDetailId = ED.OrgId
			WHERE ED.UserId = @UserId
			ORDER BY ED.EducationId
        END
GO

