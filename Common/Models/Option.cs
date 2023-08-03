namespace Common.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

public struct Option<T>
{
    public T Value { get; }
    public HasValue {get;}

private Option<T>()
{
    Value = default(T);
    HasValue = false;
}

private Option<T>(T value){
    if (value)
    {
        if (value != null)
        {
            Value = value;
            HasValue = true;
        }

        HasValue = false;
        Value = default(T);
    }
}

public static CreateSome(T value)
{
    return new Option<T>(value);
}

public static CreateNone<T>()
{
    return new Option<T>(value);
}
}