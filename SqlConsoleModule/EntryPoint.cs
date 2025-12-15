using System.Windows.Forms;
using AuthLib;

namespace SqlConsoleModule
{
    public class EntryPoint : IModuleEntry
    {
        public Form CreateForm(UserContext ctx)
        {
            return new SqlConsoleForm(ctx, false);
        }
    }
}
