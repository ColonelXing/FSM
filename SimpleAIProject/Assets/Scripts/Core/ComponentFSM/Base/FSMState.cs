using System;
using UnityEngine;
/// <summary>
/// 状态机基类
/// </summary>
public class FSMState 
{
    /// <summary>
    /// 对象宿主
    /// </summary>
    protected Agent Owner;
    protected Animation Animation;
    protected Transform Transform;
    protected Transform Root;

    private bool isFinished = true;
    public bool IsFinished
    {
        get
        {
            return isFinished;
        }
    }
    public void SetFinished(bool finished=true)
    {
        isFinished = finished;
    }

    public FSMState(Agent owner, Animation anim)
    {
        Animation = anim;
        Owner = owner;
        Transform = Owner.transform;
        Root = Transform.Find("root");
    }

    #region 初始化，进入，更新，退出，释放，命令接收
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="cmd"></param>
    protected virtual void Initialize(ICmd cmd = null)
    {

    }
    /// <summary>
    /// 进入状态
    /// </summary>
    /// <param name="cmd"></param>
    public virtual void Enter(ICmd cmd = null)
    {
        SetFinished(false);
        Initialize(cmd);
    }
    /// <summary>
    /// 更新状态
    /// </summary>
    public virtual void Execute()
    {

    }
    /// <summary>
    /// 退出状态
    /// </summary>
    public virtual void Exit()
    {

    }
    /// <summary>
    /// 释放对象
    /// </summary>
    public virtual void Release()
    {
        SetFinished(true);
    }
    /// <summary>
    /// 命令处理
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    public virtual bool ProcessCmd(ICmd cmd) { return false; }

    #endregion

    protected void CrossFade(string anim, float fadeInTime)
    {
        if (Animation.IsPlaying(anim))
            Animation.CrossFadeQueued(anim, fadeInTime, QueueMode.PlayNow);
        else
            Animation.CrossFade(anim, fadeInTime);
    }

    protected bool Move(Vector3 velocity, bool slide = true)
    {
        
        Vector3 old = Transform.position;

        Transform.position += Vector3.up * Time.deltaTime;

        velocity.y -= 9 * Time.deltaTime;
        CollisionFlags flags = Owner.Controller.Move(velocity);

        if (slide == false && (flags & CollisionFlags.Sides) != 0)
        {
            Transform.position = old;
            return false;
        }

        if ((flags & CollisionFlags.Below) == 0)
        {
            Transform.position = old;
            return false;
        }

        return true;
    }


}
