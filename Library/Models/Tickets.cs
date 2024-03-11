using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Tickets
{
	[Key]
	public int TicketId { get; set; }

	[Required(ErrorMessage = "Error, la fecha es requerida")]
	[DataType(DataType.Date)]
	public DateTime Fecha { get; set; } = DateTime.Today;

	[ForeignKey("Clientes")]
	[Range(1,int.MaxValue,ErrorMessage = "Error, ClienteId debe ser mayor a 0")]
	public int ClienteId { get; set; }

	[ForeignKey("Sistemas")]
	[Range(1, int.MaxValue, ErrorMessage = "Error, SistemaId debe ser mayor a 0")]
	public int SistemaId { get; set; }

	[ForeignKey("Prioridades")]
	[Range(1, int.MaxValue, ErrorMessage = "Error, PrioridadId debe ser mayor a 0")]
	public int PrioridadId { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string SolicitadoPor { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Asunto { get; set; }

	[Required(ErrorMessage = "Error, debe llenar este campo")]
	public string Descripcion { get; set; }



	[ForeignKey("TicketId")]
	public ICollection<TicketsDetalle> TicketsDetalle { get; set; } = new List<TicketsDetalle>();
}
