namespace Homework
{
    public static class RandomExtensions
    {
        public static void SetRandomIndex(this System.Random random, int count, out int i)
        {
            i = random.Next(count);
        }
    }
}