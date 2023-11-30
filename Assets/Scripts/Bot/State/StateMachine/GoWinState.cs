using UnityEngine;

public class GoWinState : State
{
    public GoWinState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        botController.SetDestination(GameManager.Instance._gameController._finishDestination.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (botController._botController._listBringBrick.Count <= 0)
        {
            stateMachine.ChangeState(botController.runState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}