using System.Collections;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        private const float Epsilon = 0.01f;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _movementSpeed;

        private Vector3 _direction;
        private Vector3 _turn = new Vector3(0, 90, 0);

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _agent.updateRotation = false;
            _direction = Vector3.zero;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Epsilon)
            {
                movementVector = Camera.main.transform.TransformDirection(_inputService.Axis);
                movementVector.Normalize();
            }

            movementVector += Physics.gravity;
            movementVector += transform.forward;
            
            if (_agent.enabled) 
                _agent.Move(movementVector * (_movementSpeed * Time.deltaTime));
        }

        public void TurnLeft()
        {
            _direction -= _turn;
            StartCoroutine(Turn(_direction));
        }
        
        public void TurnRight()
        {
            _direction += _turn;
            StartCoroutine(Turn(_direction));
        }

        private IEnumerator Turn(Vector3 to)
        {
            _agent.enabled = false;
            
            while (transform.rotation != Quaternion.Euler(to))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(to), 5 * Time.deltaTime);

                yield return null;
            }
            
            _agent.enabled = true;
        }
    }
}