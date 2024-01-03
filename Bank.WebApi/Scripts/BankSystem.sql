CREATE TYPE account_type AS ENUM ('Saving', 'Default');

create table users (
	id serial PRIMARY KEY,
	name varchar(100),
	address varchar(200),
	is_deleted BOOL NOT NULL DEFAULT false,
);

create index idx_users
on users(id);

create table accounts (
	id serial PRIMARY KEY,
	acc_type account_type,
	user_id int,
	balance decimal DEFAULT 0,
	is_deleted BOOL NOT NULL DEFAULT false,
	FOREIGN KEY (user_id) REFERENCES users(id)
);

create index idx_accounts
on accounts(id);

create table transactions (
	id serial PRIMARY KEY,
	account_id int,
	amount decimal,
	cause varchar(200),
	created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY (account_id) REFERENCES accounts(id)
);

create index idx_transactions
on transactions(account_id);