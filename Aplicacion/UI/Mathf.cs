using System.Drawing;

namespace Aplicacion.UI
{
    public static class Mathf
    {
        public static int LerpInt(int current, int target, int time)
        {                        
            if (target - current > 0)
            {
                if (current + time > target)
                    return current;
               return current + time;
            }

            if (target - current < 0)
            {
                if (current - time < target)
                    return current;
                return current - time;
            }

            return current;
        }

        public static Color LerpColor(Color current, Color target, int time)
        {
            if (current == target) return current;     
            int a = LerpInt(current.A, target.A, time);
            int r = LerpInt(current.R, target.R, time);
            int g = LerpInt(current.G, target.G, time);
            int b = LerpInt(current.B, target.B, time);

            a = Clamp(a, 0, 255);
            r = Clamp(r, 0, 255);
            g = Clamp(g, 0, 255);
            b = Clamp(b, 0, 255);

            return Color.FromArgb(a, r, g, b);
        }

        public static int Clamp(int current, int min, int max)
        {
            if (current < min)
                current = min;
            if (current > max)
                current = max;
            return current;
        }
    }
}
