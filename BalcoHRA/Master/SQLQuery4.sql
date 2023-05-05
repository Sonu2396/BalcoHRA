USE [Balco_HRA]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_ROLE]    Script Date: 1/19/2023 4:49:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_MASTER_ROLE]
@ROLEID	int	=NULL,
@ROLENAME	nvarchar(50)	=NULL,
@CREATEDBY	nvarchar(50)	=NULL,
@CREATIONDATETIME	datetime	=NULL,
@MODIFIEDBY	nvarchar(50)	=NULL,
@MODIFICATIONDATETIME	datetime	=NULL,
@ENTRYSTATUS NVARCHAR(20)=NULL
AS BEGIN
DECLARE @MSG NVARCHAR(MAX)=NULL
--- SAVE PART
IF @ENTRYSTATUS='Save'
BEGIN
IF EXISTS (SELECT 'TRUE' FROM MST_ROLE WHERE ROLENAME=@ROLENAME)
BEGIN
SET @MSG='Already Exists'
select @MSG
END
ELSE
BEGIN
SELECT @ROLEID=ISNULL(MAX(ROLEID),0)+1 FROM MST_ROLE
INSERT INTO MST_ROLE (ROLEID,ROLENAME,CREATEDBY,CREATIONDATETIME) 
VALUES (@ROLEID,@ROLENAME,@CREATEDBY,GETDATE())
SET @MSG='Data Saved Successfully'
select @MSG
END

END
---UPDATE PART
IF @ENTRYSTATUS='Update'
BEGIN
IF EXISTS (SELECT 'TRUE' FROM MST_ROLE WHERE ROLENAME=@ROLENAME and ROLEID!=@ROLEID)
BEGIN
SET @MSG='Already Exists'
select @MSG
END
ELSE
BEGIN

UPDATE MST_ROLE SET ROLENAME=@ROLENAME,MODIFIEDBY=@MODIFIEDBY,MODIFICATIONDATETIME=GETDATE() WHERE ROLEID=@ROLEID
SET @MSG='Data Updated Successfully'
select @MSG

END

END
---DELETE PART
IF @ENTRYSTATUS='Delete'
BEGIN

DELETE FROM  MST_ROLE  WHERE ROLEID=@ROLEID
SET @MSG='Data Deleted Successfully'
select @MSG
END
---View PART
IF @ENTRYSTATUS='List'
BEGIN

SELECT * FROM  MST_ROLE   
END
---DELETE PART
IF @ENTRYSTATUS='DropDown'
BEGIN

SELECT ROLEID,ROLENAME FROM  MST_ROLE  ORDER BY ROLENAME
END

END
	
