// <auto-generated>
// This code was auto-generated by a tool, every time
// the tool executes this code will be reset.
//
// If you need to extend the classes generated to add
// fields or methods to them, please create partial  
// declarations in another file.
// </auto-generated>

using Quantum;
using UnityEngine;

[CreateAssetMenu(menuName = "Quantum/PlayerCharacterProgression", order = Quantum.EditorDefines.AssetMenuPriorityStart + 390)]
public partial class PlayerCharacterProgressionAsset : AssetBase {
  public Quantum.PlayerCharacterProgression Settings;

  public override Quantum.AssetObject AssetObject => Settings;
  public new Quantum.PlayerCharacterProgression AssetObjectT => (Quantum.PlayerCharacterProgression)AssetObject;
  
  public override void Reset() {
    if (Settings == null) {
      Settings = new Quantum.PlayerCharacterProgression();
    }
    base.Reset();
  }
}

public static partial class PlayerCharacterProgressionAssetExts {
  public static PlayerCharacterProgressionAsset GetUnityAsset(this PlayerCharacterProgression data) {
    return data == null ? null : UnityDB.FindAsset<PlayerCharacterProgressionAsset>(data);
  }
}