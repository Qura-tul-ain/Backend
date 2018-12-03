USE [online]
CREATE TABLE dbo.Feedbackss
(
ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Subject nvarchar(50) NOT NULL,
Description nvarchar (256) NOT NULL,
FK_ID nvarchar(128) FOREIGN KEY REFERENCES dbo.AspNetUsers(Id) NOT NULL,
);
GO
