using TimeApi.Console.Client.Client;
using TimeApi.Console.Client.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// ;)


SpicaClient cs = new SpicaClient();
cs.setSession();


//builder.Services.Add(new ServiceDescriptor(typeof(ISpicaClient), new SpicaClient()));
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<ISpicaClient,SpicaClient>();
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();


public interface ISpicaClient
{
    //public static AuthenticationHeaderValue GenerateClientAuthorizationHeader(string apiKey)
    //public static void ReLogin();
    //public static void LoginWithUsername(String url, string endpoint)
    //public static bool isTokenValid(double validityTreshold)
    public bool setSession();
    public List<Employee> getAllEmployees();
    public List<Employee> getAllEmployeesByProperties(Employee employee);
    public bool AddNewEmployee(Employee employee);
    //public static bool PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
    public List<Employee> getAllEmployeesByPresence(int orgUnit, bool showInactiveEmployees, DateTime dateTime);
}