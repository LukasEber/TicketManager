# TicketManager
* [Overview](#overview)
* [Application Architecture](#application-architecture)
* [Technologies](#technologies)
* [Usage](#usage)
* [API Definition](#api-definition)
	* [Developer](#developer)
		* [Create Developer](#create-developer)
		* [Get Developer](#get-developer)
		* [Update Developer](#update-developer)
		* [Delete Developer](#delete-developer)
	* [Customer](#customer)
		* [Create Customer](#create-customer)
		* [Get Customer](#get-customer)
		* [Update Customer](#update-customer)
		* [Delete Customer](#delete-customer)
	* [Tickets](#tickets)
		* [Create Ticket](#create-ticket)
		* [Get Ticket](#get-ticket)
		* [Update Ticket](#update-ticket)
		* [Delete Ticket](#delete-ticket)
	* [Login](#login)

# Overview
# Application Architecture
# Technologies
# Usage
# API Definition
```
**==Important:==** Please refrain from using the update endpoints to add new entities, such as new tickets to customers, new tickets to developers, or new customers to developers. This won't work as these entities don't have an ID at this stage. Instead, utilize the Create endpoints for creating new objects. You can employ the update endpoints to modify existing entities, for instance, updating the status of an existing ticket using the update customer endpoint.
```
## Developer
### Create Developer
#### Create Developer Request
```
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
```
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

### Get Developer
#### Get Developer Request
```
GET /Developer/get/{id}
```
#### Get Developer Response
```
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

### Update Developer
#### Update Developer Request
```
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
```
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
### Delete Developer
#### Delete Developer Request
```
DELETE /Developer/del/{id}
```
#### Delete Developer Response
```
204 No Content
404 Not Found
400 Bad Request {message}
```
## Customer
### Create Customer
#### Create Customer Request
```
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
```
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
### Get Customer
#### Get Customer Request
```
GET /Customer/get/{id}
```
#### Get Customer Response
```
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
### Update Customer
#### Update Customer Request
```
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
```
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
### Delete Customer
#### Delete Customer Request
```
DELETE /Customer/del/{id}
```
#### Delete Customer Response
```
204 No Content
404 Not Found
400 Bad Request {message}
```
## Tickets
### Create Ticket
#### Create Ticket Request
```
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
```
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
### Get Ticket
#### Get Ticket Request
```
GET /Ticket/get/{id}
```
#### Get Ticket Response
```
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
### Update Ticket
#### Update Ticket Request
```
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
```
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
### Delete Ticket
#### Delete Ticket Request
```
DELETE /Ticket/del/{id}
```
#### Delete Ticket Response
```
- 204 No Content
- 404 Not Found
- 400 Bad Request
```
## Login
### Login Request
```
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
```
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
