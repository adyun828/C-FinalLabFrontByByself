# API Testing Examples

This document provides examples for testing the backend API using various tools.

## Using PowerShell (Windows)

### 1. Login
```powershell
$body = @{
    username = "admin"
    password = "admin123"
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri "http://localhost:5000/api/Auth/login" `
    -Method Post `
    -Body $body `
    -ContentType "application/json"

$token = $response.token
Write-Host "Token: $token"
```

### 2. Get Images
```powershell
$headers = @{
    Authorization = "Bearer $token"
}

$images = Invoke-RestMethod -Uri "http://localhost:5000/api/Images?count=3" `
    -Method Get `
    -Headers $headers

$images | ConvertTo-Json -Depth 10
```

### 3. Save Selection
```powershell
$body = @{
    imageId = 1
    selectedOption = "Very Like"
} | ConvertTo-Json

$headers = @{
    Authorization = "Bearer $token"
}

$result = Invoke-RestMethod -Uri "http://localhost:5000/api/Selections" `
    -Method Post `
    -Body $body `
    -ContentType "application/json" `
    -Headers $headers

$result | ConvertTo-Json
```

### 4. Get My Selections
```powershell
$headers = @{
    Authorization = "Bearer $token"
}

$selections = Invoke-RestMethod -Uri "http://localhost:5000/api/Selections" `
    -Method Get `
    -Headers $headers

$selections | ConvertTo-Json -Depth 10
```

## Using cURL (Cross-platform)

### 1. Login
```bash
curl -X POST http://localhost:5000/api/Auth/login \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"admin\",\"password\":\"admin123\"}"
```

**Windows CMD:**
```cmd
curl -X POST http://localhost:5000/api/Auth/login ^
  -H "Content-Type: application/json" ^
  -d "{\"username\":\"admin\",\"password\":\"admin123\"}"
```

### 2. Get Images
```bash
curl -X GET "http://localhost:5000/api/Images?count=3" \
  -H "Authorization: Bearer YOUR_TOKEN_HERE"
```

### 3. Save Selection
```bash
curl -X POST http://localhost:5000/api/Selections \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_TOKEN_HERE" \
  -d "{\"imageId\":1,\"selectedOption\":\"Very Like\"}"
```

### 4. Get My Selections
```bash
curl -X GET http://localhost:5000/api/Selections \
  -H "Authorization: Bearer YOUR_TOKEN_HERE"
```

## Using Postman

### Setup
1. Create a new Collection called "Image Selection API"
2. Add a variable `baseUrl` = `http://localhost:5000/api`
3. Add a variable `token` (will be set automatically)

### Request 1: Login
- **Method**: POST
- **URL**: `{{baseUrl}}/Auth/login`
- **Headers**: 
  - `Content-Type: application/json`
- **Body** (raw JSON):
```json
{
  "username": "admin",
  "password": "admin123"
}
```
- **Tests** (to save token):
```javascript
if (pm.response.code === 200) {
    var jsonData = pm.response.json();
    pm.collectionVariables.set("token", jsonData.token);
}
```

### Request 2: Get Images
- **Method**: GET
- **URL**: `{{baseUrl}}/Images?count=3`
- **Headers**: 
  - `Authorization: Bearer {{token}}`

### Request 3: Save Selection
- **Method**: POST
- **URL**: `{{baseUrl}}/Selections`
- **Headers**: 
  - `Content-Type: application/json`
  - `Authorization: Bearer {{token}}`
- **Body** (raw JSON):
```json
{
  "imageId": 1,
  "selectedOption": "Very Like"
}
```

### Request 4: Get My Selections
- **Method**: GET
- **URL**: `{{baseUrl}}/Selections`
- **Headers**: 
  - `Authorization: Bearer {{token}}`

## Expected Responses

### Login Success (200 OK)
```json
{
  "success": true,
  "message": "Login successful",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "username": "admin"
}
```

### Login Failure (401 Unauthorized)
```json
{
  "success": false,
  "message": "Incorrect username or password",
  "token": null,
  "username": null
}
```

