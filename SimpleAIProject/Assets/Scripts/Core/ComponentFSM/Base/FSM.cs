using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 状态机管理器基类
/// </summary>
public abstract class FSM
{
    /// <summary>
    /// 状态机宿主
    /// </summary>
    protected Agent Owner;
    protected Animation Animation;
    /// <summary>
    /// 状态列表
    /// </summary>
    protected Dictionary<int, FSMState> States;
    /// <summary>
    /// 当前状态
    /// </summary>
    protected FSMState CurrentState;
    /// <summary>
    /// 默认状态
    /// </summary>
    protected FSMState DefaultState;
    /// <summary>
    /// 下一状态
    /// </summary>
    protected FSMState NextState;

    public FSM(Agent owner, Animation anim)
    {
        Owner = owner;
        Animation = anim;
        States = new Dictionary<int, FSMState>();
    }

    protected void AddState(int key, FSMState state)
    {
        if (States.ContainsKey(key))
            return;
        States[key] = state;
    }

    protected FSMState GetState(int key)
    {
        if (States.ContainsKey(key))
        {
            return States[key];
        }
        return null;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Initialize()
    {
        CurrentState = DefaultState;
        CurrentState.Enter();
        NextState = null;
    }

    public void Update()
    {
        if (CurrentState.IsFinished)
        {
            CurrentState.Exit();
            CurrentState = DefaultState;
            CurrentState.Enter();
        }
        CurrentState.Execute();
    }

    /// <summary>
    /// 重置所有状态
    /// </summary>
    public void Reset()
    {
        FSMState state;
        for (int i = 0; i < States.Count; i++)
        {
            state = States[i];
            if (!state.IsFinished)
            {
                state.Exit();
                state.SetFinished();
            }
        }
    }

    /// <summary>
    /// 处理命令
    /// </summary>
    /// <param name="cmd"></param>
    public abstract void ProcessCmd(ICmd cmd);

    /// <summary>
    /// 处理下一个状态
    /// </summary>
    /// <param name="cmd"></param>
    protected void ChangeState(ICmd cmd)
    {
        if (NextState == null)
            return;
        CurrentState.Release();

        CurrentState.Exit();
        CurrentState = NextState;
        CurrentState.Enter(cmd);

        NextState = null;
    }
}
