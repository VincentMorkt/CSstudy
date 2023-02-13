﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
  [Keyless]
  public partial class EmployeeTerritory
  {
    [Column(TypeName = "int")]
    public long EmployeeID { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar")]
    public string TerritoryID { get; set; }
  }
}