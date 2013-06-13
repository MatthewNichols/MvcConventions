MvcConventions
==============

Training Materials for a short course on ASP.NET MVC conventions I was asked to present.


# ASP.NET MVC Convention over Configuration
Convention over Configuration is the idea of having defaults in the system that work most of the time, but can be overridden if need be. MVC has a number of these conventions.  Almost all of them can be overridden but life is easier if you just work with them.

#### MVC Request Workflow (very simplified)
1. Routing rules translate URL into Controller and Action name, as well as other values in the url
2. Controller Factory resolves/instantiates the Controller
3. Action is called
4. If the Action returns a ViewResult the View is found by the View engine
5. Action returns an ActionResult of some sort
6. ActionResult.ExecuteResult() is called to render final result.

(more details at http://jtbennett.com/blog/2009/02/the-life-and-times-of-an-asp-net-mvc-framework-request)



#### File structure

- App_Start (place for code that is called at Application Start.  No magic, you still have to call it.)
  - Areas
		- AnArea
			- Controllers
			- Models
			- Views
				- Shared
		- AnAreaAreaRegistration.cs
	- Controllers
	- Content (css, images, other static files except for script)
	- Models (or ViewModels.  These folders are conventions but not required)
	- Scripts
	- Views
		- Folders with Controller names
		- Shared
			- DisplayTemplates (Used by Html.DisplayFor)
			- EditorTemplates (Used by Html.EditorFor)
			- \_Layout.cshtml  (Default "Master Page")
		- \_ViewStart.cshtml (runs before each view)
		- Web.Config (Special Views version. Without this your views will not work.  Set Namespaces to be included in each view)
	- Global.asax (Application_Start and other life cycle events)
	- packages.config (NuGet packages)
	- Web.config
	
	

#### Routing Conventions
Often you will never need to change the Default Route
##### Default Route

    routes.MapRoute(
      name: "Default",  //Name is optional but must be unique
      url: "{controller}/{action}/{id}",
      defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
	);


##### Constraints: RegEx expressions that limit what urls can match the Route.
    routes.MapRoute(
   		 "Product",
   		 "Product/{productId}",
   		 new {controller="Product", action="Details"},
   		 new {productId = @"\d+" }   //Only matchs on integer productIds
   	);
	

[HttpPost] or [HttpGet] attributes added to your Actions effect routing as well.


	
#### View Conventions
* Go in the Views folder
* Which view to be rendered defaults to the name of the action.  It will look in Views/{ControllerName}/{ViewName}.cshtml and if not found then tries Views/Shared/{ViewName}.cshtml.  You can can give a full path relative to the site root.
