CREATE Table animal (
    animalID INT PRIMARY Key,
    animalName varchar (20),
    animalEats varchar(20)
);

INSERT INTO animal(animalID, animalName, animalEats)
VALUES
    (1, 'cat', 'milk'),
    (2, 'dog', 'bones'),
    (3, 'elephant', 'tree');


SELECT *
FROM animal;

