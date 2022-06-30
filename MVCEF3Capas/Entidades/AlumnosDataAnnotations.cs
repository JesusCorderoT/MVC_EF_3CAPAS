using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    [MetadataType(typeof(AlumnosDataAnnotations))]



    public partial class ALUMNOS{ 
    }


    public class AlumnosDataAnnotations
    {
        [Key]
        public int id { get; set; }
        /*---------------------------------------------------------------------------*/

        //  ^[a-zA-Z](\s*[a-zA-Z]*)*[a-zA-Z]+$    solo letras y espacios



        [RegularExpression("^[a-zA-Z](\n*[a-zA-Z]*)*[a-zA-Z]+$", ErrorMessage ="Solo letras sin espacios" )]
        [StringLength(60,MinimumLength =3,ErrorMessage ="El {0} debe llevar maximo {1} y minimo {2} letras ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="El {0} es necesario")]
        public string nombre { get; set; }
        /*---------------------------------------------------------------------------*/






        [RegularExpression("^[a-zA-Z](\n*[a-zA-Z]*)*[a-zA-Z]+$", ErrorMessage = "Solo letras sin espacios")]
        [Required(ErrorMessage = "El {0} es necesario")]
        public string primerApellido { get; set; }
        /*---------------------------------------------------------------------------*/





        [RegularExpression("^[a-zA-Z](\n*[a-zA-Z]*)*[a-zA-Z]+$", ErrorMessage = "Solo letras sin espacios")]
        [Required(ErrorMessage = "El {0} es necesario")]
        public string segundoApellido { get; set; }
        /*---------------------------------------------------------------------------*/






        [Required(ErrorMessage = "El {0} es necesario")]
        public string correo { get; set; }
        /*---------------------------------------------------------------------------*/







        [MaxLength(10, ErrorMessage = "Longitud máxima de {1}")]
        public string telefono { get; set; }
        /*---------------------------------------------------------------------------*/







        public DateTime fechaNacimiento { get; set; }
        /*---------------------------------------------------------------------------*/


        //^[A-Z]{4}[0-9]{6}[A-Z]{6}[0-9]{2} validar curp


        [RegularExpression("^[A-Z]{4}[0-9]{6}[A-Z]{6}[0-9]{2}", ErrorMessage = "No cumple con el formato de CURP")]
        [Required(ErrorMessage = "El {0} es necesario")]
        public string curp { get; set; }
        /*---------------------------------------------------------------------------*/






        [Range(10000, 40000, ErrorMessage = "El sueldo debe estar entre el {1} y el {2}")]
        public decimal sueldo { get; set; }
        /*---------------------------------------------------------------------------*/







        public int idestadoorigen { get; set; }
        /*---------------------------------------------------------------------------*/







        public int idEstatus { get; set; }
        /*---------------------------------------------------------------------------*/





    }
}
