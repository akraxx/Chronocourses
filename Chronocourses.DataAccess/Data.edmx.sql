
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2013 10:35:16
-- Generated from EDMX file: D:\Documents\Visual Studio 2010\Projects\Chronocourses\Chronocourses.DataAccess\Chronocourses.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [chronocourses];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

DELETE FROM EntityProduct;
DELETE FROM Product;
DELETE FROM TypeProduct;
DELETE FROM Brand;
DELETE FROM Entity;
DELETE FROM Shop;
DELETE FROM Address;

DBCC CHECKIDENT('Product', RESEED, 0)
DBCC CHECKIDENT('TypeProduct', RESEED, 0)
DBCC CHECKIDENT('Brand', RESEED, 0)
DBCC CHECKIDENT('Entity', RESEED, 0)
DBCC CHECKIDENT('Shop', RESEED, 0)
DBCC CHECKIDENT('Address', RESEED, 0)

INSERT INTO Address (Number, ZipCode, City, Country, Street) VALUES (1, 59000, "Lille", "FRANCE", "Solférino");
INSERT INTO Shop (Height,Width,Name,AddressID) VALUES (22,15,"Auchan",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,2,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,4,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,6,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,7,1,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,8,1,"shelf 1",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,2,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,4,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,6,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,7,3,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,8,3,"shelf 2",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,2,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,4,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,6,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,7,5,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,8,5,"shelf 3",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,2,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,4,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,6,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,7,7,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,8,7,"shelf 4",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,1,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,2,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,3,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,4,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,5,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,6,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,7,"shelf 5",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,1,"shelf 6",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,2,"shelf 6",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,3,"shelf 6",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,4,"shelf 6",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,5,"shelf 6",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,6,"shelf 6",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,7,"shelf 6",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,11,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,12,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,13,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,14,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,15,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,16,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,17,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,18,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,19,"shelf 7",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,1,20,"shelf 7",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,11,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,12,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,13,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,14,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,15,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,16,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,17,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,18,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,19,"shelf 8",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,3,20,"shelf 8",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,11,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,12,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,13,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,14,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,15,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,16,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,17,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,18,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,19,"shelf 9",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,5,20,"shelf 9",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,12,"shelf 10",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,11,12,"shelf 10",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,12,12,"shelf 10",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,13,12,"shelf 10",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (1,10,21,"start",0);

INSERT INTO Brand (Name) VALUES ("Lays");
INSERT INTO Brand (Name) VALUES ("Lipton");
INSERT INTO Brand (Name) VALUES ("Durex");
INSERT INTO Brand (Name) VALUES ("Coca");
INSERT INTO Brand (Name) VALUES ("Nestle");
INSERT INTO Brand (Name) VALUES ("Lu");
INSERT INTO Brand (Name) VALUES ("Danone");
INSERT INTO Brand (Name) VALUES ("Vico");
INSERT INTO Brand (Name) VALUES ("Herta");
INSERT INTO Brand (Name) VALUES ("Kinder");
INSERT INTO Brand (Name) VALUES ("Bonduelle");
INSERT INTO Brand (Name) VALUES ("Heinz");
INSERT INTO Brand (Name) VALUES ("Milka");
INSERT INTO Brand (Name) VALUES ("Charal")
INSERT INTO Brand (Name) VALUES ("Hoss");
INSERT INTO Brand (Name) VALUES ("Pere Dodu");
INSERT INTO Brand (Name) VALUES ("Findus");
INSERT INTO Brand (Name) VALUES ("Nike");
INSERT INTO Brand (Name) VALUES ("Adidas");
INSERT INTO Brand (Name) VALUES ("MaxiSport");
INSERT INTO Brand (Name) VALUES ("Reebok");
INSERT INTO Brand (Name) VALUES ("Ricard");
INSERT INTO Brand (Name) VALUES ("Pastis");



INSERT INTO TypeProduct (Label) VALUES ("Première nécéssité");
INSERT INTO TypeProduct (Label) VALUES ("Boissons");
INSERT INTO TypeProduct (Label) VALUES ("Sports");
INSERT INTO TypeProduct (Label) VALUES ("Charcuterie");
INSERT INTO TypeProduct (Label) VALUES ("Vetements");
INSERT INTO TypeProduct (Label) VALUES ("Dessert");
INSERT INTO TypeProduct (Label) VALUES ("Apéritif");


INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (8, "Durex", 1, 3,1,"A utiliser sans modération");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (7, "Brosse à dent", 1, 11,1," ... ");

INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (70, "Jean", 1, 18,3,"Jean Nike");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (40, "T-shirt", 1, 19,3,"T-shirt Adidas");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (60, "Pull", 1, 21,3,"Pull Reebok");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (10, "Marcel", 1, 20,3,"Marcel MaxiSport");

INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (3, "Chips", 1, 1,7,"Chips barbecue");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (10, "Saucisson", 1, 16,7,"Redthesaucisson");

INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (7, "Rosé", 1,15,2,"A boire frais");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (12, "Pastis", 1,23,2,"A boire frais");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (13, "Ricard", 1,22,2,"A boire frais");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (2, "Coca", 1,4,2,"A boire frais");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (2.5, "Ice Tea", 1,2,2,"A boire frais");

INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (25, "Altère", 1,15,3,"Devenez comme Maximilieu");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (80, "Banc abdos", 1,20,3,"Devenez comme Maximilieu");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (75, "Appareil de traction", 1,20,3,"Devenez comme Maximilieu");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (100, "Appareil à pompe", 1,20,3,"Devenez comme Maximilieu");

INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (4, "Yaourt", 1,7,6,"Delicieux !");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (8, "Chocolat", 1,10,6,"Delicieux !");
INSERT INTO Product (Price, Name, Available, BrandID, TypeProductID, Description) VALUES (13, "Chocolat au lait", 1,13,6,"Delicieux !");

INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(1,14);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(2,15);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(3,16);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(1,17);


INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(17,3);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(18,4);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(19,5);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(20,6);

INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(26,9);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(27,10);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(28,11);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(29,12);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(29,13);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(29,8);


INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(40,1);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(41,2);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(42,18);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(43,19);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(43,20);


INSERT INTO Address (Number, ZipCode, City, Country, Street) VALUES (55, 62000, "Arras", "FRANCE", "rue de la bière");
INSERT INTO Shop (Height,Width,Name,AddressID) VALUES (5,8,"MiniMarket",2);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,0,2,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,0,3,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,0,4,"shelf 1",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,0,1,"shelf 1",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,2,2,"shelf 2",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,2,3,"shelf 2",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,4,2,"shelf 3",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,4,3,"shelf 3",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,0,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,1,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,2,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,3,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,4,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,5,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,6,0,"shelf 4",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,7,0,"shelf 4",1);

INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,6,2,"shelf 5",1);
INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,6,3,"shelf 5",1);


INSERT INTO Entity(ShopID,PositionX,PositionY,Label,Container) VALUES (2,6,4,"start",0);

INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(82,3);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(83,7);

INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(84,8);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(85,17);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(86,11);

INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(90,14);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(92,12);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(96,19);

INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(87,1);
INSERT INTO EntityProduct (Entity_Id, Product_Id) VALUES(89,20);