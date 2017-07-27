using UnityEngine;


/// <summary>
/// 游戏对象实体类型
/// </summary>
public enum E_EntityType
{
    None = -2,
    Player = -1,
    SwordsMan = 0,
    Peasant = 1,
    Count, //怪物数量种类
}

/// <summary>
/// 有限状态机种类
/// </summary>
public enum E_FSMType
{
    None,
    SimpleHero,
    Player,
    Boss01,
    Count,
}

public enum E_WeaponType
{
    None = -1,
    Katana = 0,
    Max,
}


public enum E_WeaponState
{
    NotInHands,
    Ready,
    Attacking,
    Reloading,
    Empty,
}

public enum E_MotionType
{
    None,
    Walk,
    Run,
    Sprint,
    Roll,
    Attack,
    Block,
    Knockdown,
    Death,
}

public enum E_MoveType
{
    None,
    Forward,
    Backward,
    StrafeLeft,
    StrafeRight,
}

public enum E_RotationType
{
    Left,
    Right
}

public enum E_DamageType
{
    Front,
    Back,
    BreakBlock,
    InKnockdown,
    Enviroment,
}