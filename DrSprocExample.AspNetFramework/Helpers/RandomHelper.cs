using System;
using System.Linq;

namespace UnityE2ETest.Helpers
{
    public static class RandomHelper
    {
        public static int IntBetween(int a, int b)
        {
            var randGen = new Random();

            return randGen.Next(a, b);
        }

        public static DateTime DateInPast(int numDaysInPast)
        {
            var randGen = new Random();

            var daysInPast = randGen.Next(0, numDaysInPast);

            return DateTime.Now.AddDays((0 - daysInPast));
        }

        public static string RandomString(int length = 20)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}