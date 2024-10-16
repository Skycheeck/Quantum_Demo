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
        public PlayerLink* PlayerLink;
    }

    public override void OnEnabled(Frame f)
    {
        base.OnEnabled(f);
        _persistentHitCollection3D = f.Physics3D.AllocatePersistentHitCollection3D(3);
    }

    public override void OnDisabled(Frame f)
    {
        base.OnDisabled(f);
        f.Physics3D.FreePersistentHitCollection3D(_persistentHitCollection3D);
    }

    public override void Update(Frame f, ref Filter filter)
    {
        if (!f.IsVerified) return;
        
        f.Physics3D.OverlapShape(_persistentHitCollection3D, filter.Transform3D->Position,
            filter.Transform3D->Rotation, Shape3D.CreateSphere(filter.Attacker->Radius), filter.Attacker->Mask);

        for (int i = 0; i < _persistentHitCollection3D->Count; i++)
        {
            EntityRef entityRef = _persistentHitCollection3D->HitsBuffer[i].Entity;
            FP damage = filter.Attacker->DPS * f.DeltaTime;
            f.Signals.TakeDamage(entityRef, damage, filter.PlayerLink->Player);
        }

        _persistentHitCollection3D->Reset();
    }
}