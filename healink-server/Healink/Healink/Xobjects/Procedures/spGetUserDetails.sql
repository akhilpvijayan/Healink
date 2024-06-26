USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetUserDetails')
DROP PROCEDURE [spGetUserDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserDetails]
	 (@UserId BIGINT,
	 @IsOrganizationUser BIT)
        AS
        BEGIN

		IF (@IsOrganizationUser <> 1)
		    SELECT 
				US.UserId,
				US.Username,
				US.Email,
				US.LastLogin,
				US.CreatedDate,
				US.IsActive,
				US.IsVerified,
				US.RoleId,
				RL.RoleName,
				UD.UserDetailId,
				UD.FirstName,
				UD.LastName,
				UD.ProfileImage,
				UD.ProfileCover,
				UD.UserBio,
				UD.Gender,
				CT.CountryId,
				CT.CountryName,
				ST.StateId,
				ST.StateName,
				UD.Region,
				UD.Specialization,
				UD.ConnectionsCount,
				UD.CreatedBy,
				UD.ModifiedBy,
				UD.ModifiedDate
				FROM Users US
				INNER JOIN UserDetails UD ON UD.UserId = US.UserId
				INNER JOIN Roles RL ON RL.RoleId = US.RoleId
				INNER JOIN Countries CT ON CT.CountryId = UD.CountryId
				INNER JOIN States ST ON ST.StateId = UD.StateId
				WHERE US.UserId = @UserId
			ELSE
				SELECT 
				US.UserId,
				US.Username,
				US.Email,
				US.LastLogin,
				US.CreatedDate,
				US.IsActive,
				US.IsVerified,
				US.RoleId,
				RL.RoleName,
				OD.OrganizationDetailId,
				OD.OrganizationName,
				OD.OrganizationWebsite,
				OD.OrganizationLogo,
				OD.OrganizationCover,
				OD.OrganizationBio,
				CT.CountryId,
				CT.CountryName,
				OS.OrganizationSizeType OrganizationSize,
				ST.StateId,
				ST.StateName,
				OD.Region,
				OD.FollowCount,
				OD.TagLine,
				IT.IndustryName,
				OD.CreatedBy,
				OD.ModifiedDate,
				OD.ModifiedBy
				FROM Users US
				INNER JOIN OrganizationDetails OD ON OD.UserId = US.UserId
				INNER JOIN IndustryTypes IT ON IT.IndustryTypeId =OD.OrganizationTypeId
				INNER JOIN Roles RL ON RL.RoleId = US.RoleId
				INNER JOIN Countries CT ON CT.CountryId =OD.CountryId
				INNER JOIN States ST ON OD.StateId =ST.StateId
				INNER JOIN OrganizationSize OS ON OS.OrganizationSizeId = OD.OrganizationSize
				WHERE US.UserId = @UserId
        END
GO