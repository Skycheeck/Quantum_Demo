using System;
using Photon.Deterministic;

namespace Quantum;

[Serializable]
public struct PlayerCharacterStats
{
    public FP Speed;
    public FP DPS;
    public FP AttackRadius;

    public void Serialize(BitStream stream)
    {
        stream.Serialize(ref Speed);
        stream.Serialize(ref DPS);
        stream.Serialize(ref AttackRadius);
    }

    public override string ToString() => $"{nameof(Speed)} : {Speed}, {nameof(DPS)} : {DPS}, {nameof(AttackRadius)} : {AttackRadius}";
}