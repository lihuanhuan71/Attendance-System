CREATE TABLE [dbo].[Table] (
    [Id]       INT       NOT NULL,
    [name]     CHAR (3)  NULL,
    [password] INT       NULL,
    [mac]      CHAR (48) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

