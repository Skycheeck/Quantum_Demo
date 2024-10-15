using Photon.Deterministic;

namespace Quantum
{
  partial class RuntimePlayer
  {
    public EntityRef CharacterRef;

    partial void SerializeUserData(BitStream stream)
    {
      stream.Serialize(ref CharacterRef);
    }
  }
}
