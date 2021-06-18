create database Shoe
use Shoe

create table UserAccount(
   ID int primary key,
   UserName char(100),
   Password char(100),
   Status char(50)
)
insert into UserAccount values(1,'conglinh','2000','Active');
insert into UserAccount values(2,'cong123','123','Block');
insert into UserAccount values(3,'cong124','124','Active');
insert into UserAccount values(4,'cong111','111','Block');
insert into UserAccount values(5,'cong122','122','Active');
insert into UserAccount values(6,'cong121','121','Active');

create table LoaiSP(
  ID int Primary key,
  Name nvarchar(100),
  Description nvarchar(100)
)

insert into LoaiSP values(1,'SNEAKER','High Quality');
insert into LoaiSP values(2,'NIKE','High Quality');
insert into LoaiSP values(3,'GUCCI','High Quality');

create table SanPham(
  ID int primary key identity,
  Name nvarchar(100),
  UniCost int,
  Quanity int,
  Image varchar(50),
  Discription nvarchar(100),
  Status int,
  IDLoai int,
  FOREIGN KEY (IDLoai) REFERENCES LoaiSP(ID) 
)

insert into SanPham values('Sandar',150000,10,'image1.jpg','Made in Japan',1,1);
insert into SanPham values('Hendior',100000,50,'image2.jpg','Made in Japan',1,1);
insert into SanPham values('Valien',50000,20,'image6.jpg','Made in Korea',1,2);
insert into SanPham values('Boston',50000,20,'image4.jpg','Made in Korea',1,2);
insert into SanPham values('Poland',200000,20,'image5.jpg','Made in China',1,3);
insert into SanPham values('Naggy',50000,20,'image3.jpg','Made in China',0,3);

