﻿USE [Mediflow]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[GetOrderCartDetails]
		@CID = 8

SELECT	@return_value as 'Return Value'

GO
