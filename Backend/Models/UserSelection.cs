using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    // 3. 用户选择记录表
    [Table("T_UserSelections")]
    public class UserSelection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 注意：通常关系型数据库建议使用 UserId (int) 作为外键
        // 但如果您业务逻辑必须存 Username，可以保留这样
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        // --- 外键关系配置 ---

        // 外键字段
        public int ImageId { get; set; }

        // [ForeignKey] 建立关联：
        // 告诉 ORM，上面的 "ImageId" 字段是对应 "ImageInfo" 表的外键
        [ForeignKey("ImageId")]
        public virtual ImageInfo? Image { get; set; }

        public string SelectedOption { get; set; } = string.Empty;

        public DateTime SelectedAt { get; set; } = DateTime.Now;
    }


}
