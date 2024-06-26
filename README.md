# Coneways Game of Life
[![.NET](https://github.com/ulfk/GameOfLife/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/ulfk/GameOfLife/actions/workflows/dotnet-desktop.yml)

## Why?

Hard to believe that I never implemented Coneways Game of Life before. But eventually I stumbled over this exercise and thought "it is time for it". I've done it in C#.

## How?

After implementing a first algorithm I realized that only by getting the population itself distributed over the (infinite) space, the program got really slow. The problem was not, having too many living cells, but having some living cells very far away from each other. This caused performance problems, because my first aproach to solve the algorithm, was to first calculate the overall rectangle containing all living cells. Then I iteratited through every single cell of this rectangle. Why? Because any dead cell could come to live if it has three neighbors. But even with only a few cells moving apart from each other (gliders!), the rectangle got really big and thus the program got really slow.

The improoved approach is, to process the living cells in a first step (note: only the living cells are stored in a SortedSet, dead cells are not stored because... why??). As a part of this first processing step, I collect all dead neighbor cells of each living cell. Thus I get a list of all dead cells that have at least one neighbor. Dead cells without neighbors won't come to live anyway, thus we don't have to check them. Then after having processed the living cells, I process these collected currently dead cells to check if they come to live with the current setting of neighbors. 

This second approach causes the algorithm runtime to grow only with the size of the popuplation and not with it's distribution in the available (infinite) space.

## Features of the UI

The UI has the following features (hint: 'universe' is the configuration of cells):

- generate random universe
- load universe form file (TXT or RLE, see below)
- save current universe state to file (TXT or RLE)
- loaded univers is displayed centered
- start/stop evolving of generations
- reload previously loaded universe with single click
- display current number of generations and number of living cells
- change speed of generations
- change display-size of cells
- move the displayed universe by dragging it with the mouse
- change cells by holding SHIFT and mouse-left-click
- history of universes including every generation (possibility to navigate back and forth)

The program supports these data files:

- RLE files like described here: https://www.conwaylife.com/wiki/Run_Length_Encoded 
- plain text files: every non-space character is interpreted as living cell

There are predefined files or you can open any other file.

## Screenshot

<img alt="Screnshot of Gam of Life UI" src="https://github.com/ulfk/game-of-life/blob/main/screenshot.png" width="350px"/>

## ToDo

- if universe is in stable state stop the timer
- replace start/save/reload/history button texts with icons

## Bookmarks

- https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
- RLE files like described here: https://www.conwaylife.com/wiki/Run_Length_Encoded 

