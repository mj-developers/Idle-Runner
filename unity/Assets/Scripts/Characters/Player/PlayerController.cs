// Assets/Scripts/Characters/Player/PlayerController.cs
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Jump Settings")]
    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToApex = 0.4f;
    public float apexVelocityThreshold = 0.1f;

    [Header("Gravity Modifiers")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float apexHangMultiplier = 0.5f;
    public float apexHangDuration = 0.1f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Gizmos Ground Check")]
    public float gizmoHalfWidth = 1f;
    public Color groundedGizmoColor = Color.green;
    public Color notGroundedGizmoColor = Color.red;
    public float gizmoLineThickness = 6f;

    public Rigidbody2D Rb { get; private set; }
    public Animator Animator { get; private set; }
    private InputSystem_Actions actions;
    public InputAction JumpAction => actions.Player.Jump;
    public bool IsHoldingJump { get; set; }
    public StateMachine<PlayerController> StateMachine { get; private set; }
    public IState<PlayerController> RunState { get; private set; }
    public IState<PlayerController> JumpState { get; private set; }


    // -----------------------------------
    // Propiedades dinámicas para física
    // -----------------------------------

    // Escala de gravedad base necesaria
    public float GravityScale
    {
        get
        {
            float g = -2f * maxJumpHeight / (timeToApex * timeToApex);
            return g / Physics2D.gravity.y;
        }
    }
    // Velocidad inicial para alcanzar el apex
    public float InitialJumpVelocity
    {
        get
        {
            float g = -2f * maxJumpHeight / (timeToApex * timeToApex);
            return Mathf.Abs(g) * timeToApex;
        }
    }
    // Velocidad mínima si cortas el salto
    public float MinJumpVelocity
    {
        get
        {
            float g = -2f * maxJumpHeight / (timeToApex * timeToApex);
            return Mathf.Sqrt(2f * Mathf.Abs(g) * minJumpHeight);
        }
    }

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        actions = new InputSystem_Actions();
        actions.Player.Jump.performed += _ => IsHoldingJump = true;
        actions.Player.Jump.canceled += _ => IsHoldingJump = false;

        RunState = new RunState();
        JumpState = new JumpState();
        StateMachine = new StateMachine<PlayerController>(this);
    }

    void OnEnable() => actions.Player.Enable();
    void OnDisable() => actions.Player.Disable();

    void Start() => StateMachine.Initialize(RunState);

    void Update()
    {
        StateMachine.HandleInput();
        StateMachine.LogicUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        ) != null;
    }

    void OnDrawGizmos()
    {
        if (groundCheck == null) return;

        Vector3 center = groundCheck.position;
        Vector3 a = center + Vector3.left * gizmoHalfWidth;
        Vector3 b = center + Vector3.right * gizmoHalfWidth;

        bool grounded = Application.isPlaying && IsGrounded();
        Color lineCol = grounded ? groundedGizmoColor : notGroundedGizmoColor;

        Handles.color = lineCol;
        Handles.DrawAAPolyLine(gizmoLineThickness, new Vector3[] { a, b });
        
    }
}
