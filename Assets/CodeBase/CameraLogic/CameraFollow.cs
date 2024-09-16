using UnityEngine;

namespace CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _following;
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private void LateUpdate()
        {
            if (_following == null)
                return;

            Quaternion rotation = Quaternion.Euler(_rotationAngleX, _following.rotation.eulerAngles.y, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPosition();

            transform.position = position;
            transform.rotation = rotation;
        }

        public void Follow(GameObject following)
        {
            _following = following.transform;
            //gameObject.transform.parent = _following.transform;
        }

        private Vector3 FollowingPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += _offsetY;

            return followingPosition;
        }
    }
}