using UnityEngine;

namespace Homework.Dogs
{
    public static class ColorGenerator
    {
        private static float _defaultComponent = 0.1f;

        public static float DefaultComponent
        {
            get
            {
                return _defaultComponent;
            }

            set
            {
                if(value >= 0 && value <= 1)
                {
                    _defaultComponent = value;
                }
            }
        }

        public static float GetRandomComponent()
        {
            var random = new System.Random();
            return (float)random.NextDouble() / 2 + 0.5f;
        }

        public static Color GenerateRandomRedColor()
        {
            return new Color(GetRandomComponent(), DefaultComponent, DefaultComponent);
        }

        public static Color GenerateRandomGreenColor()
        {
            return new Color(DefaultComponent, GetRandomComponent(), DefaultComponent);
        }

        public static Color GenerateRandomBlueColor()
        {
            return new Color(DefaultComponent, DefaultComponent, GetRandomComponent());
        }
    }
}