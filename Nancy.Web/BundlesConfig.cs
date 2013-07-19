using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SquishIt.Framework;
using SquishIt.Framework.CSS;
using SquishIt.Framework.JavaScript;

namespace Nancy.Web {
	public class SquishItFile {
		public string Url { get; set; }

		public bool Minify { get; set; }
	}

	public static class Bundles
  {
      public static List<SquishItFile> PublicJavaScript = new List<SquishItFile>
      {
          new SquishItFile { Url = "~/public/static/js/jquery-1.6.4.js", Minify = true },
          new SquishItFile { Url = "~/public/static/js/startup.js", Minify = true }
      };

      public static List<SquishItFile> AdminJavaScript = new List<SquishItFile>
      {
          new SquishItFile { Url = "~/admin/static/js/lib/angular.js", Minify = true },
          new SquishItFile { Url = "~/admin/static/js/app/app.js", Minify = false }
      };

      public static List<SquishItFile> PublicCss = new List<SquishItFile>
      {
          new SquishItFile { Url = "~/public/static/css/site.css", Minify = true }
      };

      public static List<SquishItFile> AdminCss = new List<SquishItFile>
      {
          new SquishItFile { Url = "~/admin/static/less/bootstrap/bootstrap.less", Minify = true },
          new SquishItFile { Url = "~/admin/static/less/theme/theme.less", Minify = true }
      };
  }
	public class SquishItStartup {
		protected static string BasePathForTesting = "";

		protected static JavaScriptBundle BuildJavaScriptBundle( List<SquishItFile> files ) {
			var bundle = Bundle.JavaScript();

			foreach ( var item in files ) {
				var url = item.Url;

				if ( !string.IsNullOrWhiteSpace( BasePathForTesting ) ) {
					url = BasePathForTesting + item.Url.Replace( "~", "" );
				}

				if ( item.Minify ) {
					bundle.Add( url );
				} else {
					bundle.AddMinified( url );
				}
			}

			return bundle;
		}

		protected static CSSBundle BuildCssBundle( List<SquishItFile> files ) {
			var bundle = Bundle.Css();

			foreach ( var item in files ) {
				var url = item.Url;

				if ( !string.IsNullOrWhiteSpace( BasePathForTesting ) ) {
					url = BasePathForTesting + item.Url.Replace( "~", "" );
				}

				if ( item.Minify ) {
					bundle.Add( url );
				} else {
					bundle.AddMinified( url );
				}
			}

			return bundle;
		}

		public static void Setup( string basePathForTesting = "" ) {
			BasePathForTesting = basePathForTesting;

			// CSS
			BuildCssBundle( Bundles.PublicCss ).ForceRelease().AsCached( "public-css", "~/assets/css/public-css" );
			BuildCssBundle( Bundles.PublicCss ).ForceDebug().AsNamed( "public-css-debug", "" );

			// JS
			BuildJavaScriptBundle( Bundles.PublicJavaScript ).ForceRelease().AsCached( "public-js", "~/assets/js/public-js" );
			BuildJavaScriptBundle( Bundles.PublicJavaScript ).ForceDebug().AsNamed( "public-js-debug", "" );

		}
	}
}