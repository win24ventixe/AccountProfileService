﻿using System.ComponentModel.DataAnnotations;

namespace Presentation.Data.Entities;

public class ContactTypeEntity
{
    [Key]
    public int Id { get; set; } 
    public string ContactType { get; set; } = null!;

}
