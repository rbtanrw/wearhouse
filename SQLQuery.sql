use WearHouse

create table DataUser(
	name varchar(100) not null,
	email varchar(100) primary key not null,
	password varchar(100) not null
)

insert DataUser values
('Admin', 'admin@gmail.com', 'adminWH'),
('User', 'user@gmail.com', 'UserWH');

select * from DataUser

create table ProductCategory(
	category varchar(50) not null
)

insert ProductCategory values
('Shoes'), ('Hats'), ('Clothes'), ('Bags'), ('Socks')

select * from ProductCategory