# 图像选择系统 - 详细说明文档

## 项目概述

这是一个完整的前后端分离的图像选择系统，满足所有基础目标要求。

### 已实现的功能

#### 后端 (Backend)
- ? ASP.NET Core Web API RESTful 服务
- ? JWT 身份验证机制
- ? 用户登录接口 (POST /api/Auth/login)
- ? 获取图像接口 (GET /api/Images) - 需要登录
- ? 保存选择接口 (POST /api/Selections) - 需要登录
- ? 密码哈希加盐存储（SHA256）
- ? 静态测试用户数据（3个账号）
- ? 静态图像数据（10张图片）
- ? CORS 跨域支持

#### 前端 (Frontend)
- ? WPF 桌面图形界面
- ? 用户登录窗口
- ? 图像展示与选择界面
- ? HTTP 请求（GET, POST）
- ? JWT Token 管理
- ? 自动循环加载图像
- ? 友好的用户体验

## 快速开始

### 环境要求
- .NET 8.0 SDK
- Windows 操作系统（WPF 应用）
- Visual Studio 2022 或 VS Code（推荐）

### 启动步骤

#### 方法一：命令行启动

**1. 启动后端（终端1）**
```bash
cd D:\code\C#\FinalLab\Backend
dotnet run
```
后端将在 http://localhost:5000 启动

**2. 启动前端（终端2）**
```bash
cd D:\code\C#\FinalLab\Frontend
dotnet run
```

**3. 登录使用**
- 用户名: `admin`，密码: `admin123`
- 用户名: `testuser`，密码: `test123`
- 用户名: `user1`，密码: `password`

#### 方法二：Visual Studio 启动

1. 打开 `FinalLab.sln`
2. 右键 Backend 项目 -> 调试 -> 启动新实例
3. 右键 Frontend 项目 -> 调试 -> 启动新实例

## 项目结构说明

### 后端结构
```
Backend/
├── Controllers/     # API 控制器
│   ├── AuthController.cs         # 登录认证
│   ├── ImagesController.cs       # 图像管理
│   └── SelectionsController.cs   # 选择记录
├── Services/           # 业务逻辑
│   ├── UserService.cs # 用户认证、JWT生成
│   ├── ImageService.cs    # 图像数据管理
│   └── SelectionService.cs# 选择记录存储
├── Models/         # 数据模型
└── DTOs/           # 数据传输对象
```

### 前端结构
```
Frontend/
├── LoginWindow.xaml/.cs  # 登录窗口
├── MainWindow.xaml/.cs   # 主窗口
├── Services/
│   └── ApiService.cs    # HTTP 请求服务
└── Models/               # 数据模型
```

## 工作流程

### 1. 登录流程
```
用户输入账号密码 → 发送 POST 请求 → 后端验证 → 
返回 JWT Token → 前端保存 Token → 进入主界面
```

### 2. 图像选择流程
```
请求图像列表 → 后端验证 Token → 返回随机图像 → 
前端展示 → 用户选择选项 → 提交选择 → 
后端保存 → 自动加载下一张
```

## API 接口详解

### 1. 登录接口
**请求**
```http
POST /api/Auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "admin123"
}
```

**成功响应**
```json
{
  "success": true,
  "message": "登录成功",
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "username": "admin"
}
```

### 2. 获取图像接口
**请求**
```http
GET /api/Images?count=3
Authorization: Bearer {token}
```

**响应**
```json
[
  {
    "id": 1,
    "title": "风景图片1",
    "description": "美丽的山景",
 "imageUrl": "https://picsum.photos/400/300?random=1",
    "options": ["非常喜欢", "喜欢", "一般", "不喜欢"]
  }
]
```

### 3. 保存选择接口
**请求**
```http
POST /api/Selections
Authorization: Bearer {token}
Content-Type: application/json

{
  "imageId": 1,
  "selectedOption": "非常喜欢"
}
```

**响应**
```json
{
  "success": true,
  "message": "选择已保存"
}
```

## 技术实现细节

### JWT 认证实现
```csharp
// 生成 Token
var claims = new[] {
    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
};
var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(60));
```

### 密码安全处理
```csharp
// SHA256 + Salt
string HashPassword(string password) {
    string salt = "StaticSaltForDemo";
    using var sha256 = SHA256.Create();
    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
    return Convert.ToBase64String(hashedBytes);
}
```

