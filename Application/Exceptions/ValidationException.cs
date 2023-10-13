using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validation)
        {
            foreach (var error in validation.Errors) 
            {  
                Errors.Add(error.ErrorMessage); 
            }   
            
        }
    }
}