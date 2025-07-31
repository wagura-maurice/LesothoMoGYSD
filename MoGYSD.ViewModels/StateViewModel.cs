namespace MoGYSD.ViewModels;
/// <summary>
/// Generic view model for representing operation states/results with payload data
/// </summary>
/// <typeparam name="T">Type of the data payload included in the response</typeparam>
public class StateViewModel<T>
{
    /// <summary>Status code indicating operation result (e.g., 200 for success)</summary>
    public int Code { get; set; }

    /// <summary>Human-readable message describing the operation outcome</summary>
    public string Msg { get; set; }

    /// <summary>Actual data payload returned by the operation</summary>
    public T Data { get; set; }

    /// <summary>Count of items in the data payload (useful for paging scenarios)</summary>
    public int Count { get; set; }
}

/// <summary>
/// Basic model representing stored procedure output with identifier
/// </summary>
public class SPOutput
{
    /// <summary>Unique identifier returned from stored procedure execution</summary>
    public int Id { get; set; }
}
