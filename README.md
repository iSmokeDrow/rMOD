rMOD v0.9.5 Beta 1

Features:
- LUA based structure files
	- Ability to load structure files when chosen or manually
	- Ability to define structures folder
	- Ability to assign unique FileName/TableName via Manage Structures GUI
	- Execution of code during row processing (load and save) by defining ProcessRow function
- Tabs
	- Unique ability to clear current tab of all but the current structure (columns)
	- Unique ability to reload current tab data (clear current tab + load data)
	- Unique ability to reload current tab structure + data (completely reset current tab + load structure + load data)
	- Ability to close current tab
- Loading/Saving of .rdb files
	- Ability to define save directory
	- Ability to save directly to hashed name
	- Ability to automatically append (ascii) to file names
	- Ability to select encoding
- Loading/Saving of sql tables
	- Choice to drop/truncate target tables
	- Ability to backup target table before save operation
	- Unique ability to generate parameterized insert queries based on multiple methods
- Unique 'GuessName' functionality (attempts to guess FileName/TableName based on structure name)
	

