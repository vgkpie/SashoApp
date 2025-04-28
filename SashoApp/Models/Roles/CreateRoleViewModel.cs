using System.ComponentModel.DataAnnotations;

namespace SashoApp.Models.Roles
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Моля, въведете име на роля.")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "Името на ролята трябва да е между 2 и 256 символа.")]
        public string RoleName { get; set; }
    }
}
