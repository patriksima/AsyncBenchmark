using BenchmarkDotNet.Attributes;

namespace TestAsync;

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public async Task<string> GetStringWithAsync()
    {
        return await GetStringWithAsyncCore();
    }

    private async Task<string> GetStringWithAsyncCore()
    {
        return await Task.FromResult<string>("I'm great developer.");
    }

    [Benchmark]
    public async Task<string> GetStringWithoutAsync()
    {
        return await GetStringWithoutAsyncCore();
    }

    private Task<string> GetStringWithoutAsyncCore()
    {
        return Task.FromResult<string>("I'm great developer.");
    }

    [Benchmark]
    public async ValueTask<string> GetStringWithoutAsyncValue()
    {
        return await GetStringWithoutAsyncValueCore();
    }

    private ValueTask<string> GetStringWithoutAsyncValueCore()
    {
        return ValueTask.FromResult<string>("I'm great developer");
    }

    [Benchmark]
    public async ValueTask<string> GetStringWithAsyncValue()
    {
        return await GetStringWithAsyncValueCore();
    }

    private async ValueTask<string> GetStringWithAsyncValueCore()
    {
        return await ValueTask.FromResult<string>("I'm great developer");
    }
    
    [Benchmark]
    public string GetStringSync()
    {
        return "I'm great developer.";
    }
}