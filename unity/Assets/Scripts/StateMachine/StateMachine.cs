public class StateMachine<TContext>
{
    /// Estado actual.
    public IState<TContext> CurrentState { get; private set; }

    private readonly TContext context;

    public StateMachine(TContext context)
    {
        this.context = context;
    }

    /// Inicializa la máquina con un estado de inicio.
    public void Initialize(IState<TContext> startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter(context);
    }

    /// Cambia al nuevo estado, llamando Exit y Enter.
    public void ChangeState(IState<TContext> newState)
    {
        CurrentState.Exit(context);
        CurrentState = newState;
        CurrentState.Enter(context);
    }

    /// Debe llamarse cada frame en Update() del contexto.
    public void HandleInput()
    {
        CurrentState.HandleInput(context);
    }

    /// Debe llamarse cada frame en Update() del contexto.
    public void LogicUpdate()
    {
        CurrentState.LogicUpdate(context);
    }

    /// Debe llamarse en FixedUpdate() del contexto.
    public void PhysicsUpdate()
    {
        CurrentState.PhysicsUpdate(context);
    }
}
