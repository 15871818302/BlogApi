using System;
using System.Collections.Generic;
using BlogSystem.Domain.Common;
using BlogSystem.Domain.ValueObjects;

namespace BlogSystem.Domain.Entities;

public class Post : EntityBase
{
  public string Title { get; private set; }
  public string Content { get; private set; }
  public string Slug { get; private set; }
  public DateTime CreatedDate { get; private set; }
  public PostStatus Status { get; private set; }
  public DateTime? PublishedDate { get; private set; }
  public DateTime? LastModifiedDate { get; private set; }
  public Guid AuthorId { get; private set; }
  public virtual ICollection<Comment> Comments { get; private set; }
  public virtual ICollection<Tag> Tags { get; private set; }

  // 无参构造函数(为ORM保留)
  private Post() { }

  // 添加带参数的构造函数
  public Post(string title, string content, Guid authorId)
  {
    Title = title;
    Content = content;
    AuthorId = authorId;
    Slug = GenerateSlug(title);
    CreatedDate = DateTime.UtcNow;
    Status = PostStatus.Draft;
    Comments = new List<Comment>();
    Tags = new List<Tag>();
  }

  // 发布
  public void Publish()
  {
    Status = PostStatus.Published;
    PublishedDate = DateTime.UtcNow;
  }
  // 添加评论
  public void AddComment(string content, Guid userId, string userName)
  {
    var comment = new Comment(content, userId, userName, Id);
    Comments.Add(comment);
  }
  // 更新
  public void Update(string title, string content)
  {
    Title = title;
    Content = content;
    LastModifiedDate = DateTime.UtcNow;

    if (Status == PostStatus.Published)
    {
      Slug = GenerateSlug(title);
    }
  }
  // 添加标签
  public void AddTag(Tag tag)
  {
    Tags.Add(tag);
  }

  private string GenerateSlug(string title)
  {
    // 简单实现 - 实际项目中应更复杂
    return title.ToLower().Replace(" ", "-");
  }
}
