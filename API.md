# 图像选择系统 API 文档

**基础URL:** `http://localhost:5000/api`  
**认证:** JWT Bearer Token  
**数据库:** SQLite (app.db)

---

## 数据模型

### User (T_Users)
| 字段 | 类型 | 说明 |
|------|------|------|
| Id | int | 自增主键 |
| Username | string(50) | 用户名（必填） |
| PasswordHash | string | 密码哈希（必填） |
| CreatedAt | DateTime | 创建时间 |
| IsAdmin | bool | 是否管理员 |

### ImageInfo (T_Images)
| 字段 | 类型 | 说明 |
|------|------|------|
| Id | int | 自增主键 |
| Title | string(200) | 图片标题（必填） |
| IMageBase64 | TEXT | Base64图片数据 |
| Type | string(50) | 图片类型 (image/png, image/jpeg) |

### UserSelection (T_UserSelections)
| 字段 | 类型 | 说明 |
|------|------|------|
| Id | int | 自增主键 |
| Username | string(50) | 用户名（必填） |
| ImageId | int | 图片ID外键 |
| Image | ImageInfo | 关联的图片对象 |
| SelectedOption | string | 选择的选项（**允许值: "优" / "良" / "差"**） |
| SelectedAt | DateTime | 选择时间 |

**SelectedOption 允许的值:**
- `"优"` - 表示非常满意
- `"良"` - 表示满意
- `"差"` - 表示不满意

---

## API 接口
{
  "success": true,
  "message": "注册成功",
  "userId": 4,        // 后端生成并返回
  "username": "newuser"
}
```

**错误响应:**
- `400` - 用户名已存在 / 参数格式错误 / 密码强度不足
- `500` - 服务器错误

---

### 2. 用户登录

```http
POST /api/Auth/login
Content-Type: application/json
```
```json
{
  "username": "admin",
  "password": "admin123"
}
```

**响应 (200)**
```json
{
  "success": true,
  "message": "登录成功",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "username": "admin"
}
```

**错误响应:**
- `400` - 用户名或密码为空
- `401` - 用户名或密码错误
- `500` - 服务器错误

---

### 3. 获取随机图片

```http
GET /api/Images?count=3
Authorization: Bearer {token}
```

**参数:** `count` (1-10, 默认3)

**响应 (200)**
```json
[
  {
    "id": 1,
    "title": "风景图片1",
    "iMageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
    "type": "image/png"
  }
]
```

---

### 4. 根据ID获取图片

```http
GET /api/Images/{id}
Authorization: Bearer {token}
```

**响应 (200)**
```json
{
  "id": 1,
  "title": "风景图片1",
  "iMageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
  "type": "image/png"
}
```

**错误响应:**
- `401` - 未授权
- `404` - 图片不存在
- `500` - 服务器错误

---

### 5. 上传图片（客户端添加图片）

```http
POST /api/Images
Authorization: Bearer {token}
Content-Type: application/json
```
```json
{
  "title": "新上传的图片",
  "imageBase64": "iVBORw0KGgoAAAANSUhEUgAAAAEAAAAB...",
  "type": "image/png"
}
```

**请求参数说明:**
| 字段 | 类型 | 必填 | 说明 |
|------|------|------|------|
| title | string(200) | 是 | 图片标题 |
| imageBase64 | string | 是 | Base64编码的图片数据（不含前缀） |
| type | string(50) | 是 | 图片类型 (image/png, image/jpeg, image/gif, image/webp) |

**响应 (201)**
```json
{
  "success": true,
  "message": "图片上传成功",
  "imageId": 123
}
```

**错误响应:**
- `400` - 参数无效（标题为空、Base64格式错误、类型不支持）
- `401` - 未授权
- `500` - 服务器错误

---

### 5. 保存选择记录

```http
POST /api/Selections
Authorization: Bearer {token}
Content-Type: application/json
```
```json
{
  "imageId": 1,
  "selectedOption": "优"
}
```

**请求参数说明:**
| 字段 | 类型 | 必填 | 允许值 |
|------|------|------|--------|
| imageId | int | 是 | > 0 |
| selectedOption | string | 是 | **"优" / "良" / "差"** |

**响应 (200)**
```json
{
  "success": true,
  "message": "选择已保存"
}
```

**错误响应:**
- `400` - 参数无效（imageId ≤ 0 或 selectedOption 不在允许值范围内）
- `401` - 未授权
- `500` - 服务器错误

---

### 6. 获取选择历史

```http
GET /api/Selections
Authorization: Bearer {token}
```

**响应 (200)**
```json
[
  {
    "id": 1,
    "username": "admin",
    "imageId": 1,
    "image": {
      "id": 1,
      "title": "风景图片1",
      "iMageBase64": "...",
      "type": "image/png"
    },
    "selectedOption": "优",
    "selectedAt": "2025-12-06T10:30:00Z"
  }
]
```

---

## 错误码

| 状态码 | 说明 |
|--------|------|
| 200 | 成功 |
| 201 | 创建成功（注册、上传） |
| 400 | 请求错误（参数无效、验证失败） |
| 401 | 未授权（Token无效或过期、密码错误） |
| 404 | 资源不存在 |
| 500 | 服务器错误 |

---

## 快速测试（PowerShell）

```powershell
# 1. 注册新用户
$registerBody = @{
    username = "testuser"
    password = "Test123456"
} | ConvertTo-Json

