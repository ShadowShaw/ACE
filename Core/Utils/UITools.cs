using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Utils
{
    public class UITools
    {
        public static string GetStringFromEditBox(TextBox editBox)
        {
            return editBox.Text.Trim();
        }

        public static string GetBaseUrlFromEditBox(TextBox editBox)
        {
            string result;
            result = editBox.Text.Trim();
            result = result.ToLower();
            if (result.EndsWith("/") == false)
            {
                result = result + "/";
            }
            if (result.EndsWith("api/") == false)
            {
                result = result + "api/";
            }

            return result;
        }
    }
}
