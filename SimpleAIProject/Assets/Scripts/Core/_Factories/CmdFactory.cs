using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 命令工厂
/// </summary>
public static class CmdFactory
{
    //命令类型
    public enum E_CmdType
    {
        None = -1,
        Idle,
        Move,
        GoTo,
        Attack,
        Death,
        WeaponShow,
        Count,
    }

    static private Dictionary<E_CmdType, Queue<ICmd>> UnusedCmds = new Dictionary<E_CmdType, Queue<ICmd>>();

#if DEBUG
    static private List<ICmd> UsedCmds = new List<ICmd>();
#endif

    static CmdFactory()
    {
        for (E_CmdType i = 0; i < E_CmdType.Count; i++)
        {
            UnusedCmds[i] = new Queue<ICmd>();
            //如果命令队列需要预分配可以在该处分配
        }
    }

    /// <summary>
    /// 创建命令
    /// </summary>
    /// <param name="type">命令类型</param>
    public static ICmd Create(E_CmdType type)
    {
        ICmd cmd = null;
        if (UnusedCmds[type] != null && UnusedCmds[type].Count > 0)
        {
            cmd = UnusedCmds[type].Dequeue();
        }
        else
        {
            switch (type)
            {
                case E_CmdType.Idle:
                    cmd = new CmdIdle();
                    break;
                case E_CmdType.Move:
                    cmd = new CmdMove();
                    break;
                case E_CmdType.Attack:
                    cmd = new CmdAttack();
                    break;
                case E_CmdType.Death:
                    cmd = new CmdDeath();
                    break;
                case E_CmdType.WeaponShow:
                    cmd = new CmdWeaponShow();
                    break;
                default:
                    Debug.LogError("No Cmd to Create!!! ICmd Type: " + type);
                    break;
            }
        }
        if (cmd != null)
        {
            cmd.Reset();
            cmd.SetActive();
#if DEBUG
            UsedCmds.Add(cmd);
#endif
        }

        return cmd;
    }

    /// <summary>
    /// 放回缓存
    /// </summary>
    /// <param name="cmd"></param>
    public static void Return(ICmd cmd)
    {
        if (cmd == null)
            return;
        cmd.SetUnused();
        UnusedCmds[cmd.Type].Enqueue(cmd);
#if DEBUG
        UsedCmds.Remove(cmd);
#endif
    }

    /// <summary>
    /// Denug Log输出正在使用的命令列表
    /// </summary>
    public static void Report()
    {
#if DEBUG
        Debug.Log("====================Start======================");
        Debug.Log("Cmd Factory Used Cmd count:" + UsedCmds.Count);
        for (int i = 0; i < UsedCmds.Count; i++)
        {
            Debug.Log(UsedCmds[i]);
        }
        Debug.Log("====================End======================");
#endif
    }
}
