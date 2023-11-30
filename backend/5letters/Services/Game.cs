// using System;
// using System.Collections.Generic;
// using System.Linq;
// using _5letters.Services;
//
// public class Game
// {
// 	public string PlayerToken;
// 	public string VictoryWord;
// 	public List<Word> WordsInGame;
// 	public string PlayerName;
// 	public GameStages GameStage;
//
// 	public Game(GameDataToStart gameData)
// 	{
// 		PlayerToken = gameData.Token;
// 		PlayerName = gameData.PlayerName;
// 		VictoryWord = gameData.VictoryWord;
// 		WordsInGame = new List<Word>();
// 		GameStage = GameStages.GameInProgress;
// 	}
// 	
//
// 	public static Game RunGame(Game nowGame, string nowWorld)
// 	{
// 		nowGame.WordsInGame.Add(Word.ChekWord(nowGame.VictoryWord, nowWorld));
// 		if (nowGame.WordsInGame.Last().Status == WordStatus.VictoryWord)
// 		{
// 			nowGame.GameStage = GameStages.Victory;
// 			GameStatistics.ReturnGameStatistics(nowGame);
// 		}
// 		else if (nowGame.WordsInGame.Count == 5)
// 		{
// 			nowGame.GameStage = GameStages.Defeat;
// 			GameStatistics.ReturnGameStatistics(nowGame);
// 		}
//
// 		return nowGame;
// 	}
// }
//
// public enum GameStages
// {
// 	GameInProgress,
// 	Victory,
// 	Defeat
// }
//
// public class Word
// {
// 	public string StringWord;
// 	public List<Letter> Letters;
// 	public WordStatus Status;
// 	public Word(string stringWord)
// 	{
// 		StringWord = stringWord;
// 		Letters = new List<Letter>();
// 	}
// //здесь еще длжен быть метод который проверяет существует ли слово, но я не знаю как его рализовать. Будет ближе к концу проекта 
// 	public static Word ChekWord(string victoryWord, string nowWord)
// 	{
// 		Word result = new Word(nowWord);
// 		for (int i = 0; i < 5; i++)
// 		{
// 			var nowLetter = nowWord[i];
// 			if (victoryWord[i] == nowLetter)
// 			{
// 				result.Letters.Add(new Letter(nowLetter, PositionInVictoryWord.RightPlace));
// 			}
// 			else if (victoryWord.Contains(nowLetter))
// 			{
// 				result.Letters.Add(new Letter(nowLetter, PositionInVictoryWord.InWord));
// 			}
// 			else
// 			{
// 				result.Letters.Add(new Letter(nowLetter, PositionInVictoryWord.WrongLetter));
// 			}
// 		}
//
// 		if (result.Letters.All(x => x.Position == PositionInVictoryWord.RightPlace))
// 		{
// 			result.Status = WordStatus.VictoryWord;
// 		}
// 		else
// 		{
// 			result.Status = WordStatus.NotVictoryWord;		
// 		}
//
// 		return result;
// 	}
// }
//
// public enum WordStatus
// {
// 	VictoryWord,
// 	NotVictoryWord,
// 	ErrorWord
// }
//
// public class Letter
// {
// 	public char WordLetter;
// 	public PositionInVictoryWord Position;
// 	public Letter(char letter, PositionInVictoryWord positionInVictoryWord)
// 	{
// 		WordLetter = letter;
// 		Position = positionInVictoryWord;
// 	}
// }
//
// public enum PositionInVictoryWord
// {
// 	RightPlace,
// 	InWord,
// 	WrongLetter
// }
//
