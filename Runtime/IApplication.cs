namespace LiteNinja.Applications
{
    /// <summary>
    /// The IApplication interface defines the contract for an application object.
    /// </summary>
    public interface IApplication
    {
        ApplicationContext Context { get; }
        public void Inject(object obj);
    }
}