namespace Examples.CleanArquitecture.Domain.Common;

public abstract class BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? DateCreated { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? DateModified { get; set; }
}
