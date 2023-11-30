using UnityEngine;

public class State
{
    public FiniteStateMachine stateMachine;
    public BotController botController;

    public State(BotController botController, FiniteStateMachine stateMachine)
    {
        this.botController = botController;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        botController._botController._animator.SetInteger(Settings.Animation_Character, 3);
    }

    public virtual void Exit()
    {
        botController._botController._animator.SetInteger(Settings.Animation_Character, 0);
    }
    public virtual void LogicUpdate()
    {
        
    }
    public virtual void PhysicsUpdate()
    {

    }
}