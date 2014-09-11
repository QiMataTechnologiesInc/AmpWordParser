CREATE VIEW [dbo].[CommaSeperatedCategoryHeirarchies]
	AS 
WITH RootCategories(CategoryId,Category)
AS
(
	SELECT CategoryId, CategoryName
	FROM Datasheet.Category
	WHERE ParentCategoryId IS NULL
)

SELECT r.Category, c.CategoryName
FROM RootCategories as r
JOIN Datasheet.Category as c
ON r.CategoryId = c.ParentCategoryId
