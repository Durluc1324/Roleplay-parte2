namespace Ucu.Poo.RoleplayGame;

public class Spell : IAttack, IDefense 
{
    public int AttackValue
    {
        get
        {
            return 70;
        }
    }

    public int DefenseValue
    {
        get
        {
            return 70;
        }
    }
}
