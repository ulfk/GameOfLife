# Coneways Game of Life

## Why?

Hard to believe that I never implemented Coneways Game of Life before. But eventually I stumbled over this excersive and thought "it is time for it". I've done it in C# .NET Core.

## How?

After implementing a first algorithm I realized that only by getting the population itself distributed over the (infinite) space, the program got really slow. The problem was not, having too many living cells, but having some living cells very far away from each other. This caused performance problems, because my first aproach to solve the algorithm, was to first calculate the overall rectangle containing all living cells. Then I iteratited through every single cell of this rectangle. Why? Because any dead cell could come to live if it has three neighbors. But even with only a few cells moving apart from each other (gliders!), the rectangle got really big and thus the program got really slow.

The improoved approach is, to process the living cells in a first step (note: only the living cells are stored in a SortedSet, dead cells are not stored because... why??). As a part of this first processing step, I collect all dead neighbor cells of each living cell. Thus I get a list of all dead cells that have at least one neighbor. Dead cells without neighbors won't come to live anyway, thus we don't have to check them. Then after having processed the living cells, I process these collected currently dead cells to check if they come to live with the current setting of neighbors. 

This second approach causes the algorithm runtime to grow only with the size of the popuplation and not with it's distribution in the available (infinite) space.

## Features of the UI

The start configuration is generated randomized or can be loaded from a file. Available files are recognized by naming convention so you can add new files as needed. One of the files can be selected as start population. The processing can be started and stopped and the frequency of generating a new generation can be adjusted. The displayed canvas can be dragged by the mouse to change the visible area. The size of the displayed cells can be changed.

As datafiles, the program supports:

- plain text files: every non-space character is interpreted as living cell
- RLE files like described here: https://www.conwaylife.com/wiki/Run_Length_Encoded 

## Screenshot

<img alt="Screnshot of Gam of Life UI" src="https://github.com/ulfk/game-of-life/blob/main/screenshot.png" width="350px"/>

## ToDo

- center universe after loading from file
- add posibility to set cells manually by mouse-click
- add functionality to save universe to file

## Bookmarks

- https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens

