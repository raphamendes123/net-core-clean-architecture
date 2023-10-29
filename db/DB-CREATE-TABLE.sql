USE BET_PH GO
 
IF OBJECT_ID('UserAdresses') IS NOT NULL DROP TABLE UserAdresses
IF OBJECT_ID('UserContacts') IS NOT NULL DROP TABLE UserContacts
IF OBJECT_ID('TokenEmail') IS NOT NULL DROP TABLE TokenEmail
IF OBJECT_ID('UserAdresses') IS NOT NULL DROP TABLE UserAdresses
IF OBJECT_ID('UserContacts') IS NOT NULL DROP TABLE UserContacts
IF OBJECT_ID('Users') IS NOT NULL DROP TABLE Users
IF OBJECT_ID('TypeStatusEvent') IS NOT NULL DROP TABLE TypeStatusEvent 
IF OBJECT_ID('TypeRaceColor') IS NOT NULL DROP TABLE TypeRaceColor 
IF OBJECT_ID('TypeContact') IS NOT NULL DROP TABLE TypeContact
IF OBJECT_ID('TypeSex') IS NOT NULL DROP TABLE TypeSex
IF OBJECT_ID('TypeAddress') IS NOT NULL DROP TABLE TypeAddress
IF OBJECT_ID('TypeProfile') IS NOT NULL DROP TABLE TypeProfile


CREATE TABLE TypeProfile
(
	Id 			BIGINT NOT NULL PRIMARY KEY (Id),
	Description	VARCHAR(100) NOT NULL
)

INSERT INTO TypeProfile VALUES(1,'Administrator')
INSERT INTO TypeProfile VALUES(2,'UserStandard')

GO
CREATE TABLE TypeAddress
(
	Id 			BIGINT NOT NULL PRIMARY KEY (Id),
	Description	VARCHAR(100) NOT NULL
)

INSERT INTO TypeAddress VALUES(1,'Residential')
INSERT INTO TypeAddress VALUES(2,'Commercial')
INSERT INTO TypeAddress VALUES(3,'Delivery')

GO

CREATE TABLE TypeSex
(
	Id 			BIGINT NOT NULL PRIMARY KEY (Id),
	Description	VARCHAR(100) NOT NULL
)

INSERT INTO TypeSex VALUES(1,'I dont want to declare')
INSERT INTO TypeSex VALUES(2,'Masculine')
INSERT INTO TypeSex VALUES(3,'Feminine')


CREATE NONCLUSTERED INDEX idx_id ON TypeSex  (Id)

GO

CREATE TABLE TypeContact
(
	Id 			BIGINT NOT NULL PRIMARY KEY (Id),
	Description	VARCHAR(100) NOT NULL
)

CREATE NONCLUSTERED INDEX idx_id ON TypeContact  (Id)
INSERT INTO TypeContact VALUES(1,'Fixed')
INSERT INTO TypeContact VALUES(2,'Fax') 
INSERT INTO TypeContact VALUES(3,'Cellphone') 
INSERT INTO TypeContact VALUES(4,'Whatsapp') 
INSERT INTO TypeContact VALUES(5,'Telegram') 
INSERT INTO TypeContact VALUES(6,'Call Center') 

GO

 

CREATE TABLE TypeRaceColor
(
	Id 			BIGINT NOT NULL PRIMARY KEY (Id),
	Description	VARCHAR(100) NOT NULL
)

CREATE NONCLUSTERED INDEX idx_id ON TypeRaceColor  (Id)
INSERT INTO TypeRaceColor VALUES(1,'Yellow')
INSERT INTO TypeRaceColor VALUES(2,'White')
INSERT INTO TypeRaceColor VALUES(3,'Indigenous')
INSERT INTO TypeRaceColor VALUES(4,'Brown') 
INSERT INTO TypeRaceColor VALUES(5,'Black') 
INSERT INTO TypeRaceColor VALUES(6,'Others') 
INSERT INTO TypeRaceColor VALUES(7,'I dont want to declare') 

 
CREATE TABLE TypeStatusEvent
(
	Id 			BIGINT NOT NULL PRIMARY KEY (Id),
	Description	VARCHAR(100) NOT NULL
)

INSERT INTO TypeStatusEvent VALUES(1,'Under Construction')
INSERT INTO TypeStatusEvent VALUES(2,'Open')
INSERT INTO TypeStatusEvent VALUES(3,'Closed') 
 
 
 

CREATE TABLE Users
(
	Id 			    BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY (Id) ,
	Cpf			    BIGINT NOT NULL,
	Name 		    VARCHAR(50) NOT NULL,
	Surname	        VARCHAR(100) NOT NULL,
	DisplayName     VARCHAR(50) NOT NULL,
	BirthDate 	    DATE NOT NULL, 
	Email	        VARCHAR(50) NOT NULL,
	IdTypeSex	    BIGINT NULL FOREIGN KEY REFERENCES TypeSex(Id),
	IdTypeRaceColor BIGINT NULL FOREIGN KEY REFERENCES TypeRaceColor(Id),
	IdTypeProfile   BIGINT NULL FOREIGN KEY REFERENCES TypeProfile(Id),
	Password	    NVARCHAR(MAX) NOT NULL,
	ImageProfile    NVARCHAR(MAX) NULL
)

CREATE NONCLUSTERED INDEX idx_cpf ON Users (Cpf)
CREATE UNIQUE INDEX idx_unique_cpf ON Users (Cpf)

 

CREATE TABLE UserContacts
(
	Id 			  BIGINT NOT NULL IDENTITY(1,1), 
	IdUser	  	  BIGINT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	IdTypeContact BIGINT NOT NULL FOREIGN KEY REFERENCES TypeContact(Id),
	Description	  VARCHAR(50)	
)


CREATE NONCLUSTERED INDEX idx_iduser ON UserContacts  (IdUser)

CREATE TABLE UserAdresses
(
	Id 			    BIGINT NOT NULL IDENTITY(1,1), 
   	IdUser		    BIGINT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	IdTypeAddress   BIGINT NOT NULL FOREIGN KEY REFERENCES TypeAddress(Id),
	ZipCode		 	VARCHAR(50) NOT NULL,
	LocationName 	VARCHAR(50) NOT NULL,
	Number  	 	VARCHAR(50) NOT NULL,
	Complement	 	VARCHAR(100) NOT NULL,
	Neighborhood 	VARCHAR(50) NOT NULL,	
	City			VARCHAR(50) NOT NULL,
	State			VARCHAR(50) NOT NULL
)

CREATE NONCLUSTERED INDEX idx_iduser ON UserAdresses  (IdUser)
 
CREATE TABLE TokenEmail
(
	Id 			    BIGINT NOT NULL IDENTITY(1,1), 
	IdUser		    BIGINT NOT NULL FOREIGN KEY REFERENCES Users(Id), 
	Token		    NVARCHAR(MAX) NOT NULL,
	Active		    BIT DEFAULT(1) NOT NULL,
	CreationDate    DATETIME DEFAULT(GETDATE()) NOT NULL,
	ExpirationDate  DATETIME DEFAULT('19000101') NOT NULL
)

CREATE NONCLUSTERED INDEX idx_iduser ON TokenEmail  (IdUser)

 
 
 