CREATE TABLE products(
 id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
 name VARCHAR(100) NOT NULL,
 description VARCHAR(1000) NOT NULL,
 net_price real
)