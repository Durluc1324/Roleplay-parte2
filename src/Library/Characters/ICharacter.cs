namespace Ucu.Poo.RoleplayGame;

public interface ICharacter
{
    int Health { get; set; }
    string Name { get; set; }
    int DefenseValue { get;}
    int AttackValue { get;}

    void ReceiveAttack(int power);
    void Cure();
}