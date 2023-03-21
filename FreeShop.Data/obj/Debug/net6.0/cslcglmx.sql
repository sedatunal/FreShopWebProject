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
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(100) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(35) NOT NULL,
    [LastName] nvarchar(35) NOT NULL,
    [Address] nvarchar(max) NULL,
    [UserType] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(60) NOT NULL,
    [Description] nvarchar(max) NULL,
    [UnitPrice] decimal(18,2) NULL,
    [UnitInStock] int NOT NULL,
    [ImagePath] nvarchar(max) NULL,
    [CategoryId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'ModifiedDate', N'Password', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Address], [CreatedDate], [Email], [FirstName], [LastName], [ModifiedDate], [Password], [UserType])
VALUES (1, NULL, '2022-11-01T17:50:58.4274501+03:00', N'admin@freshop.com', N'Sedat', N'Admin', NULL, N'123456', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'ModifiedDate', N'Password', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'ModifiedDate', N'Password', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Address], [CreatedDate], [Email], [FirstName], [LastName], [ModifiedDate], [Password], [UserType])
VALUES (2, NULL, '2022-11-01T17:50:58.4274516+03:00', N'kullanici@freeshop.com', N'Kullanici', N'KullaniciSoyad', NULL, N'654321', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'ModifiedDate', N'Password', N'UserType') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221101145058_first', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Comments] (
    [Id] int NOT NULL IDENTITY,
    [CommentText] nvarchar(250) NOT NULL,
    [ProductId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [ModifiedDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comments_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

UPDATE [Users] SET [CreatedDate] = '2022-11-07T01:03:39.8423940+03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [CreatedDate] = '2022-11-07T01:03:39.8423957+03:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Comments_ProductId] ON [Comments] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221106220340_comment', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Comments] ADD [Rate] int NOT NULL DEFAULT 0;
GO

UPDATE [Users] SET [CreatedDate] = '2022-11-07T01:16:11.7980479+03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [CreatedDate] = '2022-11-07T01:16:11.7980495+03:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221106221612_comment2', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Products] ADD [CommentId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Comments] ADD [UserId] int NOT NULL DEFAULT 0;
GO

UPDATE [Users] SET [CreatedDate] = '2022-11-07T13:43:22.4603268+03:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Users] SET [CreatedDate] = '2022-11-07T13:43:22.4603292+03:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
GO

ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221107104322_deneme3', N'6.0.10');
GO

COMMIT;
GO

