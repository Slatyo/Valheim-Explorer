<p align="center">
  <img src="Explorer/Package/icon.png" alt="Explorer" width="128">
</p>

<h1 align="center">Valheim-Explorer</h1>

<p align="center">
  <a href="https://github.com/Slatyo/Valheim-Explorer/releases"><img src="https://img.shields.io/github/v/release/Slatyo/Valheim-Explorer?style=flat-square" alt="GitHub release"></a>
  <a href="https://opensource.org/licenses/MIT"><img src="https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square" alt="License: MIT"></a>
</p>

<p align="center">
  A Valheim mod that adds an "Explorer" skill.<br>
  As you explore, your skill increases, allowing you to reveal more of the map with each step.
</p>

## Features

- New **Explorer** skill that levels up through exploration
- Map fog clearance scales with skill level (100% at level 0, up to 250% at level 100)
- XP gained from walking, running, swimming, jumping, and sailing
- Fully configurable XP rates and radius multipliers
- Server-synced configuration

## Installation

### Thunderstore (Recommended)
Install via [r2modman](https://valheim.thunderstore.io/package/ebkr/r2modman/) or [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager).

### Manual
1. Install [BepInEx](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
2. Install [Jotunn](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/)
3. Place `Explorer.dll` in `BepInEx/plugins/`

## Configuration

### BepInEx Config (`BepInEx/config/com.explorer.valheim.cfg`)

| Setting | Default | Description |
|---------|---------|-------------|
| BaseXpGainPerExplore | 0.1 | Base XP per exploration tick |
| RunningXpMultiplier | 1.5 | XP multiplier when running |
| SwimmingXpMultiplier | 2.0 | XP multiplier when swimming |
| JumpingXpGain | 0.05 | XP gained per jump |
| SailingXpMultiplier | 1.25 | XP multiplier when sailing |
| SkillIncreaseStep | 1.0 | Skill increase per XP event |

### JSON Config (`BepInEx/config/Explorer.json`)

Server-enforced settings:

| Setting | Default | Description |
|---------|---------|-------------|
| BaseExplorationRadiusMultiplier | 100 | Fog clearance % at skill level 0 |
| MaxExplorationRadiusMultiplier | 250 | Fog clearance % at skill level 100 |
| SkillName | "Explorer" | Skill display name |
| XpGainCooldown | 1.0 | Seconds between XP gains |
| MinDistanceForXp | 5.0 | Minimum distance for XP award |

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for development setup and guidelines.

## Acknowledgments

- Built using [JotunnModStub](https://github.com/Valheim-Modding/JotunnModStub) template
- Powered by [Jötunn](https://valheim-modding.github.io/Jotunn/) - the Valheim Library
- [BepInEx](https://github.com/BepInEx/BepInEx) - Unity game patcher and plugin framework

## License

[MIT](LICENSE) © Slatyo
