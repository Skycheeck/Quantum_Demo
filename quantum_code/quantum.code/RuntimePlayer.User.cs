using Photon.Deterministic;

namespace Quantum
{
  partial class RuntimePlayer
  {
    public EntityRef CharacterRef;
    public PlayerModel PlayerModel;

    partial void SerializeUserData(BitStream stream)
    {
      stream.Serialize(ref CharacterRef);
      PlayerModel.Serialize(stream);
    }
  }
}
