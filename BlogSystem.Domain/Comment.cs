using System;
using BlogSystem.Domain.Common;

namespace BlogSystem.Domain.Entities;

public class Comment : EntityBase
{
  public string Content { get; private set; }
  public Guid UserId { get; private set; }
  public string UserName { get; private set; }
  public DateTime CreatedDate { get; private set; }
  public Guid PostId { get; private set; }

  private Comment() { }

  public Comment(string content, Guid userId, string userName, Guid postId)
  {
    Content = content;
    UserId = userId;
    UserName = userName;
    PostId = postId;
    CreatedDate = DateTime.UtcNow;
  }

  public void UpdateContent(string content)
  {
    Content = content;
  }
}
