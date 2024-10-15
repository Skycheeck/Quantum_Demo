namespace Quantum
{
    unsafe class PlayerSpawnSystem : SystemSignalsOnly, ISignalOnPlayerDataSet
    {
        private CharacterSpec _characterSpec;

        public override void OnInit(Frame f)
        {
            base.OnInit(f);
            _characterSpec = f.FindAsset<CharacterSpec>("Resources/DB/PlayerCharacterConfig");
        }

        public void OnPlayerDataSet(Frame frame, PlayerRef player)
        {
            // Create a new entity for the player based on the prototype.
            var entity = frame.Create(_characterSpec.CharacterPrototype);

            frame.Add(entity, new PlayerLink {Player = player});
            frame.Add(entity, new Speed {Value = _characterSpec.Speed});
            frame.Add(entity, new Attacker() {DPS = _characterSpec.DPS, Radius = _characterSpec.AttackRadius, Mask = _characterSpec.AttackMask});

            // Offset the instantiated object in the world, based on its ID.
            if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform))
            {
                transform->Position.X = (int)player;
            }

            frame.GetPlayerData(player).CharacterRef = entity;
        }
    }
}