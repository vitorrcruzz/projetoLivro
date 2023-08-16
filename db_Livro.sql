create database db_Livro;

use db_Livro;

create table tbl_Livro(
	id_Livro int primary key auto_increment,
    nm_Livro varchar(80) not null,
    id_Autor int,
    data_Inicio datetime not null,
    data_Termino datetime not null,
    nota_Livro char(5) not null,
    constraint foreign key (id_Autor) references tbl_Autor(id_Autor)
);

create table tbl_Autor(
	id_Autor int primary key auto_increment,
    nm_Autor varchar(80) not null
);

drop database db_livro;

desc tbl_Autor;
desc tbl_Livro;

select * from tbl_Autor;
select * from tbl_Livro;