# Bannersample

An example mod for [Mount and Blade 2: Bannerlord](https://store.steampowered.com/app/261550/Mount__Blade_II_Bannerlord/) using [Harmony](https://github.com/pardeike/Harmony).

I created this to quickly debug or fix some bugs I came across on release but have since been fixed, and also to explore how modding the game differs from for example [Rimworld](https://store.steampowered.com/app/294100/RimWorld/).

# Usage

Open project in your C# IDE of choice, in my case [Rider](https://www.jetbrains.com/rider/).

Download Harmony and add a dotnet 4.8 compatible .dll to project references. In this example `<HARMONYPATH>\Release\net48\0Harmony.dll`

Use [dotpeek](https://www.jetbrains.com/decompiler/) or [ILSpy](https://github.com/icsharpcode/ILSpy) to look at the games .dlls and find interesting parts you want to modify.

From your game folder add the desired .dlls to project references. In this example

`<YOURGAMEPATH>\bin\Win64_Shipping_Client\TaleWorlds.Core.dll`
`<YOURGAMEPATH>\bin\Win64_Shipping_Client\TaleWorlds.MountAndBlade.dll`
`<YOURGAMEPATH>\bin\Win64_Shipping_Client\TaleWorlds.CampaignSystem.dll`
`<YOURGAMEPATH>\bin\Win64_Shipping_Client\TaleWorlds.Library.dll`

Use Harmony to patch and modify methods or add new game components. See [Harmony Documentation](https://harmony.pardeike.net/articles/intro.html) for more info on patching.

If you need a reference for modules in general, adding content/menus etc. use dotPeek/ILSpy to look at one of the existing modules, for example:

`<YOURGAMEPATH>\Modules\StoryMode\bin\Win64_Shipping_Client\StoryMode.dll`
`<YOURGAMEPATH>\Modules\StoryMode\SubModule.xml`
`<YOURGAMEPATH>\Modules\StoryMode\ModuleData\story_mode_settlements.xml`

# Building

Make sure your project is set to compile for dotnet 4.8 and x64 Release.

Compile as Class Library.

# Installing
Either modify the `config.sh` script to match your game path and run `install.sh` using [MinGW](http://www.mingw.org/) (comes with [git](https://git-scm.com/)).

Alternatively, copy the resulting `Bannersample.dll` along with any other .xml you reference to your new module path. For this example the structure is
`<YOURGAMEPATH>\Modules\Bannersample\bin\Win64_Shipping_Client\Bannersample.dll`
`<YOURGAMEPATH>\Modules\Bannersample\SubModule.xml`

# Debugging

Use `Debug.Print()` to see if your module loads correctly and patched methods are executed. Just open the log file while or after running, by default it's located at

`C:\ProgramData\Mount and Blade II Bannerlord\logs\rgl_log_<NUMBER>.log`

If your game crashes because of an exception, confirm the crash reporter prompt just before sending the files listed. You can find them in the same location as the log at

`C:\ProgramData\Mount and Blade II Bannerlord\crashes\<DATE>\`

There you can find logs of the crashed session as well as a `dump.dmp` which you can open for example with [WinDbg Preview](https://www.microsoft.com/en-us/p/windbg-preview/9pgjgd53tn86?activetab=pivot:overviewtab) and click or run `!analyze -v` to see the actual call stack of the exception. You can then look up the functions in dotPeek or ILSpy and see why it crashed.

A useful function of Harmony is to surround existing methods with a Finalizer, which automatically adds a `try/catch`. You can use this to print more information before a exception or silently catch the entire thing.

# Uninstalling

Remove your module folder manually or run `uninstall.sh`.

Happy modding!