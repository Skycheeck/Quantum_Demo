using Photon.Deterministic;

namespace Quantum;

public partial class EnemiesSpawnConfig
{
    public FPVector3 SpawnBounds;
    public int InitialCount;
    public EnemySpec[] Enemies;
}