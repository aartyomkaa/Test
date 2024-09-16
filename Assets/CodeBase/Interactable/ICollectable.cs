using System;

namespace CodeBase.Interactable
{
    public interface ICollectable
    {
        int Cost { get; }
        
        event Action<int> Collected;

        void OnCollected();
    }
}