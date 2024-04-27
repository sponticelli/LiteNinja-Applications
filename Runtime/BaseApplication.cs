using LiteNinja.Commands;
using UnityEngine;

namespace LiteNinja.Applications
{
    [DefaultExecutionOrder(ExecutionOrder.Application)]
    /// <summary>
    /// The BaseApplication abstract class provides a base implementation for an application object in the Unity game engine.
    /// It implements the IApplication interface and provides methods for setting up the application, binding services, and injecting dependencies.
    /// This class is intended to be inherited by specific application classes that provide their own implementations of the abstract methods.
    /// </summary>
    public abstract class BaseApplication : MonoBehaviour, IApplication
    {
        [SerializeField]
        protected BaseApplicationSettings _applicationSettings;
        
        
        protected ApplicationContext _context;
        protected CommandFactory _commandFactory;   
        
        
        public ApplicationContext Context => _context;
        
        protected void Awake()
        {
            DontDestroyOnLoad(this);
            _context = new ApplicationContext(null);
            
            SetupApplication();
        }
        
        /// <summary>
        /// Injects the specified object with the application's dependencies.
        /// </summary>
        /// <param name="obj"></param>
        public void Inject(object obj)
        {
            _context.Injector.Inject(obj);
        }
        
        private void SetupApplication()
        {
            Application.targetFrameRate = _applicationSettings.TargetFrameRate;
            
            Bind();
            PreSetup();
            BindServices();
            _context.Injector.PostBindings();
            PostSetup();
        }

        private void Bind()
        {
            var injector = _context.Injector;
            injector.Bind<IApplication>(this);
            _commandFactory = new CommandFactory(injector);
            injector.Bind(_commandFactory);
        }


        /// <summary>
        /// Called before any services are bound.
        /// </summary>
        protected abstract void PreSetup();
        
        /// <summary>
        /// Used to bind additional services.
        /// PostBindings will be called after this method.
        /// </summary>
        protected abstract void BindServices();
        
        /// <summary>
        /// Called after all services are bound and injected.
        /// </summary>
        protected abstract void PostSetup();
        
    }
}