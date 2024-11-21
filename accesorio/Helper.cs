using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace accesorio
{
    static public class Helper
    {
        public static void CargarDropDown<T>(DropDownList dropDown, string dataValueField, string dataTextField, IEnumerable<T> lista)
        {
            dropDown.DataSource = lista;
            dropDown.DataValueField = dataValueField;
            dropDown.DataTextField = dataTextField;
            dropDown.DataBind();
        }
    }
}
