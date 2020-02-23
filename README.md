# Poker Showdown

## Assumptions

* User of this library will ensure that raw input is validated prior to creating a new instance of the Player class
* User of this library will validate that duplicate cards will not be added across multiple players
* Hands containing four of the same card will be classified as Three of a Kind
* Hands containing three of a kind and an additional pair will be classified as Three of a Kind
* Hands containing two pairs will be classified as One Pair
* If multiple players hold a hand of identical rank and strength, multiple winners will be identified
* Custom exceptions (see below) should be handed by the end user implementing this library


## Exceptions

* CardDataInvalidException
* DuplicateCardException
* InvalidHandLengthException
* RankNotValidException
* SuitNotValidException

## Example

The following is an example of how to use this library. 

```cs
IGame pokerGame = new Game();

pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
pokerGame.AddPlayer("Player2, 6D, 6H, 6S, 5C, 8H");
pokerGame.AddPlayer("Player3, 9C, 9D, AH, KH, 2S");

var pokerGameWinners = pokerGame.DetermineWinningPlayers();
```

The expected value of `pokerGameWinners` is a `List<Player>` containing a single `Player` object, with `Name` "Player2".