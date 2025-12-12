# 图像选择系统 (Image Selection System)

## 项目简介

这是一个基于 .NET 8.0 的前后端分离的图像选择系统，包含：
- **后端 (Backend)**: ASP.NET Core Web API，提供 RESTful 服务
- **前端 (Frontend)**: WindowsForm 桌面应用程序，提供图形用户界面

## 功能特性

### 后端功能
- ? JWT 身份验证
- ? 用户登录 (POST /api/Auth/login)
- ? 获取图像列表 (GET /api/Images)
- ? 保存用户选择 (POST /api/Selections)
- ? 密码哈希加盐存储
- ? CORS 支持

### 前端功能
- ? 用户登录界面
- ? 图像展示与选择
- ? HTTP 请求 (GET/POST)
- ? 循环获取新图像
- ? 用户选择记录
- ? 友好的 UI 界面

## 技术栈

### 后端
- .NET 8.0
- ASP.NET Core Web API
- JWT Authentication
- SHA256 密码哈希

### 前端
- .NET 8.0
- WPF (Windows Presentation Foundation)
- Newtonsoft.Json

## 项目结构

```
FinalLab/
├── Backend/          # 后端项目
│   ├── Controllers/       # API 控制器
│   │   ├── AuthController.cs# 认证控制器
│   │   ├── ImagesController.cs    # 图像控制器
│   │   └── SelectionsController.cs # 选择控制器
│   ├── Services/    # 业务服务
│   │   ├── IUserService.cs
│   │   ├── UserService.cs
│   │   ├── IImageService.cs
│   │   ├── ImageService.cs
│   │   ├── ISelectionService.cs
│   │   └── SelectionService.cs
│   ├── Models/           # 数据模型
│   │   ├── User.cs
│   │   ├── ImageInfo.cs
│   │   └── UserSelection.cs
│   ├── DTOs/   # 数据传输对象
│   │   ├── LoginRequest.cs
│   │   ├── LoginResponse.cs
│   │   └── SelectionRequest.cs
│   ├── Program.cs        # 程序入口
│   ├── appsettings.json       # 配置文件
│   └── Backend.csproj         # 项目文件
│
├── Frontend/         # 前端项目
│   ├── Models/          # 数据模型
│   │   ├── LoginRequest.cs
│   │   ├── LoginResponse.cs
│   │   ├── ImageInfo.cs
│   │   └── SelectionRequest.cs
│   ├── Services/  # API 服务
│   │   └── ApiService.cs
│   ├── LoginWindow.xaml       # 登录窗口
│   ├── LoginWindow.xaml.cs
│   ├── MainWindow.xaml   # 主窗口
│   ├── MainWindow.xaml.cs
│   ├── App.xaml           # 应用程序
│   ├── App.xaml.cs
│   └── Frontend.csproj        # 项目文件
│
├── FinalLab.sln     # 解决方案文件
└── README.md # 本文件
```

## 安装与运行

### 前置要求
- .NET 8.0 SDK 或更高版本
- Visual Studio 2022 或 Visual Studio Code
- Windows 操作系统（用于运行 WPF 应用）

### 步骤 1: 克隆或下载项目

```bash
cd D:\code\C#\FinalLab\
```

### 步骤 2: 还原依赖包

```bash
# 在项目根目录
dotnet restore
```

### 步骤 3: 运行后端

```bash
# 进入后端目录
cd Backend

# 运行后端 API (默认端口 5000)
dotnet run
```

后端将在 `http://localhost:5000` 启动。

**注意**: 如果端口被占用，可以修改 `Backend/Properties/launchSettings.json` 或直接指定端口：
```bash
dotnet run --urls "http://localhost:5000"
```

### 步骤 4: 运行前端

**在新的终端窗口中：**

```bash
# 进入前端目录
cd Frontend

# 运行前端应用
dotnet run
```

或者在 Visual Studio 中：
1. 右键点击 `Frontend` 项目
2. 选择"设为启动项目"
3. 按 F5 运行

### 步骤 5: 使用系统

1. 在登录窗口输入测试账号：
   - 用户名: `admin`，密码: `admin123`
   - 用户名: `testuser`，密码: `test123`
   - 用户名: `user1`，密码: `password`

2. 登录成功后，系统会显示图像和选项
3. 选择您的偏好选项
4. 系统自动保存并加载下一张图像
5. 重复此过程

## 测试账号

系统内置以下测试账号（密码已哈希加盐）：

| 用户名 | 密码 | 说明 |
|--------|------|------|
| admin | admin123 | 管理员账号 |
| testuser | test123 | 测试用户 |
| user1 | password | 普通用户 |

## 安全特性

1. **JWT 认证**: 所有需要授权的接口都使用 JWT Token 验证
2. **密码哈希**: 使用 SHA256 + Salt 对密码进行哈希处理
3. **CORS 配置**: 支持跨域请求
4. **授权检查**: 图像和选择接口需要登录后才能访问

## 配置说明

### 后端配置 (appsettings.json)

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

### 前端配置 (ApiService.cs)

```csharp
public string BaseUrl { get; set; } = "http://localhost:5000/api";
```

如果后端运行在不同端口，请修改此地址。

## 常见问题

### Q1: 前端无法连接到后端
**A**: 确保：
1. 后端已经启动并运行在 `http://localhost:5000`
2. 检查防火墙设置
3. 确认 `ApiService.cs` 中的 `BaseUrl` 正确

### Q2: 图像无法显示
**A**: 
1. 确保网络连接正常（使用在线图片服务）
2. 检查防火墙是否阻止了图片请求

### Q3: 登录失败
**A**: 
1. 检查用户名和密码是否正确
2. 查看后端控制台的错误信息
3. 确认后端服务正常运行

### Q4: 编译错误
**A**:
1. 确保安装了 .NET 8.0 SDK
2. 运行 `dotnet restore` 还原依赖
3. 清理并重新生成：`dotnet clean && dotnet build`

## 扩展功能建议

1. **数据库集成**: 集成 Entity Framework Core 和 SQL Server/PostgreSQL
2. **用户注册**: 添加用户注册功能
3. **图像上传**: 允许管理员上传自定义图像
4. **数据统计**: 显示用户选择的统计信息
5. **多语言支持**: 添加国际化支持
6. **单元测试**: 添加完整的单元测试和集成测试

## 开发者信息

- **项目类型**: 实验项目
- **编码**: GB2312 (默认支持)
- **.NET 版本**: 8.0
- **开发工具**: Visual Studio 2022 / VS Code

## 许可证

本项目仅用于学习和实验目的。


---

**祝您使用愉快！** 
