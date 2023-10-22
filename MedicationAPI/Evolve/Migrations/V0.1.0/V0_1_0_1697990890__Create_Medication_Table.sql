CREATE TABLE medication(
	id SERIAL PRIMARY KEY,
	name VARCHAR(150) NOT NULL,
	quantity int NOT NULL,
	creation_date TIMESTAMP NOT NULL
);