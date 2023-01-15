SELECT * FROM [User] WHERE Deleted = 0

UPDATE [User] SET Deleted = 1 WHERE Id=5

INSERT INTO [User] (Username,Password) VALUES ('b','b')

Select Id from [Storage] where Deleted=0

Select * from [Receipts] where  '2020-12-27 22:05:14'<Time and Time< '2020-12-28 23:05:14' and Deleted = 0


Select sum(RI.Amount) as amount from [Receipts_item] RI Where RI.Id_receiptFK in (Select Id from [Receipts] where  '2020-12-27 22:05:14'<Time and Time< '2020-12-28 23:05:14' and Deleted = 0
)
/*Upit za količinu itema u vremenu*/
Select ST.Item,sum(RI.Amount) as amount,sum(R.Total) as total,  AVG(R.Discount) as avgdiscount from [Receipts_item] RI, [Receipts] R, [Storage] ST Where RI.Id_receiptFK = R.Id AND '2020-12-27 22:05:14'<Time and Time< '2020-12-30 23:05:14' and R.Deleted = 0 AND ST.Id = RI.Id_itemFK group by ST.Item

/*racuni*/
Select *  from [Receipts] R where Time >= cast( floor( cast( getdate() as float)) as datetime)
Select ST.Item,sum(RI.Amount) as amount, sum(R.Total) as total  from [Receipts_item] RI, [Receipts] R, [Storage] ST where RI.Id_receiptFK = R.Id AND Time >= cast( floor( cast( getdate() as float)) as datetime)and R.Deleted = 0 AND ST.Id = RI.Id_itemFK group by ST.Item

SELECT S.Id,S.Item, S.Price, S.Cooler,S.Backstorage,S.Deleted, COUNT(H.Id) FROM dbo.Storage S, dbo.Happyhour H WHERE S.Deleted = 0  Group by S.Id,S.Item, S.Price, S.Cooler,S.Backstorage,S.Deleted,S.Id

/*select S.Id, EXISTS(SELECT Count(H.Id) FROM dbo.Happyhour H WHERE S.Id=H.Id) from dbo.Storage S where ex*/

  SELECT S.*, 
       CASE WHEN H.IdItem_FK IS NOT NULL
       THEN 1
       ELSE 0
       END
       AS OnHappyHour

    FROM dbo.Storage S
    LEFT JOIN dbo.Happyhour H
    ON S.Id=H.IdItem_FK


SELECT R.Id, R.Time, R.Total, R.Payment_method, R.Discount, U.Username as Waiter FROM  [Receipts] R, [User] U WHERE U.Id = R.Waiter_id AND @from<Time AND Time< @to AND R.Deleted = 0 

SELECT RI.Id_itemFK AS Id, S.Item, RI.Amount, RI.Price AS Price_per_unit, RI.Amount*RI.Price AS Total  FROM [Receipts_item] RI, [Storage] S WHERE RI.Id_receiptFK =175 AND S.Id=Id_itemFK