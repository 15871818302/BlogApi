using System;
using System.Collections.Generic;
using BlogSystem.Domain.Common;

namespace BlogSystem.Domain.Entities;

public class Author : EntityBase
{
  public string Name { get; private set; }
  public string Email { get; private set; }
  public string Bio { get; private set; }
  public virtual ICollection<Post> Posts { get; private set; }

  private Author() { } // 为ORM保留

  public Author(string name, string email, string bio)
  {
    Name = name;
    Email = email;
    Bio = bio;
    Posts = new List<Post>();
  }

  public void UpdateProfile(string name, string bio)
  {
    Name = name;
    Bio = bio;
  }

}
