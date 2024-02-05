namespace BootcampAPI.DTOs;

public class ResponseDto<T>
{
    public T? Data { get; set; }

    public List<string>? Errors { get; set; }


    // Static factory method design pattern
    public static ResponseDto<T> Success(T data)
    {
        return new ResponseDto<T>
        {
            Data = data
        };
    }

    public static ResponseDto<T> Fail(List<string> errors)
    {
        return new ResponseDto<T>
        {
            Errors = errors
        };
    }

    public static ResponseDto<T> Fail(string error)
    {
        return new ResponseDto<T>
        {
            Errors = [error]
        };
    }
}
