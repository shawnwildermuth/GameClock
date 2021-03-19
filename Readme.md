# GameClock

This small utility allows you to create a small clock that is top-most and will stay on top of the screen.

I forked an older project written in WPF (https://github.com/qqga/WpfTime) as a starting point. I made some significant changes:

- Ported it to .NET Core 3.1
- Moved the settings into a Settings Dialog
- Moved settings into a simple .json file
- Remembered window location
- Fixed some minor bugs.

I hope you'll enjoy it. If you want it over games, you need to have the game playing in Windowed-Borderless (Topmost windows don't show over full-screen games.)