using MicroBotServices.Models.ValidationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBotServices.Models.Base
{
    /// <summary>
    /// Base class for validatable view models.
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// Validates the specified throw edit.
        /// </summary>
        /// <param name="throwEdit">if set to <c>true</c> [throw edit].</param>
        /// <returns></returns>
        /// <exception cref="EditException"></exception>
        public IEnumerable<Edit> Validate(bool throwEdit = false)
        {
            List<Edit> editsList = new List<Edit>();
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true))
            {
                validationResults.ForEach(r => { editsList.Add(new Edit() { FieldName = r.MemberNames.First(), Message = r.ErrorMessage }); });
            }
            if (throwEdit && editsList.Count > 0)
            {
                throw new EditException() { Edits = editsList };
            }
            return editsList;
        }

        public bool Validate()
        {
            List<Edit> editsList = new List<Edit>();
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true))
            {
                validationResults.ForEach(r => { editsList.Add(new Edit() { FieldName = r.MemberNames.First(), Message = r.ErrorMessage }); });
            }
            if (editsList.Count > 0)
            {
                throw new EditException() { Edits = editsList };
            }
            return true;
        }
    }
}
