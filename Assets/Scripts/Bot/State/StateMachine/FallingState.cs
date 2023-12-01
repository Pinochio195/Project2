using UnityEngine;

public class FallingState : State
{
    public FallingState(BotController botController, FiniteStateMachine stateMachine) : base(botController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        botController._botController._animator.SetInteger(Settings.Animation_Character, 2);
        if (botController._botController._listBringBrick.Count > 0)
        {
            Debug.Log(botController._botController._listBringBrick.Count);
            for (int i = 0; i < botController._botController._listBringBrick.Count; i++)
            {
                var a = botController._botController._listBringBrick[i]._rigidbody;
                botController._botController._listBringBrick[i].mesh.material = botController._botController._listBringBrick[i].materialAll;
                botController._botController._listBringBrick[i].color = AddBrick.MyColor.All;
                if (a != null)
                {
                    a.transform.SetParent(null);
                    a.isKinematic = false;
                    a.useGravity = true;
                    a.AddExplosionForce(900, botController.transform.position, 1.5f);
                }
                if (i == botController._botController._listBringBrick.Count - 1)
                {
                    botController._botController._listBringBrick.Clear();
                    botController._botController.inDexDotWeen = 0;
                }
            }

            Debug.Log(botController._botController._listBringBrick.Count);
        }
    }

    public override void Exit()
    {
        base.Exit();
        botController._botController._animator.SetInteger(Settings.Animation_Character, 3);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!botController._botController.isCheckFallDown)
        {
            stateMachine.ChangeState(botController.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}