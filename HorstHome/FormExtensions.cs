using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;

namespace FritzHome
{
    public static class FormExtensions
    {
        internal static void SetLanguage(this Form form, CultureInfo lang)
        {
            Thread.CurrentThread.CurrentUICulture = lang;
            Thread.CurrentThread.CurrentCulture = lang;
            CultureInfo.DefaultThreadCurrentCulture = lang;
            CultureInfo.DefaultThreadCurrentUICulture = lang;

            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());

            ApplyResourceToControl(resources, form, lang);
            resources.ApplyResources(form, "$this", lang);
        }

        private static void ApplyResourceToControl(ComponentResourceManager resources, Control control, CultureInfo lang)
        {
            foreach (Control c in control.Controls)
            {
                ApplyResourceToControl(resources, c, lang);
                resources.ApplyResources(c, c.Name, lang);
            }
        }
    }
}