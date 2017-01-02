using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToWeb.JsonApi
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

    public enum ECrudAction
    {
        Undefined = 0,
        Insert = 1,
        Update = 2
    }
}