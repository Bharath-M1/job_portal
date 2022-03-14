

![Logo](https://job360store.blob.core.windows.net/file-container/MicrosoftTeams-image.png)
Job360 is a portal to apply jobs and post companies in web.


## Packages and framework

**Client side:** Angular, Kendo, Bootstrap, Ng2

**Server side:** Asp.net core Webapi, Entity Framework, Azure Sql Server, Azure App Services


## Features

- Seeker Module (Create a profile, update eductaion, update skills ,update experience, apply jobs, upload resume in azure)
- Company Module (Create a company profile, post jobs, see job applicants)
- Admin Module (Control Center, Account Management - Seeker, Company, Job Management, Sticky Note)


## API Reference
For Full api Reference pls follow this link https://job360webapi.azurewebsites.net/swagger/index.html
#### Get all Users

```http
  GET /api/User

```

#### Get item

```http
  GET /api/User/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |




## Screenshot

#### Landing Page
![landingpage](https://job360store.blob.core.windows.net/file-container/homepage)

#### Company Dashboard
![companydashboard](https://job360store.blob.core.windows.net/file-container/companydashboard)


#### Job Listing
![joblisting](https://job360store.blob.core.windows.net/file-container/seekerdashboard)


#### Admin Dashboard
![aboard](https://job360store.blob.core.windows.net/file-container/admin%20dashboard.png)



#### Ef Diagram
![DbEF](https://job360store.blob.core.windows.net/file-container/Ef%20diagram.png
)

## Authors

- [@Bharath](https://github.com/Bharath-M1)
- [@Mohamed ali](https://github.com/moli-debugger)
- [@Deepak](https://github.com/DeepakChakravarthy)


## Run Locally

Clone the project

```bash
  git clone https://github.com/Bharath-M1/Job360
```

Go to the project directory


Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm start (or) ng serve
```


## Support

For support, email bharath.maghes@gmail.com , mkmohamedalimoli@gmail.com, deepakchakravirthy.d@gmail.com.


## License

[MIT](https://choosealicense.com/licenses/mit/)

