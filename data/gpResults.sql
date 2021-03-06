
CREATE TABLE [dbo].[GPResult] (
[driverNumber] int,
[teamCode] char(3) default '',
[gpID] char(4) default '',
[place] varchar(15) default '',
[fastestLap] varchar(15) default '',
[gridPosition] varchar(15) default '',
PRIMARY KEY ([driverNumber],[gpID])
);

INSERT INTO [GPResult] VALUES (44,'MER','gp1','4','','2');
INSERT INTO [GPResult] VALUES (44,'MER','gp2','1','','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp3','1','fastestLap','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp4','1','','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp5','2','fastestLap','2');
INSERT INTO [GPResult] VALUES (44,'MER','gp6','1','','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp7','1','','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp8','7','fastestLap','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp9','1','fastestLap','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp10','3','','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp11','1','','2');
INSERT INTO [GPResult] VALUES (44,'MER','gp12','1','fastestLap','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp13','1','fastestLap','2');
INSERT INTO [GPResult] VALUES (44,'MER','gp14','1','','6');
INSERT INTO [GPResult] VALUES (44,'MER','gp15','1','','1');
INSERT INTO [GPResult] VALUES (44,'MER','gp17','3','','3');

INSERT INTO [GPResult] VALUES (77,'MER','gp1','1','','1');
INSERT INTO [GPResult] VALUES (77,'MER','gp2','2','','4');
INSERT INTO [GPResult] VALUES (77,'MER','gp3','3','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp4','11','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp5','3','','1');
INSERT INTO [GPResult] VALUES (77,'MER','gp6','3','fastestLap','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp7','2','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp8','2','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp9','5','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp10','1','fastestLap','3');
INSERT INTO [GPResult] VALUES (77,'MER','gp11','DNF','','1');
INSERT INTO [GPResult] VALUES (77,'MER','gp12','2','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp13','2','','1');
INSERT INTO [GPResult] VALUES (77,'MER','gp14','14','','9');
INSERT INTO [GPResult] VALUES (77,'MER','gp15','8','','2');
INSERT INTO [GPResult] VALUES (77,'MER','gp16','8','','1');
INSERT INTO [GPResult] VALUES (77,'MER','gp17','2','','2');

INSERT INTO [GPResult] VALUES (33,'RBR','gp1','DNF','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp2','3','','2');
INSERT INTO [GPResult] VALUES (33,'RBR','gp3','2','','7');
INSERT INTO [GPResult] VALUES (33,'RBR','gp4','2','fastestLap','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp5','1','','4');
INSERT INTO [GPResult] VALUES (33,'RBR','gp6','2','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp7','3','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp8','DNF','','5');
INSERT INTO [GPResult] VALUES (33,'RBR','gp9','DNF','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp10','2','','2');
INSERT INTO [GPResult] VALUES (33,'RBR','gp11','2','fastestLap','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp12','3','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp13','DNF','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp14','6','','2');
INSERT INTO [GPResult] VALUES (33,'RBR','gp15','2','fastestLap','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp16','DNF','','3');
INSERT INTO [GPResult] VALUES (33,'RBR','gp17','1','','1');

INSERT INTO [GPResult] VALUES (23,'RBR','gp1','DNF','','5');
INSERT INTO [GPResult] VALUES (23,'RBR','gp2','4','','7');
INSERT INTO [GPResult] VALUES (23,'RBR','gp3','5','','13');
INSERT INTO [GPResult] VALUES (23,'RBR','gp4','8','','12');
INSERT INTO [GPResult] VALUES (23,'RBR','gp5','5','','9');
INSERT INTO [GPResult] VALUES (23,'RBR','gp6','8','','6');
INSERT INTO [GPResult] VALUES (23,'RBR','gp7','6','','5');
INSERT INTO [GPResult] VALUES (23,'RBR','gp8','15','','9');
INSERT INTO [GPResult] VALUES (23,'RBR','gp9','3','','4');
INSERT INTO [GPResult] VALUES (23,'RBR','gp10','10','','10');
INSERT INTO [GPResult] VALUES (23,'RBR','gp11','DNF','','5');
INSERT INTO [GPResult] VALUES (23,'RBR','gp12','12','','6');
INSERT INTO [GPResult] VALUES (23,'RBR','gp13','15','','6');
INSERT INTO [GPResult] VALUES (23,'RBR','gp14','7','','4');
INSERT INTO [GPResult] VALUES (23,'RBR','gp15','3','','4');
INSERT INTO [GPResult] VALUES (23,'RBR','gp16','6','','12');
INSERT INTO [GPResult] VALUES (23,'RBR','gp17','4','','5');

