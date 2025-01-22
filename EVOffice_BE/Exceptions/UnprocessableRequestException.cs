namespace EVOffice_BE.Exceptions;

public class UnprocessableRequestException : Exception
{
    public UnprocessableRequestException(string message) : base(message) { }
}
