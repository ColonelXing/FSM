using UnityEngine;
using System.Collections;

/// <summary>
/// 获取各种动画名字
/// </summary>
[System.Serializable]
public abstract class AnimSet : MonoBehaviour
{
    /// <summary>
    /// 获取Idle动画
    /// </summary>
    /// <param name="weapon"></param>
    /// <param name="weaponState"></param>
    /// <returns></returns>
    public abstract string GetIdleAnim(E_WeaponType weapon, E_WeaponState weaponState);
    /// <summary>
    /// 获取移动动画
    /// </summary>
    /// <param name="motion"></param>
    /// <param name="move"></param>
    /// <param name="weapon"></param>
    /// <param name="weaponState"></param>
    /// <returns></returns>
    public abstract string GetMoveAnim(E_MotionType motion, E_MoveType move, E_WeaponType weapon, E_WeaponState weaponState);
    /// <summary>
    /// 获取躲避动画
    /// </summary>
    /// <param name="weapon"></param>
    /// <param name="weaponState"></param>
    /// <returns></returns>
    public abstract string GetRollAnim(E_WeaponType weapon, E_WeaponState weaponState);
    /// <summary>
    /// 获取拿和收武器动画
    /// </summary>
    /// <param name="weapon"></param>
    /// <param name="isShow"></param>
    /// <returns></returns>
    public abstract string GetWeaponAnim(E_WeaponType weapon, bool isShow);
    /// <summary>
    /// 获取死亡动画
    /// </summary>
    /// <param name="weapon"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public abstract string GetDeathAnim(E_WeaponType weapon, E_DamageType type);
}
