USE SelfServiceCheckoutDB;

DECLARE @TimeStamp DATETIME2 = GETDATE();

IF (SELECT COUNT(*) FROM [dbo].[Currencies]) = 0
BEGIN
	INSERT INTO [dbo].[Currencies]
	(
		[ISOCode]
		,[RatioToLcy]
		,[IsLocalCurrency]
		,[Created]
		,[Modified]
	)
	VALUES
	('HUF', 1, 1, @TimeStamp, @TimeStamp)
	,('EUR', 351, 0, @TimeStamp, @TimeStamp)
END