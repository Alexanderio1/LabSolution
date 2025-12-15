using System.Windows.Forms;
using AuthLib;

namespace TableBrowserModule
{
    public class EntryPoint : IModuleEntry
    {
        public Form CreateForm(UserContext ctx)
        {
            return new TableBrowserForm(ctx);
        }
    }
}
