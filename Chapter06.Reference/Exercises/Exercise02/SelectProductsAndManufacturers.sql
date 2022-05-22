SELECT Product.Name, Product.Price, Manufacturer.Name as Manufacturer, Manufacturer.Country 
FROM Factory.Product as Product 
INNER JOIN Factory.Manufacturer as Manufacturer 
ON Product.ManufacturerId = Manufacturer.Id 