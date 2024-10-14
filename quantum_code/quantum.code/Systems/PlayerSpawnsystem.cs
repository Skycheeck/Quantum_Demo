namespace Quantum
{
    unsafe class PlayerSpawnSystem : SystemSignalsOnly, ISignalOnPlayerDataSet
    {
        public void OnPlayerDataSet(Frame frame, PlayerRef player)
        {
            var spec = frame.FindAsset<CharacterSpec>("Resources/DB/PlayerCharacterConfig");

            // Create a new entity for the player based on the prototype.
            var entity = frame.Create(spec.CharacterPrototype);

            frame.Add(entity, new PlayerLink {Player = player});
            frame.Add(entity, new Speed {Value = spec.Speed});
            frame.Add(entity, new Attacker() {DPS = spec.DPS, Radius = spec.AttackRadius});

            // Offset the instantiated object in the world, based on its ID.
            if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform))
            {
                transform->Position.X = (int)player;
            }
        }
    }
}