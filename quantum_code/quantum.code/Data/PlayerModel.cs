using System;
using Photon.Deterministic;

namespace Quantum;

[Serializable]
public struct PlayerModel
{
    public PlayerCharacterStats PlayerCharacterStats;
    public int EnemiesKilled;
    
    public void Serialize(BitStream stream)
    {
        PlayerCharacterStats.Serialize(stream);
        stream.Serialize(ref EnemiesKilled);
    }

    public override string ToString() => $"{nameof(PlayerCharacterStats)} : {PlayerCharacterStats}, {nameof(EnemiesKilled)} : {EnemiesKilled}";
}