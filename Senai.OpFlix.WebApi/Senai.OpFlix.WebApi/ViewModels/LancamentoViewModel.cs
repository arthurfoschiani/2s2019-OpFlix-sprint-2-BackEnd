using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.ViewModels
{
    public class LancamentoViewModel
    {
        [Required]
        public string NomeMidia { get; set; }
        [Required]
        public DateTime? DataLancamento { get; set; }
    }
}
