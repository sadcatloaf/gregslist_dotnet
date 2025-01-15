CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE cars(
  -- make sure the first column in your table is the id
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  make TINYTEXT NOT NULL,
  model TINYTEXT NOT NULL,
  year SMALLINT UNSIGNED NOT NULL,
  price INT UNSIGNED NOT NULL,
  color TINYTEXT,
  img_url TEXT NOT NULL,
  description TEXT,
  engine_type ENUM('v6', 'v8', 'v10', '4-cylinder', 'unknown') NOT NULL,
  mileage MEDIUMINT UNSIGNED NOT NULL,
  has_clean_title BOOLEAN NOT NULL,
  creator_id VARCHAR(255) NOT NULL,
  -- there must be a match between an account id and the creator_id of a car to create a car
  -- if someone deletes their account, go delete all of the cars that account created
  FOREIGN KEY(creator_id) REFERENCES accounts(id) ON DELETE CASCADE
);

DROP TABLE cars;

-- INSERT INTO 
-- cars(make, model, year, price, color, img_url, description, engine_type, mileage, has_clean_title, creator_id)
-- VALUES("mazda", "miata", 1996, 6000, "red", "https://images.unsplash.com/photo-1725199583250-9f59567ba965?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8bWlhdGF8ZW58MHx8MHx8fDA%3D", "car for jeremy", "4-cylinder", 10000, false, "jeremy");