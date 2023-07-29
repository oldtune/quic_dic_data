namespace Common.Models;
using System;
public struct Result<T>
{
    public bool Ok { set; get; }
    private T _data;
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

    }
}

public struct Error
{
    private IEnumerable<string> _customError;
    //only show exception to developer, do not show to customer
    private Exception _exception;

    public ReadOnlyCollection<string> Errors()
    {
        return new ReadOnlyCollection<string>(_customError);
    }
}
