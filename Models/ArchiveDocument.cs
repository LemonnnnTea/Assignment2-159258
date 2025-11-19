using System;
using System.ComponentModel.DataAnnotations; // 用于数据类型注解

namespace MyArchiveProject.Models
{
    public class ArchiveDocument
    {
        public int Id { get; set; }

        public string Title { get; set; } // 档案名称

        public string Category { get; set; } // 档案类别 (如：人事、财务)

        public string Author { get; set; } // 上传人

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; } // 上传日期

        public string Description { get; set; } // 详细描述

        public string SecurityLevel { get; set; } // 密级 (公开/机密)
    }
}