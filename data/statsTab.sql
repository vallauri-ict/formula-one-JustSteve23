CREATE PROCEDURE [dbo].[statProc]
    @driverN int
        AS
            DECLARE @driverNumber int
            DECLARE @totalPoints int
            DECLARE @poleNumber int
            DECLARE @raceWinNumber int
            DECLARE @raceSecondNumber int
            DECLARE @raceThirdNumber int
            DECLARE @podiumNumber int
            DECLARE @fastestLapNumber int
        
        IF NOT EXISTS (select * from sysobjects where name='Stats' and xtype='U') 
            BEGIN 
                CREATE TABLE [Stats] ( 
                    [driverNumber] int NOT NULL ,
                    [totalPoints] int NOT NULL ,
                    [poleNumber] int NOT NULL ,
                    [raceWinNumber] int NOT NULL ,
                    [raceSecondNumber] int NOT NULL ,
                    [raceThirdNumber] int NOT NULL ,
                    [podiumNumber] int NOT NULL ,
                    [fastestLapNumber] int NOT NULL ,
                    PRIMARY KEY ([driverNumber])
                )
            END 

        IF EXISTS (select * from sysobjects where name='Driver' and xtype='U')  
            BEGIN 
                SELECT @totalPoints=points FROM [Driver] WHERE [Driver].driverNumber=@driverN
                SELECT @raceWinNumber=COUNT(*) FROM [GPResult] WHERE [GPResult].driverNumber=@driverN AND place='1'
                SELECT @raceSecondNumber=COUNT(*) FROM [GPResult] WHERE [GPResult].driverNumber=@driverN AND place='2' 
                SELECT @raceThirdNumber=COUNT(*) FROM [GPResult] WHERE [GPResult].driverNumber=@driverN AND place='3'
                SELECT @podiumNumber=COUNT(*) FROM [GPResult] WHERE [GPResult].driverNumber=@driverN AND place IN ('1','2','3')
                SELECT @poleNumber=COUNT(*) FROM [GPResult] WHERE [GPResult].driverNumber=@driverN AND gridPosition='1'   
                SELECT @fastestLapNumber=COUNT(*) FROM [GPResult] WHERE [GPResult].driverNumber=@driverN AND fastestLap='fastestLap'   
            END 

        IF EXISTS (select * from [Stats] WHERE driverNumber=@driverN) 
            BEGIN 
                UPDATE [Stats] SET 
                totalPoints=@totalPoints, 
                poleNumber=@poleNumber,  
                raceWinNumber=@raceWinNumber, 
                raceSecondNumber=@raceSecondNumber, 
                raceThirdNumber=@raceThirdNumber, 
                podiumNumber=@podiumNumber,
                fastestLapNumber=@fastestLapNumber 
                WHERE driverNumber=@driverN
            END 
        ELSE  
            BEGIN 
                INSERT INTO [Stats] VALUES( 
                @driverN, 
                @totalPoints, 
                @poleNumber, 
                @raceWinNumber, 
                @raceSecondNumber, 
                @raceThirdNumber,  
                @podiumNumber,
                @fastestLapNumber
                ) 
            END 

    RETURN 0;