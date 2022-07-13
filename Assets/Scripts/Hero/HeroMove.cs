using UnityEngine;

public class HeroMove : ITickable
{
    private readonly CharacterController _characterController;
    private readonly Transform _heroTransform;
    private readonly IInputService _inputService;
    private readonly Camera _camera;

    private const float MOVEMENT_SPEED = 2f;
    private const float MOTION_ERROR = 0.001f;
    
    public bool IsMove { get; private set; }

    public HeroMove(IInputService inputService, CharacterController characterController, Transform heroTransform)
    {
        _inputService = inputService;
        _characterController = characterController;
        _heroTransform = heroTransform;
        _camera = Camera.main;
    }

    public void Tick(float dt)
    {
        Move(dt);
    }

    private void Move(float dt)
    {
        Vector3 movementVector = Vector3.zero;
        Vector2 axis = _inputService.MoveDirection;
        IsMove = false;
        if (axis.sqrMagnitude > MOTION_ERROR)
            movementVector = SetMoveDirection(movementVector, axis);

        movementVector += Physics.gravity;
        _characterController.Move(movementVector * (MOVEMENT_SPEED * dt));
    }

    private Vector3 SetMoveDirection(Vector3 movementVector, Vector2 axis)
    {
        movementVector = _camera.transform.TransformDirection(axis);
        IsMove = true;
        movementVector.y = 0;
        movementVector.Normalize();
        _heroTransform.forward = movementVector;
        return movementVector;
    }
}
