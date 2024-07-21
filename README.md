# UnityCooldown

UnityCooldown is a flexible and efficient cooldown system for Unity projects. This library provides an easy-to-use solution for implementing cooldown mechanics in your games, from simple ability timers to complex multi-stage cooldowns.

Current version: v0.5.0

## Features

- Simple and intuitive API
- Flexible cooldown creation with customizable duration and finish handlers
- Progress tracking and event-based notifications
- Support for common ticker to optimize performance when using multiple cooldowns
- Built-in MonoBehaviour-based tickers for easy integration with Unity's update cycle
- Unscaled time support for cooldowns that should ignore time scale changes
- Cooldown handler for easy management of cooldown events and early termination
- Easy integration with existing Unity projects

## Installation

To install UnityCooldown in your Unity project, you can use the Unity Package Manager:

1. Open your project in Unity
2. Go to Window > Package Manager
3. Click the "+" button and choose "Add package from git URL"
4. Enter the following URL: `https://github.com/ega-ega/UnityCooldown.git#v0.5.0`

## Usage

### Basic Usage

Here's a simple example of how to create and use a cooldown:

```csharp
using Cooldown;
using UnityEngine;

public class CooldownExample : MonoBehaviour
{
    private CooldownFactory _factory;
    private Cooldown _abilityCooldown;
    private MonoTicker _ticker;

    void Start()
    {
        _factory = new CooldownFactory();
        _ticker = gameObject.AddComponent<MonoTicker>();
        
        // Create a 5-second cooldown
        _abilityCooldown = _factory.Create(5f, _ticker, OnCooldownFinished);
        
        // Start the cooldown
        _abilityCooldown.Launch();
    }

    void Update()
    {
        if (_abilityCooldown.IsFinish)
        {
            Debug.Log("Cooldown is finished!");
        }
        else
        {
            Debug.Log($"Cooldown progress: {_abilityCooldown.Progress:P2}");
        }
    }

    void OnCooldownFinished()
    {
        Debug.Log("Cooldown finished!");
    }
}
```

### Advanced Usage

For more complex scenarios, you can use the `AdvanceCooldownFactory` with a common ticker and `CooldownHandler`:

```csharp
public class AdvancedCooldownExample : MonoBehaviour
{
    private AdvanceCooldownFactory _factory;
    private CooldownHandler _cooldownHandler;

    void Start()
    {
        var commonTicker = gameObject.AddComponent<UnscaledMonoTicker>();
        _factory = new AdvanceCooldownFactory(commonTicker);

        var cooldown = _factory.CreateWithCommonTicker(5f);
        
        _cooldownHandler = new CooldownHandler(
            cooldown,
            progress => Debug.Log($"Cooldown progress: {progress:P2}"),
            () => Debug.Log("Cooldown finished!")
        );

        cooldown.Launch();
    }

    void OnDisable()
    {
        // Detach the handler when the component is disabled
        _cooldownHandler.Break();
    }
}
```

## Components

- `Cooldown`: The main class representing a cooldown.
- `CooldownFactory`: Factory for creating cooldown instances.
- `AdvanceCooldownFactory`: Factory for creating cooldowns with a common ticker.
- `ICooldownReadonly`: Interface for read-only access to cooldown properties.
- `ITicker`: Interface for implementing custom tick sources.
- `MonoTicker`: A MonoBehaviour-based ticker that uses `Time.deltaTime`.
- `UnscaledMonoTicker`: A MonoBehaviour-based ticker that uses `Time.unscaledTime`.
- `CooldownHandler`: A utility class for managing cooldown event subscriptions.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.