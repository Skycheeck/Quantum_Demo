using System.Linq;
using Photon.Deterministic;

namespace Quantum;

public unsafe class EnemySpawnSystem : SystemMainThreadFilter<EnemySpawnSystem.Filter>
{
    private EnemiesSpawnConfig _enemiesSpawnConfig;

    public struct Filter
    {
        public EntityRef Entity;
        public Dead* Dead;
    }

    public override void OnInit(Frame f)
    {
        base.OnInit(f);
        
        _enemiesSpawnConfig = f.FindAsset<EnemiesSpawnConfig>("Resources/DB/EnemiesSpawnConfig");

        for (int i = 0; i < _enemiesSpawnConfig.InitialCount; i++)
        {
            EnemySpec enemySpec = GetRandomEnemySpec(f);
            SpawnEnemy(f, enemySpec.EnemyPrototype, enemySpec.Health, GetPosition(f, _enemiesSpawnConfig));
        }
    }

    public override void Update(Frame f, ref Filter filter)
    {
        EnemySpec enemySpec = GetRandomEnemySpec(f);
        SpawnEnemy(f, enemySpec.EnemyPrototype, enemySpec.Health, GetPosition(f, _enemiesSpawnConfig));
    }

    private EnemySpec GetRandomEnemySpec(Frame f)
    {
        return _enemiesSpawnConfig.Enemies[f.Global->RngSession.Next(0, _enemiesSpawnConfig.Enemies.Length)];
    }

    private static void SpawnEnemy(Frame f, AssetRefEntityPrototype entityPrototype, FP health, FPVector3 position)
    {
        EntityRef entityRef = f.Create(entityPrototype);
        
        if (!f.Unsafe.TryGetPointer(entityRef, out Transform3D* transform3D)) return;
        transform3D->Position = position;

        f.Add(entityRef, new Health {Current = health});
    }

    private static FPVector3 GetPosition(Frame f, EnemiesSpawnConfig enemiesSpawnConfig)
    {
        return new FPVector3(
            f.Global->RngSession.NextInclusive(-enemiesSpawnConfig.SpawnBounds.X / 2, enemiesSpawnConfig.SpawnBounds.X),
            0,
            f.Global->RngSession.NextInclusive(-enemiesSpawnConfig.SpawnBounds.Z / 2, enemiesSpawnConfig.SpawnBounds.Z));
    }
}