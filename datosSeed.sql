--Insertar datos en Usuarios
INSERT INTO Usuario(Email, Password, Rol, FechaAlta, EmailAdministrador)
VALUES
('admin1@example.com', '123456', 'admin', '2024-09-09', 'admin1@example.com'),
('digit1@example.com', '123456', 'digit', '2024-09-09', 'admin1@example.com');


-- Insertar datos en la tabla Atletas
INSERT INTO Atletas (Nombre, Apellido, Pais, Sexo)
VALUES 
('John', 'Doe', 'USA', 'M'),
('Jane', 'Smith', 'UK', 'F');

-- Insertar datos en la tabla Disciplinas
INSERT INTO Disciplinas (Nombre_Disciplina, AnioDeIntegracion)
VALUES
('Carreras', 2000),
('Salto Largo', 2010);

-- Insertar datos en la tabla Eventos
-- Asumiendo que Disciplina es un campo que indica el nombre de la disciplina, si no es así, puede que se deba cambiar a 'DisciplinaId'
INSERT INTO Eventos (Nombre, Disciplina, FechaInicio, FechaFin)
VALUES
('Maratón', 'Carreras', '2024-05-01', '2024-05-05'),
('Salto Largo',  'Salto Largo', '2024-06-10', '2024-06-12');

-- Insertar datos en la tabla Paises
INSERT INTO Paises (Nombre, Delegado, TelDelegado, CantHabitantes)
VALUES
('Estados Unidos', 'John Delegado', '123-456-7890', 331000000),
('Reino Unido', 'Jane Delegada', '987-654-3210', 67000000);
