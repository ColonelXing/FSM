using System;

/// <summary>
/// 玩家动画获取配置
/// </summary>
public class SetPlayer : AnimSet
{
    public override string GetDeathAnim(E_WeaponType weapon, E_DamageType type)
    {
        throw new NotImplementedException();
    }

    public override string GetIdleAnim(E_WeaponType weapon, E_WeaponState weaponState)
    {
        if (weaponState == E_WeaponState.NotInHands)
            return "idle";

        return "idleSword";
    }

    public override string GetMoveAnim(E_MotionType motion, E_MoveType move, E_WeaponType weapon, E_WeaponState weaponState)
    {
        if (weaponState == E_WeaponState.NotInHands)
        {
            if (motion != E_MotionType.Walk)
                return "run";
            else
                return "walk";
        }

        if (motion != E_MotionType.Walk)
            return "runSword";

        return "walkSword";
    }

    public override string GetRollAnim(E_WeaponType weapon, E_WeaponState weaponState)
    {
        throw new NotImplementedException();
    }

    public override string GetWeaponAnim(E_WeaponType weapon, bool isShow)
    {
        if (isShow)
            return "showSwordRun";
        else
            return "hidSwordRun";
    }
}
