public interface IState<TContext>
{

    /// Se llama al entrar en el estado.
    void Enter(TContext context);

    /// Se llama al salir del estado.
    void Exit(TContext context);

    /// Lectura de input o eventos de usuario.
    void HandleInput(TContext context);

    /// L�gica de juego (sin f�sicas).
    void LogicUpdate(TContext context);

    /// L�gica de f�sicas, desde FixedUpdate.
    void PhysicsUpdate(TContext context);
}