### HTTP 请求实现
```csharp
// 前端 ApiService
public async Task<LoginResponse> LoginAsync(string username, string password) {
    var request = new LoginRequest { Username = username, Password = password };
    var json = JsonConvert.SerializeObject(request);
    var content = new StringContent(json, Encoding.UTF8, "application/json");
    var response = await _httpClient.PostAsync($"{BaseUrl}/Auth/login", content);
    return JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());
}
```

## 数据说明

### 静态用户数据
系统内置 3 个测试账号：

| ID | 用户名 | 密码 | 密码哈希值 |
|----|--------|------|------------|
| 1 | admin | admin123 | 已哈希存储 |
| 2 | testuser | test123 | 已哈希存储 |
| 3 | user1 | password | 已哈希存储 |

### 静态图像数据
- 共 10 张图片
- 使用在线图片服务（Lorem Picsum）
- 每张图片包含 4 个选项
- 每次随机返回指定数量

## 安全特性

### 1. 身份验证
- 所有图像和选择接口都需要 JWT Token
- Token 有效期 60 分钟
- 无效 Token 返回 401 Unauthorized

### 2. 密码安全
- 永不明文存储密码
- SHA256 哈希算法
- 加盐处理（实际应用应为每个用户使用不同的盐）

### 3. API 保护
- `[Authorize]` 特性保护敏感接口
- Claims 验证用户身份
- CORS 配置支持跨域访问

## 配置说明

### 后端配置（appsettings.json）
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

### 前端配置（ApiService.cs）
```csharp
public string BaseUrl { get; set; } = "http://localhost:5000/api";
```

## 常见问题

### Q1: 无法连接后端
**原因**: 后端未启动或端口被占用
**解决**: 
1. 确认后端已运行
2. 检查 http://localhost:5000 是否可访问
3. 查看后端控制台错误信息

### Q2: 登录失败
**原因**: 用户名或密码错误
**解决**: 使用提供的测试账号

### Q3: 图片不显示
**原因**: 网络连接问题或防火墙阻止
**解决**: 
1. 检查网络连接
2. 允许应用访问网络

### Q4: Token 过期
**原因**: Token 有效期 60 分钟
**解决**: 重新登录获取新 Token

## 扩展建议

### 可以添加的功能
1. **数据库集成**: 使用 Entity Framework Core + SQL Server
2. **用户注册**: 添加注册接口和界面
3. **图像上传**: 允许管理员上传自定义图像
4. **数据统计**: 显示用户选择的统计图表
5. **导出功能**: 导出选择记录为 Excel/CSV
6. **多语言**: 支持中英文切换

### 生产环境改进
1. 使用真实数据库
2. 每个用户独立的密码盐
3. 刷新 Token 机制
4. 日志记录（Serilog）
5. 单元测试和集成测试
6. Docker 容器化部署
7. HTTPS 加密传输

## 测试说明

### 手动测试
1. 启动后端和前端
2. 使用测试账号登录
3. 查看图像是否正确显示
4. 选择选项后是否自动保存和跳转
5. 退出登录功能是否正常

### API 测试
使用 PowerShell 或 Postman 测试（见 API_TESTING.md）

## 技术栈总结

| 层次 | 技术 | 版本 |
|------|------|------|
| 后端框架 | ASP.NET Core | 8.0 |
| 前端框架 | WPF | .NET 8.0 |
| 认证方式 | JWT | Bearer Token |
| 序列化 | Newtonsoft.Json | 13.0.3 |
| 加密算法 | SHA256 | - |
| 开发工具 | Visual Studio | 2022 |

## 项目亮点

1. ? **完整的前后端分离架构**
2. ? **标准的 RESTful API 设计**
3. ? **JWT 身份验证实现**
4. ? **密码安全处理（哈希+盐）**
5. ? **清晰的项目结构**
6. ? **友好的用户界面**
7. ? **完整的文档**

## 学习收获

通过本项目，您应该掌握：

1. ? 如何使用 .NET 构建 Web API
2. ? 如何实现 JWT 认证
3. ? 如何进行密码安全处理
4. ? 如何在 WPF 中进行 HTTP 请求
5. ? 如何设计 RESTful API
6. ? 前后端分离的开发模式
7. ? 异步编程（async/await）

## 致谢

本项目用于教学和实验目的，展示了现代 .NET 开发的最佳实践。

---

**祝您学习愉快！如有问题，请查阅其他文档或提出 Issue。** ??
