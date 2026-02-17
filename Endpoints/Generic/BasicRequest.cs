namespace hlzn1.APIModels;

public class BasicRequest
{
    public required string Id { get; set; } = string.Empty;
}

public class BasicCollectionRequest
{
    public int? Page { get; set; } = 0;
}

public class BasicCreateUpdateRequest<T>
{
    public T Data { get; set; } = default!;
}

public class BasicCreateUpdateResponse<T>
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; } = default!;
}
