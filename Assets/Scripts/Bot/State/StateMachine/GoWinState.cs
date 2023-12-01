public class GoWinState : State
{
    public GoWinState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter(); 
        botController._botController.agent.enabled = true;
        botController.SetDestination(GameManager.Instance._gameController._finishDestination.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!botController._botController.isCheckFallDown)
        {
            if (botController._botController._listBringBrick.Count <= 0)
            {
                stateMachine.ChangeState(botController.idleState);
            }
        }
        else
        {
            stateMachine.ChangeState(botController.fallingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}