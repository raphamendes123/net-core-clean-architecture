using FluentValidation.Results;

namespace Infrastructure.Common.Api
{
    public static class CustomValidationFailure
    {
        public static IList<ValidationFailureModel> ToValidationFailures(this IList<ValidationFailure> validationFailures) 
        {
            return validationFailures.Select(f => new ValidationFailureModel(f.PropertyName, f.ErrorMessage)).ToList();
        }            
    }

    public class ValidationFailureModel
    {
        public ValidationFailureModel(string propertyName, string errorMessage)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
        }

        public string PropertyName;
        public string ErrorMessage;
    }

}
