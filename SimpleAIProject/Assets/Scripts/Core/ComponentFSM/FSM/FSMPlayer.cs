using UnityEngine;
/// <summary>
/// 玩家角色的状态机组件
/// </summary>
public class FSMPlayer : FSM
{
    enum E_StateType
    {
        Idle,
        Move,
        GoTo,
        Attack,
        Death,
    }
    public FSMPlayer(Agent owner, Animation anim) : base(owner, anim) { }

    /// <summary>
    /// 初始化状态机
    /// </summary>
    public override void Initialize()
    {
        AddState(E_StateType.Idle, new StateIdle(Owner, Animation));
        AddState(E_StateType.Move, new StateMove(Owner, Animation));
        AddState(E_StateType.Attack, new StateAttack(Owner, Animation));

        DefaultState = GetState(E_StateType.Idle);
        base.Initialize();
    }

    void AddState(E_StateType key, FSMState state)
    {
        AddState((int)key, state);
    }

    FSMState GetState(E_StateType key)
    {
        return GetState((int)key);
    }

    public override void ProcessCmd(ICmd cmd)
    {
        if (CurrentState.ProcessCmd(cmd))
            NextState = null;
        else
        {
            if (cmd is CmdMove)
                NextState = GetState(E_StateType.Move);
            else if (cmd is CmdAttack)
                NextState = GetState(E_StateType.Attack);
            else if (cmd is CmdDeath)
                NextState = GetState(E_StateType.Death);
            else if (cmd is CmdWeaponShow)
                NextState = GetState(E_StateType.Idle);
        }

        if (NextState == null)
            return;
        ChangeState(cmd);
    }
}
