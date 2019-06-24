IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SaveComment]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SaveComment]
GO

CREATE procedure [dbo].[SaveComment]
(
	@Id int,
	@ProductId int,
	@Author nvarchar(200),
	@Message nvarchar(4000))
AS
BEGIN
	IF (@Id = 0)
		BEGIN
			INSERT INTO [dbo].[Comment] (
      			ProductId,
				Author,
      			[Message])
			VALUES (
				@ProductId,
	  			@Author,
      			@Message)
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Comment] SET
	  			Author = @Author,
      			[Message] = @Message
			WHERE Id = @Id
		END
END

GO
