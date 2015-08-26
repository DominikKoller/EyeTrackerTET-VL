# README #

### This is ### 
a VL implementation for [TheEyeTribe Eyetracker](http://theeyetribe.com/).
Can be used in [vvvv](http://vvvv.org).

### This is ###
Both a fun thing to have and a very telling example for the potential of VL as a full-blown visual programming language. It involves class structures (impossible in vvvv), interfaces (not yet 'official' in VL), and Async Message handling via observables.

### To get up ###
and running, you'll need:


* vvvv >= 50alpha34.100

* TheEyeTribe Device

* TheEyeTribe Server (comes with SDK: [http://dev.theeyetribe.com](http://dev.theeyetribe.com) )

* TETCSharpClient.dll
can be compiled from: [TET C# Client on github](https://github.com/EyeTribe/tet-csharp-client)
put it into /tetdlls

* /tetdlls/TETCSharpClient.dll.vlimport
Included. Made by VL .net typeimporter (not yet released)

* TETWrapper.dll
can be compiled from included:
c#/TETWrapper/TETWrapper.sln
put it into /tetdlls

* /tetdlls/TETWrapper.dll.vlimport
Included. Made by VL .net typeimporter (not yet released)


Then Start at the helppatches:

* /vl/Eyetracker (Devices TheEyeTribe) help.v4p
* /vl/CalibrationRunner (TheEyeTribe) help.v4p

Everything else should be in the Contribution at vvvv.org!
Any feedback, +/-, on VL, the patching patterns I chose, or on the plugin specifically, is really appreciated!

[dominikkoller.net](http://dominikkoller.net/)

yours faithfully,
..vvvvpraxisintern dominikkoller