INSERT INTO [GPResult] VALUES (16,'FER','gp1','2','','7');
INSERT INTO [GPResult] VALUES (16,'FER','gp2','DNF','','11');
INSERT INTO [GPResult] VALUES (16,'FER','gp3','11','','6');
INSERT INTO [GPResult] VALUES (16,'FER','gp4','3','','4');
INSERT INTO [GPResult] VALUES (16,'FER','gp5','4','','8');
INSERT INTO [GPResult] VALUES (16,'FER','gp6','DNF','','9');
INSERT INTO [GPResult] VALUES (16,'FER','gp7','14','','13');
INSERT INTO [GPResult] VALUES (16,'FER','gp8','DNF','','13');
INSERT INTO [GPResult] VALUES (16,'FER','gp9','8','','5');
INSERT INTO [GPResult] VALUES (16,'FER','gp10','6','','11');
INSERT INTO [GPResult] VALUES (16,'FER','gp11','7','','4');
INSERT INTO [GPResult] VALUES (16,'FER','gp12','4','','4');
INSERT INTO [GPResult] VALUES (16,'FER','gp13','5','','7');
INSERT INTO [GPResult] VALUES (16,'FER','gp14','4','','14');
INSERT INTO [GPResult] VALUES (16,'FER','gp15','10','','12');
INSERT INTO [GPResult] VALUES (16,'FER','gp16','DNF','','4');
INSERT INTO [GPResult] VALUES (16,'FER','gp17','13','','9');

INSERT INTO [GPResult] VALUES (5,'FER','gp1','10','','11');
INSERT INTO [GPResult] VALUES (5,'FER','gp2','DNF','','10');
INSERT INTO [GPResult] VALUES (5,'FER','gp3','6','','5');
INSERT INTO [GPResult] VALUES (5,'FER','gp4','10','','10');
INSERT INTO [GPResult] VALUES (5,'FER','gp5','12','','12');
INSERT INTO [GPResult] VALUES (5,'FER','gp6','7','','11');
INSERT INTO [GPResult] VALUES (5,'FER','gp7','13','','14');
INSERT INTO [GPResult] VALUES (5,'FER','gp8','DNF','','17');
INSERT INTO [GPResult] VALUES (5,'FER','gp9','10','','14');
INSERT INTO [GPResult] VALUES (5,'FER','gp10','9','','15');
INSERT INTO [GPResult] VALUES (5,'FER','gp11','11','','11');
INSERT INTO [GPResult] VALUES (5,'FER','gp12','10','','15');
INSERT INTO [GPResult] VALUES (5,'FER','gp13','12','','14');
INSERT INTO [GPResult] VALUES (5,'FER','gp14','3','','12');
INSERT INTO [GPResult] VALUES (5,'FER','gp15','13','','11');
INSERT INTO [GPResult] VALUES (5,'FER','gp16','12','','13');
INSERT INTO [GPResult] VALUES (5,'FER','gp17','14','','13');

