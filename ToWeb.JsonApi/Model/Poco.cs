
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http.ModelBinding;
using FluentValidation;

namespace ToWeb.JsonApi.Model
{
    public class Poco
    {
        [Key]
        [Required]
        public Guid Key { get; set; }

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
        public static ModelStateDictionary Validate(this Poco poco, ECrudAction action)
        {
            var retValue = new ModelStateDictionary();
            
            var v = new PocoValidator().Validate(poco, ruleSet: "default," + action).Errors.ToList();
            v.ForEach(e => retValue.AddModelError(e.PropertyName, e.ErrorMessage));

            var d = DataAnnotationsValidator.TryValidate(poco).ToList();
            d.ForEach(e => retValue.AddModelError(e.MemberNames.FirstOrDefault(), e.ErrorMessage));

            return retValue;
        }
    }

    public class PocoValidator : AbstractValidator<Poco>
    { 
        public PocoValidator()
        {
            // Always validated
            RuleFor(poco => poco.Title).NotEmpty().WithMessage("Title is empty");

            // Only validated on action Insert
            RuleSet("Insert", () =>
            {
                RuleFor(poco => poco.Key).Empty().WithMessage("Key is not empty");
            });
        }
    }
}