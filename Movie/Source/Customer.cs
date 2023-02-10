using System.Globalization;

namespace Movie
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            this._name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// The goal of this excercise is to refactor the (smelly) code below. Go go go!
        /// </summary>
        /// <returns></returns>
        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + GetName() + "\n";

            foreach (Rental each in _rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.Regular:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NewRelease:
                        thisAmount += each.GetDaysRented() * 3;
                        break;
                    case Movie.Childrens:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        break;
                }

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NewRelease) && each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                // show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += "Amount owed is " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}
