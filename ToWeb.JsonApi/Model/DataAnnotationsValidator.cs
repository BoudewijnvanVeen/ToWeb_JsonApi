using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToWeb.JsonApi.Model
{
    public static class DataAnnotationsValidator
    {
        public static ICollection<ValidationResult> TryValidate(object @object)
        {
            var context = new ValidationContext(@object, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(@object, context, results);
            return results;
        }
    }
}