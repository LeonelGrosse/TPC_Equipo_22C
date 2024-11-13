using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace accesorio
{
    static public class Validator
    {
        private static RequiredFieldValidator validator;
        private static RegularExpressionValidator rgxValidator;

        public static void CampoVacio(string idControl, string mensajeError, System.Web.UI.HtmlControls.HtmlGenericControl idContainerControl)
        {
            validator = new RequiredFieldValidator();
            validator.ControlToValidate = idControl;
            validator.ErrorMessage = mensajeError;
            validator.CssClass = "RequiredMessage";
            validator.Display = ValidatorDisplay.Dynamic;

            idContainerControl.Controls.Add(validator);
        }

        public static void ExpresionRegular(string idControl, string mensajeError, System.Web.UI.HtmlControls.HtmlGenericControl idContainerControl, string regularExpression)
        {
            rgxValidator = new RegularExpressionValidator();
            rgxValidator.ControlToValidate = idControl;
            rgxValidator.ErrorMessage = mensajeError;
            rgxValidator.CssClass = "RequiredMessage";
            rgxValidator.Display = ValidatorDisplay.Dynamic;
            rgxValidator.ValidationExpression = regularExpression;

            idContainerControl.Controls.Add(rgxValidator);
        }
    }
}
