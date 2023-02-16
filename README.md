# Backend Take-home Asessment

## What does this API accomplish:

The API contains a `POST` route that retrieves Premium Quotes based on the caller's business type and a list of states. 


## How To Use
In `Coterie.Api`, from the terminal use `dotnet run` or run the `Coterie.Api` solution configuration.
- Swagger Docs: https://localhost:5001/swagger/index.html
- Direct Route for Postman or curl: https://localhost:5001/api/premium


## Request/Response

Example Request:

```json
{
  "business": "Plumber",
  "revenue": 6000000,
  "states": [
    "TX",
    "OH",
    "FLORIDA"
  ]
}
```

Example Response:

```json
{
  "business": "Plumber",
  "revenue": 6000000,
  "premiums": [
    {
      "premium": 11316,
      "state": "TX"
    },
    {
      "premium": 12000,
      "state": "OH"
    },
    {
      "premium": 14400,
      "state": "FL"
    }
  ],
  "isSuccessful": true,
  "transactionId": "27373db4-56c3-4383-a2e1-f55c77b4aa3f"
}
```
