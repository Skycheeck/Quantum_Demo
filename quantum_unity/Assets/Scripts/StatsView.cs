using Quantum;
using UnityEngine;
using UnityEngine.UI;

public class StatsView : MonoBehaviour
{
    [SerializeField] private Text _speedTextBox, _DPSTextBox, _AttackRadiusTextBox;

    public void UpdateView(PlayerCharacterStats playerCharacterStats)
    {
        _speedTextBox.text = $"Speed: {playerCharacterStats.Speed}";
        _DPSTextBox.text = $"DPS: {playerCharacterStats.DPS}";
        _AttackRadiusTextBox.text = $"Attack Radius: {playerCharacterStats.AttackRadius}";
    }
}