INSERT INTO [GPResult] VALUES (55,'MCL','gp1','5','','8');
INSERT INTO [GPResult] VALUES (55,'MCL','gp2','9','fastestLap','3');
INSERT INTO [GPResult] VALUES (55,'MCL','gp3','9','','9');
INSERT INTO [GPResult] VALUES (55,'MCL','gp4','13','','7');
INSERT INTO [GPResult] VALUES (55,'MCL','gp5','13','','13');
INSERT INTO [GPResult] VALUES (55,'MCL','gp6','6','','7');
INSERT INTO [GPResult] VALUES (55,'MCL','gp7','DNF','','7');
INSERT INTO [GPResult] VALUES (55,'MCL','gp8','2','','3');
INSERT INTO [GPResult] VALUES (55,'MCL','gp9','DNF','','9');
INSERT INTO [GPResult] VALUES (55,'MCL','gp10','DNF','','6');
INSERT INTO [GPResult] VALUES (55,'MCL','gp11','5','','10');
INSERT INTO [GPResult] VALUES (55,'MCL','gp12','6','','7');
INSERT INTO [GPResult] VALUES (55,'MCL','gp13','7','','10');
INSERT INTO [GPResult] VALUES (55,'MCL','gp14','5','','13');
INSERT INTO [GPResult] VALUES (55,'MCL','gp15','5','','15');
INSERT INTO [GPResult] VALUES (55,'MCL','gp16','4','','8');
INSERT INTO [GPResult] VALUES (55,'MCL','gp17','6','','6');

INSERT INTO [GPResult] VALUES (4,'MCL','gp1','3','fastestLap','4');
INSERT INTO [GPResult] VALUES (4,'MCL','gp2','5','','6');
INSERT INTO [GPResult] VALUES (4,'MCL','gp3','13','','8');
INSERT INTO [GPResult] VALUES (4,'MCL','gp4','5','','5');
INSERT INTO [GPResult] VALUES (4,'MCL','gp5','9','','10');
INSERT INTO [GPResult] VALUES (4,'MCL','gp6','10','','8');
INSERT INTO [GPResult] VALUES (4,'MCL','gp7','7','','10');
INSERT INTO [GPResult] VALUES (4,'MCL','gp8','4','','6');
INSERT INTO [GPResult] VALUES (4,'MCL','gp9','6','','11');
INSERT INTO [GPResult] VALUES (4,'MCL','gp10','15','','8');
INSERT INTO [GPResult] VALUES (4,'MCL','gp11','DNF','','8');
INSERT INTO [GPResult] VALUES (4,'MCL','gp12','13','','8');
INSERT INTO [GPResult] VALUES (4,'MCL','gp13','8','','9');
INSERT INTO [GPResult] VALUES (4,'MCL','gp14','8','fastestLap','11');
INSERT INTO [GPResult] VALUES (4,'MCL','gp15','4','','9');
INSERT INTO [GPResult] VALUES (4,'MCL','gp16','10','','15');
INSERT INTO [GPResult] VALUES (4,'MCL','gp17','5','','4');

INSERT INTO [GPResult] VALUES (11,'RPT','gp1','6','','6');
INSERT INTO [GPResult] VALUES (11,'RPT','gp2','6','','17');
INSERT INTO [GPResult] VALUES (11,'RPT','gp3','7','','4');
INSERT INTO [GPResult] VALUES (11,'RPT','gp6','5','','4');
INSERT INTO [GPResult] VALUES (11,'RPT','gp7','10','','8');
INSERT INTO [GPResult] VALUES (11,'RPT','gp8','10','','4');
INSERT INTO [GPResult] VALUES (11,'RPT','gp9','5','','6');
INSERT INTO [GPResult] VALUES (11,'RPT','gp10','4','','4');
INSERT INTO [GPResult] VALUES (11,'RPT','gp11','4','','9');
INSERT INTO [GPResult] VALUES (11,'RPT','gp12','7','','5');
INSERT INTO [GPResult] VALUES (11,'RPT','gp13','6','','11');
INSERT INTO [GPResult] VALUES (11,'RPT','gp14','2','','3');
INSERT INTO [GPResult] VALUES (11,'RPT','gp15','DNF','','5');
INSERT INTO [GPResult] VALUES (11,'RPT','gp16','1','','5');
INSERT INTO [GPResult] VALUES (11,'RPT','gp17','DNF','','15');

