﻿using System.ComponentModel.DataAnnotations;

namespace Presentation.Data.Entities;

public class AddressTypeEntity
{
    [Key]
    public int Id { get; set; } 
    public string AddressType { get; set; }  = null!;
}
