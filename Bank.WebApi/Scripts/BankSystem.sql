CREATE TYPE account_type AS ENUM ('saving', 'default');

create table users (
	id serial PRIMARY KEY,
	name varchar(100),
	address varchar(200)
);

create table accounts (
	id serial PRIMARY KEY,
	acc_type account_type,
	user_id int,
	balance decimal,
	FOREIGN KEY (user_id) REFERENCES users(id)
);

create table transactions (
	id serial PRIMARY KEY,
	account_id int,
	amount decimal,
	FOREIGN KEY (account_id) REFERENCES accounts(id)
);