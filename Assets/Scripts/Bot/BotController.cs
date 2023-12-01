using DG.Tweening;
using Lean.Pool;
using Ring;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour, CharacterInterface
{
    [HeaderTextColor(0.2f, .7f, .8f, headerText = "PlayerCOntroller For Player")] public Bot_Manager _botController;
    public AddBrick nearestBrick;
    public bool isChecking;
    public FiniteStateMachine stateMachine;
    public RunState runState;
    public IdleState idleState;
    public GoWinState goState;
    public FallingState fallingState;
    [SerializeField] public Rigidbody _rigidbody;

    private void Start()
    {
        //_botController.currentState = Bot_Manager.BotState.Idle;
        stateMachine = new FiniteStateMachine();
        runState = new RunState(this, stateMachine);
        idleState = new IdleState(this, stateMachine);
        goState = new GoWinState(this, stateMachine);
        fallingState = new FallingState(this, stateMachine);
        stateMachine.Initialize(idleState);
    }

    public void FallBackDown()
    {
        _rigidbody.velocity = Vector3.up * 500;
        Debug.Log(_rigidbody.velocity);
    }

    #region State Machine

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        if (Input.GetKeyDown(KeyCode.K))
        {
            FallBackDown();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetDestination(Vector3 destination)
    {
        _botController.agent.SetDestination(destination);
    }

    public virtual void FindNearestBrick()
    {
        float minDistanceSqr = Mathf.Infinity; // sử dụng biến vô cùng thay cho 10000
        nearestBrick = null;

        List<AddBrick> bricks = GameManager.Instance._gameController._listBrickSpawnAddBrick; // Lưu danh sách gạch vào một biến cục bộ
        int brickCount = bricks.Count;
        for (int i = 0; i < brickCount; i++)
        {
            AddBrick brick = bricks[i];
            if (brick.color.ToString().Equals(_botController.botName.ToString()))
            {
                float distanceSqr = (brick.transform.position - transform.position).sqrMagnitude;

                if (distanceSqr < minDistanceSqr)
                {
                    minDistanceSqr = distanceSqr;
                    nearestBrick = brick;
                }
            }
        }
    }


    #endregion State Machine

    public void AddBrick(AddBrick addBrick,MeshRenderer mesh, List<GameObject> trails, ParticleSystem trail)
    {
        // Đặt tên biến rõ ràng hơn
        int brickIndex = _botController.inDexDotWeen;
        mesh.material = _botController._materialPlayer;
        float index = brickIndex * 0.34f;
        addBrick.transform.SetParent(_botController._parentListTransform);

        addBrick.transform.DOLocalMove(new Vector3(0, index, 0), 0.25f).SetEase(Ease.InQuint).SetUpdate(true).OnComplete(() =>
        {
            trails.ForEach(t => t.gameObject.SetActive(false));
            addBrick._rigidbody.transform.localEulerAngles = new Vector3(0, 90, 0);
            addBrick._rigidbody.isKinematic = true;
            addBrick._rigidbody.useGravity = false;
            _botController._listBringBrick.Add(addBrick);
            MusicManager.Instance.PlayAudio_AddBrick();
            Vibrate();
            trail.Play();
        });

        // Tăng inDexDotWeen sau khi sử dụng
        _botController.inDexDotWeen++;
    }

    public void RemoveBrick()
    {
        if (_botController._listBringBrick.Count > 0)
        {
            MusicManager.Instance.PlayAudio_RemoveBrick();
            LeanPool.Despawn(_botController._listBringBrick[_botController._listBringBrick.Count - 1]);//lean pool
            _botController._listBringBrick.RemoveAt(_botController._listBringBrick.Count - 1);
            _botController.inDexDotWeen--;
        }
    }

    public void ClearBrick()
    {
    }

    #region Change Animation

    private void ChangeAnimation(int value)
    {
        _botController._animator.SetInteger("State", value);
    }

    #endregion Change Animation

    private static void Vibrate()
    {
        //Handheld.Vibrate();
    }
}