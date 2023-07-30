namespace Common.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

public struct Result<T>
{
    public bool Ok { set; get; }
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

    public Error GetError()
    {
        return _error;
    }
}

public struct Error
{
    private List<string> _customError = new List<string>();
    //only show exception to developer, do not show to customer
    private Exception _exception;
    public bool HasException => _exception != null;

    public ReadOnlyCollection<string> Errors()
    {
        return new ReadOnlyCollection<string>(_customError);
    }

    public Exception Exception()
    {
        return _exception;
    }

    public Error(string error)
    {
        _customError.Add(error);
    }

    public Error(Exception ex)
    {
        _customError.Add("Unexpected error");
    }
}

public struct None
{
    public static None Default = new None();
}