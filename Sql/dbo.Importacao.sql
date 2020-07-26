CREATE TABLE [dbo].[Importacao] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [DataEntrega]   DATE            NULL,
    [NomeProduto]   NVARCHAR (50)   NULL,
    [Quantidade]    INT             NULL,
    [ValorUnitario] DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

