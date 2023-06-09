USE [Balco_HRA]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_SBU]    Script Date: 1/19/2023 4:50:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_MASTER_SBU]
@SBUID	int	=NULL,
@SBUName	nvarchar(50)	=NULL,
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
IF EXISTS (SELECT 'TRUE' FROM MST_SBU WHERE SBUName=@SBUName)
BEGIN
SET @MSG='Already Exists'
select @MSG
END
ELSE
BEGIN
SELECT @SBUID=ISNULL(MAX(SBUID),0)+1 FROM MST_SBU
INSERT INTO MST_SBU(SBUID,SBUName,CreatedBy,CreationDateTime) 
VALUES (@SBUID,@SBUName,@CreatedBy,GETDATE())
SET @MSG='Data Saved Successfully'
select @MSG
END

END
---UPDATE PART
IF @ENTRYSTATUS='Update'
BEGIN
IF EXISTS (SELECT 'TRUE' FROM MST_SBU WHERE SBUName=@SBUName and SBUID!=@SBUID)
BEGIN
SET @MSG='Already Exists'
select @MSG
END
ELSE
BEGIN

UPDATE MST_SBU SET SBUName=@SBUName,ModifiedBy=@ModifiedBy,ModificationDate=GETDATE() WHERE SBUID=@SBUID
SET @MSG='Data Updated Successfully'
select @MSG

END

END
---DELETE PART
IF @ENTRYSTATUS='Delete'
BEGIN

DELETE FROM  MST_SBU  WHERE SBUID=@SBUID
SET @MSG='Data Deleted Successfully'
select @MSG
END
---View PART
IF @ENTRYSTATUS='List'
BEGIN

SELECT * FROM  MST_SBU 
END
---DELETE PART
IF @ENTRYSTATUS='DropDown'
BEGIN

SELECT SBUID,SBUName FROM  MST_SBU  ORDER BY SBUID
END

END
	

