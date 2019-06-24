IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SaveProduct]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SaveProduct]
GO

CREATE procedure [dbo].[SaveProduct]
(
	@Id int,
	@Name nvarchar(200),
	@Description nvarchar(4000),
	@ThumbnailImage nvarchar(MAX))
AS
BEGIN
	IF (@Id = 0)
		BEGIN
			INSERT INTO [dbo].[Product] (
	  			[Name],
      			[Description],
      			ThumbnailImage)
			VALUES (
	  			@Name,
      			@Description,
      			@ThumbnailImage)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Product] SET
	  			[Name] = @Name,
      			[Description] = @Description,
      			ThumbnailImage = @ThumbnailImage
			WHERE Id = @Id
		END
END

GO
