using System;

namespace AutoFac.API
{
    public static class RandomExentions
    {
       public static double RandomDouble(this Random random ,int max, int mix)
        {
            if (max <= mix)
                throw new ArgumentException($"非法参数{nameof(max)}--{nameof(mix)}");
            var x = random.NextDouble();
            return x * max + (1 - x) * mix;
        }
    }
}
