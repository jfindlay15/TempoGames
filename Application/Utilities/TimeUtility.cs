namespace Application.Utilities
{
    public static class TimeUtility
    {
        /// <summary>
        /// Converts seconds into a format of a string that looks like this: 0d 0h 0m
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string GetTimeDurationFromSeconds(this int seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            var result = string.Format("{0:D1}d {1:D1}h {2:D1}m", time.Days, time.Hours, time.Minutes);
            return result;
        }
    }
}