INSERT INTO [GPResult] VALUES (18,'RPT','gp1','DNF','','9');
INSERT INTO [GPResult] VALUES (18,'RPT','gp2','7','','13');
INSERT INTO [GPResult] VALUES (18,'RPT','gp3','4','','3');
INSERT INTO [GPResult] VALUES (18,'RPT','gp4','9','','6');
INSERT INTO [GPResult] VALUES (18,'RPT','gp5','6','','6');
INSERT INTO [GPResult] VALUES (18,'RPT','gp6','4','','5');
INSERT INTO [GPResult] VALUES (18,'RPT','gp7','9','','9');
INSERT INTO [GPResult] VALUES (18,'RPT','gp8','3','','8');
INSERT INTO [GPResult] VALUES (18,'RPT','gp9','DNF','','7');
INSERT INTO [GPResult] VALUES (18,'RPT','gp10','DNF','','13');
INSERT INTO [GPResult] VALUES (18,'RPT','gp12','DNF','','12');
INSERT INTO [GPResult] VALUES (18,'RPT','gp13','13','','15');
INSERT INTO [GPResult] VALUES (18,'RPT','gp14','9','','1');
INSERT INTO [GPResult] VALUES (18,'RPT','gp15','DNF','','13');
INSERT INTO [GPResult] VALUES (18,'RPT','gp16','3','','10');
INSERT INTO [GPResult] VALUES (18,'RPT','gp17','10','','8');

INSERT INTO [GPResult] VALUES (3,'REN','gp1','DNF','','10');
INSERT INTO [GPResult] VALUES (3,'REN','gp2','8','','9');
INSERT INTO [GPResult] VALUES (3,'REN','gp3','8','','11');
INSERT INTO [GPResult] VALUES (3,'REN','gp4','4','','8');
INSERT INTO [GPResult] VALUES (3,'REN','gp5','14','','5');
INSERT INTO [GPResult] VALUES (3,'REN','gp6','11','','13');
INSERT INTO [GPResult] VALUES (3,'REN','gp7','4','fastestLap','4');
INSERT INTO [GPResult] VALUES (3,'REN','gp8','6','','7');
INSERT INTO [GPResult] VALUES (3,'REN','gp9','4','','8');
INSERT INTO [GPResult] VALUES (3,'REN','gp10','5','','5');
INSERT INTO [GPResult] VALUES (3,'REN','gp11','3','','6');
INSERT INTO [GPResult] VALUES (3,'REN','gp12','9','','10');
INSERT INTO [GPResult] VALUES (3,'REN','gp13','3','','5');
INSERT INTO [GPResult] VALUES (3,'REN','gp14','10','','5');
INSERT INTO [GPResult] VALUES (3,'REN','gp15','7','','6');
INSERT INTO [GPResult] VALUES (3,'REN','gp16','5','','7');
INSERT INTO [GPResult] VALUES (3,'REN','gp17','7','fastestLap','12');

INSERT INTO [GPResult] VALUES (31,'REN','gp1','8','','14');
INSERT INTO [GPResult] VALUES (31,'REN','gp2','DNF','','5');
INSERT INTO [GPResult] VALUES (31,'REN','gp3','14','','14');
INSERT INTO [GPResult] VALUES (31,'REN','gp4','6','','9');
INSERT INTO [GPResult] VALUES (31,'REN','gp5','8','','11');
INSERT INTO [GPResult] VALUES (31,'REN','gp6','13','','15');
INSERT INTO [GPResult] VALUES (31,'REN','gp7','5','','6');
INSERT INTO [GPResult] VALUES (31,'REN','gp8','8','','12');
INSERT INTO [GPResult] VALUES (31,'REN','gp9','DNF','','10');
INSERT INTO [GPResult] VALUES (31,'REN','gp10','7','','7');
INSERT INTO [GPResult] VALUES (31,'REN','gp11','DNF','','7');
INSERT INTO [GPResult] VALUES (31,'REN','gp12','8','','11');
INSERT INTO [GPResult] VALUES (31,'REN','gp13','DNF','','12');
INSERT INTO [GPResult] VALUES (31,'REN','gp14','11','','7');
INSERT INTO [GPResult] VALUES (31,'REN','gp15','9','','7');
INSERT INTO [GPResult] VALUES (31,'REN','gp16','3','','11');
INSERT INTO [GPResult] VALUES (31,'REN','gp17','9','','11');

