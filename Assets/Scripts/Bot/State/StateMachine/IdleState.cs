using UnityEngine;

public class IdleState : State
{
    public IdleState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        botController.FindNearestBrick();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (botController.nearestBrick != null)
        {
            stateMachine.ChangeState(botController.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}