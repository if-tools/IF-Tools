namespace IFTools.Components;

public class CurrentPage
{
    public string CurrentPageName { get; private set; }
    
    public string NotificationBoxText = "";

    public bool NotificationBoxShown;
    
    public event Action OnChange;

    public void SetCurrentPageName(string name)
    {
        if (!string.Equals(CurrentPageName, name)) 
        {
            CurrentPageName = name;
            NotifyStateChanged();
        }
    }
    
    public async void ShowNotification(string text)
    {
        if (NotificationBoxShown)
        {
            NotificationBoxText = text;
            NotifyStateChanged();
            return;
        }
        
        NotificationBoxText = text;
        NotificationBoxShown = true;
        NotifyStateChanged();
        
        await Task.Delay(4000);
        
        NotificationBoxShown = false;
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
}