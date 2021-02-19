CREATE TABLE [dbo].[Employee] (
    [Id]           INT        NOT NULL IDENTITY,
    [EmployeeId]   INT        NOT NULL,
    [FirstName]    NCHAR (50) NOT NULL,
    [LastName]     NCHAR (50) NOT NULL,
    [EmailAddress] NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

