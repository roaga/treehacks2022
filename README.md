## MechanicEase 

This project was developed during TreeHacks 2022 by [Rohan](https://github.com/roaga), [Christian](https://github.com/kychris), [Andy](https://github.com/al1729), and [Simona](https://github.com/robotAstray).

## Inspiration

Though the gaming industry has grown rapidly in recent years, accessibility in games has not progressed as much as it could. One major reason for this is the heavy resource investment needed to create accessibility settings that serve every player without sacrificing the game's enjoyability. Smaller game studios have even more trouble with this issue.

_So what if with a simple plugin, game developers could automatically tailor their game mechanics to each individual player, making them accessible while following their creative intent?_

## What It Does

MechanicEase is a Unity plugin that:
1. allows game developers to lay out game variables to use throughout their code
2. learns from player behavior to automatically optimize these variables to meet the developer's intended player experience

For the sake of this demo, we focused on mechanics related to motor skill, such as jumping and running in a 2D platformer. These mechanics may normally give trouble to players with motor impairments.

## How It Works

The plugin itself is built for the popular Unity game engine in C#. In the Unity Editor, developers can set variable names, constraints, and targets to match their creative intent. In their code, they simply have to reference these variables as desired and send data back to the plugin to evaluate the player performance. The plugin stores and processes all data for each parameter and interfaces with a Flask server in Python that handles the math and logic that optimizes each game variable through curve fitting. The demo platformer game was also built in Unity.
![Screenshot from 2022-02-20 05-52-54](https://user-images.githubusercontent.com/62884362/154830464-95c51a77-1b0a-4b9f-b42b-a6f677c8265c.png)

## Next Steps

We would like to explore more advanced machine learning and optimization methods to give even better results and offer a better player experience. Additionally, we would like to see how this tool can be applied to other game genres, types of mechanics, and types of disabilities.

Additionally, this tool has the potential to be used for dynamic difficulty scaling and personalized gaming experiences for all players, not just for those in need of better accessibility.

Eventually, we would like to add more polish and convenience features to make this a proper plugin. For example, developers still have to write a minimal amount of code to read the updates from our plugin, but we could easily allow them to pass the variable references into our plugin so they don't have to write as much code. Once complete, we would love to release this tool so it can help as many developers and players as possible.

## Requirements

This project relies on the Unity game engine (specifically version 2020.3.29f1, though it should be easily adaptable to later versions as well) and various Python libraries and frameworks, including Flask.

## Usage

First run the Flask server. Then open the game in Unity and hit play to test it out!
