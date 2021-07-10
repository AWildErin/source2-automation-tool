using SAT.Core;
using SAT.Core.Json;

namespace SAT.Modules
{
	/// <summary>
	/// A custom module that runs a program or command during the build process
	/// </summary>
	public class CustomModule : BaseModule
	{
		public CustomModule( ModuleConfig config ) : base( config )
		{

		}

		public override void Build()
		{
			//throw new System.NotImplementedException();
		}
	}
}
