public class Player : BaseCreature
{
    protected new void Start()
    {
        base.Start();
        health = 100;
        damage = 5;
    }
}