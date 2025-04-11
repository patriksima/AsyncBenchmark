# Async vs Await Benchmark (.NET)

This benchmark compares the performance impact of using `async/await` with `Task` and `ValueTask` in C#. It focuses on scenarios where the asynchronous operation is **trivial** and **completes immediately**, such as returning a constant value.

## Purpose

The goal is to understand the **overhead introduced by `async/await`** in cases where it may be unnecessary. For example, returning a cached value or a precomputed result in an async method.

## Benchmark Cases

| Method Name                  | Description                                                                 |
|-----------------------------|-----------------------------------------------------------------------------|
| `GetStringSync`             | Returns a string synchronously.                                             |
| `GetStringWithoutAsync`     | Returns `Task<string>` without using `async` or `await`.                    |
| `GetStringWithAsync`        | Uses `async` + `await`, wrapping `Task.FromResult`.                         |
| `GetStringWithoutAsyncValue`| Returns `ValueTask<string>` without using `async` or `await`.               |
| `GetStringWithAsyncValue`   | Uses `async` + `await`, wrapping `ValueTask.FromResult`.                    |

## Key Takeaways

- **Avoid unnecessary `async/await`** if the method doesn't actually await anything.
- Using `Task.FromResult` or `ValueTask.FromResult` **directly is more efficient**, as it avoids state machine generation and heap allocations.
- `ValueTask<T>` can be more efficient than `Task<T>` for frequently synchronous results.
- In real-world I/O-bound scenarios, this overhead is negligible, but in performance-critical code paths (e.g., high-frequency methods, microservices, low-latency systems), it can add up.

## Example

```csharp
private Task<string> GetStringWithoutAsyncCore()
{
    return Task.FromResult("I'm great developer.");
}

private async Task<string> GetStringWithAsyncCore()
{
    return await Task.FromResult("I'm great developer.");
}
