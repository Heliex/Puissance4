using System.ComponentModel.DataAnnotations;

namespace Puissance4_FrontEnd.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nom d'utilisateur ou Email")]
        [StringLength(100)]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        [Validation.UniqueAccount.MailUnique]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nom d'utilisateur")]
        [Validation.UniqueAccount.PseudoUnique]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

}
