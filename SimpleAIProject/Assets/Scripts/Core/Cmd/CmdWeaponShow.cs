
public class CmdWeaponShow : ICmd
{
    public bool IsShow = true;

    public CmdWeaponShow() : base(CmdFactory.E_CmdType.WeaponShow) { }
}
