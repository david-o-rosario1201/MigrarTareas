using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class ClientesDetalleTelefonos
{
	[Key]
	public int Id { get; set; }

	public int ClienteId { get; set;}

    public string Telefono { get; set; }
}
