using FluentValidation;
using KingHotel.Application.Commands.User;
using System.Text.RegularExpressions;

namespace KingHotel.Application.Validators.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Por favor, digite um email válido.");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caracter especial");

            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome deve ser preenchido");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
