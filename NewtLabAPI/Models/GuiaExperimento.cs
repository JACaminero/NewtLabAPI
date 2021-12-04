﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtlabAPI.Models
{
    [NotMapped]
    public class GuiaExperimento
    {
        [Key]
        public int GuiaId { get; set; }
        public int Descripcion { get; set; }
        public int Instruccion { get; set; }
        public int Titulo { get; set; }
        public Experimento Experimento { get; set; }
    }
}
