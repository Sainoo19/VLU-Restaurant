CREATE DATABASE quanlicaphe

GO 


USE quanlicaphe

GO
-- Food 

-- Table 

-- FoodCategory 

-- Account 

-- Bill 

-- BillInfo 

 

CREATE TABLE TableFood 

( 

	id INT IDENTITY PRIMARY KEY, 

	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên', 

	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người 

) 

GO
CREATE TABLE Account 

( 

	UserName NVARCHAR(100) PRIMARY KEY,	 

	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Kter', 

	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0, 

	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff 

) 

GO 
CREATE TABLE FoodCategory 

( 

	id INT IDENTITY PRIMARY KEY, 

	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' 

) 

GO 
CREATE TABLE Food 

( 

	id INT IDENTITY PRIMARY KEY, 

	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên', 

	idCategory INT NOT NULL, 

	price FLOAT NOT NULL DEFAULT 0 

 

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id) 

) 

GO 
CREATE TABLE Bill 

( 

	id INT IDENTITY PRIMARY KEY, 

	dateCheckIn DATE NOT NULL DEFAULT GETDATE(), 

	dateCheckOut DATE, 

	idTable INT NOT NULL, 

	status INT NOT NULL DEFAULT 0
-- 1: đã thanh toán && 0: chưa thanh toán 

 

FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id) 

) 
GO 


CREATE TABLE BillInfo 

( 

	id INT IDENTITY PRIMARY KEY, 

	idBill INT NOT NULL, 

	idFood INT NOT NULL, 

	count INT NOT NULL DEFAULT 0 

 

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id), 

	FOREIGN KEY (idFood) REFERENCES dbo.Food(id) 

) 


INSERT INTO Account VALUES 
(N'admin', N'nth', N'1','1' )
SELECT UserName, DisplayName, Type FROM Account 
Delete Account
select *from Account


DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT TableFood (name) VALUES (N'Bàn ' + CAST (@i AS nvarchar(100))) -- dùng để insert into nhanh hơn insert into từng bàn
	SET @i = @i +1 
END
GO 



UPDATE dbo.TableFood SET status  = N'Có người' WHERE id = 2
UPDATE dbo.TableFood SET status  = N'Có người' WHERE id = 5
UPDATE dbo.TableFood SET status  = N'Có người' WHERE id = 9
UPDATE dbo.TableFood SET status  = N'Có người' WHERE id = 10




-- thêm category
INSERT INTO FoodCategory (name) VALUES 
(N'Món ăn'),
(N'Thức uống'),
(N'Kem'),
(N'Ăn vặt'),
(N'Hải sản'),
(N'Mì gói')





-- thêm món ăn
INSERT INTO Food (name, idCategory, price) VALUES 
(N'Coca', 1, 12000),
(N'Pepsi', 1, 12000),
(N'7up', 1, 15000),
(N'Red Bull', 1, 15000),
(N'Sting dâu', 1, 15000),
(N'Cà phê đá', 2, 25000),
(N'Cà phê sữa', 2, 25000),
(N'Bạc xỉu', 2, 25000),
(N'Americano', 2, 35000),
(N'Espresso', 2, 35000),
(N'Trà sữa trân châu phô mai', 3, 30000),
(N'Trà sữa trân châu pudding', 3, 25000),
(N'Trà sữa trân châu chuối', 3, 30000),
(N'Trà sữa trân châu chuối', 3, 30000),
(N'Thêm topping', 3, 5000),
(N'Bánh trán cuộn', 4, 20000),
(N'Bánh trán trộn', 4, 15000),
(N'Snack trứng muối', 4, 16000),
(N'Cá viên chiên', 4, 70000),
(N'Mực chiên nước mắm', 5, 20000),
(N'Khô cá bống', 5, 20000),
(N'Sushi cá hồi', 5, 200000),
(N'Combo hải sản',5, 300000),
(N'Mì hảo hảo', 6, 15000),
(N'Mì Omachi', 6, 20000),
(N'Mì cung đình', 6, 15000),
(N'Mì xào',6, 20000)


-- them bill
INSERT INTO Bill (dateCheckIn, dateCheckOut, idTable, status) VALUES 
(GETDATE(), null, 2, 0),  --idTable 2: ban 1
(GETDATE(), null, 5, 0),  --idTable 5: ban 4
(GETDATE(), null, 9, 0),  --idTable 9: ban 8
(GETDATE(), null, 10, 0)  --idTable 10: ban 9

INSERT INTO Bill (dateCheckIn, dateCheckOut, idTable, status) VALUES -- cac ban da CheckOut
(GETDATE(), GETDATE(), 1, 1), --idTable 1: ban 0
(GETDATE(), GETDATE(), 4, 1), -- idTable 4: ban 3
(GETDATE(), GETDATE(), 7, 1) -- idTable 7 : ban 7

--UPDATE Bill SET status = 1 WHERE status = 1
--UPDATE Bill SET status = 0 WHERE idTable = 2
--UPDATE Bill SET status = 0 WHERE idTable = 5
--UPDATE Bill SET status = 0 WHERE idTable = 9
--UPDATE Bill SET status = 0 WHERE idTable =10



-- them BillInfo
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(1,11,1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(1,15,1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(1,18,1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(2, 7, 2)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(2, 3, 1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(3, 1, 3)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(3, 23,1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(4, 19, 5)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(4, 8, 2)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(4, 7, 2)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(4, 19, 2)
INSERT INTO BillInfo (idBill, idFood, count) VALUES --INSERT cho ban da CHECKOUT
(5, 7, 1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(5, 5, 2)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(6, 9, 1)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(7, 1, 2)
INSERT INTO BillInfo (idBill, idFood, count) VALUES
(7, 10, 1)


select*from Bill
select *from Account


--trung them bang
CREATE TABLE Staff
(
MaNV int not null primary key,

Name Char(50) not null,

Addr char(200) not null,

PhoneNumber Varchar (12) not null,

Gioitinh nchar(10) NOT NULL DEFAULT 0 ,-- 0 nam,1 nu

status nchar(10) NOT NULL DEFAULT 0, -- 0=staff, 1 manager

Wage float NOT NULL DEFAULT 0


)
GO
alter table staff add Ngaysinh date


insert into Staff
values(0011,'Nguyen Viet Trung','D17 Me Coc','0941xxxxxx','NAM','Nhan Vien',100000,'05/09/2003'),(0023,'Nguyen Thanh Hiep','30B Hoai Thanh','0902xxxxxx',0,1,80000000,'21/10/2003')
insert into Staff
values(0034,'Nguyen Minh Thong','abc','0902xxxxxx','NAM','Nhan Vien',120000,'01/01/2003')

select* from Staff

delete Staff
drop table staff








