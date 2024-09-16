using System;
using UnityEngine;

namespace CodeBase.Interactable
{
    [RequireComponent(typeof(BoxCollider))]
    public class Collectable : MonoBehaviour, ICollectable
    {
        [SerializeField] private int _cost;

        public int Cost => _cost;
        
        public event Action<int> Collected;

        private void OnTriggerEnter(Collider other)
        {
            OnCollected();
        }

        public void OnCollected()
        {
            Collected?.Invoke(_cost);
            gameObject.SetActive(false);
        }
    }
}