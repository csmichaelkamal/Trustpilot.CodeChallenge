using System;

namespace TrustPilot.CodeChallenge.API.Constants
{
    /// <summary>
    /// Maze Dimentions, it should be between 15 and 25 for both Height and Width
    /// </summary>
    public static class MazeDimensions
    {
        #region Private Members

        private static int _height = 15;
        private static int _width = 25;

        #endregion

        #region Ctor

        static MazeDimensions()
        {
            var heightFromSettings = Environment.GetEnvironmentVariable("Maze:Dimensions:Height");
            var widthFromSettings = Environment.GetEnvironmentVariable("Maze:Dimensions:Width");

            if (!string.IsNullOrEmpty(heightFromSettings) && !int.TryParse(heightFromSettings, out _height))
            {
            }

            if (!string.IsNullOrEmpty(widthFromSettings) && !int.TryParse(widthFromSettings, out _width))
            {
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Maze Height
        /// </summary>
        public static int Height { get => _height; private set { } }
        
        /// <summary>
        /// Maze Width
        /// </summary>
        public static int Width { get => _width; private set { } }

        #endregion
    }
}
