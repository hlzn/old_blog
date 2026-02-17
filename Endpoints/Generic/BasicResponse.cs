namespace hlzn1.APIModels;

public class BasicResponse<T>
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; } = default!;
    public bool? MightBeMore { get; set; }
}