# Unity Game Enemy AI Framework  
### FSM • Behavior Trees • Perception System  

Created and maintained by **Unity King**  
https://unityking.com

---

## Quick Start (Read This First)

This repository contains **only the `Assets/` folder** with a complete, modular **Enemy AI framework**.

### How to Use This Repository

1. **Create or open a Unity project**  
   - Unity 2021 LTS or newer recommended

2. **Copy the `Assets` folder** from this repository  
   Paste it directly into your Unity project root  
   (merge with existing Assets if needed)

3. **Open Unity**
   - Unity will automatically import all scripts

4. **Create an Enemy GameObject**
   - Add required components (explained below)

That’s it. The framework is now ready to use.

---

## 📁 Project Structure

Assets/
├── Scripts/
│    ├── EnemyAI/
│    │    ├── Core/
│    │    │    ├── EnemyAIController.cs
│    │    │    ├── EnemyBlackboard.cs
│    │    ├── FSM/
│    │    │    ├── IState.cs
│    │    │    ├── StateMachine.cs
│    │    │    ├── IdleState.cs
│    │    │    ├── PatrolState.cs
│    │    │    ├── ChaseState.cs
│    │    │    └── AttackState.cs
│    │    ├── BehaviorTree/
│    │    │    ├── BTNode.cs
│    │    │    ├── Selector.cs
│    │    │    ├── Sequence.cs
│    │    │    └── ActionNode.cs
│    │    ├── Perception/
│    │    │    ├── EnemyPerception.cs
│    │    │    └── VisionSensor.cs
│    │    └── Movement/
│    │         └── EnemyMovement.cs


Each folder represents a **single responsibility system**, making the framework easy to understand, debug, and extend.

---

## Architecture Overview

This framework combines **three AI techniques**:

### Finite State Machine (FSM)
Used for **high-level behavior**:
- Idle
- Patrol
- Chase
- Attack

FSM decides *what* the enemy should do.

---

### Behavior Trees (BT)
Used for **decision-making logic inside states**.

BT decides *how* the enemy should act:
- Selector (OR logic)
- Sequence (AND logic)
- Action Nodes (actual gameplay logic)

---

### Perception System
Used to **sense the environment**:
- Vision-based detection
- Player awareness
- Target tracking

---

## Core Components Explained

### EnemyAIController
The **brain** of the enemy.

Responsibilities:
- Initializes the FSM
- Updates current state
- Shares data via Blackboard
- Connects Perception and Movement

```csharp
EnemyAIController
````

Attach this to **every enemy GameObject**.

---

### EnemyBlackboard

Shared memory between:

* FSM
* Behavior Trees
* Sensors

Stores:

* Current target
* Distance to target
* Visibility
* Attack range status

```csharp
blackboard.target
blackboard.isInAttackRange
```

---

## Finite State Machine (FSM)

### Available States

* `IdleState`
* `PatrolState`
* `ChaseState`
* `AttackState`

Each state:

* Implements `IState`
* Has `Enter()`, `Tick()`, `Exit()`

### Example: Idle → Chase Transition

```csharp
public void Tick()
{
    if (ai.blackboard.target != null)
        ai.ChangeState(new ChaseState(ai));
}
```

FSM controls **macro behavior flow**.

---

## Behavior Trees

Behavior Trees are used for **fine-grained logic**.

### Core Nodes

* `Selector` → Try children until one succeeds
* `Sequence` → Execute all children in order
* `ActionNode` → Actual gameplay logic

---

### Example: ActionNode

```csharp
ActionNode chaseTarget = new ActionNode(() =>
{
    if (blackboard.target == null)
        return BTNode.State.Failure;

    movement.MoveTo(blackboard.target.position);
    return BTNode.State.Running;
});
```

This makes Behavior Trees **code-driven and flexible**.

---

## Perception System

### VisionSensor

Detects targets using physics overlap.

Features:

* Distance-based detection
* Layer filtering
* Real-time updates

```csharp
Collider[] hits = Physics.OverlapSphere(
    transform.position,
    viewDistance,
    targetLayer
);
```

### EnemyPerception

Acts as a bridge between sensors and AI logic.

```csharp
CurrentTarget = vision.DetectedTarget;
```

---

## Enemy Movement

### EnemyMovement

Handles physical movement.

Currently supports:

* Direct movement toward target

```csharp
movement.MoveTo(target.position);
```

### Can be extended to:

* NavMeshAgent
* Root motion
* Flying / swimming AI

---

## Example Enemy Setup (Step-by-Step)

1. Create an empty GameObject
   `Enemy`

2. Add components:

   * `EnemyAIController`
   * `EnemyPerception`
   * `VisionSensor`
   * `EnemyMovement`
   * (Optional) Collider / Rigidbody

3. Set VisionSensor:

   * View Distance
   * Target Layer (Player)

4. Press ▶ Play

Enemy will:

* Stay idle
* Detect player
* Chase
* Attack (logic ready)

---

## Extending the Framework

You can easily add:

### FSM

* FleeState
* SearchState
* AlertState

### Behavior Tree

* Cooldown decorators
* Inverter nodes
* Repeater nodes

### Perception

* Hearing sensor
* Damage sensor
* Line-of-sight checks

### Movement

* NavMesh pathfinding
* Strafing
* Cover system

---

## Use Cases

* FPS / TPS enemies
* Stealth games
* Survival AI
* Boss behavior systems
* R&D AI experiments

---

## License

MIT License
Free for personal and commercial use.

---

## Author

**Unity King**
[https://unityking.com](https://unityking.com)
Game Development • AI Systems • Tools

---

⭐ If this framework helps you, consider starring the repository.

```
Ab isko **push kar**, koi complain nahi aayegi 😎💪
```
