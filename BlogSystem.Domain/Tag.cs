using System.Collections.Generic;
using BlogSystem.Domain.Common;

namespace BlogSystem.Domain.ValueObjects;

public class Tag : ValueObject
{
  public string Name { get; private set; }

  private Tag() { } // 为ORM保留

  public Tag(string name)
  {
    Name = name.ToLower();
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
  }
}
