CREATE TABLE [dbo].[customer] (
    [customerID]          INT           NOT NULL,
    [customerFirstName]   NVARCHAR (50) NULL,
    [customerLastName]    NVARCHAR (50) NULL,
    [customerPhoneNumber] INT           NULL,
    CONSTRAINT [PK_cusotmers] PRIMARY KEY CLUSTERED ([customerID] ASC)
);

