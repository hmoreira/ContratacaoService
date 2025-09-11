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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250908203631_InitialCreate'
)
BEGIN
    CREATE TABLE [Contratos] (
        [Id] uniqueidentifier NOT NULL,
        [PropostaId] uniqueidentifier NOT NULL,
        [DataContratacao] datetime2 NOT NULL,
        [StatusContratacao] smallint NOT NULL,
        [DadosCliente_ClienteId] uniqueidentifier NOT NULL,
        [DadosCliente_Nome] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Contratos] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250908203631_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250908203631_InitialCreate', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910130055_AdicionarConstrutorPadrao'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contratos]') AND [c].[name] = N'DadosCliente_ClienteId');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Contratos] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Contratos] DROP COLUMN [DadosCliente_ClienteId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910130055_AdicionarConstrutorPadrao'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contratos]') AND [c].[name] = N'DadosCliente_Nome');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Contratos] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Contratos] DROP COLUMN [DadosCliente_Nome];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910130055_AdicionarConstrutorPadrao'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250910130055_AdicionarConstrutorPadrao', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910132609_RemocaoStatusContratacao'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contratos]') AND [c].[name] = N'StatusContratacao');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Contratos] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Contratos] DROP COLUMN [StatusContratacao];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910132609_RemocaoStatusContratacao'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250910132609_RemocaoStatusContratacao', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250911185017_InitialContratoDb'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250911185017_InitialContratoDb', N'9.0.9');
END;

COMMIT;
GO

