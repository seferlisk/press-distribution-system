# Press Distribution System

Github link:  https://github.com/seferlisk/press-distribution-system/tree/main/PressDistributionSystemWebApp

This is a web app that facilitates the distribution and return of press products.

        
To achieve this:
- There are two user roles (agency, distributor)
- The AGENCY can log-in and make CRUD actions in three components: Publications, Distributors and Kiosks. It can also link a kiosk to one distributor.
- The DISTRIBUTOR can log-in and create a distribution for a given publication as well as make an entry of the returns (the unsold publications).
        
## Installation

This is an Asp.Net project. To run it, you need to have Visual Studio installed. You can download it [here](https://visualstudio.microsoft.com/downloads/).

It uses entity framework to connect to an SQL Server database. The connection string is in the `appsettings.json` file. You can change it to your own database.

You can find the database initialization script in Data folder. (PressDistributionSystemInitScript.sql)

## Usage

Login as an agency user with the following credentials:

- Username: AgencyUser1@email.com
- Password: 123456
 
- Username: AgencyUser2@email.com
- Password: 123456


Login as an distributor user with the following credentials:

- Username: distributor1@email.com
- Password: 123456

- Username: distributor2@email.com
- Password: 123456

- Username: distributor3@email.com
- Password: 123456