using System;

namespace FiringRange.Code.Data.Progress
{
    [Serializable]
    public class UserProgress : IPropertyChanged
    {
        public event Action OnPropertyChanged;

        public UserProgress()
        {
        }

        public void Prepare()
        {
            
        }

        private void SendPropertyChanged() => OnPropertyChanged?.Invoke();
    }
}