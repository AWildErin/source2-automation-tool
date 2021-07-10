using System.Text.Json;

namespace SAT.Util
{
	public static class JsonExtension
	{
		// https://stackoverflow.com/a/58193164
		public static T ToObject<T>( this JsonElement element )
		{
			var json = element.GetRawText();
			return JsonSerializer.Deserialize<T>( json );
		}

		public static T ToObject<T>( this JsonDocument document )
		{
			var json = document.RootElement.GetRawText();
			return JsonSerializer.Deserialize<T>( json );
		}
	}
}
