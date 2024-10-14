using Photon.Deterministic;
using Quantum.Physics3D;

namespace Quantum.Systems;

public unsafe class AttackSystem : SystemMainThreadFilter<AttackSystem.Filter>
{
    private HitCollection3D* _persistentHitCollection3D;

    public struct Filter
    {
        public EntityRef Entity;
        public Transform3D* Transform3D;
        public Attacker* Attacker;
    }

    public override void OnInit(Frame f)
    {
        base.OnInit(f);
        _persistentHitCollection3D = f.Physics3D.AllocatePersistentHitCollection3D(3);
    }

    public override void Update(Frame f, ref Filter filter)
    {
        f.Physics3D.OverlapShape(_persistentHitCollection3D, filter.Transform3D->Position,
            filter.Transform3D->Rotation, Shape3D.CreateSphere(filter.Attacker->Radius), filter.Attacker->Mask);

        for (int i = 0; i < _persistentHitCollection3D->Count; i++)
        {
            EntityRef entityRef = _persistentHitCollection3D->HitsBuffer[i].Entity;
            if (f.Has<Dead>(entityRef)) continue;

            if (!f.Unsafe.TryGetPointer(entityRef, out Health* health)) continue;
            health->Current -= filter.Attacker->DPS * f.DeltaTime;
            
            if (health->Current > FP._0) continue;
            f.Add<Dead>(entityRef);
        }
        
        _persistentHitCollection3D->Reset();
    }
}