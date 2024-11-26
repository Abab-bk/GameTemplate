## MyGameTemplate

## Skip StarMenu or BootSplash

If u want to skip start menu on run game, add argument: --SkipStartMenu.

If u want to skip boot splash on run game, add argument: --SkipBootSplash.

## Theory

In my game template, you should keep "one scene", so, no "Scene Manager" or something like it.

The game world is a TREE!

## Application

The `Application` class is the entry point of the game.

It is located at `res://Scenes/Application.tscn` and contains a `StateMachine` child node that governs the application's flow. 

The `Application` process is ```Always```, it means that Application NEVER paused.

## World

The `World` class represents the game's environment.

It is recommended for users to add or remove entities from the world. You know, "one scene".

## Debugger

The `Debugger` class is a utility for debugging purposes.

It uses [ImGui Godot](https://github.com/pkdawson/imgui-godot) to render a ui, providing insights into the game's state and performance.

## AppSaver

`AppSaver` is responsible for saving user preferences, game data, and other critical information.

The save model is defined in the `res://Scripts/Models` folder .

The template uses [MemoryPack](https://github.com/Cysharp/MemoryPack).

## Ui

We have a ui lib named "[Ds_Ui](https://github.com/xlljc/Ds_Ui)", check the source repo.

## GTweens

[GTweensGodot](https://github.com/Guillemsc/GTweensGodot) lib can simplify animation programming.

## Luban

I encourage you to use a data-driven method and Excel to manage your game data.

[luban](https://github.com/focus-creative-games/luban) Luban is a perfact tool.

In ```Tools/Luban/Datas``` to edit your excel file.

Run ```Gen.bat``` or ```Gen.sh``` to export data.

Check static class ```Data``` after your read luban's doc.

## Unit Test

Has a test project, used [NUnit](https://github.com/nunit/nunit) .

## Translator

```Translator``` class is a wrapper for [Linguini](https://github.com/Ygg01/Linguini)
By default ```.ftl```  files are located in ```Assets\Locale```
