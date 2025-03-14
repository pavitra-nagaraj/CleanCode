namespace hamaraBasket;

public class IndianWineUpdater : ItemUpdater
{
    public IndianWineUpdater(Item item) : base(item) { }

    protected override void UpdateQuality()
    {
        if (item.Quality < 50)
            item.Quality++;
    }

    protected override void HandleExpired()
    {
        if (item.SellIn < 0 && item.Quality < 50)
            item.Quality++; // Improves after expiration
    }
}
