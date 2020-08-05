

CREATE Messages vaults (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    body VARCHAR(1200) NOT NULL,
    phonenumber VARCHAR(50) DEFAULT,
    email VARCHAR(255),  
    PRIMARY KEY (id)
);


