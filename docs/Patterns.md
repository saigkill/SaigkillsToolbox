# Pipeline Pattern

This is a behavioral pattern where the main goal is to split a complex job into multiple steps, each with a specific functionality. It’s really good for several types of architectures. For a system composed of various microservices with numerous components, this is a way to keep things easier to read and maintain.
This pattern has several key concepts similar to the chain of responsibility one.

## IPipeline

```csharp
public interface IPipeline<T>
{
    public string Name { get; set; }
    public IReadOnlyCollection<IStep> Steps { get; }
    void WithStep(IStep step);
    Task<T> StartAsync(IData data);
}
```

## IStep

```csharp
public interface IStep
{
    Task<IData> ExecuteAsync(IData data);
}
```

## Pipeline generic

```csharp
public class Pipeline<T> : IPipeline<T> where T : IData
{
    private readonly List<IStep> _steps = new();
    public string Name { get; set; }
    public IReadOnlyCollection<IStep> Steps => _steps;

    public Pipeline(string name)
    {
        Name = name;
    }

    public void WithStep(IStep step)
    {
        _steps.Add(step);
    }

    public async Task<T> StartAsync(IData input)
    {
        IData result = input;
        foreach (var step in Steps)
        {
            try
            {
                result = await step.ExecuteAsync(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        return (T)result;
    }
}
```

## Example Usage

```csharp
var pipeline = new Pipeline<OutputData>("MyFirstPipeline");

pipeline.WithStep(new ToUpperStep());
pipeline.WithStep(new TextLengthStep());

var input = new InputData
{
   Text = "Hello World!"
};

var output = await pipeline.StartAsync(input);

Console.WriteLine($"Starting pipeline {pipeline.Name}...");
Console.WriteLine($"Input text: '{input.Text}'");
Console.WriteLine($"Length of text is: {output.Result}");
```

Idea from [Tiago Martins](https://medium.com/@martinstm/pipeline-pattern-c-e01e2dd7238c).

# Result pattern

## Result

This class can be used for using the result pattern.

### Usage

```csharp
public Result<string> GetUserNameById(int userId)
{
    if (userId <= 0)
    {
        return Result<string>.Failure("Invalid user ID");
    }

    // We simulate obtaining a username
    string userName = "John Doe"; // This would be the actual logic to get the name

    return Result<string>.Success(userName);
}

public void ProcessUserName()
{
    var result = GetUserNameById(1);

    if (result.IsSuccess)
    {
        Console.WriteLine($"User name: {result.Value}");
    }
    else
    {
        Console.WriteLine($"Error: {result.ErrorMessage}");
    }
}
```

### More
More about that on: [David May](https://medium.com/@davisaac8/an-alternative-to-try-catch-in-c-b0e5dfafa910)