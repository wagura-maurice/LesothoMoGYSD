namespace MoGYSD.Services;
/// <summary>
/// Service for processing string properties within entities using specified processing functions.
/// Implements <see cref="IStringProcessingService"/> to provide generic string processing capabilities.
/// </summary>
public class StringProcessingService : IStringProcessingService
{
    /// <summary>
    /// Processes all string properties of an entity using the specified string processor function.
    /// </summary>
    /// <typeparam name="T">The type of the entity</typeparam>
    /// <param name="entity">The entity instance to process</param>
    /// <param name="stringProcessor">Function that processes individual string values</param>
    /// <remarks>
    /// This method will:
    /// 1. Check for null entity
    /// 2. Find all writable string properties
    /// 3. Apply the string processor to each non-null/empty string value
    /// 4. Set the processed value back to the property
    /// </remarks>
    public void ProcessEntityStrings<T>(T entity, Func<string, string> stringProcessor)
    {
        if (entity == null) return;

        var properties = typeof(T).GetProperties()
            .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

        foreach (var property in properties)
        {
            var currentValue = (string)property.GetValue(entity);
            if (!string.IsNullOrEmpty(currentValue))
            {
                var processedValue = stringProcessor(currentValue);
                property.SetValue(entity, processedValue);
            }
        }
    }
}

public interface IStringProcessingService
{
    void ProcessEntityStrings<T>(T entity, Func<string, string> stringProcessor);
}