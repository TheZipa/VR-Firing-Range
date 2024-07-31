using System;

namespace FiringRange.Code.Data.Progress
{
    public interface IPropertyChanged
    {
        event Action OnPropertyChanged;
    }
}