INSERT INTO [GPResult] VALUES (10,'ATR','gp1','7','','12');
INSERT INTO [GPResult] VALUES (10,'ATR','gp2','15','','8');
INSERT INTO [GPResult] VALUES (10,'ATR','gp3','DNF','','10');
INSERT INTO [GPResult] VALUES (10,'ATR','gp4','7','','11');
INSERT INTO [GPResult] VALUES (10,'ATR','gp5','11','','7');
INSERT INTO [GPResult] VALUES (10,'ATR','gp6','9','','10');
INSERT INTO [GPResult] VALUES (10,'ATR','gp7','8','','12');
INSERT INTO [GPResult] VALUES (10,'ATR','gp8','1','','10');
INSERT INTO [GPResult] VALUES (10,'ATR','gp9','DNF','','16');
INSERT INTO [GPResult] VALUES (10,'ATR','gp10','9','','9');
INSERT INTO [GPResult] VALUES (10,'ATR','gp11','6','','12');
INSERT INTO [GPResult] VALUES (10,'ATR','gp12','5','','9');
INSERT INTO [GPResult] VALUES (10,'ATR','gp13','DNF','','4');
INSERT INTO [GPResult] VALUES (10,'ATR','gp14','13','','15');
INSERT INTO [GPResult] VALUES (10,'ATR','gp15','6','','8');
INSERT INTO [GPResult] VALUES (10,'ATR','gp16','11','','9');
INSERT INTO [GPResult] VALUES (10,'ATR','gp17','8','','10');

INSERT INTO [GPResult] VALUES (26,'ATR','gp1','DNF','','13');
INSERT INTO [GPResult] VALUES (26,'ATR','gp2','10','','14');
INSERT INTO [GPResult] VALUES (26,'ATR','gp3','12','','17');
INSERT INTO [GPResult] VALUES (26,'ATR','gp4','DNF','','14');
INSERT INTO [GPResult] VALUES (26,'ATR','gp5','10','','16');
INSERT INTO [GPResult] VALUES (26,'ATR','gp6','12','','12');
INSERT INTO [GPResult] VALUES (26,'ATR','gp7','11','','11');
INSERT INTO [GPResult] VALUES (26,'ATR','gp8','9','','11');
INSERT INTO [GPResult] VALUES (26,'ATR','gp9','7','','12');
INSERT INTO [GPResult] VALUES (26,'ATR','gp10','8','','12');
INSERT INTO [GPResult] VALUES (26,'ATR','gp11','15','','13');
INSERT INTO [GPResult] VALUES (26,'ATR','gp12','19','','13');
INSERT INTO [GPResult] VALUES (26,'ATR','gp13','4','','8');
INSERT INTO [GPResult] VALUES (26,'ATR','gp14','12','','17');
INSERT INTO [GPResult] VALUES (26,'ATR','gp15','11','','10');
INSERT INTO [GPResult] VALUES (26,'ATR','gp16','7','','6');
INSERT INTO [GPResult] VALUES (26,'ATR','gp17','11','','7');

INSERT INTO [GPResult] VALUES (7,'ARR','gp1','DNF','','19');
INSERT INTO [GPResult] VALUES (7,'ARR','gp2','11','','16');
INSERT INTO [GPResult] VALUES (7,'ARR','gp3','15','','20');
INSERT INTO [GPResult] VALUES (7,'ARR','gp4','17','','18');
INSERT INTO [GPResult] VALUES (7,'ARR','gp5','15','','20');
INSERT INTO [GPResult] VALUES (7,'ARR','gp6','14','','14');
INSERT INTO [GPResult] VALUES (7,'ARR','gp7','12','','16');
INSERT INTO [GPResult] VALUES (7,'ARR','gp8','13','','14');
INSERT INTO [GPResult] VALUES (7,'ARR','gp9','9','','13');
INSERT INTO [GPResult] VALUES (7,'ARR','gp10','14','','20');
INSERT INTO [GPResult] VALUES (7,'ARR','gp11','12','','19');
INSERT INTO [GPResult] VALUES (7,'ARR','gp12','11','','16');
INSERT INTO [GPResult] VALUES (7,'ARR','gp13','9','','18');
INSERT INTO [GPResult] VALUES (7,'ARR','gp14','15','','8');
INSERT INTO [GPResult] VALUES (7,'ARR','gp15','15','','17');
INSERT INTO [GPResult] VALUES (7,'ARR','gp16','14','','19');
INSERT INTO [GPResult] VALUES (7,'ARR','gp17','12','','16');

INSERT INTO [GPResult] VALUES (99,'ARR','gp1','9','','18');
INSERT INTO [GPResult] VALUES (99,'ARR','gp2','14','','19');
INSERT INTO [GPResult] VALUES (99,'ARR','gp3','17','','19');
INSERT INTO [GPResult] VALUES (99,'ARR','gp4','14','','17');
INSERT INTO [GPResult] VALUES (99,'ARR','gp5','17','','19');
INSERT INTO [GPResult] VALUES (99,'ARR','gp6','16','','20');
INSERT INTO [GPResult] VALUES (99,'ARR','gp7','DNF','','18');
INSERT INTO [GPResult] VALUES (99,'ARR','gp8','16','','18');
INSERT INTO [GPResult] VALUES (99,'ARR','gp9','DNF','','17');
INSERT INTO [GPResult] VALUES (99,'ARR','gp10','11','','17');
INSERT INTO [GPResult] VALUES (99,'ARR','gp11','10','','14');
INSERT INTO [GPResult] VALUES (99,'ARR','gp12','15','','17');
INSERT INTO [GPResult] VALUES (99,'ARR','gp13','10','','20');
INSERT INTO [GPResult] VALUES (99,'ARR','gp14','DNF','','10');
INSERT INTO [GPResult] VALUES (99,'ARR','gp15','16','','16');
INSERT INTO [GPResult] VALUES (99,'ARR','gp16','13','','14');
INSERT INTO [GPResult] VALUES (99,'ARR','gp17','16','','14');

INSERT INTO [GPResult] VALUES (20,'HAS','gp1','DNF','','16');
INSERT INTO [GPResult] VALUES (20,'HAS','gp2','12','','15');
INSERT INTO [GPResult] VALUES (20,'HAS','gp3','10','','16');
INSERT INTO [GPResult] VALUES (20,'HAS','gp4','DNF','','16');
INSERT INTO [GPResult] VALUES (20,'HAS','gp5','DNF','','17');
INSERT INTO [GPResult] VALUES (20,'HAS','gp6','15','','16');
INSERT INTO [GPResult] VALUES (20,'HAS','gp7','17','','20');
INSERT INTO [GPResult] VALUES (20,'HAS','gp8','DNF','','15');
INSERT INTO [GPResult] VALUES (20,'HAS','gp9','DNF','','20');
INSERT INTO [GPResult] VALUES (20,'HAS','gp10','12','','18');
INSERT INTO [GPResult] VALUES (20,'HAS','gp11','13','','15');
INSERT INTO [GPResult] VALUES (20,'HAS','gp12','16','','19');
INSERT INTO [GPResult] VALUES (20,'HAS','gp13','DNF','','17');
INSERT INTO [GPResult] VALUES (20,'HAS','gp14','DNF','','16');
INSERT INTO [GPResult] VALUES (20,'HAS','gp15','17','','18');
INSERT INTO [GPResult] VALUES (20,'HAS','gp16','15','','16');
INSERT INTO [GPResult] VALUES (20,'HAS','gp17','18','','17');

INSERT INTO [GPResult] VALUES (8,'HAS','gp1','DNF','','15');
INSERT INTO [GPResult] VALUES (8,'HAS','gp2','13','','20');
INSERT INTO [GPResult] VALUES (8,'HAS','gp3','16','','18');
INSERT INTO [GPResult] VALUES (8,'HAS','gp4','16','','19');
INSERT INTO [GPResult] VALUES (8,'HAS','gp5','16','','14');
INSERT INTO [GPResult] VALUES (8,'HAS','gp6','19','','17');
INSERT INTO [GPResult] VALUES (8,'HAS','gp7','15','','17');
INSERT INTO [GPResult] VALUES (8,'HAS','gp8','12','','16');
INSERT INTO [GPResult] VALUES (8,'HAS','gp9','12','','15');
INSERT INTO [GPResult] VALUES (8,'HAS','gp10','17','','16');
INSERT INTO [GPResult] VALUES (8,'HAS','gp11','9','','16');
INSERT INTO [GPResult] VALUES (8,'HAS','gp12','17','','18');
INSERT INTO [GPResult] VALUES (8,'HAS','gp13','14','','16');
INSERT INTO [GPResult] VALUES (8,'HAS','gp14','DNF','','19');
INSERT INTO [GPResult] VALUES (8,'HAS','gp15','DNF','','19');

