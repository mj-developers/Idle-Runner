using UnityEngine;

public class RunState : IState<PlayerController>
{
    public void Enter(PlayerController context)
    {
        // Se ejecuta al entrar en Run
        context.Animator.Play("Run");
    }

    public void Exit(PlayerController context)
    {
        // Método presente para cumplir la interfaz
    }

    public void HandleInput(PlayerController context)
    {
        // Si pulsas salto y estás en el suelo, cambiamos a Jump
        if (context.JumpAction.triggered && context.IsGrounded())
        {
            context.StateMachine.ChangeState(context.JumpState);
        }
    }

    public void LogicUpdate(PlayerController context)
    {
        // Aquí se podrá manejar otros inputs (ej. ataque)
    }

    public void PhysicsUpdate(PlayerController context)
    {
        // Método presente para cumplir la interfaz
    }
}
