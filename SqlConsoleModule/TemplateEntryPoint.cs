using System.Windows.Forms;
using AuthLib;

namespace SqlConsoleModule
{
    public class TemplateEntryPoint : IModuleEntry
    {
        public Form CreateForm(UserContext ctx)
        {
            return new SqlConsoleForm(ctx, true);
        }
    }
}
