# 👨‍💻 BambooCardCodingTest
Bamboo-card - Developer Coding Test Task

## ⚙️ Setup

There are two ways to run the project:
* If you already have Docker installed, you can choose the first option:
  1. Run the following command in the root directory of the project:
     ```bash
     docker build -t bamboo-card-coding-test .
     docker run -p 3000:80 -e ASPNETCORE_ENVIRONMENT=Development bamboo-card-coding-test
     ```
  2. Open your browser and go to `http://localhost:3000/swagger/index.html`
* If you don't have Docker installed, you can choose the second option:
  1. [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) should be installed on your system.
  2. Run the following commands in the root directory of the project:
     ```bash
     dotnet restore
     dotnet run --project src/API
     ```
  3. Open your browser and go to `https://localhost:7087/swagger/index.html`

## ✨ Enhancements
* Replace **IMemoryCache** with **Distributed Cache** (Redis). It is better to use Redis for caching in a production environment because it is more scalable and can be used in a distributed environment (when the application is running on multiple servers).
* Add **MediatR** for better separation of concerns and to make the code more readable and maintainable.
* Cover the code with unit tests using **xUnit** or **NUnit**.
* I didn't find a way to get specific number of BestStories from the API, so I had to get all the stories and then filter them in the code. It would be better if I could get only the required number of stories from the API.
* Add logging to the application to make it easier to debug and monitor.
* Check all of the edge cases when count in GetBestStories will be bigger than 200, etc.
* Use custom Result or library like FluentResult to have more control over the response and possible errors.

## 📝 Notes
* To prevent risk of overloading the Hacker News API I decided to create CacheProxy and use IMemoryCache there.
* I decided to use Onion Architecture (Clean Architecture) because I think that it is a good way to structure the project and make it easier for future improvements.
* Also I wanted to try Refit package to make API calls. It is working good and setup was really easy. Moreover, it's using source generators under the hood.