### Get Images Success (200 OK)
```json
[
  {
    "id": 5,
"title": "Landscape Image 5",
    "description": "Snow mountain scenery",
 "imageUrl": "https://picsum.photos/400/300?random=5",
 "options": [
      "Very Like",
      "Like",
   "Neutral",
      "Dislike"
    ]
  },
  {
    "id": 2,
    "title": "Landscape Image 2",
    "description": "Charming beach",
    "imageUrl": "https://picsum.photos/400/300?random=2",
    "options": [
      "Very Like",
      "Like",
      "Neutral",
      "Dislike"
    ]
  }
]
```

### Save Selection Success (200 OK)
```json
{
  "success": true,
  "message": "Selection saved"
}
```

### Unauthorized (401)
```json
{
  "type": "https://tools.ietf.org/html/rfc7235#section-3.1",
  "title": "Unauthorized",
  "status": 401
}
```

## Testing Scenarios

### Scenario 1: Complete User Journey
```powershell
# 1. Login
$loginBody = @{ username = "admin"; password = "admin123" } | ConvertTo-Json
$loginResponse = Invoke-RestMethod -Uri "http://localhost:5000/api/Auth/login" -Method Post -Body $loginBody -ContentType "application/json"
$token = $loginResponse.token

# 2. Get images
$headers = @{ Authorization = "Bearer $token" }
$images = Invoke-RestMethod -Uri "http://localhost:5000/api/Images?count=5" -Method Get -Headers $headers

# 3. Select first image
$selectionBody = @{ 
    imageId = $images[0].id
    selectedOption = $images[0].options[0]
} | ConvertTo-Json
Invoke-RestMethod -Uri "http://localhost:5000/api/Selections" -Method Post -Body $selectionBody -ContentType "application/json" -Headers $headers

# 4. Get selection history
$history = Invoke-RestMethod -Uri "http://localhost:5000/api/Selections" -Method Get -Headers $headers
$history | Format-Table
```

### Scenario 2: Test All Users
```powershell
$users = @(
    @{ username = "admin"; password = "admin123" },
    @{ username = "testuser"; password = "test123" },
    @{ username = "user1"; password = "password" }
)

foreach ($user in $users) {
    $body = $user | ConvertTo-Json
  try {
        $response = Invoke-RestMethod -Uri "http://localhost:5000/api/Auth/login" -Method Post -Body $body -ContentType "application/json"
Write-Host "? $($user.username) login successful" -ForegroundColor Green
    } catch {
   Write-Host "? $($user.username) login failed" -ForegroundColor Red
    }
}
```

### Scenario 3: Test Without Authentication
```powershell
# This should fail with 401 Unauthorized
try {
    Invoke-RestMethod -Uri "http://localhost:5000/api/Images" -Method Get
} catch {
    Write-Host "Expected error: Unauthorized access blocked" -ForegroundColor Yellow
}
```

## Performance Testing

### Load Test with PowerShell
```powershell
# Login once
$body = @{ username = "admin"; password = "admin123" } | ConvertTo-Json
$response = Invoke-RestMethod -Uri "http://localhost:5000/api/Auth/login" -Method Post -Body $body -ContentType "application/json"
$token = $response.token
$headers = @{ Authorization = "Bearer $token" }

# Make 100 requests
$times = @()
1..100 | ForEach-Object {
    $start = Get-Date
    Invoke-RestMethod -Uri "http://localhost:5000/api/Images?count=3" -Method Get -Headers $headers | Out-Null
    $end = Get-Date
    $times += ($end - $start).TotalMilliseconds
}

Write-Host "Average response time: $([math]::Round(($times | Measure-Object -Average).Average, 2)) ms"
Write-Host "Min: $([math]::Round(($times | Measure-Object -Minimum).Minimum, 2)) ms"
Write-Host "Max: $([math]::Round(($times | Measure-Object -Maximum).Maximum, 2)) ms"
```

## Troubleshooting

### Connection Refused
```
Problem: Cannot connect to http://localhost:5000
Solution: Ensure backend is running (dotnet run in Backend folder)
```

### 401 Unauthorized
```
Problem: API returns 401 even with token
Solution: Check token is valid and not expired (60 min lifetime)
  Ensure "Bearer " prefix in Authorization header
```

### 400 Bad Request
```
Problem: Request rejected
Solution: Validate JSON format
         Check required fields are present
         Verify data types match expected
```
