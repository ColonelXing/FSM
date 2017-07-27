using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ICmdHandler
{
    void ProcessCmd(ICmd cmd);
}

/// <summary>
/// 黑板
/// </summary>
[System.Serializable]
public class BlackBoard
{
    /// <summary>
    /// 黑板拥有者
    /// </summary>
    [System.NonSerialized]
    public Agent Owner;
    /// <summary>
    /// 拥有者的对象
    /// </summary>
    [System.NonSerialized]
    public GameObject GameObject;

    ////////////////////////Stats/////////////////////////
    /// <summary>
    /// 速度
    /// </summary>
    [System.NonSerialized]
    public float Speed = 0f;
    /// <summary>
    /// 生命
    /// </summary>
    [System.NonSerialized]
    public float Health = 100f;

    [System.NonSerialized]
    public float IdleTimer = 0f;

    [System.NonSerialized]
    public Vector3 MoveDir;

    /// <summary>
    /// 预期位置
    /// </summary>
    [System.NonSerialized]
    public Vector3 DesiredPosition;
    /// <summary>
    /// 预期方向
    /// </summary>
    [System.NonSerialized]
    public Vector3 DesiredDirection;

    /// <summary>
    /// 选择的武器类型
    /// </summary>
    public E_WeaponType WeaponSelected = E_WeaponType.Katana;
    /// <summary>
    /// 当前武器状态
    /// </summary>
    public E_WeaponState WeaponState = E_WeaponState.NotInHands;
    /// <summary>
    /// 当前移动类型
    /// </summary>
    public E_MotionType MotionType = E_MotionType.None;

    /////////////////////////init stats///////////////////
    /// <summary>
    /// 最大冲刺速度
    /// </summary>
    public float MaxSprintSpeed = 8;
    /// <summary>
    /// 最大跑速度
    /// </summary>
    public float MaxRunSpeed = 4;
    /// <summary>
    /// 最大走速度
    /// </summary>
    public float MaxWalkSpeed = 1.5f;

    ///////////////// SETTINGS /////////////////////////////
    public float SpeedSmooth = 2.0f;
    public float RotationSmooth = 2.0f;
    public float RotationSmoothInMove = 8.0f;
    public float RollDistance = 4.0f;
    public float MoveSpeedModifier = 1;

    #region Cmd
    ////////////////////////Cmd///////////////////////////
    List<ICmd> ActiveCmds = new List<ICmd>();
    List<ICmdHandler> CmdHandlers = new List<ICmdHandler>();
    /// <summary>
    /// 添加命令进行派发
    /// </summary>
    /// <param name="cmd"></param>
    public void AddCmd(ICmd cmd)
    {
        IdleTimer = 0f;
        ActiveCmds.Add(cmd);
        for (int i = 0; i < CmdHandlers.Count; i++)
        {
            CmdHandlers[i].ProcessCmd(cmd);
        }
    }
    /// <summary>
    /// 获取指定激活命令
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public ICmd GetCmd(int index)
    {
        return ActiveCmds[index];
    }
    /// <summary>
    /// 激活的命令个数
    /// </summary>
    public int CmdCount
    {
        get
        {
            return ActiveCmds.Count;
        }
    }




    /// <summary>
    /// 添加命令监听对象
    /// </summary>
    /// <param name="handler"></param>
    public void AddCmdHandler(ICmdHandler handler)
    {
        if (CmdHandlers.Contains(handler))
            return;
        CmdHandlers.Add(handler);
    }
    /// <summary>
    /// 移除命令监听对象
    /// </summary>
    /// <param name="handler"></param>
    public void RemoveCmdHandler(ICmdHandler handler)
    {
        if (CmdHandlers.Contains(handler))
            CmdHandlers.Remove(handler);
    }

    /// <summary>
    /// 统一回收命令对象
    /// </summary>
    public void Update()
    {
        IdleTimer += Time.deltaTime;

        ICmd cmd;
        for (int i = 0; i < ActiveCmds.Count; i++)
        {
            cmd = ActiveCmds[i];
            if (cmd.IsActive)
                continue;
            CmdFactory.Return(cmd);
            ActiveCmds.RemoveAt(i);
            return;
        }
    }
    #endregion
}
