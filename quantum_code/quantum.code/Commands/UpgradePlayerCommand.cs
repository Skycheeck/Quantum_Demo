using System.Collections.Generic;
using System.Linq;
using Photon.Deterministic;

namespace Quantum.Commands;

public class UpgradePlayerCommand : DeterministicCommand
{
    
    public override void Serialize(BitStream stream)
    {
        
    }

    public void Execute(Frame f, PlayerCharacterProgression progression, RuntimePlayer runtimePlayer)
    {
        ChanceUpgradePair[] pairs =
        [
            new ChanceUpgradePair(progression.SpeedProgression.Chance, new SpeedUpgrade(progression.SpeedProgression.Step)),
            new ChanceUpgradePair(progression.DPSProgression.Chance, new DPSUpgrade(progression.DPSProgression.Step)),
            new ChanceUpgradePair(progression.AttackRadiusProgression.Chance, new AttackRadiusUpgrade(progression.AttackRadiusProgression.Step))
        ];

        int index = GetRandomIndex(f, pairs.Select(x => x.Chance).ToArray());

        IUpgrade upgrade = pairs[index].Upgrade;
        upgrade.Upgrade(runtimePlayer);
    }

    private unsafe int GetRandomIndex(Frame f, IReadOnlyList<FP> chances)
    {
        FP total = chances.Aggregate<FP, FP>(0, (current, chance) => current + chance);
        FP randomValue = f.Global->RngSession.NextInclusive(0, total);

        FP cumulative = FP._0;
        for (int i = 0; i < chances.Count; i++)
        {
            cumulative += chances[i];
            if (randomValue <= cumulative)
            {
                return i;
            }
        }
        
        return -1;
    }

    private readonly struct ChanceUpgradePair(FP chance, IUpgrade upgrade)
    {
        public readonly FP Chance = chance;
        public readonly IUpgrade Upgrade = upgrade;
    }
}