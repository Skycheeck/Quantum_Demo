﻿using Quantum.Systems;

namespace Quantum {
  public static class SystemSetup {
    public static SystemBase[] CreateSystems(RuntimeConfig gameConfig, SimulationConfig simulationConfig) {
      return new SystemBase[] {
        // pre-defined core systems
        new Core.CullingSystem2D(), 
        new Core.CullingSystem3D(),
        
        new Core.PhysicsSystem2D(),
        new Core.PhysicsSystem3D(),

        Core.DebugCommand.CreateSystem(),

        new Core.NavigationSystem(),
        new Core.EntityPrototypeSystem(),
        new Core.PlayerConnectedSystem(),

        // user systems go here 
        new PlayerSpawnSystem(),
        new EnemySpawnSystem(),
        
        new MoveCharacterSystem(),
        new AttackSystem(),
        
        new TakeDamageSystem(),
        new RespawnEnemySystem(),
        new DeathSystem(),
        new PlayerProgressionSystem(),
      };
    }
  }
}
