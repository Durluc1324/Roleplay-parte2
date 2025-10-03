namespace Ucu.Poo.RoleplayGame;

public class Staff : IDefense, IAttack
{
    public int AttackValue 
    {
        get
        {
            return 100;
        } 
    }

    public int DefenseValue
    {
        get
        {
            return 100;
        }
    }
}
