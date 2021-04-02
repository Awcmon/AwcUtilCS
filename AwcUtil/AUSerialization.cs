using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AwcUtil
{
	public class AUSerialization
	{
		//Note: Non-recursive
		public static List<T> DeserializeJSONFromPathToList<T>(string folderPath)
		{
			List<T> ret = new List<T>();

			if (!Directory.Exists(folderPath))
			{
				return ret;
			}

			string[] filePaths = Directory.GetFiles(folderPath);

			foreach (string filePath in filePaths)
			{
				string jsonString = File.ReadAllText(filePath);
				ret.Add(JsonSerializer.Deserialize<T>(jsonString));
			}

			return ret;
		}

		//file name is the dict key
		public static Dictionary<string, T> DeserializeJSONFromPathToDict<T>(string folderPath)
		{
			Dictionary<string, T> ret = new Dictionary<string, T>();

			if (!Directory.Exists(folderPath))
			{
				return ret;
			}

			string[] filePaths = Directory.GetFiles(folderPath);

			foreach (string filePath in filePaths)
			{
				string jsonString = File.ReadAllText(filePath);
				ret.Add(filePath, JsonSerializer.Deserialize<T>(jsonString));
			}

			return ret;
		}

		public static void SerializeToPath<T>(T ob, string fileName, string folderPath)
		{
			string jsonString = JsonSerializer.Serialize(ob);
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
			File.WriteAllText($"{folderPath}/{fileName}.json", jsonString);
		}
	}
}
