using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _movementSpeed;

    private const float MotionError = 0.001f;
    
    private IInputService _inputService;
    private Camera _camera;

    public bool IsMove { get; private set; }

    public void Init(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 movementVector = Vector3.zero;
        Vector2 axis = _inputService.MoveDirection;
        IsMove = false;
        if (axis.sqrMagnitude > MotionError)
        {
            movementVector = _camera.transform.TransformDirection(axis);
            IsMove = true;
            movementVector.y = 0;
            movementVector.Normalize();
            transform.forward = movementVector;
        }

        movementVector += Physics.gravity;
        _characterController.Move(movementVector * _movementSpeed * Time.deltaTime);
    }
}
