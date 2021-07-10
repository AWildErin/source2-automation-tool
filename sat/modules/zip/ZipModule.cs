using SAT.Core;
using SAT.Core.Json;
using SAT.Util;
using System;
using System.Collections.Generic;

namespace SAT.Modules.Zip
{
	public class ZipModule : BaseModule
	{
		public ZipModule( ModuleConfig config ) : base( config )
		{

		}

		public override void Build()
		{
			foreach ( var test in Config.GetOptionsProperty( "ignoreFiles" ).ToObject<List<string>>() )
			{
				Console.WriteLine( test );
			}
		}
	}
}
