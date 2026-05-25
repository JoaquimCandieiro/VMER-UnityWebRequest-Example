drop database if exists vmer_unitywebrequest;

create database if not exists vmer_unitywebrequest;

use vmer_unitywebrequest;

create table player_info(
	id int primary key auto_increment,
	name varchar(32) not null,
	lives int,
    health decimal(4, 1)
);

insert into player_info(name, lives, health)
values
('Player1', 3, 98.0),
('Player2', 1, 70.5),
('Player3', 2, 36.0);

select *
from player_info;

delete
from player_info
where id = 4;