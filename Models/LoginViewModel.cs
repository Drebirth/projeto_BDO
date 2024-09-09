using System.ComponentModel.DataAnnotations;

namespace projetoBDO.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "O usuário é obrigatorio!")]
    public string? Usuario  { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name ="Lembrar-me")]
    public bool RememberMe { get; set; }


}