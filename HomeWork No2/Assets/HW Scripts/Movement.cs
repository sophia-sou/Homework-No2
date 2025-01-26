using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed;
    public float runSpeed;

    [SerializeField]
    InputAction _moveAction;

    [SerializeField]
    InputAction _runAction;

    [SerializeField]
    private bool _isRunning = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        _moveAction = InputSystem.actions.FindAction("Move");
        _runAction = InputSystem.actions.FindAction("Sprint");

        _runAction.started += context => { _isRunning = true; }; //anonymous function
        _runAction.canceled += context => { _isRunning = false; };
    }
    private void Update()   
    {
        Vector2 currentMoveValue = _moveAction.ReadValue<Vector2>();
        Move(new (currentMoveValue.x, 0, currentMoveValue.y));
    }

    private void Move(Vector3 input)
    {
        if (input.sqrMagnitude == 0)
        {
            return;
        }

        // if running -> use run speed
        // else -> use walk speed
        float currentSpeed = _isRunning ? runSpeed : walkSpeed;

        input.y = 0;
        controller.Move(Time.deltaTime * currentSpeed * input);
    }
}
