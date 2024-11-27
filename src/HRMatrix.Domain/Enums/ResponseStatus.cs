using System.ComponentModel.DataAnnotations;

namespace HRMatrix.Domain.Enums;

public enum ResponseStatus
{
    [Display(Name = "В ожидании")]
    Pending,

    [Display(Name = "Отклонено")]
    Rejected,

    [Display(Name = "Одобрено")]
    Approved
}