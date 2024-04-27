namespace LiteNinja.Applications
{
    /// <summary>
    /// The ExecutionOrder static class provides constants that define the execution order of various components in the application.
    /// This is used to control the order in which scripts and systems are initialized and updated within the Unity game engine.
    /// </summary>
    public static class ExecutionOrder
    {
        public const int Unity_EventSystem = -1000;
        public const int Application = Unity_EventSystem + 100;
        public const int SceneRoot = Application + 100;
        public const int Transition = SceneRoot + 100;
        public const int Zero = 0;
    }
}