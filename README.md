# aspnetcore-webapi-seed

This is a seed project that contains various setup that I think is useful when building an Asp.Net Core Web Api project. It includes:
* Swagger UI
* JsonConverters for strong types.
* Stylecop

## JsonConverters for strong types
I think strong types can be useful for leveraging compile-time checks on code correctness. For example, where ambiguity arises, if strong types are used for numeric identifier types, it can help to avoid identifiers being passed into the wrong argument of a function.

For the strong types I used, Newtonsoft.Json's default behaviour is to serialize these objects as `{}`. By labelling the underlying value type using `JsonProperty` this would be seralized as `{value: 1}` for example, which is verbose for an identifier type. The strong type converter in this project serializes strong value types as the underlying `int` or `long`, i.e. just `1`. It could be easily extended to handle other data types.
