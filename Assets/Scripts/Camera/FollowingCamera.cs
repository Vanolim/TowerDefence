using UnityEngine;
using UnityEngine.Serialization;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private float _distance;
    [SerializeField] private float _offsetY;

    private void LateUpdate()
    {
        if (_target != null)
        {
            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();

            transform.position = position;
            transform.rotation = rotation;
        }
    }

    private Vector3 FollowingPointPosition()
    {
        Vector3 followingPosition = _target.position;
        followingPosition.y += _offsetY;
        return followingPosition;
    }

    public void SetFollowObject(GameObject following) => _target = following.transform;
}
