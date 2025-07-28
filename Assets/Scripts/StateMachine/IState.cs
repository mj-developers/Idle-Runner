public interface IState<TContext>
{

    /// Se llama al entrar en el estado.
    void Enter(TContext context);

    /// Se llama al salir del estado.
    void Exit(TContext context);

    /// Lectura de input o eventos de usuario.
    void HandleInput(TContext context);

    /// Lógica de juego (sin físicas).
    void LogicUpdate(TContext context);

    /// Lógica de físicas, desde FixedUpdate.
    void PhysicsUpdate(TContext context);
}
