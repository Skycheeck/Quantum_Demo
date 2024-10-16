using Quantum.Commands;

namespace Quantum.Systems;

public unsafe class PlayerProgressionSystem : SystemMainThread
{
    private PlayerCharacterProgression _playerCharacterProgression;

    public override void OnInit(Frame f)
    {
        base.OnInit(f);
        _playerCharacterProgression = f.FindAsset<PlayerCharacterProgression>("Resources/DB/PlayerCharacterProgressionConfig");
    }

    public override void Update(Frame f)
    {
        for (int i = 0; i < f.PlayerCount; i++)
        {
            if (f.GetPlayerCommand(i) is not UpgradePlayerCommand command) continue;
            RuntimePlayer runtimePlayer = f.GetPlayerData(i);
            
            command.Execute(f, _playerCharacterProgression, runtimePlayer);
            bool syncResult = SyncModelToEntity(f, runtimePlayer.CharacterRef, runtimePlayer.PlayerModel.PlayerCharacterStats);
            if (!syncResult) Log.Error($"Failed to sync upgrade changes for player {i}!");

            f.Events.PlayerModelUpdatedEvent(i, runtimePlayer.PlayerModel);
        }
    }

    private static bool SyncModelToEntity(Frame f, EntityRef entityRef, PlayerCharacterStats playerCharacterStats)
    {
        if (!f.Unsafe.TryGetPointer(entityRef, out Speed* speed)) return false;
        if (!f.Unsafe.TryGetPointer(entityRef, out Attacker* attacker)) return false;

        speed->Value = playerCharacterStats.Speed;
        attacker->DPS = playerCharacterStats.DPS;
        attacker->Radius = playerCharacterStats.AttackRadius;
        
        return true;
    }
}