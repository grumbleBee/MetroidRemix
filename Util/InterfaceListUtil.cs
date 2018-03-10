using CSE3902.Interfaces;
using System.Collections.Generic;

namespace CSE3902.Util
{
    static class InterfaceListUtil
    {
        public const string DefaultFont = "DefaultFont";

        public static ICollection<IPhysicsObject> GameObjectListToPhysicsObjectList(ICollection<IGameObject> gameObjects)
        {
            ICollection<IPhysicsObject> physicsObjects = new List<IPhysicsObject>();
            foreach (IGameObject gameObject in gameObjects)
            {
                if (gameObject is IPhysicsObject)
                    physicsObjects.Add((IPhysicsObject)gameObject);
            }
            return physicsObjects;
        }

        public static ICollection<ICollidableObject> GameObjectListToCollidableObjectList(ICollection<IGameObject> gameObjects)
        {
            ICollection<ICollidableObject> collidableObjects = new List<ICollidableObject>();
            foreach (IGameObject gameObject in gameObjects)
            {
                if (gameObject is ICollidableObject)
                    collidableObjects.Add((ICollidableObject)gameObject);
            }
            return collidableObjects;
        }

        public static ICollection<IVisibleObject> GameObjectListToVisibleObjectList(ICollection<IGameObject> gameObjects)
        {
            ICollection<IVisibleObject> visibleObjects = new List<IVisibleObject>();
            foreach (IGameObject gameObject in gameObjects)
            {
                if (gameObject is IVisibleObject)
                    visibleObjects.Add((IVisibleObject)gameObject);
            }
            return visibleObjects;
        }
    }
}
