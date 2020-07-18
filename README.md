# VoronoiLib
Modification of [Zalgo2462\'s VoronoiLib](https://github.com/Zalgo2462/VoronoiLib) for use in my own projects. Feel free to use or modify further.

# Changes
- Migrated project VoronoiLib to .NET Standard 2.0
- Migrated projects VoronoiDemo and VoronoiSpeedTest to .NET Core 3.1
- Merged [EttieneS\' pull request](https://github.com/Zalgo2462/VoronoiLib/pull/5) with fix
- Added [Lloyd\'s relaxation algorithm](https://en.wikipedia.org/wiki/Lloyd%27s_algorithm)
- Added edges of the bounding box to the output
- Fixed a bug in original implementation causing creation of excess Delaunay triangles because of Voronoi regions neighbouring each other outside of the bounding box
