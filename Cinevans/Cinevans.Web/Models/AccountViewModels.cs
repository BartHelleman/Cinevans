using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Cinevans.Language;

namespace Cinevans.Models
{
    /*
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
    

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
    */

    [ExcludeFromCodeCoverage]
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource),ErrorMessageResourceName = "EmailVerplicht")]
        [Display(Name = "E-mail")]
        [EmailAddress (ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailOngeldig")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WachtwoordVerplicht")]
        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WachtwoordVerplicht")]
        [Display(Name = "Wachtwoord", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Display(Name = "OnthoudMij", ResourceType = typeof(Resource))]
        public bool RememberMe { get; set; }
    }


    [ExcludeFromCodeCoverage]
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailVerplicht")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "EmailOngeldig")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WachtwoordVerplicht")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WachtwoordEis", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WachtwoordVerplicht")]
        [Display(Name = "WachtwoordBevestigen", ResourceType = typeof(Resource))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WachtwoordOvereen")]
        public string ConfirmPassword { get; set; }
    }

    /*
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    */
}
