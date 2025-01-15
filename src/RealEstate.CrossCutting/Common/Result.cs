using System.ComponentModel.DataAnnotations;

namespace RealEstate.CrossCutting.Common;

public enum Result
{
    [Display(Name = "Success")]
    Success,

    [Display(Name = "Error")]
    Error,

    [Display(Name = "NoRecords")]
    NoRecords,

    [Display(Name = "IsNotActive")]
    IsNotActive,

    [Display(Name = "InvalidPassword")]
    InvalidPassword
}