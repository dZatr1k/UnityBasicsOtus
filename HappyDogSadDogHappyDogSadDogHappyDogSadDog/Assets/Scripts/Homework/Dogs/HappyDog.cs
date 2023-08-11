using UnityEngine;

namespace Homework.Dogs
{
    public sealed class HappyDog : Dog
    {
        public override void ChangeColor()
        {
            GetSpriteRenderer().color = ColorGenerator.GenerateRandomRedColor();
        }

        protected override void Bark()
        {
            Debug.Log("цюб:) цюб:) цюб:) цюб:) цюб:) цюб:) цюб:) цюб:) цюб:)");
        }
    }
}