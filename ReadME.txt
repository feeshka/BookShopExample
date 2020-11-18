I used PostgreSql at this project.

-- Config files: "appsettings.json" into projects "BookShop.Infrasructure.Data", "BookShop.Web.Host" 
	Update "DefaultConnection" to "DefaultConnection": "Server=your_pg_server; Database=prefer_db_name;User Id=server_user_id;Password=server_user_password;"

-- For Data Base creation use Package Manager Console -> Update-Database
-- Sturtup Project: BookShop.Web.Host
-- Requests:
		Create new Book: https://your_host_addres:port/api/Book/
			request object example:
					{
						"author": "Лермонтов",
						"title": "Демон",
						"pubHouse": "Московский",
						"pubYear": "2015",
						"discount": 0,
						"price": 600,
						"isAvailable": true,
						"discountEndDate": "2021-05-11T00:00:00",
						"description": "Демон"
					}
				returns created entity id
				
		Get All books: https://your_host_addres:port/api/Book/
			request object example:
				{
					"author": "",
					"title": ""
				}
			returns an array of filtered books
			
		Get book by id: https://your_host_addres:port/api/Book/id
			returns book object
			
			
I have plans to implement:
 -- Identity
 -- Unit of Work
 -- Swagger
 -- more business logic