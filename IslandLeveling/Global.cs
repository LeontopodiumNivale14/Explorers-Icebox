/*
 * This file is used to import all the necessary namespaces and classes that are used in the plugin.
 * This file is then imported in ALL the files in the plugin.
 *
 * you never have to worry about importing the same namespaces in every file. Especially usefull für utility classes.
 */

global using Dalamud.Interface.Windowing;
global using Dalamud.Interface;
global using Dalamud.Plugin;
global using ECommons.DalamudServices;
global using ECommons.ImGuiMethods;
global using ECommons.Schedulers;
global using ECommons;
global using ImGuiNET;
global using System.Linq;
global using System.Numerics;
global using System;
global using static ECommons.GenericHelpers;

global using static IslandLeveling.ISLeveling;
global using static IslandLeveling.Util.Utils;

// tables being used acrossed the plugin
global using static IslandLeveling.Util.IslandData.IslandAmounts;
global using static IslandLeveling.Util.IslandData.IslandIDs;
global using static IslandLeveling.Config;
global using static IslandLeveling.Util.IslandData.IslandMics;

