namespace Console {
	using System;
	using System.Diagnostics;
	using Nancy.Hosting.Self;

	class Program {
		static void Main( string[] args ) {
			var uri =
				new Uri( "http://localhost:3579" );

			using ( var host = new NancyHost( uri ) ) {
				host.Start();

				Console.WriteLine( "Your application is running on " + uri );
				Console.WriteLine( "Press any [Enter] to close the host." );
				Process ieProcess = new Process();
				// Set the application that our Process is
				// going to start.
				ieProcess.StartInfo.FileName = "chrome";
				// Pass in the url that iexplore will visit upon
				// starting as a command line argument.
				ieProcess.StartInfo.Arguments = uri.AbsoluteUri;
				// Start the command line execution
				ieProcess.Start();
				Console.ReadLine();
			}
		}
	}
}
