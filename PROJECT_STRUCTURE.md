# Project Structure Documentation

## Complete File Tree

```
FinalLab/
©¦
©À©¤©¤ Backend/     # Backend Web API Project
©¦   ©À©¤©¤ Controllers/                  # API Controllers
©¦©¦   ©À©¤©¤ AuthController.cs         # Authentication endpoint (POST /api/Auth/login)
©¦   ©¦   ©À©¤©¤ ImagesController.cs       # Image endpoints (GET /api/Images)
©¦   ©¦   ©¸©¤©¤ SelectionsController.cs   # Selection endpoints (POST /api/Selections)
©¦   ©¦
©¦   ©À©¤©¤ Services/     # Business Logic Layer
©¦   ©¦   ©À©¤©¤ IUserService.cs           # User service interface
©¦   ©¦   ©À©¤©¤ UserService.cs   # User authentication & JWT generation
©¦   ©¦   ©À©¤©¤ IImageService.cs    # Image service interface
©¦   ©¦   ©À©¤©¤ ImageService.cs         # Static image data management
©¦   ©¦   ©À©¤©¤ ISelectionService.cs      # Selection service interface
©¦   ©¦   ©¸©¤©¤ SelectionService.cs     # User selection storage
©¦   ©¦
©¦   ©À©¤©¤ Models/# Data Models
©¦   ©¦   ©À©¤©¤ User.cs  # User model with hashed password
©¦   ©¦   ©À©¤©¤ ImageInfo.cs   # Image information model
©¦   ©¦   ©¸©¤©¤ UserSelection.cs# User selection record model
©¦   ©¦
©¦   ©À©¤©¤ DTOs/       # Data Transfer Objects
©¦   ©¦   ©À©¤©¤ LoginRequest.cs           # Login request payload
©¦   ©¦   ©À©¤©¤ LoginResponse.cs          # Login response with JWT token
©¦   ©¦   ©¸©¤©¤ SelectionRequest.cs       # Selection submission payload
©¦   ©¦
©¦   ©À©¤©¤ Properties/
©¦   ©¦   ©¸©¤©¤ launchSettings.json       # Launch configuration (port 5000)
©¦   ©¦
©¦   ©À©¤©¤ Backend.csproj      # Project file with dependencies
©¦   ©À©¤©¤ Program.cs         # Application entry & configuration
©¦   ©¸©¤©¤ appsettings.json            # JWT & application settings
©¦
©À©¤©¤ Frontend/ # Frontend WPF Project
©¦   ©À©¤©¤ Models/      # Data Models (mirror backend DTOs)
©¦   ©¦   ©À©¤©¤ LoginRequest.cs
©¦   ©¦   ©À©¤©¤ LoginResponse.cs
©¦   ©¦   ©À©¤©¤ ImageInfo.cs
©¦   ©¦ ©¸©¤©¤ SelectionRequest.cs
©¦   ©¦
©¦   ©À©¤©¤ Services/          # API Communication Layer
©¦   ©¦   ©¸©¤©¤ ApiService.cs     # HTTP client for backend API
©¦   ©¦
©¦   ©À©¤©¤ LoginWindow.xaml              # Login UI (XAML)
©¦   ©À©¤©¤ LoginWindow.xaml.cs           # Login logic (Code-behind)
©¦   ©À©¤©¤ MainWindow.xaml       # Main UI (XAML)
©¦   ©À©¤©¤ MainWindow.xaml.cs          # Main logic (Code-behind)
©¦   ©À©¤©¤ App.xaml      # Application resources
©¦   ©À©¤©¤ App.xaml.cs      # Application startup
©¦   ©¸©¤©¤ Frontend.csproj          # Project file with dependencies
©¦
©À©¤©¤ FinalLab.sln    # Visual Studio Solution file
©À©¤©¤ README.md     # Complete documentation
©À©¤©¤ QUICKSTART.md # Quick start guide
©¸©¤©¤ .gitignore      # Git ignore file

```

