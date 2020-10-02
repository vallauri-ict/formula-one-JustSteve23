CREATE TABLE [dbo].[Team] (
[teamCode] char(3) NOT NULL default '',
[teamFullName] varchar(130) NOT NULL default '',
[teamChief] varchar(100) NOT NULL default '',
[teamPowerUnit] varchar(100) NOT NULL default '',
[teamFirstEntryYear] int NOT NULL ,
[teamHQPlace] varchar(70) NOT NULL default '',
[nationCode] char(2) NOT NULL default '',
PRIMARY KEY ([teamCode])
);

INSERT INTO [Team] VALUES ('MER','Mercedes-AMG Petronas F1 Team','Toto Wolff','Mercedes',1970,'Brackley','GB');
INSERT INTO [Team] VALUES ('RBR','Aston Martin Red Bull Racing','Christian Horner','Honda',1997,'Milton Keynes','GB');
INSERT INTO [Team] VALUES ('FER','Scuderia Ferrari Mission Winnow','Mattia Binotto','Ferrari',1950,'Maranello','IT');
INSERT INTO [Team] VALUES ('MCL','McLaren F1 Team','Andreas Seidl','Renault',1966,'Woking','GB');
INSERT INTO [Team] VALUES ('RPT','BWT Racing Point F1 Team','Otmar Szafnauer','Mercedes',2019,'Silverstone','GB');
INSERT INTO [Team] VALUES ('REN','Renault DP World F1 Team','Cyril Abiteboul','Renault',1986,'Enstone','GB');
INSERT INTO [Team] VALUES ('ATR','Scuderia Alpha Tauri','Franz Tost','Honda',2020,'Faenza','IT');
INSERT INTO [Team] VALUES ('ARR','Alfa Romeo Racing ORLEAN','Frédéroc Vasseur','Ferrari',1993,'Hinwil','CH');
INSERT INTO [Team] VALUES ('HAS','Haas F1 Team','Guenther Steiner','Ferrari',2016,'Kannapolis','US');
INSERT INTO [Team] VALUES ('WLR','Williams Racing','Simon Roberts','Mercedes',1978,'Grove','GB');