try {
    $register = Invoke-RestMethod -Uri "http://localhost:5000/api/Auth/register" `
        -Method Post -Body $registerBody -ContentType "application/json"
    Write-Host "✓ 注册成功: $($register.username)" -ForegroundColor Green
} catch {
    Write-Host "注册失败（可能用户已存在）" -ForegroundColor Yellow
}

# 2. 登录
$login = Invoke-RestMethod -Uri "http://localhost:5000/api/Auth/login" `
    -Method Post -Body '{"username":"testuser","password":"Test123456"}' `
    -ContentType "application/json"
Write-Host "✓ 登录成功，Token: $($login.token.Substring(0,20))..." -ForegroundColor Green

# 3. 获取图片
$headers = @{ Authorization = "Bearer $($login.token)" }
$images = Invoke-RestMethod -Uri "http://localhost:5000/api/Images?count=3" `
    -Headers $headers
Write-Host "✓ 获取到 $($images.Count) 张图片" -ForegroundColor Green

# 4. 上传图片
$uploadBody = @{
    title = "测试图片"
    imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
    type = "image/png"
} | ConvertTo-Json

$uploadResult = Invoke-RestMethod -Uri "http://localhost:5000/api/Images" `
    -Method Post -Body $uploadBody -ContentType "application/json" -Headers $headers
Write-Host "上传成功，图片ID: $($uploadResult.imageId)"

# 5. 提交选择（使用允许的值：优/良/差）
$selectionResult = Invoke-RestMethod -Uri "http://localhost:5000/api/Selections" `
    -Method Post -Body "{`"imageId`":$($images[0].id),`"selectedOption`":`"优`"}" `
    -ContentType "application/json" -Headers $headers
Write-Host "✓ $($selectionResult.message)" -ForegroundColor Green

# 6. 查看历史
$history = Invoke-RestMethod -Uri "http://localhost:5000/api/Selections" -Headers $headers
Write-Host "✓ 历史记录数: $($history.Count)" -ForegroundColor Green
$history | Format-Table ImageId, SelectedOption, SelectedAt
```

---

## 附录：SelectedOption 值说明

**定义位置:** `Backend.Models.UserSelection.SelectedOption` 字段

**允许的值（枚举式字符串）:**

| 值 | 含义 | 使用场景 |
|----|------|----------|
| `"优"` | 非常满意 | 图片质量优秀、内容符合预期 |
| `"良"` | 满意 | 图片质量良好、基本符合预期 |
| `"差"` | 不满意 | 图片质量较差、不符合预期 |

**注意事项:**
- 提交选择时必须使用上述三个值之一
- 建议在后端实现时添加验证逻辑，拒绝非法值
- 前端应提供下拉选择或单选按钮，避免用户输入错误值

---

**更新日期:** 2025-12-07
