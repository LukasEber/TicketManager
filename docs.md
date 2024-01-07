# TicketManager
* [Overview](#Overview)
* [Application Architecture](#Application-Architecture)
* [Technologies](#Technologies)
* [Usage](#Usage)
* [API Definition](#API-Definition)
	* [Developer](#Developer)
		* [Create Developer](#Create-Developer)
		* [Get Developer](#Get-Developer)
		* [Update Developer](#Update-Developer)
		* [Delete Developer](#Delete-Developer)
	* [Customer](#Customer)
		* [Create Customer](#Create-Customer)
		* [Get Customer](#Get-Customer)
		* [Update Customer](#Update-Customer)
		* [Delete Customer](#Delete-Customer)
	* [Tickets](#Tickets)
		* [Create Ticket](#Create-Ticket)
		* [Get Ticket](#Get-Ticket)
		* [Update Ticket](#Update-Ticket)
		* [Delete Ticket](#Delete-Ticket)
	* [Login](#Login)

# Overview {#Overview}
# Application Architecture {#Application-Architecture}
# Technologies {#Technologies}
# Usage {#Usage}
# API Definition {#API-Definition}
## Developer {#Developer}
### Create Developer {#Create-Developer}
#### Create Developer Request
```json
POST /Developer/create 
```
```json
{
  "name": "Meier GmbH & CO KG",
  "credentials": {
    "mailAddress": "kontakt@meier.de",
    "password": "meier123"
  },
  "applications": [
    "Management",
    "CustomerApp"
  ]
}
```
#### Create Developer Response
```json
201 Created
400 Bad Request {message}
```
```json
{
    "name": "Meier GmbH & CO KG",
    "id": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "credentials": {
        "mailAddress": "kontakt@meier.de",
        "password": "meier123"
    },
    "tickets": null,
    "assignedCustomers": null,
    "applications": [
        "Management",
        "CustomerApp"
    ]
}
```

### Get Developer {#Get-Developer}
#### Get Developer Request
```json
GET /Developer/get/{id}
```
#### Get Developer Response
```json
200 Success
404 Not Found 
400 Bad Request {message}
```
```json
{
    "name": "Meier GmbH & CO KG",
    "id": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "credentials": {
        "mailAddress": "kontakt@meier.de",
        "password": "meier123"
    },
    "tickets": [],
    "assignedCustomers": [
        {
            "name": "Kunde Meier 1",
            "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "credentials": {
                "mailAddress": "Kunde1@Kunde.de",
                "password": "123dsdsds45"
            },
            "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
            "tickets": [
                {
                    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
                    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
                    "developerID": null,
                    "title": "Ticket1",
                    "description": "first TIcket created",
                    "application": "Management",
                    "priority": 1,
                    "status": 1,
                    "attachments": [
                        "attachment1",
                        "attachment2"
                    ],
                    "comment": null
                }
            ],
            "applications": null
        }
    ],
    "applications": [
        "Management",
        "CustomerApp"
    ]
}
```

### Update Developer {#Update-Developer}
#### Update Developer Request
```json
PUT /Developer/update/{id}
```
```json
{
    "name": "Meier GmbH & CO KG",
    "id": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "credentials": {
        "mailAddress": "kontaktupdated@meier.de",
        "password": "meier123"
    },
    "tickets": [],
    "assignedCustomers": [
        {
            "name": "Kunde Meier 1",
            "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "credentials": {
                "mailAddress": "Kunde1@Kunde.de",
                "password": "123dsdsds45"
            },
            "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
            "tickets": [
                {
                    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
                    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
                    "developerID": null,
                    "title": "Ticket1",
                    "description": "first TIcket created",
                    "application": "Management",
                    "priority": 1,
                    "status": 1,
                    "attachments": [
                        "attachment1",
                        "attachment2"
                    ],
                    "comment": null
                }
            ],
            "applications": null
        }
    ],
    "applications": [
        "Management",
        "CustomerApp",
        "New Customer App"
    ]
}
```
#### Update Developer Response
```json
201 Created
404 Not Found
400 Bad Request {message}
```
```json
{
    "name": "Meier GmbH & CO KG",
    "id": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "credentials": {
        "mailAddress": "kontaktupdated@meier.de",
        "password": "meier123"
    },
    "tickets": [],
    "assignedCustomers": [
        {
            "name": "Kunde Meier 1",
            "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "credentials": {
                "mailAddress": "Kunde1@Kunde.de",
                "password": "123dsdsds45"
            },
            "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
            "tickets": [
                {
                    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
                    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
                    "developerID": null,
                    "title": "Ticket1",
                    "description": "first TIcket created",
                    "application": "Management",
                    "priority": 1,
                    "status": 1,
                    "attachments": [
                        "attachment1",
                        "attachment2"
                    ],
                    "comment": null
                }
            ],
            "applications": null
        }
    ],
    "applications": [
        "Management",
        "CustomerApp",
        "New Customer App"
    ]
}
```
### Delete Developer {#Delete-Developer}
#### Delete Developer Request
```json
DELETE /Developer/del/{id}
```
#### Delete Developer Response
```json
204 No Content
404 Not Found
400 Bad Request {message}
```
## Customer {#Customer}
### Create Customer {#Create-Customer}
#### Create Customer Request
```json
POST /Customer/create
```
```json
{
    "Name": "Kunde 1",
    "Credentials": {
        "mailAddress": "Kunde1@Kunde.de",
        "Password": "123dsdsds45"
    },
    "DeveloperID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "Applications": [
        "Management"
    ]
}
```
#### Create Customer Response
```json
201 Created
400 Bad Request {message}
```
```json
{
    "name": "Kunde 1",
    "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "credentials": {
        "mailAddress": "Kunde1@Kunde.de",
        "password": "123dsdsds45"
    },
    "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "tickets": null,
    "applications": [
        "Management"
    ]
}
```
### Get Customer {#Get-Customer}
#### Get Customer Request
```json
GET /Customer/get/{id}
```
#### Get Customer Response
```json
200 OK
404 Not Found
400 Bad Request {message}
```
```json
{
    "name": "Kunde Meier 1",
    "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "credentials": {
        "mailAddress": "Kunde1@Kunde.de",
        "password": "123dsdsds45"
    },
    "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "tickets": [
        {
            "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
            "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "developerID": null,
            "title": "Ticket1",
            "description": "first TIcket created",
            "application": "Management",
            "priority": 1,
            "status": 1,
            "attachments": [
                "attachment1",
                "attachment2"
            ],
            "comment": null
        }
    ],
    "applications": null
}
```
### Update Customer {#Update-Customer}
#### Update Customer Request
```json
PUT /Customer/update/{id}
```
```json
{
    "name": "Kunde Meier 1 updated",
    "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "credentials": {
        "mailAddress": "Kunde1-kontakt@Kunde.de",
        "password": "123dsdsds45"
    },
    "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "tickets": [
        {
            "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
            "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "developerID": null,
            "title": "Ticket1",
            "description": "first TIcket created",
            "application": "Management",
            "priority": 1,
            "status": 1,
            "attachments": [
                "attachment1",
                "attachment2"
            ],
            "comment": null
        }
    ],
    "applications": null
}
```
#### Update Customer Response
```json
201 Created
404 Not Found
400 Bad Request {message}
```
```json
{
    "name": "Kunde Meier 1 updated",
    "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "credentials": {
        "mailAddress": "Kunde1-kontakt@Kunde.de",
        "password": "123dsdsds45"
    },
    "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "tickets": [
        {
            "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
            "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "developerID": null,
            "title": "Ticket1updated",
            "description": "first TIcket created",
            "application": "Management",
            "priority": 1,
            "status": 1,
            "attachments": [
                "attachment1",
                "attachment2"
            ],
            "comment": null
        }
    ],
    "applications": null
}
```
### Delete Customer {#Delete-Customer}
#### Delete Customer Request
```json
DELETE /Customer/del/{id}
```
#### Delete Customer Response
```json
204 No Content
404 Not Found
400 Bad Request {message}
```
## Ticket {#Tickets}
### Create Ticket {#Create-Ticket}
#### Create Ticket Request
```json
POST /Ticket/create
```
```json
{
    "CustomerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "DeveloperID": null,
    "Title": "Ticket1",
    "Description": "first TIcket created",
    "Application": "Management",
    "Priority": 1,
    "Status": 1,
    "Attachments": [
        "attachment1",
        "attachment2"
    ],
    "Comment": null
}
```
#### Create Ticket Response
```json
201 Created
400 Bad Request {message}
```
```json
{
    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "developerID": null,
    "title": "Ticket1",
    "description": "first TIcket created",
    "application": "Management",
    "priority": 1,
    "status": 1,
    "attachments": [
        "attachment1",
        "attachment2"
    ],
    "comment": null
}
``` 
### Get Ticket {#Get-Ticket}
#### Get Ticket Request
```json
GET /Ticket/get/{id}
```
#### Get Ticket Response
```json
200 OK
404 Not Found
400 Bad Request {message}
```
```json
{
    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "developerID": null,
    "title": "Ticket1",
    "description": "first TIcket created",
    "application": "Management",
    "priority": 1,
    "status": 1,
    "attachments": [
        "attachment1",
        "attachment2"
    ],
    "comment": null
}
``` 
### Update Ticket {#Update-Ticket}
#### Update Ticket Request
```json
PUT /Ticket/update/{id}
```
```json
{
    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "developerID": null,
    "title": "Ticket1UPDATED",
    "description": "first TIcket updated",
    "application": "Management",
    "priority": 1,
    "status": 2,
    "attachments": [
        "attachment1",
        "attachment2"
    ],
    "comment": "important to finish"
}
```
#### Update Ticket Response
```json
201 Created
404 Not Found
400 Bad Request {message}
```
```json
{
    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
    "developerID": null,
    "title": "Ticket1UPDATED",
    "description": "first TIcket updated",
    "application": "Management",
    "priority": 1,
    "status": 2,
    "attachments": [
        "attachment1",
        "attachment2"
    ],
    "comment": "important to finish"
}
```
### Delete Ticket {#Delete-Ticket}
#### Delete Ticket Request
```json
DELETE /Ticket/del/{id}
```
#### Delete Ticket Response
```json
- 204 No Content
- 404 Not Found
- 400 Bad Request
```
## Login {#Login}
### Login Request
```json
POST /auth/login
```
```json
{
  "credentials": {
    "mailAddress": "kontakt@meier.de",
    "password": "meier123"
  }
}
```
### Login Response
```json
200 OK
401 Unauthorized
404 Not Found
400 Bad Request {message}
```
```json
{
    "name": "Meier GmbH & CO KG",
    "id": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
    "credentials": {
        "mailAddress": "kontakt@meier.de",
        "password": "meier123"
    },
    "tickets": [],
    "assignedCustomers": [
        {
            "name": "Kunde Meier 1",
            "id": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
            "credentials": {
                "mailAddress": "Kunde1@Kunde.de",
                "password": "123dsdsds45"
            },
            "developerID": "a2269214-d36a-40d8-8fab-6e11b126c3c7",
            "tickets": [
                {
                    "id": "7de3bd0d-7073-419d-add1-01352d2ceb70",
                    "customerID": "bc5d0b1e-41ce-4bab-84cd-987d5f9add05",
                    "developerID": null,
                    "title": "Ticket1",
                    "description": "first TIcket created",
                    "application": "Management",
                    "priority": 1,
                    "status": 1,
                    "attachments": [
                        "attachment1",
                        "attachment2"
                    ],
                    "comment": null
                }
            ],
            "applications": null
        }
    ],
    "applications": [
        "Management",
        "CustomerApp"
    ]
}
```

### TicketManager.Application
### TicketManager.Client
### TicketManager.Domain





















































