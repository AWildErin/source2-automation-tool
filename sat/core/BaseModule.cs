using SAT.Core.Json;

namespace SAT.Core
{
	public abstract class BaseModule
	{
		public ModuleConfig Config { get; private set; }

		public BaseModule( ModuleConfig config )
		{
			Config = config;
		}

		public abstract void Build();

		public virtual void PreBuild() { }
		public virtual void PostBuild() { }
	}
}
