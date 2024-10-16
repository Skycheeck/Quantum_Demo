using Quantum;
using Quantum.Commands;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class HUDPresenter : MonoBehaviour
{
    [SerializeField] private EnemiesDestroyedView _enemiesDestroyedView;
    [SerializeField] private StatsView _statsView;
    [SerializeField] private Button _upgradeButton;
    
    private UpgradePlayerCommand _upgradePlayerCommand;

    private void Start()
    {
        QuantumEvent.Subscribe(this, (EventPlayerModelUpdatedEvent e) => OnPlayerModelUpdated(e.Model));
        
        _upgradePlayerCommand = new UpgradePlayerCommand();
        _upgradeButton.onClick.AddListener(() => QuantumRunner.Default.Game.SendCommand(_upgradePlayerCommand));
    }

    private void OnPlayerModelUpdated(PlayerModel model)
    {
        _enemiesDestroyedView.UpdateView(model.EnemiesKilled);
        _statsView.UpdateView(model.PlayerCharacterStats);
    }
}