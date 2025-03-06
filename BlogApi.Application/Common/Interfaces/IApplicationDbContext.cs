using BlogSystem.Domain.Entities;
using BlogSystem.Domain.Common;
using BlogSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Application.Common.Interfaces;

/// <summary>
/// 应用数据库上下文接口，定义应用程序需要访问的所有实体集合
/// </summary>
public class IApplicationDbContext
{
  // 文章合集
  DbSet<Post> Posts { get; }

  // 文章评论合集
  DbSet<Comment> Comments { get; }

  // 标签合集
  DbSet<Tag> Tags { get; }

  // 作者合集
  DbSet<Author> Authors { get; }

  // 保存更改
  Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
