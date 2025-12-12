using Backend.Models;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    // ==========================================
    // 1. 数据库上下文 (DbContext)
    // 负责管理实体对象与数据库表之间的连接
    // ==========================================
    public class AppDbContext : DbContext
    {
        // 对应您定义的三个实体模型
        public DbSet<ImageInfo> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSelection> UserSelections { get; set; }

        // 配置数据库路径
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 这里指定数据库文件名为 "app.db"，它会在运行目录下生成
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }

    // ==========================================
    // 2. 仓储层 (Repository)
    // 封装所有具体的 CRUD 业务逻辑
    // ==========================================
    public class DataRepository
    {
        // ---------------------------------------------------------
        // 初始化与工具方法
        // ---------------------------------------------------------

        // 确保数据库已创建 (仅用于演示/开发环境)
        public void InitializeDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        // ---------------------------------------------------------
        // User (用户) 相关操作
        // ---------------------------------------------------------

        // [Create] 创建新用户
        public User AddUser(string username, string passwordHash, bool isAdmin = false)
        {
            using (var context = new AppDbContext())
            {
                // 检查用户是否已存在
                if (context.Users.Any(u => u.Username == username))
                {
                    throw new Exception("用户名已存在");
                }

                var user = new User
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    IsAdmin = isAdmin,
                    CreatedAt = DateTime.Now
                };

                context.Users.Add(user);
                context.SaveChanges();
                
                return user;
            }
        }

        // [Read] 根据用户名查找用户 (用于登录验证)
        public User? GetUserByUsername(string username)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        // [Update] 修改用户密码
        public bool UpdatePassword(string username, string newHash)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null) return false;

                user.PasswordHash = newHash;
                context.SaveChanges();
                return true;
            }
        }

        // ---------------------------------------------------------
        // ImageInfo (图片) 相关操作
        // ---------------------------------------------------------

        // [Create] 上传/保存图片信息
        public int AddImage(string title, string base64Data, string type)
        {
            using (var context = new AppDbContext())
            {
                var img = new ImageInfo
                {
                    Title = title,
                    IMageBase64 = base64Data,
                    Type = type
                };

                context.Images.Add(img);
                context.SaveChanges();
                return img.Id; // 返回生成的ID，供后续使用
            }
        }

        // [Read] 获取所有图片列表
        public List<ImageInfo> GetAllImages()
        {
            using (var context = new AppDbContext())
            {
                return context.Images.ToList();
            }
        }

        // [Delete] 删除图片
        // 注意：如果数据库开启了级联删除，这也会删除关联的 UserSelection
        public void DeleteImage(int imageId)
        {
            using (var context = new AppDbContext())
            {
                var img = context.Images.Find(imageId);
                if (img != null)
                {
                    context.Images.Remove(img);
                    context.SaveChanges();
                }
            }
        }

        // ---------------------------------------------------------
        // UserSelection (用户选择) 相关操作 - 重点
        // ---------------------------------------------------------

        // [Create] 记录用户的选择
        public void AddSelection(string username, int imageId, string option)
        {
            using (var context = new AppDbContext())
            {
                // 验证图片是否存在 (虽然外键约束会检查，但在代码层检查更友好)
                var imageExists = context.Images.Any(i => i.Id == imageId);
                if (!imageExists) throw new Exception("指定的图片不存在");

                var selection = new UserSelection
                {
                    Username = username,
                    ImageId = imageId, // 这里直接使用外键ID
                    SelectedOption = option,
                    SelectedAt = DateTime.Now
                };

                context.UserSelections.Add(selection);
                context.SaveChanges();
            }
        }

        // [Read] 获取用户的历史记录 (包含图片详情)
        // 这个方法展示了如何利用 UserSelection 类中的 public virtual ImageInfo Image 属性
        public List<UserSelection> GetUserHistory(string username)
        {
            using (var context = new AppDbContext())
            {
                return context.UserSelections
                    // .Include 类似于 SQL 中的 JOIN
                    // 它会把关联的 ImageInfo 数据填充到 selection.Image 属性中
                    .Include(s => s.Image)
                    .Where(s => s.Username == username)
                    .OrderByDescending(s => s.SelectedAt) // 按时间倒序
                    .ToList();
            }
        }
    }
}
