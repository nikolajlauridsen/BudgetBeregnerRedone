ALTER PROC InsertBudget 
@Name NVarChar(max)
AS
BEGIN
INSERT INTO Budget(Name) VALUES (@Name);
SELECT SCOPE_IDENTITY();
END

CREATE PROC GetBudgets
AS
BEGIN
SELECT Name, ID FROM Budget;
END

EXEC GetBudgets

ALTER PROC GetBudget
@ID int
AS
BEGIN
SELECT Name, ID FROM Budget WHERE ID = @ID
END

CREATE PROC RemoveBudget
@ID int
AS
BEGIN
DELETE FROM Budget WHERE ID = @ID
END


ALTER PROC InsertExpense
@Name NVarChar(Max),
@Amount Money,
@BudgetID INT
AS
BEGIN
INSERT INTO Expense(Name, Amount, BudgetID) VALUES (@Name, @Amount, @BudgetID);
SELECT SCOPE_IDENTITY();
END

CREATE PROC DeleteExpense 
@ID INT
AS
BEGIN
DELETE FROM Expense WHERE ID = @ID
END

ALTER PROC InsertIncome
@Name NVarChar(Max),
@Amount Money,
@BudgetID INT
AS
BEGIN
INSERT INTO Income(Name, Amount, BudgetID) VALUES (@Name, @Amount, @BudgetID)
SELECT SCOPE_IDENTITY();
END

CREATE PROC DeleteIncome 
@ID INT
AS
BEGIN
DELETE FROM Income WHERE ID = @ID
END


ALTER PROC GetIncomeLines
@BudgetID INT
AS
BEGIN
SELECT Name, Amount, ID FROM Income WHERE BudgetID = @BudgetID;
END

ALTER PROC GetExpenseLines
@BudgetID INT
AS
BEGIN
SELECT Name, Amount, ID FROM Expense WHERE BudgetID = @BudgetID;
END

EXEC InsertIncome @Name = 'SU', @Amount = 5100, @BudgetID = 1, @ID=4;
EXEC InsertIncome @Name = 'Løn', @Amount = 3000, @BudgetID = 1, @ID=4;

EXEC InsertExpense @Name= 'Husleje', @Amount = 2850, @BudgetID=1, @ID=4;
EXEC InsertExpense @Name= 'Mobil', @Amount = 200, @BudgetID=1, @ID=4;
