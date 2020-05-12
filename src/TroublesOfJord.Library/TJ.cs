using System;
using System.Reflection;
using TroublesOfJord.Core;
using TroublesOfJord.Storage;
using TroublesOfJord.Utils;
using Module = TroublesOfJord.Core.Module;

namespace TroublesOfJord
{
	public static class TJ
	{
		public static Action<string> InfoLogHandler = Console.WriteLine;
		public static Action<string> WarnLogHandler = Console.WriteLine;
		public static Action<string> ErrorLogHandler = Console.WriteLine;
		public static Action<string> GameLogHandler = Console.WriteLine;

		public static Module Module { get; set; }

		public static StorageService StorageService { get; } = new StorageService();

		public static GameSession Session
		{
			get; set;
		}

		public static Player Player
		{
			get
			{
				if (Session == null)
				{
					return null;
				}

				return Session.Player;
			}
		}

		public static bool IsFighting
		{
			get
			{
				var player = Player;
				if (player == null)
				{
					return false;
				}

				return player.AttackTarget != null;
			}
		}

		public static string Version
		{
			get
			{
				var assembly = typeof(TJ).GetTypeInfo().Assembly;
				var name = new AssemblyName(assembly.FullName);

				return name.Version.ToString();
			}
		}

		public static void LogInfo(string message, params object[] args)
		{
			if (InfoLogHandler == null)
			{
				return;
			}

			InfoLogHandler(StringUtils.FormatMessage(message, args));
		}

		public static void LogWarn(string message, params object[] args)
		{
			if (WarnLogHandler == null)
			{
				return;
			}

			WarnLogHandler(StringUtils.FormatMessage(message, args));
		}

		public static void LogError(string message, params object[] args)
		{
			if (ErrorLogHandler == null)
			{
				return;
			}

			ErrorLogHandler(StringUtils.FormatMessage(message, args));
		}

		public static void GameLog(string message, params object[] args)
		{
			if (GameLogHandler == null)
			{
				return;
			}

			GameLogHandler(StringUtils.FormatMessage(message, args));
		}
	}
}