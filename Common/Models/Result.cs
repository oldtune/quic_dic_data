using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Common.Models;
public class Result<T>
{
    public bool Ok => _error != null;
    private T _data;
    private Error _error;
    public T Unwrap()
    {
        if (Ok)
        {
            return _data;
        }

        throw new InvalidOperationException("Cannot unwrap failed result");
    }

    public static Result<T> CreateResult(T value)
    {
        if (value == null)
        {
            return new Result<T>
            {
                _error = new Error(new Exception("Null value"))
            };
        }

        if (typeof(T) == typeof(Exception))
        {
            return new Result<T>
            {
                _error = new Error(value as Exception)
            };
        }

        return new Result<T>
        {
            _data = value
        };
    }

    public static Result<T> CreateError(Error error)
    {
        if (error == null)
        {
            return new Result<T>
            {
                _error = new Error("Unkown exception")
            };
        }

        return new Result<T>
        {
            _error = error
        };
    }

    public static Result<T> CreateError(Exception ex)
    {
        return CreateError(new Error(ex));
    }

    public Error GetError()
    {
        return _error;
    }

    public async static Task<Result<T>> FromTask(Func<Task<T>> task)
    {
        try
        {
            var result = await task();
            return CreateResult(result);
        }
        catch (Exception ex)
        {
            return CreateError(ex);
        }
    }

    public async static Task<Result<None>> FromTask(Func<Task> task)
    {
        try
        {
            await task();
            return Result<None>.CreateResult(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }

    public async static Task<Result<T>> FromValueTask(Func<ValueTask<T>> valueTask)
    {
        try
        {
            var result = await valueTask();
            return CreateSuccess(result);
        }
        catch (Exception ex)
        {
            return Result<T>.CreateError(ex);
        }

    }

    public async static Task<Result<None>> FromValueTask(Func<ValueTask> valueTask)
    {
        try
        {
            valueTask();
            return Result<None>.CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }

    public async static Task<Result<None>> FromValueTaskNone(Func<ValueTask<T>> valueTask)
    {
        try
        {
            valueTask();
            return Result<None>.CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }

    public async static Task<Result<None>> FromTaskNone(Func<Task<T>> task)
    {
        try
        {
            task();
            return Result<None>.CreateSuccess(None.Default);
        }
        catch (Exception ex)
        {
            return Result<None>.CreateError(ex);
        }
    }



    private async Task<Result<T>> CreateFromTryCatch(Func<Task<T>> task)
    {
        try
        {
            var result = await task();
            return CreateSuccess(result);
        }
        catch (Exception ex)
        {
            return Result<T>.CreateError(ex);
        }
    }

    private Result<T> CreateFromTryCatch(Func<T> func)
    {
        try
        {
            var result = func();
            return CreateSuccess(result);
        }
        catch (Exception ex)
        {
            return CreateError(ex);
        }
    }

    public static Result<T> CreateSuccess(T value)
    {
        return new Result<T>
        {
            _data = value
        };
    }
}

public static class ResultExtension
{
    public static Result<R> Map<T, R>(this Result<T> result, Func<T, R> map)
    {
        if (result.Ok)
        {
            return Result<R>.CreateSuccess(map(result.Unwrap()));
        }

        return Result<R>.CreateError(result.GetError());
    }
}