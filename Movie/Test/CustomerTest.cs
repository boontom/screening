namespace Movie.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            Customer c = new Customer("David");
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestAddRental()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Gone with the Wind", Movie.Regular);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
        }

        [TestMethod]
        public void TestGetName()
        {
            Customer c = new Customer("David");
            Assert.AreEqual("David", c.GetName());
        }

        [TestMethod]
        public void StatementForRegularMovie()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Gone with the Wind", Movie.Regular);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
            string expected = "Rental Record for Sallie\n" +
                                "\tGone with the Wind\t3.5\n" +
                                "Amount owed is 3.5\n" +
                                "You earned 1 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForNewReleaseMovie()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Star Wars", Movie.NewRelease);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
            string expected = "Rental Record for Sallie\n" +
                                "\tStar Wars\t9.0\n" +
                                "Amount owed is 9.0\n" +
                                "You earned 2 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForChildrensMovie()
        {
            Customer customer2 = new Customer("Sallie");
            Movie movie1 = new Movie("Madagascar", Movie.Childrens);
            Rental rental1 = new Rental(movie1, 3); // 3 day rental
            customer2.AddRental(rental1);
            string expected = "Rental Record for Sallie\n" +
                                "\tMadagascar\t1.5\n" +
                                "Amount owed is 1.5\n" +
                                "You earned 1 frequent renter points";
            string statement = customer2.Statement();
            Assert.AreEqual(expected, statement);
        }

        [TestMethod]
        public void StatementForManyMovies()
        {
            Customer customer1 = new Customer("David");
            Movie movie1 = new Movie("Madagascar", Movie.Childrens);
            Rental rental1 = new Rental(movie1, 6); // 6 day rental
            Movie movie2 = new Movie("Star Wars", Movie.NewRelease);
            Rental rental2 = new Rental(movie2, 2); // 2 day rental
            Movie movie3 = new Movie("Gone with the Wind", Movie.Regular);
            Rental rental3 = new Rental(movie3, 8); // 8 day rental
            customer1.AddRental(rental1);
            customer1.AddRental(rental2);
            customer1.AddRental(rental3);
            string expected = "Rental Record for David\n" +
                                "\tMadagascar\t6.0\n" +
                                "\tStar Wars\t6.0\n" +
                                "\tGone with the Wind\t11.0\n" +
                                "Amount owed is 23.0\n" +
                                "You earned 4 frequent renter points";
            string statement = customer1.Statement();
            Assert.AreEqual(expected, statement);
        }
    }
}
