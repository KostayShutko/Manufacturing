using FluentValidation;
using System.Text;

namespace Manufacturing.Common.Application.Factories;

public static class ErrorMessageFactory
{
    public static string CreateErrorMessage(Exception exception)
    {
        var strBuilder = new StringBuilder();

        if (exception is ValidationException validationException)
        {
            foreach (var failure in validationException.Errors)
            {
                strBuilder.AppendLine($"{failure.PropertyName}: {failure.ErrorMessage}");
            }
        }
        else
        {
            strBuilder.Append(exception.Message);
        }

        return strBuilder.ToString();
    }
}
