using System;
using Quantum;
using Quantum.Commands;
using UniRx;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class HUDPresenter : MonoBehaviour
{
    [SerializeField] private EnemiesDestroyedView _enemiesDestroyedView;
    [SerializeField] private StatsView _statsView;
    [SerializeField] private Button _upgradeButton;
    
    private UpgradePlayerCommand _upgradePlayerCommand;
    
    private IObservable<Unit> _upgradeButtonClickedObservable;
    private Subject<PlayerModel> _playerModelUpdatedObservable;
    
    private IDisposable _upgradeButtonClickedSubscription;
    private IDisposable _playerModelUpdatedSubscription;

    private void Awake()
    {
        _upgradePlayerCommand = new UpgradePlayerCommand();
        _playerModelUpdatedObservable = new Subject<PlayerModel>();
        _upgradeButtonClickedObservable = _upgradeButton.onClick.AsObservable();
        
        QuantumEvent.Subscribe(this,
            (EventPlayerModelUpdatedEvent e) => { _playerModelUpdatedObservable.OnNext(e.Model); });
    }

    private void OnDestroy() => QuantumEvent.UnsubscribeListener(this);

    private void OnEnable()
    {
        _upgradeButtonClickedSubscription = _upgradeButtonClickedObservable.Subscribe(OnUpgradeButtonClicked);
        _playerModelUpdatedSubscription = _playerModelUpdatedObservable.Subscribe(OnPlayerModelUpdated);
    }

    private void OnDisable()
    {
        _upgradeButtonClickedSubscription.Dispose();
        _playerModelUpdatedSubscription.Dispose();
    }

    private void OnUpgradeButtonClicked(Unit obj)
    {
        QuantumRunner.Default.Game.SendCommand(_upgradePlayerCommand);
    }

    private void OnPlayerModelUpdated(PlayerModel model)
    {
        _enemiesDestroyedView.UpdateView(model.EnemiesKilled);
        _statsView.UpdateView(model.PlayerCharacterStats);
    }
}