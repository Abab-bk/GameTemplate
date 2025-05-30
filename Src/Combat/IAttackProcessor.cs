namespace Game.Combat;

public interface IAttackProcessor<in T>
{
    public ProcessedAttack ProcessAttack(T target, Attack attack);
}