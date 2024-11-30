using HRMatrix.Domain.Enums;

namespace HRMatrix.Application.DTOs.Order;

public class ResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public ResponseStatus Status { get; set; }
    public string StatusName { get; set; }
    public DateTime CreatedAt { get; set; }
}