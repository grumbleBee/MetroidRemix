using CSE3902.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSE3902.Util;

namespace CSE3902
{
    class CollisionHandler
    {
        private struct CollisionItem
        {
            public enum Direction { Up, Down, Left, Right }

            public string Collider;
            public string Collidee;
            public Direction ColDirection;
            public bool PixelPerfect;
        }

        readonly Dictionary<CollisionItem, Type> _collisionDict;
        ICollection<ICollidableObject> _gameObjects;
        private static CollisionHandler _instance;
        public static CollisionHandler Instance
        {
            get
            {
                var collisionHandler = _instance ?? (_instance = new CollisionHandler());
                return collisionHandler;
            }
        }

        private CollisionHandler()
        {
            _collisionDict = LoadCollisionDict(@"Content/CollisionDictionary.csv");
        }

        public void HandleCollisions(ICollection<ICollidableObject> gameObjects)
        {
            gameObjects = gameObjects.Where(e => e.DoCollisions).ToList();
            _gameObjects = gameObjects;
            foreach (ICollidableObject collider in gameObjects)
            {
                if (collider.NoOutwardCollisions) continue;
                List<KeyValuePair<float, ICommandCollision>> overlapCommandDict = new List<KeyValuePair<float, ICommandCollision>>();
                List<KeyValuePair<ICommandCollision, IGameObject[]>> objectsDict = new List<KeyValuePair<ICommandCollision, IGameObject[]>>();
                DetectCollisions(collider, overlapCommandDict, objectsDict);
                ResolveCollisions(overlapCommandDict, objectsDict);
            }
        }

