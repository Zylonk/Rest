using apis.Model;

namespace apis.DataBase
{
    public class GetrContext
    {
        public static TfinContext Context { get; } = new TfinContext();
        
    }
}
