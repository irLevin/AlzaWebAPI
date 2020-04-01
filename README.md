# AlzaWebAPI Task
This API project provides information about:
1) All available products at the moment
2) Get specific product data based on its ID
3) Update description of the specific product

More detailed information about endpoints and their parameters is provided in Swagger Documentation.

# Start Project
Project can be start by using IDE (IDE used for the project development is VS Community 2019)

# Products Data
The projects supports two modes in order to load the existing product data, namely:
1) DB data
2) Mock data
You can easily to switch between them by changing setting "isTestMode" in appsettings.json (AlzaTask). In case "isTestMode"=true, the Mock data will be loaded, otherwise data from DB.

# Project Unit tests
In order to run suit of the Unit tests, you need to go the "Alza.Tests" -> ProductControllerTest.cs. In this file you will find set of the tests that can be tested one by one or whole set once. In order to check the specific test, you need to stay on the selected test then right-click -> Run/Debug Test. The test will be executed with the provided data that can be easily changed in Alza.Data ->MockData ->MockDataProvider.cs.

# Project Structure
The API Project consist of several sub-projects in order to devide logic to different layers.<br/>
**-Alza.BusinessLogic** its contains classes of the interfaces and own classes of the repositories. In order to extend the existing functionality, we can add the required functions easily.<br/>
**- Alza.Common** contains set of the objects: Class Entities, Logger, Models, IDataProvider. In case if we want to extend the existing functionality by providing information about additional objects, e.g. distributers, orders etc. The new classes should be added with all required information into this sub-project.<br/>
**-Alza.Data** contains auto-generated classes migrations, mapper profile class for the mapping entities and models, SQL/Mock Data Providers. <br/>
**Important points** 
The project supports EF Core, the approach used Code First. 
All functions support async retrieving data as well as sync. Each endpoint has two options to choose.<br/>
**-Alza.Test** contains set of the Unit tests for each endpoints and different status results.<br/>
**-Alza.Task** contains API Controller as well as all projects settings.<br/>

**Thank you for your attention**

