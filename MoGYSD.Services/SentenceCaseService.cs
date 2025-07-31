using System.Text;

namespace MoGYSD.Services;

/// <summary>
/// Service implementation for converting text to sentence case.
/// Implements the ISentenceCaseService interface to provide sentence case conversion functionality.
/// </summary>
public class SentenceCaseService : ISentenceCaseService
{
    private readonly IStringProcessingService _stringProcessingService;
    public SentenceCaseService(IStringProcessingService stringProcessing)
    {
        _stringProcessingService = stringProcessing;
    }
    public string ToSentenceCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Convert to lowercase first, then capitalize first letter
        return input.Length == 1
            ? input.ToUpper()
            : char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }
    public string ToProperSentenceCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        // Convert entire string to lowercase first
        string lowerInput = input.ToLower();

        // Capitalize first letter
        var result = new StringBuilder(char.ToUpper(lowerInput[0]) + lowerInput.Substring(1));

        // Capitalize letters following a period+space
        for (int i = 1; i < result.Length - 2; i++)
        {
            if (result[i] == '.' && char.IsWhiteSpace(result[i + 1]))
            {
                result[i + 2] = char.ToUpper(result[i + 2]);
            }
        }

        return result.ToString();
    }
    public void ProcessEntityStrings<T>(T entity)
    {
        _stringProcessingService.ProcessEntityStrings(entity, ToProperSentenceCase);
    }
}

public interface ISentenceCaseService
{
    string ToSentenceCase(string input);
    string ToProperSentenceCase(string input);
    void ProcessEntityStrings<T>(T entity);
}


