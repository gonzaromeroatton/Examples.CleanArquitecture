using FluentValidation.Results;

namespace Examples.CleanArquitecture.Application.Exceptions;

/// <summary>
/// 
/// </summary>
public sealed class BadRequestException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public BadRequestException(string message) : base(message) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="validationResult"></param>
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }

    /// <summary>
    /// 
    /// </summary>
    public IDictionary<string, string[]> ValidationErrors { get; set; } = new Dictionary<string, string[]>();
}
