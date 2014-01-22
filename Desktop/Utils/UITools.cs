using System.Windows.Forms;

namespace Desktop.Utils
{
    public static class UITools
    {
        public static string GetStringFromEditBox(TextBox editBox)
        {
            return editBox.Text.Trim();
        }

        public static string GetBaseUrlFromEditBox(TextBox editBox)
        {
            string result = editBox.Text.Trim();

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
