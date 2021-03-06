﻿using System;
using System.IO;
using System.Net;

namespace AOCHelper
{
    /// <summary>
    /// Class with utilities for the AoC event.
    /// </summary>
    public class AOCInput
    {
        private static string SESSION_FILE = "session.txt";

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

        private string _input;

        /// <summary>
        /// Constructor for the AOC helper.
        /// </summary>
        /// <param name="year">The year to get.</param>
        /// <param name="day">The day to get.</param>
        /// <param name="token">The session, can be retrieved from the browser after login.</param>
        public AOCInput(int year, int day)
        {
            // Set properties.
            Year = year;
            Day = day;
            if(File.Exists(SESSION_FILE))
                Session = File.ReadAllText(SESSION_FILE);

            // Get input, and keep it in memory.
            _input = RetreiveInput();
        }

        /// <summary>
        /// Retrieve input from the AoC website.
        /// </summary>
        /// <returns>The input from the AoC website, or <see langword="null"/> when failed.</returns>
        private string RetreiveInput()
        {
            string localFilePath = $"AoC_{Year}_{Day}.txt";

            // Check if the input needs to be downloaded first.
            if (!File.Exists(localFilePath))
                DownloadInput(localFilePath);

            // Return the contents on the disk.
            return GetLocalInput(localFilePath);
        }

        /// <summary>
        /// Get the raw input, not spitted.
        /// </summary>
        /// <returns>The raw input.</returns>
        public string GetInput()
        {
            return _input;
        }

        /// <summary>
        /// Get input split by a given substring.
        /// </summary>
        /// <param name="split">The substring to split on.</param>
        /// <returns>The input split by the given substring.</returns>
        public string[] GetInput(string split)
        {
            return GetInput()?.Split(new string[] { split }, StringSplitOptions.None);
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
        /// Set the input to example input.
        /// This is useful to still use the GetInput functionality of this class.
        /// Original input will be lost after calling this method.
        /// </summary>
        /// <param name="input">The example input.</param>
        public void SetExampleInput(string input)
        {
            _input = input.Replace("\r\n", "\n");
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
                Console.WriteLine($"Something went wrong downloading the input file from \"{requestURL}\"!");
#if DEBUG
                Console.WriteLine(ex);
#endif
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
                Console.WriteLine($"Failed to read local input from {localFilePath}!");
#if DEBUG
                Console.WriteLine(ex);
#endif
                return null;
            }
        }
    }
}
