using System;
using Photon.Deterministic;

namespace Quantum;

public partial class PlayerCharacterProgression
{
    [Serializable]
    public struct ProgressionSpec
    {
        public FP Step;
        public FP Chance;
        public IUpgrade Upgrade;
    }

    public ProgressionSpec SpeedProgression, DPSProgression, AttackRadiusProgression;
}

public interface IUpgrade
{
    bool Upgrade(Frame f, EntityRef entityRef);
}

public class SpeedUpgrade(FP step) : IUpgrade
{
    public unsafe bool Upgrade(Frame f, EntityRef entityRef)
    {
        if (!f.Unsafe.TryGetPointer(entityRef, out Speed* speed)) return false;
        speed->Value += step;
        return true;
    }
}

public class DPSUpgrade(FP step) : IUpgrade
{
    public unsafe bool Upgrade(Frame f, EntityRef entityRef)
    {
        if (!f.Unsafe.TryGetPointer(entityRef, out Attacker* attacker)) return false;
        attacker->DPS += step;
        return true;
    }
}

public class AttackRadiusUpgrade(FP step) : IUpgrade
{
    public unsafe bool Upgrade(Frame f, EntityRef entityRef)
    {
        if (!f.Unsafe.TryGetPointer(entityRef, out Attacker* attacker)) return false;
        attacker->Radius += step;
        return true;
    }
}