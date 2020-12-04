CREATE TABLE [dbo].[Student_Details]
(
	[StudentId] INT NOT NULL PRIMARY KEY, 
    [StudentName] NVARCHAR(50) NULL, 
    [StudentAge] INT NULL, 
    [StudentContact] NVARCHAR(50) NULL, 
    [StudentGender] CHAR(10) NULL
)
