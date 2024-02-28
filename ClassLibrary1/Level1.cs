using Xunit;

namespace level1;

// Level 1

// Класс для представления мандаринки
public class Mandarin
{
    public DateTime CreatedAt { get; set; }
    public bool IsSpoiled { get; set; }

    // Для level 2
    public TimeSpan Lifespan { get; set; }
    public decimal PurchasePrice { get; set; }
}

// Класс для представления пользователя
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsRegistered { get; set; }
    public bool IsAuthenticated { get; set; }
}

// Класс для управления аукционом
public class AuctionManager
{
    private List<Mandarin> mandarins;
    private List<User> users;

    public AuctionManager()
    {
        mandarins = new List<Mandarin>();
        users = new List<User>();
    }

    public void GenerateMandarin(DateTime? time = null)
    {
        var mandarin = new Mandarin()
        {
            CreatedAt = time ?? DateTime.Now,
            IsSpoiled = false
        };
        mandarins.Add(mandarin);
    }

    public void RegisterUser(User user)
    {
        users.Add(user);
    }

    public void AuthenticateUser(User user)
    {
        var registeredUser = users.FirstOrDefault(u => u.Name == user.Name);
        if (registeredUser != null)
            registeredUser.IsAuthenticated = true;
    }

    public void PlaceBid(User user, Mandarin mandarin, decimal bidAmount)
    {
        if (user.IsAuthenticated && !mandarin.IsSpoiled)
        {
            // Место для логики по обработке ставок
            // Отправка уведомлений пользователю
        }
    }

    public void PurchaseMandarin(User user, Mandarin mandarin)
    {
        if (user.IsAuthenticated && !mandarin.IsSpoiled)
        {
            // Место для логики по покупке мандаринки
            // Отправка чека на почту
        }
    }

    public void ClearSpoiledMandarins()
    {
        mandarins.RemoveAll(m => m.IsSpoiled);
    }

    public List<User> GetAllUsers()
    {
        return users;
    }

    public List<Mandarin> GetAllMandarins()
    {
        return mandarins;
    }
}

// Unit тесты на xUnit
public class AuctionManagerTests
{
    [Fact]
    public void GenerateMandarin_Should_AddMandarinToList()
    {
        // Arrange
        var auctionManager = new AuctionManager();

        // Act
        auctionManager.GenerateMandarin();

        // Assert
        Assert.NotEmpty(auctionManager.GetAllMandarins());
    }

    [Fact]
    public void RegisterUser_Should_AddUserToList()
    {
        // Arrange
        var auctionManager = new AuctionManager();
        var user = new User { Name = "John", Email = "john@example.com" };

        // Act
        auctionManager.RegisterUser(user);

        // Assert
        Assert.Contains(user, auctionManager.GetAllUsers());
    }
}
