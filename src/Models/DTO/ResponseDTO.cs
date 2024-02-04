namespace ContactManagementAPI.Models.DTO;

public class ResponseDTO<T>
{
    public string Message { get; set; }
    public T Data { get; set; }

    public ResponseDTO(T Data, string Message = "success")
    {
        this.Message = "success";
        this.Data = Data;
    }
}