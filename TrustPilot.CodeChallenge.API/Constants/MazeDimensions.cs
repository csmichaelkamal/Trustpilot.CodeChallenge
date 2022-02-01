using System;

namespace TrustPilot.CodeChallenge.API.Constants
{
    public class MazeDimensions
    {
        #region Private Members

        private int _height = 15;
        private int _width = 25;

        #endregion

        #region Ctor

        public MazeDimensions()
        {
            var heightFromSettings = Environment.GetEnvironmentVariable("Maze:Dimensions:Height");
            var widthFromSettings = Environment.GetEnvironmentVariable("Maze:Dimensions:Width");

            if (!string.IsNullOrEmpty(heightFromSettings) && !int.TryParse(heightFromSettings, out _height))
            {
                _height = 15;
            }

            if (!string.IsNullOrEmpty(widthFromSettings) && !int.TryParse(widthFromSettings, out _width))
            {
                _width = 25;
            }
        }

        #endregion

        #region Properties

        public int Height { get => _height; private set { } }
        public int Width { get => _width; private set { } }

        #endregion
    }
}
