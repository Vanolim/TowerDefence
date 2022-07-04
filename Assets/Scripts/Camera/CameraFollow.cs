using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _following;
    [SerializeField] private float _rotationAngleX;
    [SerializeField] private float _distance;
    [SerializeField] private float _offsetY;

    private void LateUpdate()
    {
        if (_following != null)
        {
            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();

            transform.position = position;
            transform.rotation = rotation;
        }
    }

    private Vector3 FollowingPointPosition()
    {
        Vector3 followingPosition = _following.position;
        followingPosition.y += _offsetY;
        return followingPosition;
    }

    public void SetFollowObject(GameObject following) => _following = following.transform;
}
