using BenchmarkDotNet.Attributes;

namespace TestAsync;

[MemoryDiagnoser]
public class Benchy
{
    public static readonly Task<string> ExampleTask = Task.FromResult("I'm great developer.");
    public static readonly ValueTask<string> ExampleValueTask = new ValueTask<string>("I'm great!");

    [Benchmark]
    public async Task<string> GetStringWithAsync()
    {
        return await GetStringWithAsyncCore();
    }

    private async Task<string> GetStringWithAsyncCore()
    {
        return await ExampleTask;
    }

    [Benchmark]
    public async Task<string> GetStringWithoutAsync()
    {
        return await GetStringWithoutAsyncCore();
    }

    private Task<string> GetStringWithoutAsyncCore()
    {
        return ExampleTask;
    }

    [Benchmark]
    public async ValueTask<string> GetStringWithoutAsyncValue()
    {
        return await GetStringWithoutAsyncValueCore();
    }

    private ValueTask<string> GetStringWithoutAsyncValueCore()
    {
        return ExampleValueTask;
    }

    [Benchmark]
    public async ValueTask<string> GetStringWithAsyncValue()
    {
        return await GetStringWithAsyncValueCore();
    }

    private async ValueTask<string> GetStringWithAsyncValueCore()
    {
        return await ExampleValueTask;
    }
}