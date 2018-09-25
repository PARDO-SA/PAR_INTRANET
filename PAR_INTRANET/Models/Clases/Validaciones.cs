using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PAR_INTRANET.Models.Clases
{
    public class FuncionEmpleValidator : ValidationAttribute
    {
        public string OtraFuncion { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(OtraFuncion))
                throw new Exception("No se ha especificado la propiedad 'OtraFuncion'");

            //Obetenemos la propiedad
            var property = validationContext.ObjectType.GetProperty(OtraFuncion);
            if (property == null)
                throw new Exception(string.Format("No se encuentra la propiedad '{0}'", OtraFuncion));

            //Comprobamos el valor
            int? valor = (int?)property.GetValue(validationContext.ObjectInstance, null);

            return valor == (int?)value ? new ValidationResult(ErrorMessage) : null;
        }
    }
}