USE [Balco_HRA]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_ROLE]    Script Date: 12/12/2022 2:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_MASTER_DEPT]
@DepartmentID	int	=NULL,
@DepartmentName	nvarchar(50)	=NULL,
@CreatedBy	nvarchar(50)	=NULL,
@CreationDateTime	datetime	=NULL,
@ModifiedBy	nvarchar(50)	=NULL,
@ModificationDate	datetime	=NULL,
@ENTRYSTATUS NVARCHAR(20)=NULL
AS BEGIN
DECLARE @MSG NVARCHAR(MAX)=NULL
--- SAVE PART
IF @ENTRYSTATUS='Save'
BEGIN
IF EXISTS (SELECT 'TRUE' FROM MST_DEPT WHERE DepartmentName=@DepartmentName)
BEGIN
SET @MSG='Already Exists'
select @MSG
END
ELSE
BEGIN
SELECT @DepartmentID=ISNULL(MAX(DepartmentID),0)+1 FROM MST_DEPT
INSERT INTO MST_ROLE (ROLEID,ROLENAME,CREATEDBY,CREATIONDATETIME) 
VALUES (@DepartmentID,@DepartmentName,@CreatedBy,GETDATE())
SET @MSG='Data Saved Successfully'
select @MSG
END

END
---UPDATE PART
IF @ENTRYSTATUS='Update'
BEGIN
IF EXISTS (SELECT 'TRUE' FROM MST_DEPT WHERE DepartmentName=@DepartmentName and DepartmentID!=@DepartmentID)
BEGIN
SET @MSG='Already Exists'
select @MSG
END
ELSE
BEGIN

UPDATE MST_DEPT SET DepartmentName=@DepartmentName,ModifiedBy=@ModifiedBy,ModificationDate=GETDATE() WHERE DepartmentID=@DepartmentID
SET @MSG='Data Updated Successfully'
select @MSG

END

END
---DELETE PART
IF @ENTRYSTATUS='Delete'
BEGIN

DELETE FROM  MST_DEPT  WHERE DepartmentID=@DepartmentID
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

SELECT DepartmentID,DepartmentName FROM  MST_DEPT  ORDER BY DepartmentID
END

END
	
