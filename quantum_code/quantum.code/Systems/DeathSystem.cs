namespace Quantum.Systems;

public unsafe class DeathSystem : SystemMainThreadFilter<DeathSystem.Filter>
{
    public struct Filter
    {
        public EntityRef EntityRef;
        public Dead* Dead;
    }

    public override void Update(Frame f, ref Filter filter)
    {
        f.Destroy(filter.EntityRef);
    }
}