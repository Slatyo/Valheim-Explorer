# Explorer

A Valheim mod that adds a new "Explorer" skill that increases your map exploration radius as you level it up.

## Features

- **New Skill: Explorer** - A custom skill that rewards exploration
- **Scaling Fog Clearance** - At level 0, you clear fog at 100% normal rate. At level 100, you clear 250% (2.5x) more!
- **Multiple XP Sources** - Gain skill XP from:
  - Walking/Running
  - Swimming
  - Jumping
  - Sailing
- **Server-Synced Configuration** - Server dictates settings for all connected players
- **Fully Configurable** - Adjust XP rates, radius multipliers, and more

## Configuration

### BepInEx Config (com.explorer.valheim.cfg)
Located in `BepInEx/config/`:
- `BaseXpGainPerExplore` - Base XP gained per exploration tick (default: 0.1)
- `RunningXpMultiplier` - XP multiplier when running (default: 1.5x)
- `SwimmingXpMultiplier` - XP multiplier when swimming (default: 2x)
- `JumpingXpGain` - XP gained per jump (default: 0.05)
- `SailingXpMultiplier` - XP multiplier when sailing (default: 1.25x)
- `SkillIncreaseStep` - How much the skill increases per XP gain (default: 1)
- `DebugMode` - Enable verbose logging (default: false)

### JSON Config (Explorer.json)
Located in `BepInEx/config/`. These settings are server-enforced:
- `BaseExplorationRadiusMultiplier` - Fog clearance at level 0 (default: 100%)
- `MaxExplorationRadiusMultiplier` - Fog clearance at level 100 (default: 250%)
- `SkillName` - The skill name shown in-game (default: "Explorer")
- `SkillDescription` - The skill description
- `XpGainCooldown` - Seconds between XP gains (default: 1)
- `MinDistanceForXp` - Minimum distance traveled for XP (default: 5)

## Installation

### Manual
1. Install BepInEx 5.4.x
2. Install Jotunn 2.26.1+
3. Copy `Explorer.dll` to `BepInEx/plugins/`

### Thunderstore (r2modman)
1. Install via r2modman or Thunderstore Mod Manager

## Changelog

### 1.0.0
- Initial release
- Added Explorer skill
- Server-synced configuration
- XP from walking, running, swimming, jumping, sailing

## Requirements
- BepInEx 5.4.2333+
- Jotunn 2.26.1+
