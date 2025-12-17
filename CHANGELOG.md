# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0](https://github.com/Slatyo/Valheim-Explorer/compare/v1.0.0...v1.1.0) (2025-12-17)


### Features

* **i18n:** add German translations for Explorer skill ([16e7a70](https://github.com/Slatyo/Valheim-Explorer/commit/16e7a70979808105e38141d19aefaed035ede642))
* initial release of Explorer mod ([baa0871](https://github.com/Slatyo/Valheim-Explorer/commit/baa087191686ffed43fa5513365cf04516cdf9ee))


### Code Refactoring

* unify plugin GUID to com.slatyo.explorer ([5f8ed30](https://github.com/Slatyo/Valheim-Explorer/commit/5f8ed30e60294f30f2d23d8710da37891d106e8f))

## [1.0.0] - 2025-11-30

### Added
- New "Explorer" skill that levels up through exploration
- Map fog clearance scales with skill level (100% at level 0, 250% at level 100)
- XP gained from walking, running, swimming, jumping, and sailing
- Configurable XP multipliers for each movement type
- Server-synced JSON configuration for radius multipliers
- BepInEx configuration for XP gain settings
