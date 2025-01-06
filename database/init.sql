-- Create database
CREATE DATABASE IF NOT EXISTS donations;

-- Go to donations database
USE donations;

-- Create userinfo table
CREATE TABLE IF NOT EXISTS userinfo (user_id INT AUTO_INCREMENT, user_auth VARCHAR(64) PRIMARY KEY, donate_tier VARCHAR(32), expire_time DATETIME);

-- Create purchase_history table
CREATE TABLE IF NOT EXISTS purchase_history (purchase_id INT PRIMARY KEY AUTO_INCREMENT, user_auth VARCHAR(64), price FLOAT, purchase_time DATETIME);

-- sample for adding userinfo
#INSERT INTO userinfo (user_auth, donate_tier, expire_time) VALUES ("76561198095238004", "gold", "2025-02-05 15:55:52");
