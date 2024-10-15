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
            UpgradePlayerCommand command = f.GetPlayerCommand(i) as UpgradePlayerCommand;
            command?.Execute(f, _playerCharacterProgression, f.GetPlayerData(i).CharacterRef);
        }
    }
}