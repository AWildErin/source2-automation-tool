using SAT.Core;
using SAT.Core.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SAT
{
    class Program
    {
		private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			Converters =
			{
				new JsonStringEnumConverter()
			}
		};

        static void Main(string[] args)
        {
			var ConfigPath = @"E:\Repositories\sandbox\_tools\sat\examples\gears.json";
			var jsonString = File.ReadAllText( ConfigPath );

			var config = JsonSerializer.Deserialize<ProjectModel>( jsonString, jsonOptions );

			Console.WriteLine( $"Project Game is: {config.Config.Game}" );
			Console.WriteLine( $"Project Name is: {config.Config.Project}" );

			/*
			var element = (JsonElement)config.Modules["contentbuilder"].Options["test 123"];
			var element1 = element.GetProperty( "Test Value" ).ToString();
			var element2 = element.GetProperty( "Args" ).ToString();
			*/

			foreach (var key in config.Modules)
			{
				var moduleConfig = key.Value;

				Console.WriteLine( $"Performing: {key.Key} step" );

				var moduleType = Type.GetType( moduleConfig.ModuleClass );

				if ( moduleType == null )
				{
					Console.WriteLine( $"Failed to run {key.Key}. ModuleType was equal to null" );
					//throw new Exception( $"Failed to run {key.Key}. ModuleType was equal to null" )
					break;
				}

				var module = (BaseModule)Activator.CreateInstance( moduleType, moduleConfig );

				module.PreBuild();
				module.Build();
				module.PostBuild();

				Console.WriteLine( $"Finished: {key.Key} step" );
			}

			Console.WriteLine( "Finished all build steps" );
		}
    }
}
