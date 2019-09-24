create database Proj;

create table Aluno(
	a_id int not null auto_increment,
	a_nome varchar(255) not null,
	a_regCbj varchar(255) not null,
	a_tel1 varchar(255) not null,
	a_tel2 varchar(255) not null,
	a_email varchar(255) not null,
	a_cpf varchar(11) not null,
	a_obs varchar(255),
	primary key (a_id),
	foreign key(pID) references Professor(p_id),
	foreign key(ent_cnpj) references Entidade(e_cnpj)
	foreign key(a_addr) references Endereco(end_id)
	
);
create table Professor(
	p_id int not null auto_increment,
	p_nome varchar(255) not null,
	p_regCbj varchar(255) not null,
	p_tel1 varchar(255) not null,
	p_tel2 varchar(255) not null,
	p_email varchar(255) not null,
	p_cpf varchar(11) not null,
	p_obs varchar(255),
	primary key (p_id
	foreign key(p_addr) references Endereco(end_id)
);

create table Endereco(
	end_id int not null auto_increment,
	end_rua varchar(255),
	end_bairro varchar(255),
	end_cidade varchar(255),
	end_estado varchar(255),
	end_cep varchar(8) not null,
	primary key (end_id)
);

create table Entidade(
	e_nome varchar(255) not null,
	e_cnpj varchar(14) not null,
	e_tel1 varchar(255) not null,
	e_tel2 varchar(255) not null,
	primary key (e_cnpj),
	foreign key(e_addr) references Endereco(end_id)
);
