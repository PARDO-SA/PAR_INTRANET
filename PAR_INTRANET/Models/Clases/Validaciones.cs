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

    public class CodVenEmpleValidator : ValidationAttribute
    {
        public CodVenEmpleValidator(params string[] propertyNames)
        {
            this.PropertyNames = propertyNames;
        }

        public string[] PropertyNames { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (PropertyNames.Count() == 0)
                throw new Exception("No se ha especificado la propiedad 'PropertyNames'");

            //Obetenemos la propiedad
            var properties = this.PropertyNames.Select(validationContext.ObjectType.GetProperty);
            var values = properties.Select(p => p.GetValue(validationContext.ObjectInstance, null)).OfType<int?>();
            bool obligatorio = false;

            foreach(var v in values)
            {
                if (v == 5)
                {
                    obligatorio = true;
                }
            }

            if (obligatorio) {
                if (value == null || (string)value == string.Empty)
                {
                    return new ValidationResult(ErrorMessage);
                } 
            }

            return null;
        }
    }
}