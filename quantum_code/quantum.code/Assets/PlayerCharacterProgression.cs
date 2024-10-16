using System;
using Photon.Deterministic;

namespace Quantum;

public partial class PlayerCharacterProgression
{
    [Serializable]
    public struct ProgressionSpec
    {
        public FP Step;
        public FP Chance;
        public IUpgrade Upgrade;
    }

    public ProgressionSpec SpeedProgression, DPSProgression, AttackRadiusProgression;
}

public interface IUpgrade
{
    void Upgrade(RuntimePlayer runtimePlayer);
}

public class SpeedUpgrade(FP step) : IUpgrade
{
    public void Upgrade(RuntimePlayer runtimePlayer)
    {
        runtimePlayer.PlayerModel.PlayerCharacterStats.Speed += step;
    }
}

public class DPSUpgrade(FP step) : IUpgrade
{
    public void Upgrade(RuntimePlayer runtimePlayer)
    {
        runtimePlayer.PlayerModel.PlayerCharacterStats.DPS += step;
    }
}

public class AttackRadiusUpgrade(FP step) : IUpgrade
{
    public void Upgrade(RuntimePlayer runtimePlayer)
    {
        runtimePlayer.PlayerModel.PlayerCharacterStats.AttackRadius += step;
    }
}