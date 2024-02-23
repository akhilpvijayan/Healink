USE [HLOperational]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetUserDetails')
DROP PROCEDURE [spGetUserDetails]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserDetails]
	 (@UserId BIGINT)
        AS
        BEGIN
		    SELECT 
				US.UserId,
				US.Username,
				US.Email,
				US.LastLogin,
				US.CreatedDate,
				US.isActive,
				US.IsVerified,
				RL.RoleName,
				UD.UserDetailId,
				UD.FirstName,
				UD.LastName,
				UD.ProfileImage,
				UD.UserBio,
				CT.CountryName,
				ST.StateName,
				UD.Region,
				UD.Specialization,
				UD.ConnectionsCount
				FROM Users US
				INNER JOIN UserDetails UD ON UD.UserId = US.UserId
				INNER JOIN Roles RL ON RL.RoleId = US.RoleId
				INNER JOIN Countries CT ON CT.CountryId = UD.CountryId
				INNER JOIN States ST ON ST.StateId = UD.StateId 
				WHERE US.UserId = @UserId
        END
GO