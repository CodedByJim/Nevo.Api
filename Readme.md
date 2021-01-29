# Nevo API

This is the unofficial NEVO API.

NEVO provides data on the composition of foods expressed per 100 g of the edible part (i.e. meat without bones, vegetables 
without waste). In certain cases, the composition of some liquid foods may be displayed per 100 ml, if applicable this is
indicated in the food name.

# Using the API
This API is provided as a docker image on the following url:   
[https://hub.docker.com/r/codedbyjim/nevo-api](https://hub.docker.com/r/codedbyjim/nevo-api)

To run this docker image execute the following command:  
`docker run -p 5555:80 codedbyjim/nevo-api:latest`

Then use the Swagger UI to fire requests:  
[http://localhost:5555/swagger/index.html](http://localhost:5555/swagger/index.html)

## Consuming the API programmatically

Open-api definitions can be found at:  
[http://localhost:5555/swagger/1.0/swagger.yaml](http://localhost:5555/swagger/1.0/swagger.yaml)

Use your favorite tool tool generate a client e.g.:  
- [NSwag](http://nswag.org/) 
- [openapi-generator](https://openapi-generator.tech/)

Happy programming!

# Supported requests
These request can also be found in de Swagger UI interface that ships with the docker image.

### Groups
Products are categorized into groups.
- List all groups.
- Get a single group
- Get the products within a group

### Nutrients
Information about the nutrients.
- Get all known nutrients.
- Get a single nutrient.
- List products containing a nutrient, ordered by percentage descending.

### Products
Data about products.
- Get all products.
- Get a single product.
- Get the product and it's nutrients.

### Sources
References to sources used to produce the data.
- Get all known sources.
- Get a single source.
- Get the nutritional values found in the source.

# Legal
By using this API you agree to the following terms:  

[NEVO - Copyright & Disclaimer](https://www.rivm.nl/en/dutch-food-composition-database/access-nevo-data/nevo-online/copyright-and-disclaimer)  

[NEVO - Conditions of use NEVO-online 2019 dataset.pdf](https://www.rivm.nl/documenten/conditions-for-use-of-nevo-online-version-201960)