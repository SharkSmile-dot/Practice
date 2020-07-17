CREATE TABLE Producers
(
Id_Producer NUMERIC(10,0),
Name VARCHAR (30),
Last_Name VARCHAR(30),
Email VARCHAR(30),
CONSTRAINT PK_Producer PRIMARY KEY (Id_Producer)
);

CREATE TABLE Films
(
Id_Film NUMERIC(10,0),
Id_Producer NUMERIC(10,0) NULL,
Title VARCHAR(30),
Description VARCHAR(200),
Section VARCHAR(20),
Genre VARCHAR(30),
Year INT,
Publisher VARCHAR(30),
CONSTRAINT PK_Film PRIMARY KEY (Id_Film),
CONSTRAINT FK_FilmsProducers FOREIGN KEY (Id_Producers) REFERENCES Producers(Id_Producers)
);
																 
																 
INSERT INTO Producers(Id_Producer, Name,Last_Name,Email) VALUES(50001,'Arthur','Michigan','A.mich@gmail.com');

INSERT INTO Producers(Id_Producer, Name,Last_Name,Email) VALUES(50002,'Igor','Smolnov','i.smlnov@gmail.com');

INSERT INTO Producers(Id_Producer, Name,Last_Name,Email) VALUES(50003,'Anna','Gilbert','a.gilb@gmail.com');

INSERT INTO Producers(Id_Producer, Name,Last_Name,Email) VALUES(50004,'Mihail','Semenov','m.semenov@gmail.com');


INSERT INTO Films
(Id_Film, Id_Producer,Title,Description,Section,Genre,Year,Publisher)
VALUES(1,50004,'Clip full of sin','Dark detective about hard life in Chicago','Adults','Detective','1987','Table-Top');

INSERT INTO Films
(Id_Film, Id_Producer,Title,Description,Section,Genre,Year,Publisher)
VALUES(2,50003,'First contact','First film about space odyssey','Family','Scince fiction','1977','20YearFox');

INSERT INTO Films
(Id_Film, Id_Producer,Title,Description,Section,Genre,Year,Publisher)
VALUES(3,50001,'Travel to West','Parody on a chinese novel Travel to east ','Family','Comedy','2002','Table-Top');

INSERT INTO Films
(Id_Film, Id_Producer,Title,Description,Section,Genre,Year,Publisher)
VALUES(4,50002,'Genre not definded ','Drama about young Producer','Adults','Drama','1999','20YearFox');


INSERT INTO Films
(Id_Film, Id_Producer,Title,Description,Section,Genre,Year,Publisher)
VALUES(5,50002,'Genre not definded 2','Sequel of previous work','Adults','Drama','2004','20YearFox');

