using Microsoft.AspNetCore.Mvc;
using MyArchiveProject.Models;
using System;
using System.Collections.Generic;
using System.Linq; // 必须引用 LINQ

namespace MyArchiveProject.Controllers
{
    public class ArchiveController : Controller
    {
        // 模拟数据库数据 (静态列表，保持数据持久)
        private static List<ArchiveDocument> _archives = new List<ArchiveDocument>
        {
            new ArchiveDocument { Id = 1, Title = "2024年度财务审计", Category = "财务部", Author = "张会计", UploadDate = new DateTime(2024, 1, 15), Description = "年度最终审计报告，包含所有收支明细。", SecurityLevel = "机密" },
            new ArchiveDocument { Id = 2, Title = "新员工入职手册 V2", Category = "人事部", Author = "李经理", UploadDate = new DateTime(2024, 3, 10), Description = "更新了带薪休假政策和保险流程。", SecurityLevel = "公开" },
            new ArchiveDocument { Id = 3, Title = "Alpha 项目技术架构", Category = "技术部", Author = "王工", UploadDate = new DateTime(2024, 5, 20), Description = "核心服务器架构图及数据库设计规范。", SecurityLevel = "机密" },
            new ArchiveDocument { Id = 4, Title = "食堂采购清单", Category = "后勤部", Author = "赵主管", UploadDate = new DateTime(2024, 6, 01), Description = "6月份蔬菜肉类采购预算。", SecurityLevel = "公开" }
        };

        // 页面：档案列表 (含搜索)
        // GET: /Archive/
        public IActionResult Index(string searchString)
        {
            // 获取所有数据
            var documents = from d in _archives
                            select d;

            // 【LINQ Searching 实现】
            // 如果搜索框有内容，则过滤 Title 或 Category
            if (!string.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(s => s.Title.Contains(searchString) || s.Category.Contains(searchString));
            }

            // 按日期降序排列 (最新的在前面)
            documents = documents.OrderByDescending(d => d.UploadDate);

            return View(documents.ToList());
        }

        // 页面：档案详情
        // GET: /Archive/Details/5
        public IActionResult Details(int id)
        {
            // 使用 LINQ 查找特定 ID
            var doc = _archives.FirstOrDefault(m => m.Id == id);

            if (doc == null)
            {
                return NotFound();
            }

            return View(doc);
        }
    }
}