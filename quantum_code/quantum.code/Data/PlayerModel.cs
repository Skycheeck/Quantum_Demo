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
}