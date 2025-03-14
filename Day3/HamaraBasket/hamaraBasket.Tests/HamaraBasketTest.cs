using hamaraBasket.Tests;
using NUnit.Framework;
using System.Collections.Generic;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketTest
    {
        

        [Test]
        public void SellByValueShouldBeReducedByOneAtEOD()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Lux Soap";
            IList<Item> items = DomainFactory.PrepareSingleItemList(name,sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(sellIn-1,Is.EqualTo(item.SellIn));
           
        }

        [Test]
        public void QualityShouldBeReducedByOneAtEOD()
        {
            int sellIn = 10;
            int quality = 10;
            string name = "Lux Soap";

            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality - 1, Is.EqualTo(item.Quality));
        }
        

        [Test]
        public void QualityShouldBeReducedByTwoAfterSellByDatePassed()
        {
            int sellIn = 0;
            int quality = 10;
            string name = "Spinach";
            

            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality - 2, Is.EqualTo(item.Quality));
        }

        [Test]
        public void Should_ThrowException_WhenQualityIsNegative()
        {
            int sellIn = 10;
            int quality = -5;
            string name = "Spinach";


            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);
            });

            StringAssert.Contains("Quality must be between 0 and 50", exception.Message);
        }

        [Test]
        public void Should_ThrowException_WhenQualityLimit_MoreThanFifty()
        {
            int sellIn = 10;
            int quality = 53;
            string name = "Spinach";

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);
            });

            StringAssert.Contains("Quality must be between 0 and 50", exception.Message);
        }

        [Test]
        public void QualityShouldIncreaseForItems()
        {
            int sellIn = 15;
            int quality = 10;
            string name = "Indian Wine";


            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality + 1, Is.EqualTo(item.Quality));
        }

        [Test]
        public void Should_NotSell_legendaryItem()
        {
            int sellIn = 15;
            int quality = 10;
            string name = "Forest Honey";


            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(sellIn, Is.EqualTo(item.SellIn));
        }

        [Test]
        public void ShouldNotDecreaseInQuality_ForLegendaryItem()
        {
            int sellIn = 15;
            int quality = 10;
            string name = "Forest Honey";


            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality, Is.EqualTo(item.Quality));
        }

        [Test]
        public void MovieTicketsIncreasesInQualityBeforeTenDays()//defect
        {
            int sellIn = 9;
            int quality = 10;
            string name = "Movie Tickets";


            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality+2, Is.EqualTo(item.Quality));
        }

        [Test]
        public void MovieTicketsIncreasesInQualityforFiveDays()//defect
        {
            int sellIn = 3;
            int quality = 10;
            string name = "Movie Tickets";


            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(quality+3, Is.EqualTo(item.Quality));
        }

        [Test]
        public void MovieTicketsDropsZeroInQualityAfterShow()//defect 
        {
            int sellIn = -1;
            int quality = 10;
            string name = "Movie Tickets";


            IList<Item> items = DomainFactory.PrepareSingleItemList(name, sellIn, quality);

            Item item = DomainFactory.GetItemAfterHamaraBasketUpdate(items);

            Assert.That(0, Is.EqualTo(item.Quality));
        }
    }
    }
