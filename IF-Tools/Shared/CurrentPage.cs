using System;

namespace IFTools.Shared
{
    public class CurrentPage
    {
        public string CurrentPageName { get; private set; }

        public void SetCurrentPageName(string name)
        {
            if (!string.Equals(CurrentPageName, name)) 
            {
                CurrentPageName = name;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}