## Component Descriptions

### Backend Components

#### Controllers
- **AuthController**: Handles user authentication
  - `POST /api/Auth/login`: Validates credentials and returns JWT token
  
- **ImagesController**: Manages image data (Requires JWT)
  - `GET /api/Images?count=N`: Returns N random images
  - `GET /api/Images/{id}`: Returns specific image by ID
  
- **SelectionsController**: Handles user selections (Requires JWT)
  - `POST /api/Selections`: Saves user's image selection
  - `GET /api/Selections`: Gets current user's selection history

#### Services
- **UserService**: 
  - Static user data (3 test accounts)
  - Password hashing with SHA256 + Salt
  - JWT token generation
  
- **ImageService**: 
  - 10 static images with online URLs
  - Random image selection
  
- **SelectionService**: 
  - In-memory storage of user selections
  - Selection history per user

#### Models & DTOs
- Clean separation between internal models and API contracts
- All properties with proper initialization

### Frontend Components

#### Windows
- **LoginWindow**: 
  - Username/password input
  - Form validation
  - Error display
  
- **MainWindow**: 
  - Image display with async loading
  - Dynamic option buttons
  - Progress counter
  - Automatic next image after selection

#### Services
- **ApiService**: 
  - Centralized HTTP communication
  - JWT token management
  - JSON serialization/deserialization
  - Error handling

## Data Flow

### Login Flow
```
User Input ¡ú LoginWindow ¡ú ApiService.LoginAsync() ¡ú 
POST /api/Auth/login ¡ú AuthController ¡ú UserService ¡ú 
JWT Token ¡ú LoginResponse ¡ú MainWindow
```

### Image Selection Flow
```
MainWindow.LoadImages() ¡ú ApiService.GetImagesAsync() ¡ú 
GET /api/Images ¡ú ImagesController ¡ú ImageService ¡ú 
List<ImageInfo> ¡ú Display in UI ¡ú User Selection ¡ú 
ApiService.SaveSelectionAsync() ¡ú POST /api/Selections ¡ú 
SelectionsController ¡ú SelectionService ¡ú Next Image
```

## Security Implementation

### Password Security
- All passwords stored as SHA256 hash
- Fixed salt for demo (should be per-user in production)
- No plaintext passwords in memory after hashing

### JWT Authentication
- HS256 signing algorithm
- 60-minute token expiration
- Validates issuer, audience, lifetime, and signature
- Required for all image and selection endpoints

### API Authorization
- `[Authorize]` attribute on protected controllers
- Claims-based user identification
- CORS enabled for development

## Static Data

### Test Users
```csharp
{ Id: 1, Username: "admin", Password: "admin123" }
{ Id: 2, Username: "testuser", Password: "test123" }
{ Id: 3, Username: "user1", Password: "password" }
```

### Images
- 10 images using Lorem Picsum service
- Each with 4 options: ["Very Like", "Like", "Neutral", "Dislike"]
- Unique IDs 1-10

## Configuration

### Backend Settings (appsettings.json)
```json
{
  "JwtSettings": {
    "SecretKey": "YourSuperSecretKeyForJWTAuthentication123456",
    "Issuer": "ImageSelectionAPI",
    "Audience": "ImageSelectionClient",
    "ExpirationMinutes": 60
  }
}
```

### Frontend Settings (ApiService.cs)
```csharp
public string BaseUrl = "http://localhost:5000/api";
```

## Extension Points

### Easy to Add
1. Database integration (replace in-memory lists with DbContext)
2. User registration (add RegisterUser method in UserService)
3. Image upload (add FileUpload endpoint)
4. Export selections (add export endpoint)
5. Real-time updates (add SignalR)

### Recommended Improvements
1. Per-user password salt
2. Refresh token mechanism
3. Input validation with FluentValidation
4. Logging with Serilog
5. Unit tests with xUnit
6. Docker containerization
