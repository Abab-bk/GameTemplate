namespace Game.Scripts;

public static class Global
{
    public static World World { get; set; }
    public static Application Application { get; set; }

    private static AppSaver _appSaver;
    
    public static AppSaver AppSaver {
        get => _appSaver; 
        set
        {
            _appSaver = value;
            EventBus.RequestSaveAppSaver += _appSaver.Save;
        }
    }
}