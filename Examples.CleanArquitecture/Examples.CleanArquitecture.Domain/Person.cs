using Examples.CleanArquitecture.Domain.Common;

namespace Examples.CleanArquitecture.Domain;

public sealed class Person : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
