# Quick Start Guide

## Running the Application

### Step 1: Start Backend (Terminal 1)
```bash
cd D:\code\C#\FinalLab\Backend
dotnet run
```

The backend will start at: http://localhost:5000

### Step 2: Start Frontend (Terminal 2)
```bash
cd D:\code\C#\FinalLab\Frontend
dotnet run
```

### Step 3: Login
Use one of these test accounts:
- Username: `admin`, Password: `admin123`
- Username: `testuser`, Password: `test123`
- Username: `user1`, Password: `password`

## Alternative: Run from Visual Studio

1. Open `FinalLab.sln` in Visual Studio
2. Right-click on `Backend` project -> Debug -> Start New Instance
3. Right-click on `Frontend` project -> Debug -> Start New Instance

## Testing the API Manually

You can test the API using curl or Postman:

### Login
```bash
curl -X POST http://localhost:5000/api/Auth/login ^
  -H "Content-Type: application/json" ^
  -d "{\"username\":\"admin\",\"password\":\"admin123\"}"
```

### Get Images (replace YOUR_TOKEN)
```bash
curl -X GET http://localhost:5000/api/Images?count=3 ^
  -H "Authorization: Bearer YOUR_TOKEN"
```

### Save Selection (replace YOUR_TOKEN)
```bash
curl -X POST http://localhost:5000/api/Selections ^
  -H "Content-Type: application/json" ^
  -H "Authorization: Bearer YOUR_TOKEN" ^
  -d "{\"imageId\":1,\"selectedOption\":\"Very Like\"}"
```
