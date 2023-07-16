-- Create the database
CREATE DATABASE [elibraryDB]
GO

USE [elibraryDB]
GO

-- Create the admin_login_tbl table
CREATE TABLE [dbo].[admin_login_tbl](
    [username] [nvarchar](50) NOT NULL,
    [password] [nvarchar](50) NULL,
    [full_name] [nvarchar](50) NULL,
    CONSTRAINT [PK_admin_login_tbl] PRIMARY KEY CLUSTERED ([username] ASC)
) ON [PRIMARY]
GO

-- Create the author_master_tbl table
CREATE TABLE [dbo].[author_master_tbl](
    [author_id] [nvarchar](20) NOT NULL,
    [author_name] [nvarchar](50) NULL,
    CONSTRAINT [PK_author_master_tbl] PRIMARY KEY CLUSTERED ([author_id] ASC)
) ON [PRIMARY]
GO

-- Create the book_issue_tbl table
CREATE TABLE [dbo].[book_issue_tbl](
    [member_id] [nvarchar](50) NULL,
    [member_name] [nvarchar](50) NULL,
    [book_id] [nvarchar](50) NULL,
    [book_name] [nvarchar](max) NULL,
    [issue_date] [nvarchar](50) NOT NULL,
    [due_date] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Create the book_master_table table
CREATE TABLE [dbo].[book_master_table](
    [book_id] [nchar](10) NOT NULL,
    [book_name] [nvarchar](max) NULL,
    [genre] [nvarchar](max) NULL,
    [author_name] [nvarchar](max) NULL,
    [publisher_name] [nvarchar](max) NULL,
    [publish_date] [nvarchar](50) NULL,
    [language] [nvarchar](50) NULL,
    [edition] [nvarchar](max) NULL,
    [book_cost] [nchar](10) NULL,
    [no_of_pages] [nchar](10) NULL,
    [book_description] [nvarchar](max) NULL,
    [actual_stock] [nchar](10) NULL,
    [current_stock] [nchar](10) NULL,
    [book_img_link] [nvarchar](max) NULL,
    CONSTRAINT [PK_book_master_table] PRIMARY KEY CLUSTERED ([book_id] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Create the member_master_tbl table
CREATE TABLE [dbo].[member_master_tbl](
    [full_name] [nvarchar](50) NULL,
    [dob] [nvarchar](50) NULL,
    [contact_no] [nvarchar](50) NULL,
    [email] [nvarchar](50) NULL,
    [state] [nvarchar](50) NULL,
    [city] [nvarchar](50) NULL,
    [pincode] [nvarchar](50) NULL,
    [full_address] [nvarchar](max) NULL,
    [member_id] [nvarchar](50) NOT NULL,
    [password] [nvarchar](50) NULL,
    [account_status] [nvarchar](50) NULL,
    CONSTRAINT [PK_member_master_tbl] PRIMARY KEY CLUSTERED ([member_id] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Create the publisher_master_tbl table
CREATE TABLE [dbo].[publisher_master_tbl](
    [publisher_id] [nchar](10) NOT NULL,
    [publisher_name] [nvarchar](max) NULL,
    CONSTRAINT [PK_publisher_master_tbl] PRIMARY KEY CLUSTERED ([publisher_id] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Add check constraints and modifications

-- Check constraint on book_master_table (book_cost should be a positive value)
ALTER TABLE [dbo].[book_master_table] ADD CONSTRAINT [CK_book_master_table_book_cost] CHECK (CAST([book_cost] AS INT) >= 0)
GO

-- Check constraint on book_master_table (no_of_pages should be a positive value)
ALTER TABLE [dbo].[book_master_table] ADD CONSTRAINT [CK_book_master_table_no_of_pages] CHECK (CAST([no_of_pages] AS INT) > 0)
GO

-- Check constraint on member_master_tbl (contact_no should be a valid phone number format)
ALTER TABLE [dbo].[member_master_tbl] ADD CONSTRAINT [CK_member_master_tbl_contact_no] CHECK (
    [contact_no] LIKE '03[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    OR [contact_no] LIKE '+923[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
)
GO

-- Check constraint on member_master_tbl (email should be a valid email address format)
ALTER TABLE [dbo].[member_master_tbl] ADD CONSTRAINT [CK_member_master_tbl_email] CHECK (
    LEN([email]) > 0 AND [email] LIKE '%@%.%'
)
GO

-- Check constraint on member_master_tbl (pincode should be a valid 6-digit numeric code)
ALTER TABLE [dbo].[member_master_tbl] ADD CONSTRAINT [CK_member_master_tbl_pincode] CHECK (
    ISNUMERIC([pincode]) = 1 AND LEN([pincode]) = 6
)
GO

-- Check constraint on book_issue_tbl (issue_date should be in the correct format)
ALTER TABLE [dbo].[book_issue_tbl] ADD CONSTRAINT [CK_book_issue_tbl_issue_date] CHECK (
    LEN([issue_date]) = 10 AND [issue_date] LIKE '_--_'
)
GO

-- Check constraint on book_issue_tbl (due_date should be in the correct format)
ALTER TABLE [dbo].[book_issue_tbl] ADD CONSTRAINT [CK_book_issue_tbl_due_date] CHECK (
    LEN([due_date]) = 10 AND [due_date] LIKE '_--_'
)
GO

-- Add necessary joins

-- Join between book_master_table and author_master_tbl
ALTER TABLE [dbo].[book_master_table] ADD CONSTRAINT [FK_book_master_table_author_master_tbl] FOREIGN KEY ([author_name]) 
    REFERENCES [dbo].[author_master_tbl] ([author_name])
GO

-- Join between book_master_table and publisher_master_tbl
ALTER TABLE [dbo].[book_master_table] ADD CONSTRAINT [FK_book_master_table_publisher_master_tbl] FOREIGN KEY ([publisher_name]) 
    REFERENCES [dbo].[publisher_master_tbl] ([publisher_name])
GO

-- Join between book_issue_tbl and member_master_tbl
ALTER TABLE [dbo].[book_issue_tbl] ADD CONSTRAINT [FK_book_issue_tbl_member_master_tbl] FOREIGN KEY ([member_id]) 
    REFERENCES [dbo].[member_master_tbl] ([member_id])
GO

-- Join between book_issue_tbl and book_master_table
ALTER TABLE [dbo].[book_issue_tbl] ADD CONSTRAINT [FK_book_issue_tbl_book_master_table] FOREIGN KEY ([book_id]) 
    REFERENCES [dbo].[book_master_table] ([book_id])
GO