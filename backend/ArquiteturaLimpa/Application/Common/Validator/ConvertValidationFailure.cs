using DomainValidationCore.Validation;
using FluentValidation.Results;

namespace Application.Common.Validator
{
    public static class ConvertValidationFailure 
    {   
        public static List<ValidationFailure> ToValidationFailure(this IEnumerable<ValidationError> errors)
        {
            var failures = new List<ValidationFailure>();
            
            var listErrors = errors.ToArray();
            for (int i = 0; i < listErrors.Length; i++)
            {
                var message = new string[listErrors.Length];
                message[0] = listErrors[i].Message;

                failures.Add(new ValidationFailure(listErrors[i].Name, listErrors[i].Message));
            }
            return failures;
        }
    } 
}