﻿using CSE3902.Cameras;
using CSE3902.Effects;
using CSE3902.Environment;
using CSE3902.Interfaces;
using CSE3902.Physics;
using CSE3902.Players;
using CSE3902.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using CSE3902.Sprites.Sprite_Factories;

namespace CSE3902.Levels
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
    internal class Brinstar : ILevel
    {
        private Collection<IGameObject> GameObjects { get; }
        public IPlayer Player1Character { get; set; }
        public IPlayer[] Players { get; set; }
        public IPhysics Physics { get; set; }
        public WorldUtil.WorldState CurrentWorldState { get; set; }
        private Camera _camera;
        private SpriteFont _defaultFont;
        private int _timeSinceLastFrame;
        private const int MillisecondsPerFrame = 60;
        private StandardGameObject _energyMarker;
        private StandardGameObject _missileMarker;


        public Brinstar()
        {
            foreach (IController controller in Game1.Controllers)
                controller.Id = 0;
            GameObjects = new Collection<IGameObject>();
            Physics = new StandardPhysics();
            SoundManager.Instance.PlaySong("brinstarLevel");
            CurrentWorldState = WorldUtil.WorldState.Paused;
        }

        public void LoadContent(LevelLoader levelLoader)
        {
            levelLoader.LoadLevel(@"Content/Brinstar.csv", GameObjects);
            _camera = new HorizontalScrollingCamera(Game1.graphics.GraphicsDevice.Viewport) {Zoom = 2f};
            Player1Character =
                new Samus(new Vector2(640, 159), 0) {ColorScheme = PlayerSpriteFactory.Instance.DefaultSchemes[0]};
            PlayerSpriteFactory.Instance.SetPlayerToCustomTextures(0,PlayerSpriteFactory.Instance.DefaultSchemes[0]);
            Players = new[] {Player1Character};            

            _camera.Focus = Player1Character;
            _camera.CameraPosition = new Vector2(_camera.Focus.Position.X - _camera.Viewport.Width / _camera.Zoom / 2, _camera.CameraPosition.Y);
            GameObjects.Add(Player1Character);
            _defaultFont = FontManager.Instance.CreateNewDefaultFont();
        }

        public void SetWorldState(WorldUtil.WorldState worldState)
        {
            CurrentWorldState = worldState;
        }

        public void Destroy(IGameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public IGameObject Spawn(IGameObject gameObject, Vector2 pos)
        {
            gameObject.Position = pos;
            GameObjects.Add(gameObject);
            return gameObject;
        }

        public void Update(GameTime gameTime)
        {
            ICollection<IGameObject> renderedObjects = GameObjects.Where(e => _camera.IsRendered(e, 15)).ToList();
            ICollection<IPhysicsObject> toDoPhysics = InterfaceListUtil.GameObjectListToPhysicsObjectList(renderedObjects).Where(e => e.PhysicsDuringLesserState >= CurrentWorldState).ToList();
            ICollection<ICollidableObject> toDoCollisions = InterfaceListUtil.GameObjectListToCollidableObjectList(renderedObjects).Where(e => e.CollideDuringLesserState >= CurrentWorldState).ToList();
            ICollection<IGameObject> toBeUpdated = GameObjects.Where(e => _camera.IsRendered(e) && e.UpdateDuringLesserState >= CurrentWorldState).ToList();
            Physics.DoPhysics(toDoPhysics, gameTime);
            CollisionHandler.Instance.HandleCollisions(toDoCollisions);
            foreach (IGameObject gameObject in toBeUpdated) gameObject.Update();
            _camera.Update();

            if (SoundManager.Instance.GetSoundEffect("obtainItem").State.ToString().Equals("Stopped") &&
                SoundManager.Instance.GetSoundEffect("brinstarLevel").State.ToString().Equals("Paused")
                )
            {
                SoundManager.Instance.ResumeSong("brinstarLevel");
                SetWorldState(WorldUtil.WorldState.Playing);
            }

            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeSinceLastFrame > MillisecondsPerFrame)
            {
                _timeSinceLastFrame = 0;
                UpdateFrames();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            ICollection<IGameObject> renderedObjects = GameObjects.Where(e => _camera.IsRendered(e)).ToList();
            spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp, transformMatrix: _camera.GetViewMatrix());
            foreach (IVisibleObject gameObject in InterfaceListUtil.GameObjectListToVisibleObjectList(renderedObjects))
                gameObject.Draw(spriteBatch);
            if (Player1Character.Health > 0)
            {
                _energyMarker = new EnergyMarker(new Vector2(_camera.CameraPosition.X + 8, _camera.CameraPosition.Y + 8));
                _energyMarker.Draw(spriteBatch);
                spriteBatch.DrawString(_defaultFont, "" + Player1Character.Health + "", new Vector2(_camera.CameraPosition.X + 58, _camera.CameraPosition.Y + 3), Color.White);
                if (Player1Character.HasMissileUpgrade && Player1Character.Missiles > 0)
                {
                    _missileMarker = new MissileMarker(new Vector2(_camera.CameraPosition.X + 8, _camera.CameraPosition.Y + 24));
                    _missileMarker.Draw(spriteBatch);
                    spriteBatch.DrawString(_defaultFont, "" + Player1Character.Missiles + "", new Vector2(_camera.CameraPosition.X + 58, _camera.CameraPosition.Y + 19), Color.White);
                }
            }
            spriteBatch.End();
        }

        public void UpdateFrames()
        {
            foreach (var gObject in GameObjects.Where(e => e is IVisibleObject))
            {
                var gameObject = (IVisibleObject) gObject;
                if (gameObject.GetSprite() != null)
                {
                    gameObject.GetSprite().NextFrame();
                }
            }
        }

        public Camera GetCamera()
        {
            return _camera;
        }

        public void SetCamera(Camera newCamera)
        {
            _camera = newCamera;
        }

        public MenuUtil.CurrentLevel GetSelectedLevel()
        {
            throw new NotImplementedException();
        }
    }
}
