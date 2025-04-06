1. Solution consists of 3 containerized applications - 1. MSSQL server container 2. Backend - .NET API application container 3. Frontend - .NET Razorpages application container
2. Install .NET 8.0 if you haven't already
3. Start Docker
4. Open the solution in an IDE - I used Visual Studio 2022
5. Re-build the Solution
6. Set the default project to docker-compose
7. Run the project
8. http://localhost:5000/swagger/index.html - Backend API URL
9. http://localhost:5001/ FrontEnd URL
10. SQL connection- server:localhost, 1434, User:sa, Password:Password12345!
