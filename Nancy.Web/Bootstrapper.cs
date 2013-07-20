namespace Nancy.Web {
	using System.IO;
	using Nancy;

	public class Bootstrapper : DefaultNancyBootstrapper {
		// The bootstrapper enables you to reconfigure the composition of the framework,
		// by overriding the various methods and properties.
		// For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
		protected string PathToProjectWebRoot() {
			var directoryName = Path.GetDirectoryName( typeof( Bootstrapper ).Assembly.CodeBase );

			if ( directoryName != null ) {
				var assemblyPath = directoryName.Replace( @"file:\", string.Empty )
												.Replace( "bin", string.Empty );

				return Path.Combine( assemblyPath );
			}

			return "";
		}

		protected override void ApplicationStartup( Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines ) {
			SquishItStartup.Setup( PathToProjectWebRoot() );
		}
	}
}