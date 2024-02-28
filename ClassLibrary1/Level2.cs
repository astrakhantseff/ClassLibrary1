using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using level1;

namespace level2;

// Level 2

// Обновленный класс для представления пользователя
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsRegistered { get; set; }
    public bool IsAuthenticated { get; set; }
    public decimal WalletBalance { get; set; }
    public int PreviousMandarinCount { get; set; }
}

// Обновленный класс для управления аукционом
public class AuctionManager
{
    private List<Mandarin> mandarins;
    private List<User> users;
    private decimal cashbackMultiplier;

    public AuctionManager(decimal cashbackMultiplier)
    {
        mandarins = new List<Mandarin>();
        users = new List<User>();
        this.cashbackMultiplier = cashbackMultiplier;
    }

    // Метод для изменения размера кэшбека
    public void SetCashbackMultiplier(decimal multiplier)
    {
        cashbackMultiplier = multiplier;
    }

    // Метод для генерации мандаринки с заданными параметрами
    public void GenerateMandarin(DateTime? time = null, TimeSpan? lifespan = null)
    {
        var mandarin = new Mandarin()
        {
            CreatedAt = time ?? DateTime.Now,
            Lifespan = lifespan ?? TimeSpan.FromDays(1),
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

            // Обновление баланса кошелька пользователя с учетом кэшбека
            decimal cashback = user.PreviousMandarinCount * cashbackMultiplier;
            user.WalletBalance -= mandarin.PurchasePrice - cashback;

            // Обновление информации о предыдущей покупке
            user.PreviousMandarinCount++;
        }
    }

    public void ClearSpoiledMandarins()
    {
        mandarins.RemoveAll(m => m.IsSpoiled);
    }

    // Дополнительные методы для получения списка мандаринок и пользователей

    public List<Mandarin> GetAllMandarins()
    {
        return mandarins;
    }

    public List<User> GetAllUsers()
    {
        return users;
    }

    public decimal CashbackMultiplier => cashbackMultiplier;
}

// Unit тесты на xUnit
public class AuctionManagerTests
{
    [Fact]
    public void SetCashbackMultiplier_Should_UpdateCashbackMultiplier()
    {
        // Arrange
        var auctionManager = new AuctionManager(0.1m);

        // Act
        auctionManager.SetCashbackMultiplier(0.15m);

        // Assert
        Assert.Equal(0.15m, auctionManager.CashbackMultiplier);
    }

    [Fact]
    public void PlaceBid_Should_SendNotificationToUser()
    {
        // Arrange
        var auctionManager = new AuctionManager(0.1m);
        var user = new User { Name = "John", Email = "john@example.com" };
        var mandarin = new Mandarin();

        // Act
        auctionManager.PlaceBid(user, mandarin, 10);
    }
}
