CREATE TABLE [dbo].[Telefone]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Numero] VARCHAR(20) NOT NULL, 
	[ContatoId] INT NOT NULL, 
    CONSTRAINT [PK_Telefone] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Telefone_Contato] FOREIGN KEY ([ContatoId]) REFERENCES [Contato]([Id])
)
