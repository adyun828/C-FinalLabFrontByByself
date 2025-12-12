using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("T_Images")]
    public class ImageInfo
    {
        [Key] // 主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 自增
        public int Id { get; set; }

        [Required] // 必填
        [MaxLength(200)] // 限制标题长度
        public string Title { get; set; } = string.Empty;

        // 指定为 TEXT 类型，适合存储长字符串（Base64）
        [Column(TypeName = "TEXT")]
        public string IMageBase64 { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;
    }
}
