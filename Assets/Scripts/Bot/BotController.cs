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

    private void Start()
    {
        //_botController.currentState = Bot_Manager.BotState.Idle;
        stateMachine = new FiniteStateMachine();
        runState = new RunState(this, stateMachine);
        idleState = new IdleState(this, stateMachine);
        goState = new GoWinState(this, stateMachine);
        stateMachine.Initialize(idleState);
    }


    #region State Machine

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
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

    /*private void SetDestination(Vector3 destination)
    {
        _botController.agent.SetDestination(destination);
    }*/

    #endregion State Machine

    /*  public void AddBrick(Transform _brick, List<GameObject> trails, ParticleSystem trail)
      {
          */
    /*_botController.inDexDotWeen++;
          float index = _botController.inDexDotWeen * 0.34f;

          _brick.transform.SetParent(_botController._parentListTransform);
          _brick.transform.DOLocalMove(new Vector3(0, index, 0), 0.25f).SetEase(Ease.InBounce).SetUpdate(true).OnComplete(() =>
          {
              Debug.Log(_botController.inDexDotWeen);
              trails.ForEach(trail => { trail.gameObject.SetActive(false); });
              _brick.transform.localEulerAngles = new Vector3(0, 90, 0);
              _botController._listBringBrick.Add(_brick.gameObject);
              MusicManager.Instance.PlayAudio_AddBrick();
              Vibrate();
              trail.Play();
          });*//*
      }*/
    public void AddBrick(Transform _brick, List<GameObject> trails, ParticleSystem trail)
    {
        // Đặt tên biến rõ ràng hơn
        int brickIndex = _botController.inDexDotWeen;

        float index = brickIndex * 0.34f;
        _brick.transform.SetParent(_botController._parentListTransform);

        _brick.transform.DOLocalMove(new Vector3(0, index, 0), 0.25f).SetEase(Ease.InQuint).SetUpdate(true).OnComplete(() =>
        {
            trails.ForEach(t => t.gameObject.SetActive(false));
            _brick.transform.localEulerAngles = new Vector3(0, 90, 0);

            _botController._listBringBrick.Add(_brick.gameObject);
            MusicManager.Instance.PlayAudio_AddBrick();
            Vibrate();
            trail.Play();
        });

        // Tăng inDexDotWeen sau khi sử dụng
        _botController.inDexDotWeen++;
    }

    public void RemoveBrick()
    {
        MusicManager.Instance.PlayAudio_RemoveBrick();
        LeanPool.Despawn(_botController._listBringBrick[_botController._listBringBrick.Count - 1]);//lean pool
        _botController._listBringBrick.RemoveAt(_botController._listBringBrick.Count - 1);
        _botController.inDexDotWeen--;
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