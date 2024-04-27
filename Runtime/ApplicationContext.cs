using LiteNinja.Injection;

namespace LiteNinja.Applications
{
    /// <summary>
    /// The ApplicationContext class is a specialized context class for application-level operations.
    /// It inherits from the AContext base class and is used to manage the application's dependencies and services.
    /// </summary>
    public class ApplicationContext : AContext
    {
        public ApplicationContext(AContext parent)
            : base(parent)
        {
        }
    }
}