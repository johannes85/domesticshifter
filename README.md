DomesticShifter
=========
Alternative (Unofficial) Windows Toolset for Programming the MagicShifter

Since there was no user friendly way to programm the MagicShifter (http://magicshifter.net/) gadget, I decided to write my own Windows toolset for this task.

At the moment the tools are in a very early state, but can be used to upload Magic Bitmap files to the MagicShifter with the limitation, that only files with 24 or 8 bits per pixle are supported.

C# Projects in this Repository
---------
* MagicShifter: Library for accessing the MagicShifter via the virtuual serial port and the C# implementation of the MagicBitmap image format.
* MagicPaint: Tool for generating Magic Bitmap images (animations)
* Uploader: Library to supply applications with the posibility to upload files to the MagicShifter. It's used by MagicPaint and can be easily integrated into other applications.



Disclaimer
---------
This toolset isn't officially supported by MagicShifter  