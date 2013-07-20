using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using SquishIt.Framework;

namespace Nancy.Web.Modules {

	public class AssetsModule : NancyModule {
		public AssetsModule()
			: base( "/assets" ) {
			Get[ "/js/{name}" ] = parameters => CreateResponse( Bundle.JavaScript().RenderCached( (string) parameters.name ), Configuration.Instance.JavascriptMimeType );
			Get[ "/css/{name}" ] = parameters => CreateResponse( Bundle.Css().RenderCached( (string) parameters.name ), Configuration.Instance.CssMimeType );
		}

		Response CreateResponse( string content, string contentType ) {
			return Response
				.FromStream( () => new MemoryStream( Encoding.UTF8.GetBytes( content ) ), contentType )
				.WithHeader( "Cache-Control", "max-age=45" );
		}
	}
}