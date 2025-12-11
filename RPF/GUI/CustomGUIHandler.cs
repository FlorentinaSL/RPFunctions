using RPF.GUI.OverWatch;
using RPF.GUI.ServerTitle;

namespace RPF.GUI;

public class CustomGUIHandler
{
    //new GUI!
    private Title _title;
    private Timer.Timer _timer;
    private Overwatch _overwatch;
    
    public void Register()
    {
        _title = new Title();
        _title.Register();

        _timer = new Timer.Timer();
        _timer.Register();
        
        // new Overwatch GUI
        _overwatch = new Overwatch();
        _overwatch.Register();
    }

    public void UnRegister()
    {
        _title.UnRegister();
        _timer.UnRegister();
        _overwatch.Unregister();
    }
}