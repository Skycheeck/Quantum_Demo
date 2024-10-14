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

[CreateAssetMenu(menuName = "Quantum/CharacterSpec", order = Quantum.EditorDefines.AssetMenuPriorityStart + 52)]
public partial class CharacterSpecAsset : AssetBase {
  public Quantum.CharacterSpec Settings;

  public override Quantum.AssetObject AssetObject => Settings;
  public new Quantum.CharacterSpec AssetObjectT => (Quantum.CharacterSpec)AssetObject;
  
  public override void Reset() {
    if (Settings == null) {
      Settings = new Quantum.CharacterSpec();
    }
    base.Reset();
  }
}

public static partial class CharacterSpecAssetExts {
  public static CharacterSpecAsset GetUnityAsset(this CharacterSpec data) {
    return data == null ? null : UnityDB.FindAsset<CharacterSpecAsset>(data);
  }
}
