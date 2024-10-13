namespace Quantum.Systems;

public unsafe class MoveCharacterSystem : SystemMainThreadFilter<MoveCharacterSystem.Filter>
{
    public struct Filter
    {
        public EntityRef Entity;
        public CharacterController3D* CharacterController;
    }

    public override void Update(Frame f, ref Filter filter)
    {
        Input input = default;
        if(f.Unsafe.TryGetPointer(filter.Entity, out PlayerLink* playerLink))
        {
            input = *f.GetPlayerInput(playerLink->Player);
        }

        filter.CharacterController->Move(f, filter.Entity, input.Direction.XOY);
    }
}