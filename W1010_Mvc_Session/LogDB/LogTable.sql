CREATE TABLE Log (  
	LogId        INTEGER PRIMARY KEY,  
	Date        DATETIME NOT NULL,  
	Level        VARCHAR(50) NOT NULL,  
	Logger        VARCHAR(255) NOT NULL,  
	Source        VARCHAR(255) NOT NULL,  
	Message        TEXT DEFAULT NULL 
); 
