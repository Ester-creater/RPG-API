IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_PERSONAGENS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [PontosVida] int NOT NULL,
    [Forca] int NOT NULL,
    [Defesa] int NOT NULL,
    [Inteligencia] int NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_TB_PERSONAGENS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'PontosVida') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGENS]'))
    SET IDENTITY_INSERT [TB_PERSONAGENS] ON;
INSERT INTO [TB_PERSONAGENS] ([Id], [Classe], [Defesa], [Forca], [Inteligencia], [Nome], [PontosVida])
VALUES (1, 1, 23, 17, 33, 'Frodo', 100),
(2, 1, 25, 15, 30, 'Sam', 100),
(3, 3, 21, 18, 35, 'Galadriel', 100),
(4, 2, 18, 18, 37, 'Gandalf', 100),
(5, 1, 17, 20, 31, 'Hobbit', 100),
(6, 3, 13, 21, 34, 'Celeborn', 100),
(7, 2, 11, 25, 35, 'Radagast', 100);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'PontosVida') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGENS]'))
    SET IDENTITY_INSERT [TB_PERSONAGENS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250911010550_InitialCreate', N'9.0.9');

CREATE TABLE [TB_ARMAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_TB_ARMAS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] ON;
INSERT INTO [TB_ARMAS] ([Id], [Dano], [Nome])
VALUES (1, 30, 'Facão'),
(2, 120, 'Scar'),
(3, 100, 'Mp40'),
(4, 140, 'Groza'),
(5, 135, 'Rambona'),
(6, 120, 'Ak47'),
(7, 110, 'Thompson');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_ARMAS]'))
    SET IDENTITY_INSERT [TB_ARMAS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250924010805_MigracaoArma', N'9.0.9');

COMMIT;
GO