INSERT INTO [GPResult] VALUES (63,'WLR','gp1','DNF','','17');
INSERT INTO [GPResult] VALUES (63,'WLR','gp2','16','','12');
INSERT INTO [GPResult] VALUES (63,'WLR','gp3','18','','12');
INSERT INTO [GPResult] VALUES (63,'WLR','gp4','12','','15');
INSERT INTO [GPResult] VALUES (63,'WLR','gp5','18','','15');
INSERT INTO [GPResult] VALUES (63,'WLR','gp6','17','','18');
INSERT INTO [GPResult] VALUES (63,'WLR','gp7','DNF','','15');
INSERT INTO [GPResult] VALUES (63,'WLR','gp8','14','','19');
INSERT INTO [GPResult] VALUES (63,'WLR','gp9','11','','18');
INSERT INTO [GPResult] VALUES (63,'WLR','gp10','18','','14');
INSERT INTO [GPResult] VALUES (63,'WLR','gp11','DNF','','17');
INSERT INTO [GPResult] VALUES (63,'WLR','gp12','14','','14');
INSERT INTO [GPResult] VALUES (63,'WLR','gp13','DNF','','13');
INSERT INTO [GPResult] VALUES (63,'WLR','gp14','16','','18');
INSERT INTO [GPResult] VALUES (63,'WLR','gp15','13','','14');
INSERT INTO [GPResult] VALUES (63,'MER','gp16','9','fastestLap','2');
INSERT INTO [GPResult] VALUES (63,'WLR','gp17','15','','18');

INSERT INTO [GPResult] VALUES (6,'WLR','gp1','11','','20');
INSERT INTO [GPResult] VALUES (6,'WLR','gp2','17','','18');
INSERT INTO [GPResult] VALUES (6,'WLR','gp3','19','','15');
INSERT INTO [GPResult] VALUES (6,'WLR','gp4','15','','20');
INSERT INTO [GPResult] VALUES (6,'WLR','gp5','19','','18');
INSERT INTO [GPResult] VALUES (6,'WLR','gp6','18','','19');
INSERT INTO [GPResult] VALUES (6,'WLR','gp7','16','','19');
INSERT INTO [GPResult] VALUES (6,'WLR','gp8','11','','20');
INSERT INTO [GPResult] VALUES (6,'WLR','gp9','DNF','','19');
INSERT INTO [GPResult] VALUES (6,'WLR','gp10','16','','19');
INSERT INTO [GPResult] VALUES (6,'WLR','gp11','14','','18');
INSERT INTO [GPResult] VALUES (6,'WLR','gp12','18','','20');
INSERT INTO [GPResult] VALUES (6,'WLR','gp13','11','','19');
INSERT INTO [GPResult] VALUES (6,'WLR','gp14','DNF','','20');
INSERT INTO [GPResult] VALUES (6,'WLR','gp15','14','','20');
INSERT INTO [GPResult] VALUES (6,'WLR','gp16','DNF','','17');
INSERT INTO [GPResult] VALUES (6,'WLR','gp17','17','','20');

INSERT INTO [GPResult] VALUES (27,'RPT','gp4','DNF','','13');
INSERT INTO [GPResult] VALUES (27,'RPT','gp5','7','','3');
INSERT INTO [GPResult] VALUES (27,'RPT','gp11','8','','20');

INSERT INTO [GPResult] VALUES (89,'WLR','gp16','16','','18');

INSERT INTO [GPResult] VALUES (51,'HAS','gp16','17','','20');
INSERT INTO [GPResult] VALUES (51,'HAS','gp17','19','','19');

