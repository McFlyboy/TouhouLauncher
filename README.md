# Touhou Launcher
![App icon](https://raw.githubusercontent.com/McFlyboy/TouhouLauncher/master/TouhouLauncher/Resources/Images/Icons/AppIcon.ico)

[![Building & Testing](https://github.com/McFlyboy/TouhouLauncher/actions/workflows/building-and-testing.yml/badge.svg)](https://github.com/McFlyboy/TouhouLauncher/actions/workflows/building-and-testing.yml)

## Introduction
Touhou Launcher is a desktop app for Windows that provides a quick and easy way to access and run [Touhou](https://en.wikipedia.org/wiki/Touhou_Project) games. It's written in C# with WPF and runs on .NET 6. The app serves as a modern and simplified alternative to an [old launcher](http://www.widdiful.co.uk/touhou.html) with the same name. 

### Key features
- Connect and launch your Touhou games from a game library
- Help you find downloads for official Touhou games
- Help find a download and connect a PC-98 emulator for playing the oldes games (Touhou 01 - 05). No emulator configuration required!
- An editor for adding fan made games with the same look and treatment as official games
- Organizing your list of games into categories
- Launch a random game

## Getting Touhou Launcher
### Download latest release
Touhou Launcher comes in 32-bit (x86) and 64-bit (x64). You can download the latest release [here](https://github.com/McFlyboy/TouhouLauncher/releases) and unzip it using your favorite zipping tool. :)

### Build from source
Alternatively you can build it yourself from source by downloading it and invoking one of the following commands from the solution directory:

``` shell
# Build for 32-bit
dotnet publish -c Release -p:PublishProfile=x86

# Build for 64-bit
dotnet publish -c Release -p:PublishProfile=x64
```

## Support
If you need help or have questions about the launcher, feel free to find me on my [Discord server](https://discord.com/invite/T7bp4Vy), or start a discussion in the [Discussions section](https://github.com/McFlyboy/TouhouLauncher/discussions) of this repo.

## A new UI is coming!
A new user interface is currently being designed for the beta release of the launcher. You can check out the design sketches [here](https://www.figma.com/file/4RDZ4GZz8maF8HgYTJsrBC/Touhou-Launcher). :)

## How to contribute
I haven't nailed down any contribution guidelines yet, but if you're eager to help out with the launcher then please do contact me through my [Discord server](https://discord.com/invite/T7bp4Vy), and we'll figure something out together. :D

## Running unit tests
You can run the unit tests from the solution directory by invoking the command:
``` shell
dotnet test
```

## License
The Touhou Launcher uses the [MIT license](https://github.com/McFlyboy/TouhouLauncher/blob/master/LICENSE).

## 3rd-party acknowledgements
Touhou Launcher uses 3rd-party open source .NET libraries. I am very grateful to the creators and contributors of these libraries for making their work open source.

**MVVM Light Toolkit**
<br/>Project: https://github.com/lbugnion/mvvmlight
<br/>Copyright (c) 2009 - 2018 Laurent Bugnion
<br/>Licence: (MIT) https://github.com/lbugnion/mvvmlight/blob/master/LICENSE

**YamlDotNet**
<br/>Project: https://github.com/aaubry/YamlDotNet
<br/>Copyright (c) 2008, 2009, 2010, 2011, 2012, 2013, 2014 Antoine Aubry and contributors
<br/>Licence: (MIT) https://github.com/aaubry/YamlDotNet/blob/master/LICENSE.txt

**INI File Parser**
<br/>Project: https://github.com/rickyah/ini-parser
<br/>Copyright (c) 2008 Ricardo Amores Hernández
<br/>Licence: (MIT) https://github.com/rickyah/ini-parser/blob/development/LICENSE
