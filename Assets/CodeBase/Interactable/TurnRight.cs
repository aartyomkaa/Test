using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Interactable
{
    public class TurnRight : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HeroMove hero))
            {
                hero.TurnRight();
                gameObject.SetActive(false);
            }
        }
    }
}