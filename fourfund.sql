
--     create table section
--     CREATE TABLE messages  (
--     id int NOT NULL AUTO_INCREMENT,
--     username VARCHAR(255) NOT NULL,
--     body VARCHAR(1200) NOT NULL,
--     phonenumber VARCHAR(50) ,
--     email VARCHAR(255),  
--     PRIMARY KEY (id)
-- );

    CREATE TABLE useradvertiser  (
    id int NOT NULL AUTO_INCREMENT,
    username VARCHAR(80) NOT NULL,
    orgname VARCHAR(80) NOT NULL,
    phonenumber VARCHAR(16) ,
    email VARCHAR(100) NOT NULL,  
     logo varchar(400),
    PRIMARY KEY (id)
);


--     CREATE TABLE userfundraiser  (
--     id int NOT NULL AUTO_INCREMENT,
--     username VARCHAR(80) NOT NULL,
--     orgname VARCHAR(80) NOT NULL,
--     phonenumber VARCHAR(16) ,
--     email VARCHAR(100) NOT NULL,  
--     logo varchar(400),
--     PRIMARY KEY (id)
-- );

-- DROP TABLE IF EXISTS useradvertiser;
-- DROP TABLE IF EXISTS userfundraiser;