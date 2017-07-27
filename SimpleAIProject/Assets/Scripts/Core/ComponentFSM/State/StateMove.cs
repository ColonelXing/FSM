using UnityEngine;
using System.Collections;

public class StateMove : StateBaseMove
{
    CmdMove Cmd;

    public StateMove(Agent owner, Animation anim) : base(owner, anim) { }

    public override void Enter(ICmd cmd)
    {
        base.Enter(cmd);
        PlayAnim(GetMotionType());
    }

    public override void Exit()
    {
        if (Cmd != null)
        {
            Cmd.SetSuccess();
            Cmd = null;
        }

        Owner.BlackBoard.Speed = 0;

        base.Exit();
    }

    public override void Execute()
    {
        if (Cmd.IsActive == false)
        {
            Release();
            return;
        }
        RotationProgress += Time.deltaTime * Owner.BlackBoard.RotationSmooth;
        RotationProgress = Mathf.Min(RotationProgress, 1);
        Quaternion q = Quaternion.Slerp(StartRotation, FinalRotation, RotationProgress);
        Owner.Transform.rotation = q;

        if (Quaternion.Angle(q, FinalRotation) > 40.0f)
            return;

        MaxSpeed = Mathf.Max(Owner.BlackBoard.MaxWalkSpeed, Owner.BlackBoard.MaxRunSpeed * Owner.BlackBoard.MoveSpeedModifier);
        float curSmooth = Owner.BlackBoard.SpeedSmooth * Time.deltaTime;

        Owner.BlackBoard.Speed = Mathf.Lerp(Owner.BlackBoard.Speed, MaxSpeed, curSmooth);
        Owner.BlackBoard.MoveDir = Owner.BlackBoard.DesiredDirection;
        // MOVE
        if (Move(Owner.BlackBoard.MoveDir * Owner.BlackBoard.Speed * Time.deltaTime) == false)
            Release();

        E_MotionType motion = GetMotionType();
        if (motion != Owner.BlackBoard.MotionType)
            PlayAnim(motion);
    }

    public override bool ProcessCmd(ICmd cmd)
    {
        if (cmd is CmdMove)
        {
            if (Cmd != null)
                Cmd.SetSuccess();
            SetFinished(false);

            Initialize(cmd);
            return true;
        }

        if (cmd is CmdWeaponShow)
        {
            cmd.SetSuccess();
            PlayAnim(GetMotionType());
            return true;
        }

        if (cmd is CmdIdle)
        {
            cmd.SetSuccess();
            SetFinished(true);
        }

        return false;
    }

    protected override void Initialize(ICmd cmd)
    {
        base.Initialize(cmd);
        Cmd = cmd as CmdMove;

        FinalRotation.SetLookRotation(Owner.BlackBoard.DesiredDirection);
        StartRotation = Owner.Transform.rotation;
        Owner.BlackBoard.MotionType = GetMotionType();
        RotationProgress = 0;
    }

}
