using CSE3902.Enemies;
using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Players;
using CSE3902.Triggers;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using CSE3902.Power_Ups;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902
{
    public class LevelLoader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void LoadLevel(string fileLocation, Collection<IGameObject> objectList)
        {
            var fileStream = File.OpenRead(fileLocation);
            var fileReader = new StreamReader(fileStream);
            int xLocation = 0;
            int yLocation = 0;
            while (!fileReader.EndOfStream)
            {
                string line = fileReader.ReadLine();
                string[] columns = line.Split(',');
                Debug.WriteLine(columns[0]);
                foreach (string column in columns)
                {
                    if (!column.Equals("*")) { 
                        Vector2 position = new Vector2(xLocation, yLocation);
                        string objectType = column;
                        objectList.Add(CreateObject(objectType, position));
                    }
                    xLocation += 16;
                }
                xLocation = 0;
                yLocation += 16;
            }
            fileReader.Close();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private static IGameObject CreateObject(string objectType, Vector2 position)
        {
            switch (objectType)
            {
                case "Samus":
                    return new Samus(position, 0);
                case "Ridley":
                    return new Ridley(position);
                case "Crawler":
                    return new Crawler(position);
                case "Skree":
                    return new Skree(position);
                case "Ripper":
                    return new Ripper(position);
                case "Bomb":
                    return new Bomb(position);
                case "EnergyRefill":
                    return new EnergyRefill(position);
                case "EnergyTank":
                    return new EnergyTank(position);
                case "MaruMari":
                    return new MaruMari(position);
                case "MissilePack":
                    return new MissilePack(position);
                case "MissileRefill":
                    return new MissileRefill(position);
                case "ChozoStatue_Right":
                    return new TileChozoStatue(position, true, false);
                case "ChozoStatue_Left":
                    return new TileChozoStatue(position, false, false);
                case "TileDestroyable":
                    return new TileDestroyable(position);
                case "Door_Right":
                    return new TileDoor(position, true, false);
                case "Door_Left":
                    return new TileDoor(position, false, false);
                case "Camera_Lock_Right":
                    return new CameraLockRightTrigger(176, position);
                case "Camera_Lock_Left":
                    return new CameraLockLeftTrigger(176, position);
                case "Camera_Unlock_Right":
                    return new CameraUnlockRightTrigger(176, position);
                case "Camera_Unlock_Left":
                    return new CameraUnlockLeftTrigger(176, position);
                case "DoorTransition_Right":
                    return new DoorTransitionTrigger(32, position, true);
                case "DoorTransition_Left":
                    return new DoorTransitionTrigger(32, position, false);
                case "DoorTransitionDoneTrigger":
                    return new DoorTransitionDoneTrigger(32, position);
                case "Camera_Lock_Up":
                    return new CameraLockUpTrigger(384, position);
                case "Camera_Lock_Down":
                    return new CameraLockDownTrigger(384, position);
                case "Camera_Unlock_Up":
                    return new CameraUnlockUpTrigger(384, position);
                case "Camera_Unlock_Down":
                    return new CameraUnlockDownTrigger(384, position);
                default:
                    if (objectType.StartsWith("TileEnvironment"))
                    {
                        return new TileEnvironment(position, int.Parse(objectType.Substring(15)));
                    } else if (objectType.Contains("CameraFocusTrigger"))
                    {
                        string[] splitObjectType = objectType.Split('_');
                        return new CameraFocusTrigger(int.Parse(splitObjectType[1]), int.Parse(splitObjectType[2]), position, splitObjectType[3], splitObjectType[4].ToLowerInvariant().Equals("right"));
                    } else
                    {
                        return null;
                    }
            }
        }
    }
}
