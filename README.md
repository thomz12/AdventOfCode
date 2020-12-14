# Advent Of Code ![](https://github.com/thomz12/AdventOfCode/workflows/Build%20Solution/badge.svg)
My solutions for the advent of code event. It also includes a very simple helper class speeding up some tasks.
To learn more about the advent of code, visit the [advent of code website!](https://adventofcode.com)
## AOCInput
### What does it do?
The Advent Of Code helper class makes some recuring task easy.
What it does:
- Fetches the input from the advent of code website
- Gets input based on user
- Optionally, splits the input
- Saves the input locally
### Usage
Reference the AOCHelper. To get input, call the AOCInput constructor like this to set it up for `2020` day `1`:

`AOCInput input = new AOCInput(2020, 1);`

To get input, you can use the following:

```
string rawInput = input.GetInput();
string[] inputSplit = input.GetInput(",");
string[] inputLines = input.GetInputLines();
```
#### Getting and setting the session ID
The helper will use the session in `session.txt`, placed next to the executable. To make life easy, you can paste your session string in the `AOCHelper/session.txt` file. This won't be updated in the repo for others to see.

The session ID can be easily retrieved from the advent of code website by logging in, and viewing your cookies in your favorite browser. You should find the session string there with name `session`.

This is necessary to get user specific input.

## AOCRunner and AOCDay
### What does it do?
The AOCRunner runs functions from an implemented AOCDay. It will report the answer and the time it took to execute the puzzles. Implementing the AOCDay is easy, since you only need to implement two functions. It provides you with a AOCInput for getting input, and the function should return a string that is the answer to the problem. Also, the constructor of the day should call its parent constructor to report what day and what year it is for. See example below

```
class Day01 : AOCDay
{
    public Day01() 
        : base(2018, 1)
    {

    }

    public override string Puzzle1(AOCInput input)
    {
        int freq = 0;
        string[] lines = input.GetInputLines();

        foreach (string line in lines)
            freq += int.Parse(line);

        return freq.ToString();
    }

    public override string Puzzle2(AOCInput input)
    {
      ...
```
To run the day, you can simple do the following:
`AOCRunner runner = new AOCRunner(new Day01());`

### Building
Building is only tested in VS2019, but since I kept it pretty simple I don't see a reason why it shouldn't work elsewhere.

### Note
If the input doesn't match, try deleting the input `.txt` input file placed next to the executable. This will re-download and use the session set in the `session.txt` file.
