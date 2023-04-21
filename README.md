### About:
This solution contains two projects. One project for the WCF Service that is connected to the SQL database, and another one for the WebAPI that serves as the WCF's consumer.
This serves as an example of using WCF service in a .Net project.

### Setup:
##### Pre-requisites:
1. SSMS and SQL server developer edition
2. Visual Studio (VS 2019 is used during my development)

##### Local Setup:
1. Clone the repository
2. TODO: DB instruction
3. TODO: startup projects

---
### Testing:
TODO

---
### Database:
```sql
USE [master]
GO
/****** Object:  Database [WcfDatabase]    Script Date: 4/21/2023 6:40:51 PM ******/
CREATE DATABASE [WcfDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WcfDatabase', FILENAME = N'C:\SQLDB\Data\WcfDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WcfDatabase_log', FILENAME = N'C:\SQLDB\Log\WcfDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WcfDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WcfDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WcfDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WcfDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WcfDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WcfDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WcfDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [WcfDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WcfDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WcfDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WcfDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WcfDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WcfDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WcfDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WcfDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WcfDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WcfDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WcfDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WcfDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WcfDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WcfDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WcfDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WcfDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WcfDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WcfDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [WcfDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [WcfDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WcfDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WcfDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WcfDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WcfDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WcfDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WcfDatabase', N'ON'
GO
ALTER DATABASE [WcfDatabase] SET QUERY_STORE = OFF
GO
USE [WcfDatabase]
GO
/****** Object:  User [dev_user]    Script Date: 4/21/2023 6:40:51 PM ******/
CREATE USER [dev_user] FOR LOGIN [dev_user] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dev_user]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/21/2023 6:40:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[EnrollmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK__User__3214EC075A5ED006] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [EnrollmentDate]) VALUES (1, N'Rommel', N'Rueco', N'rommel.rueco', N'test1', CAST(N'2023-04-17T18:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [EnrollmentDate]) VALUES (2, N'John', N'Doe', N'john.doe', N'test', CAST(N'2023-04-18T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [WcfDatabase] SET  READ_WRITE 
GO

```

---
### References:

1. Creating WCF Service:
    - https://dev.to/esdanielgomez/working-with-wcf-services-through-asp-net-and-dotvvm-a-step-by-step-guide-34f8

2. Consuming the Service using .Net 5:
	- Using Connected Services:
	https://www.thecodebuzz.com/consuming-wcf-web-services-in-net-core-best-practices/
