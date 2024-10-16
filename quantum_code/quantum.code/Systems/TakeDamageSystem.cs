using Photon.Deterministic;

namespace Quantum.Systems;

public unsafe class TakeDamageSystem : SystemSignalsOnly, ISignalTakeDamage
{
    public void TakeDamage(Frame f, EntityRef entity, FP damage, PlayerRef source)
    {
        if (!f.Unsafe.TryGetPointer(entity, out Health* health)) return; // skip if no health
        if (f.Has<Dead>(entity) || health->Current <= FP._0) return; // skip if dead

        health->Current -= damage; // do damage

        if (health->Current > FP._0) return; // skip if damage is not enough to kill
        f.Add<Dead>(entity); // add dead

        // update kill counter and send event to view
        RuntimePlayer runtimePlayer = f.GetPlayerData(source);
        runtimePlayer.PlayerModel.EnemiesKilled++;
        f.Events.PlayerModelUpdatedEvent(source, runtimePlayer.PlayerModel);
    }
}