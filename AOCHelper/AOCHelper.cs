using System;
using System.IO;
using System.Net;

namespace AOC
{
    /// <summary>
    /// Class with utilities for the AoC event.
    /// </summary>
    public class AOCHelper
    {
        /// <summary>
        /// Day of this helper.
        /// </summary>
        public int Day { get; private set; }

        /// <summary>
        /// Year of this helper.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Current session ID, since input changes per user.
        /// </summary>
        public string Session { get; private set; }

        /// <summary>
        /// Constructor for the AOC helper.
        /// </summary>
        /// <param name="year">The year to get.</param>
        /// <param name="day">The day to get.</param>
        /// <param name="token">The session, can be retrieved from the browser after login.</param>
        public AOCHelper(int year, int day, string session)
        {
            // Set properties.
            Year = year;
            Day = day;
            Session = session;
        }

        /// <summary>
        /// Retrieve input from the AoC website.
        /// </summary>
        /// <returns>The input from the AoC website, or <see langword="null"/> when failed.</returns>
        public string GetInput()
        {
            string localFilePath = $"AoC_{Year}_{Day}.txt";

            // Check if the input needs to be downloaded first.
            if (!File.Exists(localFilePath))
                DownloadInput(localFilePath);

            // Return the contents on the disk.
            return GetLocalInput(localFilePath);
        }

        /// <summary>
        /// Get input split by a given substring.
        /// </summary>
        /// <param name="split">The substring to split on.</param>
        /// <returns>The input split by the given substring.</returns>
        public string[] GetInput(string split)
        {
            return GetInput().Split(new string[] { split }, StringSplitOptions.None);
        }

        /// <summary>
        /// Get the input line by line.
        /// </summary>
        /// <returns>The input split line by line.</returns>
        public string[] GetInputLines()
        {
            return GetInput("\n");
        }

        /// <summary>
        /// Get the input for this helpers year and day.
        /// </summary>
        /// <param name="localFilePath">The file to download to.</param>
        private void DownloadInput(string localFilePath)
        {
            string requestURL = $"https://adventofcode.com/{Year}/day/{Day}/input";

            try
            {
                // Setup a web client, with session cookie.
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.Cookie, "session=" + Session);

                // Download the file.
                client.DownloadFile(requestURL, localFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong downloading the input file from \"{requestURL}\"! {ex.ToString()}");
            }
        }

        /// <summary>
        /// Get input from a local file.
        /// </summary>
        /// <param name="localFilePath">The file to read from.</param>
        /// <returns>The trimmed contents of the file.</returns>
        private static string GetLocalInput(string localFilePath)
        {
            try
            {
                // Get input from file.
                string input = File.ReadAllText(localFilePath);

                // Trim trailing white spaces or newlines before returning.
                input = input.Trim();
                return input;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read local input! {ex.ToString()}");
                return null;
            }
        }
    }
}
