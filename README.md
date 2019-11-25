# Advent Of Code
My solutions for the 2019 advent of code event. It also includes a very simple helper class speeding up some tasks.
## Helper
### What does it do?
The Advent Of Code helper class makes some recuring task easy.
What it does:
- Fetches the input from the advent of code website
- Optionally, splits the input
- Saves the input locally
### Usage
Reference the AOCHelper. Call the constructor like this to set it up for `2019` day `1`:

`AOCHelper helper = new AOCHelper(2019, 1, "my session id");`

To get input, you can use the following:

```
string input = helper.GetInput();
string[] inputSplit = helper.GetInput(",");
string[] inputLines = helper.GetInputLines();
```
#### Getting the session ID
The session ID can be easily retrieved from the advent of code website by logging in, and viewing your cookies in your favorite browser. You should find the session string there with name `session`.

This is necessary to get user specific input.

### Building
Building is only tested in VS2019, but since I kept it pretty simple I don't see a reason why it shouldn't work elsewhere.
