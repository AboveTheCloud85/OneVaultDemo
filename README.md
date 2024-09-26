# OneVaultDemo

This is a MAUI application that authenticates to Duende IdentityServer via the interactive.public Client.

- It includes a login screen with username and password. This unfortunately was not incorporated into the authentication.
- A token is retrieved from the login and then calls the Duende test API  - https://demo.duendesoftware.com/api/test
- A page can be launched to capture a QR code and shows the output on screen


Things that could not be done:

- An API that calls the Duende IdentityServer
- Test project for unit testing this API
- Client to be in-between this API and App
- Test project for unit testing of viewmodels
- Improve styling and themes in app, with some theme switching inside the app
- Cater for better unified styling between Android and iOS  
