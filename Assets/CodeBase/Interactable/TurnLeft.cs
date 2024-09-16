using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Interactable
{
    public class TurnLeft : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HeroMove hero))
            {
                hero.TurnLeft();
            }
            
            gameObject.SetActive(false);
        }
    }
}