# Build and run

```sh
$ docker-compose up --build
```
- localhost:5001?token=<token> para llegar a la interfaz, sin el token se muestra un 401 Unauthorized
- Se adjunta colección de postman para prueba de endpoints, todos requieren un bearer token menos el de autentificación
- El endpoint de autentificación recibe un payload con username y password, debe corresponser a los de http://arsene.azurewebsites.net/UserData, de lo contrario se retornará un error.
- La interfaz manipula la API interna de la aplicación con la ayuda de axios