using UnityEngine;

public class JumpState : IState<PlayerController>
{
    enum Phase { Ascend, Apex, Descend }
    Phase currentPhase;
    float apexTimer;

    public void Enter(PlayerController ctx)
    {
        // Congelar Animator y saltar al fotograma de subida
        ctx.Animator.speed = 0f;
        ctx.Animator.Play("Jump", 0, 0f);

        // Impulso inicial
        ctx.Rb.gravityScale = ctx.GravityScale;
        ctx.Rb.linearVelocity = Vector2.up * ctx.InitialJumpVelocity;

        currentPhase = Phase.Ascend;
        apexTimer = 0f;
    }

    public void Exit(PlayerController ctx)
    {
        ctx.Animator.speed = 1f;
    }

    public void HandleInput(PlayerController ctx) { }
    public void LogicUpdate(PlayerController ctx) { }

    public void PhysicsUpdate(PlayerController ctx)
    {
        float vy = ctx.Rb.linearVelocity.y;
        Phase newPhase;

        // Determinamos la fase de forma simple
        if (vy > ctx.apexVelocityThreshold) newPhase = Phase.Ascend;
        else if (vy >= -ctx.apexVelocityThreshold) newPhase = Phase.Apex;
        else newPhase = Phase.Descend;

        // Si cambiamos de fase, saltamos al fotograma correcto
        if (newPhase != currentPhase)
        {
            currentPhase = newPhase;
            switch (currentPhase)
            {
                case Phase.Ascend:
                    // frame 0/3
                    ctx.Animator.Play("Jump", 0, 0f / 3f);
                    break;
                case Phase.Apex:
                    // frame 1/3  
                    ctx.Animator.Play("Jump", 0, 1f / 3f);
                    break;
                case Phase.Descend:
                    // frame 2/3
                    ctx.Animator.Play("Jump", 0, 2f / 3f);
                    break;
            }
        }

        // Ahora la gravedad según fase
        if (currentPhase == Phase.Descend)
        {
            ctx.Rb.gravityScale = ctx.GravityScale * ctx.fallMultiplier;
        }
        else if (currentPhase == Phase.Apex)
        {
            if (apexTimer < ctx.apexHangDuration)
            {
                apexTimer += Time.fixedDeltaTime;
                ctx.Rb.gravityScale = ctx.GravityScale * ctx.apexHangMultiplier;
            }
            else
            {
                ctx.Rb.gravityScale = ctx.GravityScale;
            }
        }
        else 
        {
            if (!ctx.IsHoldingJump)
            {
                // Recorte de salto
                if (vy > ctx.MinJumpVelocity)
                    ctx.Rb.linearVelocity = new Vector2(0, ctx.MinJumpVelocity);
                ctx.Rb.gravityScale = ctx.GravityScale * ctx.lowJumpMultiplier;
            }
            else
            {
                ctx.Rb.gravityScale = ctx.GravityScale;
            }
        }

        // Al aterrizar, volvemos a Run
        if (vy <= 0f && ctx.IsGrounded())
            ctx.StateMachine.ChangeState(ctx.RunState);
    }
}
