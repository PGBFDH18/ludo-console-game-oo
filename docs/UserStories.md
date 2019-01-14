As a player, I want to play Ludo with the official rules.

The program should do all the logic for the players.

You should be able to play as two, three or four players.

The players who throws the highest dice gets to start the round.

To leave the nest you have to throw a six.

If you hit a six you'll be allowed to throw the dice again.

If you have one of your own pices blocking your way you'll have to move the one that have progressed the fursthest.

If you have two of your pieces on that same position you block the path for other players and yourself.

Once all your pieces are in the middle circle you've won.

When you've completed a lap around the gameboard you'll have to move towards the center with even dice throws.

Once you've completed 40 steps you can start to move towards the middle.

After 40 steps you have 5 steps to get into the middle.

Choose Color and playerorder
---
Colors are given to players.

Player throws dice (automaticly) to see who starts.

Player with highest dicethrow starts.

Player throws dice
---
(Display: Wich pieces are in the nest, wich pieces are on the bord and location for the pieces (number).

If dicethrow is a 6, player can choose to take a piece from nest to board, or go 6 steps with piece that is already on board.

Above repeated for player 1-x(max 4)

Display in console
---
Display pieces tileposition, either in nest or on board (Use int movement to know when a piece has moved 40 tiles).

Display all options: Move piece, pass turn. If option not vaild --> Scenario 5

Scenario
---
Scenario 1:
--
Pieces can stand on same tile / pieces cannot stay on same tile (invalid dicethrow, throw again)

Scenario 2:
--
If piece has traveled 40 tiles the piece has entered the finishline (one lap + 5 finishtiles). The piece is removed from board and nest.

Scenario 3:
--
If all four playerpieces has entered the finishline that player wins and the game ends.

Scenario 4:
--
When a piece has moved 40 tiels (one lap) it must move 5 finishtiles to enter the finishline. The piece must move an even number to enter the finishline. If the piece moves to many tiles it will move backwards on the finishtiles untill it reaches the first finishtile.

Scenario 5:
--
If piece cannot move. Move different piece with same dicethrow

Ex1: If 2 pieces on board, dicethrow 1-5. cannot move piece1, give player option to move piece2 instead.
Ex2: If 2 pieces on board, dicethrow 6. Cannot move piece1, give player option to either move piece2 or move out of nest instead.
In Console:


