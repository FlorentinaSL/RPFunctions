using RPF.GUI.ServerTitle;

namespace RPF.GUI;

public class CustomGUIHandler
{
    //new GUI!
    private Title _title;
    private Timer.Timer _timer; 
    
    public void Register()
    {
        _title = new Title();
        _title.Register();

        _timer = new Timer.Timer();
        _timer.Register();
    }

    public void UnRegister()
    {
        _title.UnRegister();
        _timer.UnRegister();
    }
}