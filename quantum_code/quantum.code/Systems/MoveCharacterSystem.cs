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
        // gets the input for player 0
        var input = *f.GetPlayerInput(0);

        filter.CharacterController->Move(f, filter.Entity, input.Direction.XOY);
    }
}