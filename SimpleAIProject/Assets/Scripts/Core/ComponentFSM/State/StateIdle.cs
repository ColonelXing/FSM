using UnityEngine;

/// <summary>
/// 角色的Idle状态
/// </summary>
public class StateIdle : FSMState
{
    ICmd WeaponCmd;
    float TimeToFinishCmd;

    public StateIdle(Agent owner, Animation anim) : base(owner, anim) { }

    public override bool ProcessCmd(ICmd cmd)
    {
        if (cmd is CmdWeaponShow)
        {
            bool isShow = cmd.Get<CmdWeaponShow>().IsShow;
            string name = Owner.AnimSet.GetWeaponAnim(Owner.BlackBoard.WeaponSelected, isShow); 
            float timeScale = 0.9f;
            if (isShow)
                timeScale = 0.8f;
            TimeToFinishCmd = Time.timeSinceLevelLoad + Animation[name].length * timeScale;
            Animation.CrossFade(name, 0.1f);
            WeaponCmd = cmd;
            return true;
        }
        return false;
    }

    public override void Execute()
    {
        if (WeaponCmd != null && TimeToFinishCmd < Time.timeSinceLevelLoad)
        {
            WeaponCmd.SetSuccess();
            WeaponCmd = null;
            //todo: play id anim. 
            PlayIdleAnim();
        }
    }

    void PlayIdleAnim()
    {
        string s = Owner.AnimSet.GetIdleAnim(Owner.BlackBoard.WeaponSelected, Owner.BlackBoard.WeaponState);
        CrossFade(s, 0.2f);
    }

    protected override void Initialize(ICmd cmd)
    {
        base.Initialize(cmd);

        Owner.BlackBoard.MotionType = E_MotionType.None;
        Owner.BlackBoard.MoveDir = Vector3.zero;
        Owner.BlackBoard.Speed = 0;

        if (WeaponCmd == null)
            PlayIdleAnim();
    }
}
