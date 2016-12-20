using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ToWeb.JsonApi.Model
{
    public class Poco
    {
        [Required]
        [DisplayName("Title")]
        [DefaultValue("My New title")]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }
       
        public bool Done { get; set; }
    }

    public static class PocoExtentions
    {
        public static List<Error> Validate(this Poco poco)
        {
            var errors = DataAnnotationsValidator.TryValidate(poco);
            return errors.Select(e => new Error() { ErrorMessage = e.ErrorMessage, MemberName = e.MemberNames.FirstOrDefault() }).ToList();
        }
    }
}