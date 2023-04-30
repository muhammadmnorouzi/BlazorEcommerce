namespace BlazorEcommerce.Shared.Extensions;

public static class UriBuilderExtensions
{
    public static void AddQuery(this UriBuilder builder, string name, string value)
    {
        string queryToAppend = $"{name}={value}";

        if (builder.Query != null && builder.Query.Length > 1)
        {
            builder.Query = builder.Query.Substring(1) + "&" + queryToAppend;
        }
        else
        {
            builder.Query = queryToAppend;
        }
    }
}