using System.Collections.Generic;
using System.Text.Json;

namespace SAT.Core.Json
{
	/// <summary>
	/// This is the model for the config files that determine what is
	/// done for each project.
	/// </summary>
	public class ProjectModel
	{
		public ProjectConfig Config { get; set; }
		public Dictionary<string, ModuleConfig> Modules { get; set; }
	}

	public class ProjectConfig
	{
		public string Project { get; set; }
		public SupportedGames Game { get; set; }
	}

	public class ModuleConfig
	{
		public string ModuleClass { get; set; }
		public Dictionary<string, object> Options { get; set; }

		public JsonElement GetOptionsProperty( string propName )
		{
			var element = (JsonElement)Options[propName];

			return element;
		}
	}
}
