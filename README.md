# Asteroids Variant

A modern take on the classic Asteroids arcade game, developed in C++ using SDL2. This variant introduces enhanced graphics, refined controls, and additional gameplay features to provide an engaging space shooter experience.

## 🚀 Features

- Smooth and responsive 2D spaceflight mechanics
- Multiple asteroid types with varying behaviors
- Player ship with thrust, rotation, and shooting capabilities
- Score tracking and high score persistence
- Visual and sound effects for immersive gameplay

## 🛠️ Installation

### Prerequisites

- C++ compiler supporting C++11 or later
- [SDL2](https://www.libsdl.org/download-2.0.php) development libraries

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/0Keyblade0/Asteroids-Variant.git
   cd Asteroids-Variant
   ```

2. Build the project:
   ```bash
   g++ -std=c++11 -o asteroids main.cpp -lSDL2 -lSDL2_image -lSDL2_mixer
   ```

3. Run the game:
   ```bash
   ./asteroids
   ```

## 🎮 Controls

- **Left Arrow / A**: Rotate ship left
- **Right Arrow / D**: Rotate ship right
- **Up Arrow / W**: Thrust forward
- **Spacebar**: Fire weapon
- **Esc**: Exit the game

## 📁 Project Structure

- `main.cpp` – Entry point of the application
- `src/` – Source files containing game logic
- `assets/` – Images, sounds, and other resources
- `README.md` – Project documentation

## 🌌 Gameplay Mechanics

Navigate your spaceship through an asteroid field, avoiding collisions and destroying asteroids to earn points. As you progress, the game increases in difficulty with more asteroids appearing. The objective is to achieve the highest score possible before losing all your lives.

## 🧪 Testing

To run tests (if available):
```bash
make test
```

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Feel free to contribute by submitting issues or pull requests!
