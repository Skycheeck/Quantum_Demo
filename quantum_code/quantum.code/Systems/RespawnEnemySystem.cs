namespace Quantum.Systems;

public unsafe class RespawnEnemySystem : SystemMainThreadFilter<RespawnEnemySystem.Filter>
{
    public struct Filter
    {
        public EntityRef Entity;
        public Dead* Dead;
    }
    
    public override void Update(Frame f, ref Filter filter)
    {
        f.Signals.SpawnEnemies(1);
    }
}