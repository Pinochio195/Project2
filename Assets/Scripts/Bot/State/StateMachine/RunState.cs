
using UnityEngine;

public class RunState : State
{
    public RunState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        botController._botController.agent.enabled = true;
        botController.SetDestination(botController.nearestBrick.transform.position);
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
            if (!botController._botController.agent.enabled)
            {
                botController._botController.agent.enabled = true;
            }
            if (botController._botController.agent.remainingDistance < 0.9f)
            {
                int index = GameManager.Instance._gameController._listBrickSpawnAddBrick.IndexOf(botController.nearestBrick);
                if (index != -1)
                {
                    GameManager.Instance._gameController._listBrickSpawnAddBrick.RemoveAt(index); // Sử dụng RemoveAt thay vì Remove
                }
                if (botController._botController._listBringBrick.Count >= 5)
                {
                    stateMachine.ChangeState(botController.goState);
                }
                else
                {
                    stateMachine.ChangeState(botController.idleState);
                }
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