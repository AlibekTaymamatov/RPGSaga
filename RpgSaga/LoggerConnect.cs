namespace RpgSaga
{
    public abstract class LoggerConnect
    {
        public LoggerConnect(ILogger logger)
        {
            Logger = logger;
        }

        protected ILogger Logger { get; set; }
    }
}