        public bool BlockedAbove(Rectangle boundingBox, int distance)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X, boundingBox.Y - distance, boundingBox.Width, distance);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.BoundingBox.Intersects(blockedChecker) && gameObject.BoundingBox != boundingBox)
                    return true;
            }
            return false;
        }

        public bool BlockedBelow(Rectangle boundingBox, int distance)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X, boundingBox.Y, boundingBox.Width, boundingBox.Height + distance);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.BoundingBox.Intersects(blockedChecker) && gameObject.BoundingBox != boundingBox)
                    return true;
            }
            return false;
        }

        public bool BlockedLeft(Rectangle boundingBox, int distance)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X - distance, boundingBox.Y, distance + boundingBox.Width, boundingBox.Height - CollisionUtilConstants.BlockedOffset);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.BoundingBox != boundingBox && gameObject.BoundingBox.Intersects(blockedChecker))
                    return true;
            }
            return false;
        }

        public bool BlockedRight(Rectangle boundingBox, int distance)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X, boundingBox.Y, distance + boundingBox.Width, boundingBox.Height - CollisionUtilConstants.BlockedOffset);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.BoundingBox != boundingBox && gameObject.BoundingBox.Intersects(blockedChecker))
                {
                    return true;
                }
            }
            return false;
        }

        public bool BlockedAbove(Rectangle boundingBox, int distance, string namespaceContains)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X, boundingBox.Y - distance, boundingBox.Width, distance);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.ToString().Contains(namespaceContains) && gameObject.BoundingBox.Intersects(blockedChecker) && gameObject.BoundingBox != boundingBox)
                    return true;
            }
            return false;
        }

        public bool BlockedBelow(Rectangle boundingBox, int distance, string namespaceContains)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X, boundingBox.Y, boundingBox.Width, boundingBox.Height + distance);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.ToString().Contains(namespaceContains) && gameObject.BoundingBox.Intersects(blockedChecker) && gameObject.BoundingBox != boundingBox)
                    return true;
            }
            return false;
        }

        public bool BlockedLeft(Rectangle boundingBox, int distance, string namespaceContains)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X - distance, boundingBox.Y, distance + boundingBox.Width, boundingBox.Height - CollisionUtilConstants.BlockedOffset);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.ToString().Contains(namespaceContains) && gameObject.BoundingBox.Intersects(blockedChecker) && gameObject.BoundingBox != boundingBox)
                    return true;
            }
            return false;
        }

        public bool BlockedRight(Rectangle boundingBox, int distance, string namespaceContains)
        {
            Rectangle blockedChecker = new Rectangle(boundingBox.X, boundingBox.Y, distance + boundingBox.Width, boundingBox.Height - CollisionUtilConstants.BlockedOffset);
            foreach (ICollidableObject gameObject in _gameObjects)
            {
                if (gameObject.ToString().Contains(namespaceContains) && gameObject.BoundingBox != boundingBox && gameObject.BoundingBox.Intersects(blockedChecker))
                {
                    return true;
                }
            }
            return false;
        }

        private void DetectCollisions(IGameObject collider, List<KeyValuePair<float, ICommandCollision>> overlapCommandDict, List<KeyValuePair<ICommandCollision, IGameObject[]>> objectsDict)
        {
            foreach (ICollidableObject collidee in _gameObjects)
            {
                string colliderS = collider.ToString().Split('.').Last();
                string collideeS = collidee.ToString().Split('.').Last();

                if (collider != collidee && collider.BoundingBox.Intersects(collidee.BoundingBox))
                {
                    CollisionItem colItem = BuildCollisionItem(colliderS, collideeS, DirectionFromBoundingBox(collidee.BoundingBox, collider.BoundingBox), false);
                    colItem.ColDirection = DirectionFromBoundingBox(collider.BoundingBox, collidee.BoundingBox);

                    var collisionRect = Rectangle.Intersect(collidee.BoundingBox, collider.BoundingBox);
                    float collisionArea = collisionRect.Width * collisionRect.Height;

                    Type commandType;
                    if (_collisionDict.TryGetValue(colItem, out commandType))
                    {
                        ICommandCollision command = Activator.CreateInstance(commandType) as ICommandCollision;
                        overlapCommandDict.Add(new KeyValuePair<float, ICommandCollision>(collisionArea, command));
                        objectsDict.Add(new KeyValuePair<ICommandCollision, IGameObject[]>(command, new[] { collider, collidee }));
                    }
                    else
                    {
                        colItem.PixelPerfect = true;
                        if (_collisionDict.TryGetValue(colItem, out commandType))
                        {
                            if (PixelPerfectCollision(((IVisibleObject)collider).GetSprite(), ((IVisibleObject)collidee).GetSprite()))
                            {
                                ICommandCollision command = Activator.CreateInstance(commandType) as ICommandCollision;
                                overlapCommandDict.Add(new KeyValuePair<float, ICommandCollision>(collisionArea, command));
                                objectsDict.Add(new KeyValuePair<ICommandCollision, IGameObject[]>(command, new[] { collider, collidee }));
                            }
                        }
                    }
                }
            }
        }

        private static void ResolveCollisions(List<KeyValuePair<float,ICommandCollision>> overlapCommandDict, List<KeyValuePair<ICommandCollision,IGameObject[]>> objectsDict)
        {
            while (overlapCommandDict.Count > 0)
            {
                var pair = overlapCommandDict.FirstOrDefault(x => x.Key == overlapCommandDict.Max(e => e.Key));

                IGameObject[] collidedObjects = objectsDict.FirstOrDefault(x => x.Key == pair.Value).Value;
                if (collidedObjects[0].BoundingBox.Intersects(collidedObjects[1].BoundingBox))
                {
                    pair.Value.Execute(collidedObjects[0], collidedObjects[1]);
                }
                overlapCommandDict.Remove(pair);
            }
        }

        private static CollisionItem BuildCollisionItem(string colliderAssem, string collideeAssem, CollisionItem.Direction dir, bool pixelPerfect)
        {
            CollisionItem col = new CollisionItem
            {
                Collider = colliderAssem.Split('.').Last(),
                Collidee = collideeAssem.Split('.').Last(),
                ColDirection = dir,
                PixelPerfect = pixelPerfect
            };
            return col;
        }

        private static CollisionItem.Direction DirectionFromBoundingBox(Rectangle collider, Rectangle collidee)
        {
            Rectangle overlap = Rectangle.Intersect(collider,collidee);
            CollisionItem.Direction dir;
            if (overlap.Width > overlap.Height)
            {
                if (collider.Center.Y < collidee.Center.Y)
                    dir = CollisionItem.Direction.Up;
                else
                    dir = CollisionItem.Direction.Down;
            } else
            {
                if (collider.Center.X < collidee.Center.X)
                    dir = CollisionItem.Direction.Left;
                else
                    dir = CollisionItem.Direction.Right;
            }
            return dir;
        }

        private static bool PixelPerfectCollision(ISprite sprite1, ISprite sprite2)
        {
            Color[] sprite1Data = new Color[sprite1.Width * sprite1.Height];
            Color[] sprite2Data = new Color[sprite2.Width * sprite2.Height];
            sprite1.Texture.GetData(0, sprite1.SourceRect, sprite1Data, 0, sprite1.Width * sprite1.Height);
            sprite2.Texture.GetData(0, sprite2.SourceRect, sprite2Data, 0, sprite2.Width * sprite2.Height);
            if (!sprite1.FacingRight)
            {
                sprite1Data = FlipSpriteDataHorizontally(sprite1Data, sprite1.Width, sprite1.Height);
            }
            if (!sprite2.FacingRight)
            {
                sprite2Data = FlipSpriteDataHorizontally(sprite2Data, sprite2.Width, sprite2.Height);
            }

            int leftBound = Math.Max(sprite1.X, sprite2.X);
            int rightBound = Math.Min(sprite1.X + sprite1.Width, sprite2.X + sprite2.Width);
            int topBound = Math.Max(sprite1.Y, sprite2.Y);
            int bottomBound = Math.Min(sprite1.Y + sprite1.Height, sprite2.Y + sprite2.Height);

            for (int y = topBound; y < bottomBound; ++y)
            {
                for (int x = leftBound; x < rightBound; ++x)
                {
                    Color sprite1Pixel = sprite1Data[(x - sprite1.X) + (y - sprite1.Y) * sprite1.SourceRect.Width];
                    Color sprite2Pixel = sprite2Data[(x - sprite2.X) + (y - sprite2.Y) * sprite2.SourceRect.Width];
                    if (sprite1Pixel.A > CollisionUtilConstants.TransparencyTolerance && sprite2Pixel.A > CollisionUtilConstants.TransparencyTolerance)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static Dictionary<CollisionItem,Type> LoadCollisionDict(string fileLocation)
        {
            Dictionary<CollisionItem, Type> colDict = new Dictionary<CollisionItem, Type>();
            var fileStream = File.OpenRead(fileLocation);
            var fileReader = new StreamReader(fileStream);
            fileReader.ReadLine();
            while (!fileReader.EndOfStream)
            {
                string line = fileReader.ReadLine();
                string[] columns = line.Split(',');

                CollisionItem colItem = new CollisionItem
                {
                    Collider = columns[0],
                    Collidee = columns[1],
                    ColDirection = DirectionFromString(columns[2])
                };
                if (columns[4].ToLowerInvariant().Equals(CollisionUtilConstants.True))
                    colItem.PixelPerfect = true;
                Type c = Type.GetType(CollisionUtilConstants.CollisionNamespace + columns[3]);
                colDict.Add(colItem, c);
            }
            fileReader.Close();
            return colDict;
        }

        private static Color[] FlipSpriteDataHorizontally(Color[] data, int width, int height)
        {
            Color[] tempData = data.ToArray();
            Color[] flippedData = new Color[tempData.Length];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = width - x - 1 + y * width;
                    flippedData[index] = tempData[x + y * width];
                }
            }

            return flippedData;
        }

        private static CollisionItem.Direction DirectionFromString(string s)
        {
            CollisionItem.Direction dir;
            string sLow = s.ToLower();
            if (sLow.Equals(CollisionUtilConstants.Up))
                dir = CollisionItem.Direction.Up;
            else if (sLow.Equals(CollisionUtilConstants.Down))
                dir = CollisionItem.Direction.Down;
            else if (sLow.Equals(CollisionUtilConstants.Left))
                dir = CollisionItem.Direction.Left;
            else
                dir = CollisionItem.Direction.Right;
            return dir;
        }
    }
}
