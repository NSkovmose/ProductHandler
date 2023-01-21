# ProductHandler

### Installing


1. Kør ProductHandler DB scriptet for at oprette databasen

2. Connectionstring skal muligvis ændres til at tilgå din server.

    "ConnectionStrings": {
    "ProductHandlerContext": "Server=localhost\\SQLEXPRESS;Database=ProductHandler;Trusted_Connection=True;"  }

3. Start projektet

4. Der bliver seeded 25 produkter ind første gang hvis der ikke er nogle i databasen.

