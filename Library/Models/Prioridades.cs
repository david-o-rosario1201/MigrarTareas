using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Prioridades
{
	[Key]
	public int PrioridadId { get; set; }

	[Required(ErrorMessage = "Debe ingresar una descripción")]
	public string Descripcion { get; set; }

	[Range(1, 31, ErrorMessage = "Debe indicar la cantidad de días de compromiso (1-31)")]
	public int DiasCompromiso { get; set; }
}
