﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizou.Domain.DTO; 
public class EditTagDto
{
    public required int TagId { get; set; }
    public required string Name { get; set; }
}