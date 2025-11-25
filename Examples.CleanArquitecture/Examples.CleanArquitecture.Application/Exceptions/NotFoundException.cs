namespace Examples.CleanArquitecture.Application.Exceptions;

/// <summary>
/// 
/// </summary>
public sealed class NotFoundException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="key"></param>
    public NotFoundException(string name, object key) :
        base($"{name} ({key}) was not found.")
    {

    }
}
