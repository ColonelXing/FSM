
/// <summary>
/// 命令基类
/// </summary>
public class ICmd
{
    /// <summary>
    /// 命令状态类型
    /// </summary>
    public enum E_State
    {
        Active,
        Success,
        Failed,
        Unused,
    }

    public E_State State = E_State.Active;

    public CmdFactory.E_CmdType Type;

    public ICmd(CmdFactory.E_CmdType type)
    {
        Type = type;
    }

    public bool IsActive
    {
        get
        {
            return State == E_State.Active;
        }
    }

    public bool IsSuccess
    {
        get
        {
            return State == E_State.Success;
        }
    }

    public bool IsFailed
    {
        get
        {
            return State == E_State.Failed;
        }
    }

    public bool IsUnUsed
    {
        get
        {
            return State == E_State.Unused;
        }
    }

    public bool IsState(E_State state)
    {
        return State == state;
    }

    public void SetActive()
    {
        State = E_State.Active;
    }

    public void SetSuccess()
    {
        State = E_State.Success;
    }

    public void SetFailed()
    {
        State = E_State.Failed;
    }

    public void SetUnused()
    {
        State = E_State.Unused;
    }

    public T Get<T>() where T : ICmd
    {
        return (T)this;
    }

    public virtual void Reset() { }
}
