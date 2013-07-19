namespace NancyApplication2 {
	using Nancy;

	public class BaseModel {
		public string Text { get; set; }

		public int Number { get; set; }
	}

	public class IndexModule : NancyModule {
		public IndexModule() {
			Get[ "/" ] = parameters => {
				var model = new BaseModel {
					Text = "Hello world",
					Number = 1
				};

				return View[ "index", model ];
			};
		}
	}
}