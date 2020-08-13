# Please follow the below steps to Run this application:


1- Install asp.net core 2.2 if not installed already,
    You can download from here directly, https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral    
2- Create a new folder in your local system, e.g E:\codingAssignment
3- Open git bash and go to this folder's location, e.g. > cd E:\codingAssignment
4- Clone this git repository on this folder using the following command:
   > git clone https://github.com/khizraSarmadkhan/CodingAssignmentOneSignal.git
5- Go to the newly cloned repo fetched files and open the .csproj file with visual studio
6- Build the Solution
7- Register your first user
8- You will need to Apply Migrations on the first db intraction, Just click on Apply Migration button on the browser and refresh the page
9- Now create new user and the first user will be assigned Admin as there must be atleast 1 Admin User. 
10-Every New User will be assigned DataEntryOperater role. An admin can update the roles for each user.

#######################################   
Notes:
1- MVC Identity is user for user management - 
2- There are 2 Roles: Admin and DataEntryOperator
3- Admin can perform all crud operations while Data Entry Operator role can only view all apps.
4- Razor Syntax is Used for all data binding
5- Entity framework Code first first approach used.
6- OneSignal Apps API implemented i.e. View all Aps, Create App, Update App and Delete App.
   Delete App was not found on the Api documentation and return 404 for my implementation. Probably the api has not configured Delete App functionality for some reason.
7- Solid - S,O,L are implemented partially for identity and OneSignal App integration.    
